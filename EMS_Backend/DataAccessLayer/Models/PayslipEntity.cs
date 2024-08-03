using System.Numerics;

namespace DataAccessLayer.Models
{
    public class PayslipEntity
    {
        public ConfigEntity Allowance { get; set; }
        public ConfigEntity Designation { get; set; }
        public ConfigEntity AllowanceType { get; set; }
        public long Price { get; set; }
    }
}
