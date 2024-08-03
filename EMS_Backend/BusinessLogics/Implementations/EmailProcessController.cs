using AutoMapper;
using AzureServices.Interfaces;
using BusinessLogics.Helper;
using BusinessLogics.Interfaces;
using BusinessLogics.Models.RequestModels;
using BusinessLogics.Models.ViewModels;
using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;

namespace BusinessLogics.Implementations
{
    public class EmailProcessController : IEmailProcessController
    {
        private readonly IUserRepository<UserEntity, Guid> _userRepository;
        private readonly IHelper _helper;
        private readonly IMapper _mapper;
        private readonly IQueueStorageService _queueStorageService;

        public EmailProcessController(IUserRepository<UserEntity, Guid> userRepository, 
                                      IHelper helper, IMapper mapper, IQueueStorageService queueStorageService)
        {
            _userRepository = userRepository;
            _helper = helper;
            _mapper = mapper;
            _queueStorageService = queueStorageService;
        }

        public async Task SendEmail(EmailRequest emailRequest)
        {
            if (emailRequest == null)
                throw new ArgumentNullException();         
            await _queueStorageService.SendMessageToQueue(emailRequest);
        }
    }
}
