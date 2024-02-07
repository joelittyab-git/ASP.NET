using System.ComponentModel.DataAnnotations;

namespace web.Entities
{
    public class Game{
        public required int Id { get; set; }
        [Required] [StringLength(30)] public required string ?Name { get; set; }
        [Required] [StringLength(20)]public required string ?Genre { get; set; }
        public required DateTime ReleaseDate { get; set; }
        [Required] [Range(1,100)] public required decimal Price { get; set; }
        [Url] [StringLength(100)] public required string ImageUri { get; set; }
    }
}