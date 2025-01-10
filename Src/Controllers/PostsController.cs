using AutoMapper;
using Catedra3Backend.Src.DTOs;
using Catedra3Backend.Src.Models;
using Catedra3Backend.Src.Repositories.Interfaces;
using Catedra3Backend.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catedra3Backend.Src.Controllers
{
    [ApiController]
    [Route("api/posts")]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IMapper _mapper;

        public PostsController(IPostRepository postRepository, ICloudinaryService cloudinaryService, IMapper mapper)
        {
            _postRepository = postRepository;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPostsAsync();
            var postDtos = _mapper.Map<IEnumerable<PostResponseDto>>(posts);
            return Ok(postDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] CreatePostDto createPostDto)
        {
            if (createPostDto.Image == null)
            {
                return BadRequest("Imagen requerida");
            }

            if(createPostDto.Image.Length > 5 * 1024 * 1024)
            {
                return BadRequest("El tamaño de la imagen excede los 5 MB");
            }

            if(!new[] { "image/jpeg", "image/png" }.Contains(createPostDto.Image.ContentType))
            {
                return BadRequest("Solo se permiten imágenes en formato JPG o PNG");
            }

            var imageUrl = await _cloudinaryService.UploadImageAsync(createPostDto.Image);

            var post = _mapper.Map<Post>(createPostDto);
            post.PublishedDate = DateTime.Now;
            post.ImageUrl = imageUrl;

            await _postRepository.CreatePostAsync(post);
            return Ok(new { message = "Post creado exitosamente"});
        }


    }
}