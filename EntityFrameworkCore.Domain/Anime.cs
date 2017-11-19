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

        public ICollection<Tag> Tags { get; set; }
        public ICollection<Episode> Episodes { get; set; }

        public Anime()
        {
            Tags = new List<Tag>();
            Episodes = new List<Episode>();
        }
    }
}
