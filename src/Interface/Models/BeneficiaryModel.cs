using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Interface.Models
{
    public class BeneficiaryModel : BaseModel
    {
        [Required]
        public int ParticipantId { get; set; }

        /// <remarks>cf https://stackoverflow.com/questions/19811180/best-data-annotation-for-a-decimal18-2 </remarks>
        [RegularExpression(@"^\d+(\.\d{1,1})?$")]
        [Range(-9999999999999999.99, 10)]
        public double ShareNumber { get; set; } = 1;
    }
}