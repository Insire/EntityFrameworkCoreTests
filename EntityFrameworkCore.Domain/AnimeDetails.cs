using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Domain
{
    public class AnimeDetails : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey(nameof(AnimeId))]
        public Anime Anime { get; set; }
        public int AnimeId { get; set; }
    }
}
