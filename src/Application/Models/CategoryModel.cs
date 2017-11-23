using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Application.Models
{
    public class CategoryModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}