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

        public async Task GeneratePayslipExcel(PayslipRequest payslip)
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Generated Files");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string uniqueFileName = Utils.CleanFileName($"_{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds()}.xlsx");
            string excelPath = Path.Combine(directory, uniqueFileName);
            var payslips = await _payslipRepository.GetPayslipByUserUID(payslip.UserUID);
            using (var excelDocument = SpreadsheetDocument.Create(excelPath,SpreadsheetDocumentType.Workbook))
            {
                //Creation of Workbook
                WorkbookPart workbookPart = excelDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                //Creation of Worksheet
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Add Worksheet to the Workbook
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet()
                {
                    SheetId = 1,
                    Name = "Payslip",
                    Id = workbookPart.GetIdOfPart(worksheetPart)
                };
                sheets.Append(sheet);

                //Creation of SheetData
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                //Creation of Rows and Columns
                //for (int i = 0; i < contents.Length; i++)
                //{
                //    Row row = new Row()
                //    {
                //        RowIndex = (uint)i,
                //        Height = 15d,
                //        CustomHeight = true,
                //    };
                //    for (int j = 0; j < contents[i].Length; j++)
                //    {
                //        CreateCell(row, contents[i][j]);
                //    }
                //    sheetData.Append(row);
                //}

                Row dataRow2 = new Row();
                dataRow2.Append(
                    new Cell() { CellValue = new CellValue("2"), DataType = CellValues.Number },
                    new Cell() { CellValue = new CellValue("Jane Smith"), DataType = CellValues.String },
                    new Cell() { CellValue = new CellValue("P"), DataType = CellValues.String },
                    new Cell() { CellValue = new CellValue("P"), DataType = CellValues.String }
                );
                sheetData.Append(dataRow2);

                //save the created workbook
                workbookPart.Workbook.Save();
            }
        }

        private void CreateCell(Row row, string value, uint formatId = 1)
        {
            Cell cell = new Cell()
            {
                DataType = CellValues.String,
                CellValue = new CellValue(Utils.ReplaceSpecialCharacter(value)),
                StyleIndex = formatId
            };
            row.Append(cell);
        }

        //public async Task GeneratePayslipExcel(PayslipRequest payslip, Microsoft.Azure.WebJobs.ExecutionContext executionContext)
        //{
        //    try
        //    {

        //        //var directory = executionContext.FunctionAppDirectory;
        //        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Generated Files");
        //        if (!Directory.Exists(directory))
        //        {
        //            Directory.CreateDirectory(directory);
        //        }
        //        string uniqueFileName = Utils.CleanFileName($"_{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds()}.xlsx");
        //        string excelPath = Path.Combine(directory, uniqueFileName);
        //        using (var excel = new WorkbookOpenXML(excelPath))
        //        {
        //            excel.AddNewPart();
        //            for (int i = 0; i < contents.Length; i++)
        //            {
        //                excel.CreateRow(i, 15d);
        //                for (int j = 0; j < contents[i].Length; j++)
        //                {
        //                    excel.CreateCell(i, j, contents[i][j]);
        //                }
        //            }
        //            excel.Close();
        //            excel.WriteAndClose();

        //        }
        //        //var payslips = await _payslipRepository.GetPayslipByUserUID(payslip.UserUID);
        //        var fileName = Utils.CleanPathName(excelPath);
        //        var data = ReadAllBytes(fileName);
        //        string blobFileName = GetUniqueName();
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            memoryStream.Write(data, 0, data.Length);
        //            await _blobStorageService.UploadAsync(blobFileName, memoryStream);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

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
