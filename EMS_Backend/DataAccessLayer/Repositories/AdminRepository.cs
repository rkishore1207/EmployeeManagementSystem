using DataAccessLayer.Intefaces;
using Utilities.ConfigService;

namespace DataAccessLayer.Repositories
{
    public class AdminRepository : BaseRepo, IAdminRepository
    {
        public AdminRepository(IConfigurationService configurationService) : base(configurationService)
        {

        }
    }
}
