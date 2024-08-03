using System.Numerics;
using BusinessLogics.Models.ViewModels;

namespace BusinessLogics.Models.RequestModels
{
    public class PayslipRequest
    {
        public ConfigView Allowance { get; set; }
        public ConfigView Designation { get; set; }
        public ConfigView AllowanceType { get; set; }
        public long Price { get; set; }
    }
}
