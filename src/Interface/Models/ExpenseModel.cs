using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Interface.Models
{
    public class ExpenseModel : BaseModel
    {
        public string Purpose { get; set; }

        /// <remarks>cf https://stackoverflow.com/questions/19811180/best-data-annotation-for-a-decimal18-2</remarks>
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(-9999999999999999.99, 9999999999999999.99)]
        public decimal Amount { get; set; }

        public DateTime ValueDate { get; set; }
        public DateTime OperationDate { get; internal set; }

        public int CategoryId { get; set; }

        /// <summary>
        /// Define participants id's for which is the expense with theirs respective share in it
        /// </summary>
        [Required]
        public List<BeneficiaryModel> Beneficiaries { internal get; set; }
    }
}