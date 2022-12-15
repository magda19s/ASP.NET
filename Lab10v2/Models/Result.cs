using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Lab10v2.Models
{
    public class Result
    {
        public int SelectedCategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<Article> articles { get; set; } = new List<Article>();
    }
}
