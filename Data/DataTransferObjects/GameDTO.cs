using System.ComponentModel.DataAnnotations;
using GameStore.Data.Entities;

namespace GameStore.Data.DataTransferObjects
{
    public record GameDTO{
        [Required] public required int Id { get; set; }
        [Required] [StringLength(30)] public required string Name{ get; set; }
        [Required] [StringLength (20)]public required List<Genre> Genre{ get; set; }
        [Required] public required DateTime ReleaseDate{ get; set; }
        [Required] [Range(1,100)] public required decimal Price{ get; set; }
        [Url] [StringLength(100)] public required string ImageUri{ get; set; }
    }

    public record CreateGameDTO{
        [Required] [StringLength(30)] public required string Name{ get; set; }
        [Required] [StringLength (20)]public required List<Genre> Genre{ get; set; }
        [Required] public required DateTime ReleaseDate{ get; set; }
        [Required] [Range(1,100)] public required decimal Price{ get; set; }
        [Url] [StringLength(100)] public required string ImageUri{ get; set; }

    }

    public record UpdateGameDTO{
        [Required] [StringLength(30)] public required string Name{ get; set; }
        [Required] [StringLength (20)]public required List<Genre> Genre{ get; set; }
        [Required] public required DateTime ReleaseDate{ get; set; }
        [Required] [Range(1,100)] public required decimal Price{ get; set; }
        [Url] [StringLength(100)] public required string ImageUri{ get; set; }
    }
}
