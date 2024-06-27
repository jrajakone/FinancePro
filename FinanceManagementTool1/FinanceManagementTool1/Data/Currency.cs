using System.ComponentModel.DataAnnotations;

namespace FinanceManagementTool1.Data
{
    public class Currency
    {
        [StringLength(1, ErrorMessage ="Name is to short")]
        public string base_code { get; set; }
        public string target_code { get; set; }
        public double conversion_rate { get; set; }

        
        
        public string Code { get; set; }
        public double Rate { get; set; }

    }
}


