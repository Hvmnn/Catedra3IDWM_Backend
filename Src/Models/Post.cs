namespace Catedra3Backend.Src.Models{

    public class Post{
        public int Id { get; set; }
        public required string Title { get; set; }
        public required DateTime PublishedDate { get; set; }
        public required string ImageUrl { get; set; }
        public required int UserId { get; set; }
        public required User User { get; set; }

    }
}