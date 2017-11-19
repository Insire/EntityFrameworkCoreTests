using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Domain
{
    public class Anime : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public int AnimeDetailsId { get; set; }
        public AnimeDetails AnimeDetails { get; set; }

        public ICollection<AnimeTag> AnimeTags { get; set; }
        public ICollection<Episode> Episodes { get; set; }

        public Anime()
        {
            AnimeTags = new List<AnimeTag>();
            Episodes = new List<Episode>();
        }
    }
}
