using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Models
{
    public class BookForUpdateDto
    {
        [Required]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
