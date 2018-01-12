using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Interface.Models
{
    public class CategoryModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}