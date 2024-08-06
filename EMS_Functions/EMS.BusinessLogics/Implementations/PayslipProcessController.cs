using AzureServices.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using EMS.BusinessLogics.Interfaces;
using EMS.BusinessLogics.Models;
using EMS.BusinessLogics.Office;
using EMS.DataAccessLayer.Interfaces;
using EMS.Utilities;

namespace EMS.BusinessLogics.Implementations
{
    public class PayslipProcessController : IPayslipProcessController
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IPayslipRepository _payslipRepository;
        string[][] contents = new string[][]
        {
            new string[] {"HouseRent","1000"},
            new string[] {"Basic","10000"},
        };

        public PayslipProcessController(IBlobStorageService blobStorageService, IPayslipRepository payslipRepository)
        {
            _blobStorageService = blobStorageService;
            _payslipRepository = payslipRepository;
        }

        public async Task GeneratePayslipExcel(PayslipRequest payslip, Microsoft.Azure.WebJobs.ExecutionContext executionContext)
        {
            try
            {

                //var directory = executionContext.FunctionAppDirectory;
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Generated Files");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string uniqueFileName = Utils.CleanFileName($"_{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds()}.xlsx");
                string excelPath = Path.Combine(directory, uniqueFileName);
                using (var excel = new WorkbookOpenXML(excelPath))
                {
                    //excel.AddNewPart();
                    //for (int i = 0; i < contents.Length; i++)
                    //{
                    //    excel.CreateRow(i, 15d);
                    //    for (int j = 0; j < contents[i].Length; j++)
                    //    {
                    //        excel.CreateCell(i, j, contents[i][j]);
                    //    }
                    //}
                    //excel.Close();
                    //excel.WriteAndClose();
                    
                }
                //var payslips = await _payslipRepository.GetPayslipByUserUID(payslip.UserUID);
                var fileName = Utils.CleanPathName(excelPath);
                var data = ReadAllBytes(fileName);
                string blobFileName = GetUniqueName();
                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(data, 0, data.Length);
                    await _blobStorageService.UploadAsync(blobFileName, memoryStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GetUniqueName()
        {
            Guid guid = Guid.NewGuid();
            return $"{guid}-Excel";
        }

        private byte[] ReadAllBytes(string fileName)
        {
            byte[] buffer = null;
            try
            {
                return File.ReadAllBytes(fileName);
            }
            catch
            {
                return buffer;
            }
        }
    }
}
