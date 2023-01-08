using Microsoft.AspNetCore.Mvc;

namespace Lab12.Models
{
    public class Category
    {
        [BindProperty]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
