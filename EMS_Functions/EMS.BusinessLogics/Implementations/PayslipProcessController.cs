using AzureServices.Interfaces;
using EMS.BusinessLogics.Interfaces;
using EMS.BusinessLogics.Models;
using EMS.BusinessLogics.Office;
using EMS.Utilities;

namespace EMS.BusinessLogics.Implementations
{
    public class PayslipProcessController : IPayslipProcessController
    {
        private readonly IBlobStorageService _blobStorageService;
        string[][] contents = new string[][]
        {
            new string[] {"HouseRent","1000"},
            new string[] {"Basic","10000"},
        };

        public PayslipProcessController(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        public async Task GeneratePayslipExcel(PayslipRequest payslip, Microsoft.Azure.WebJobs.ExecutionContext executionContext)
        {
            //var directory = executionContext.FunctionAppDirectory;
            var directory = Path.Combine(Directory.GetCurrentDirectory(),"Generated Files");
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string uniqueFileName = Utils.CleanFileName($"_{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds()}.xlsx");
            string tempPath = Path.Combine("Excel", uniqueFileName);
            string excelPath = Path.Combine(directory, tempPath);
            using (var excel = new WorkbookOpenXML(excelPath))
            {
                excel.AddNewPart();
                for (int i = 0; i < contents.Length; i++)
                {
                    excel.CreateRow(i, 15d);
                    for (int j = 0; j < contents[i].Length; j++)
                    {
                        excel.CreateCell(i, j, contents[i][j]);
                    }
                }
                excel.WriteAndClose();
                excel.Close();
            }
            var fileName = Utils.CleanPathName(excelPath);
            var data = ReadAllBytes(fileName);
            string blobFileName = GetUniqueName();
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(data, 0, data.Length);
                await _blobStorageService.UploadAsync(blobFileName, memoryStream);
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
