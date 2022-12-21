using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Lab10v2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile Image { get; set; }

        public string FilePath { get; set; }
    }
}
