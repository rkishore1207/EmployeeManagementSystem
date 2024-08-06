using System.Numerics;

namespace DataAccessLayer.Models
{
    public class PayslipEntity
    {
        public DesignationEntity Allowance { get; set; }
        public DesignationEntity Designation { get; set; }
        public DesignationEntity AllowanceType { get; set; }
        public long Price { get; set; }
    }
}
