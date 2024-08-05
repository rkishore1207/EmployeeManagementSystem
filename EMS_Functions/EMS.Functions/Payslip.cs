using System;
using System.Text;
using Azure.Storage.Queues.Models;
using EMS.BusinessLogics.Interfaces;
using EMS.BusinessLogics.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EMS.Functions
{
    public class Payslip
    {
        private readonly ILogger<Payslip> _logger;
        private readonly IPayslipProcessController _payslipProcessController;

        public Payslip(ILogger<Payslip> logger, IPayslipProcessController payslipProcessController)
        {
            _logger = logger;
            _payslipProcessController = payslipProcessController;
        }

        [Function(nameof(Payslip))]
        public async Task Run([QueueTrigger("ems-general-queue", Connection = "EmsStorageConnection")] QueueMessage message, Microsoft.Azure.WebJobs.ExecutionContext executionContext)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
            var messageBody = Encoding.UTF8.GetString(message.Body);
            var payslip = JsonConvert.DeserializeObject<PayslipRequest>(messageBody);
            await _payslipProcessController.GeneratePayslipExcel(payslip, executionContext);
        }
    }
}
