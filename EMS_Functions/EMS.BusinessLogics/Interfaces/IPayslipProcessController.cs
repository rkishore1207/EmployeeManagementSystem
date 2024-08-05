using EMS.BusinessLogics.Models;

namespace EMS.BusinessLogics.Interfaces
{
    public interface IPayslipProcessController
    {
        Task GeneratePayslipExcel(PayslipRequest payslip, Microsoft.Azure.WebJobs.ExecutionContext executionContext);
    }
}