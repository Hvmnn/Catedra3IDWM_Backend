using Catedra3Backend.Src.Services.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Catedra3Backend.Src.Services.Implements
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            var account = new Account(
                configuration["Cloudinary:dx71lh0ez"],
                configuration["Cloudinary:558632156686473"],
                configuration["Cloudinary:9RCHUlMrmzmOfrosZWW2bV8wivo"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file.Length > 5 * 1024 * 1024)
            {
                throw new ArgumentException("El tamaño del archivo excede los 5 MB.");
            }

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                AllowedFormats = new[] { "jpg", "png" }
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new Exception(uploadResult.Error.Message);
            }

            return uploadResult.SecureUrl.ToString();
        }
    }
}