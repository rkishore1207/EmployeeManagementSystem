using System;
using System.Text;
using Azure.Storage.Queues.Models;
using EMS.BusinessLogics.Interfaces;
using EMS.BusinessLogics.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EMS.Functions
{
    public class SendEmail
    {
        private readonly ILogger<SendEmail> _logger;
        private readonly IEmailProcessController _emailProcessController;

        public SendEmail(ILogger<SendEmail> logger, IEmailProcessController emailProcessController)
        {
            _logger = logger;
            _emailProcessController = emailProcessController;
        }

        [Function(nameof(SendEmail))]
        public async Task Run([QueueTrigger("ems-email-queue", Connection = "EmsStorageConnection")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
            var messageBody = Encoding.UTF8.GetString(message.Body);
            var email = JsonConvert.DeserializeObject<Email>(messageBody);
            if (email.UseCase == "ResetPassword")
                await _emailProcessController.ResetPasswordEmail(email);
        }
    }
}
