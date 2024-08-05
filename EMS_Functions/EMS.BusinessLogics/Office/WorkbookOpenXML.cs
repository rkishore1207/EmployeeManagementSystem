using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using EMS.Utilities;

namespace EMS.BusinessLogics.Office
{
    public class WorkbookOpenXML : IDisposable
    {
        SpreadsheetDocument document;
        WorkbookPart workbookPart;
        WorkbookStylesPart workbookStyles;
        WorksheetPart worksheetPart;
        Dictionary<int,Row> rowDictionary = new Dictionary<int,Row>();
        OpenXmlWriter openXmlWriter;

        public WorkbookOpenXML(string fileName)
        {
            document = SpreadsheetDocument.Create(fileName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook);
            workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
            AddStyles(document);
        }

        private void AddStyles(SpreadsheetDocument document)
        {
            workbookStyles = document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            Stylesheet stylesheet = new Stylesheet();
            stylesheet.Fonts = new Fonts(new Font() { Color = new Color() { Rgb = "000000" }, Bold = new Bold(), FontSize = new FontSize() { Val = 14 } });
            stylesheet.Borders = new Borders(new Border(new LeftBorder() { Style = BorderStyleValues.Thin, Color = new Color() { Rgb = "DCDCDC"} }));
            stylesheet.Fills = new Fills(new Fill(new PatternFill() { ForegroundColor = new ForegroundColor { Rgb = "F2F2F2" }, PatternType = PatternValues.Solid }));
            stylesheet.CellFormats = new CellFormats();
            workbookStyles.Stylesheet = stylesheet;
        }

        public void AddNewPart()
        {
            worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            Worksheet worksheet = new Worksheet();
            SheetViews sheetViews = new SheetViews();
            SheetView sheetView = new SheetView() { ShowGridLines = true, TabSelected = true, ZoomScaleNormal = (UInt32Value)100U, WorkbookViewId = (UInt32Value)0U};
            Selection selection = new Selection() { ActiveCell = "A1", SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A1"} };
            sheetView.Append(selection);
            sheetViews.Append(sheetView);
            worksheet.Append(sheetViews);
            worksheet.Append(GetColumns());
            SheetData sheetData = new SheetData();
            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;
        }

        private Columns GetColumns()
        {
            Columns columns = new Columns();
            for(int i = 0; i < 26; i++)
            {
                Column column = new Column() { Width = 33d, CustomWidth = true, Min = 2U, Max = 2U};
                columns.Append(column);
            }
            return columns;
        }          

        public void CreateRow(int rowIndex, double rowHeight = 0)
        {
            if (!rowDictionary.ContainsKey(rowIndex))
            {
                Row row = new Row();
                row.RowIndex = (uint)rowIndex;
                if(rowHeight != 0)
                {
                    row.Height = rowHeight;
                    row.CustomHeight = true;
                }
                rowDictionary.Add(rowIndex, row);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.Elements<SheetData>().First();
                sheetData.Append(row);
            }
        }

        public void CreateCell(int rowIndex, int colIndex, string value, uint formatId = 1)
        {
            if (rowDictionary.ContainsKey(rowIndex))
            {
                Cell cell = new Cell()
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(Utils.ReplaceSpecialCharacter(value)),
                    StyleIndex = formatId
                };
                rowDictionary[rowIndex].Append(cell);
            }
        }

        public void WriteAndClose()
        {
            // write and close for WorksheetPart
            openXmlWriter = OpenXmlWriter.Create(worksheetPart);
            var ws = worksheetPart.Worksheet;
            var sheetData = ws.Elements<SheetData>().First();
            openXmlWriter.WriteStartElement(ws);
            openXmlWriter.WriteStartElement(sheetData);
            openXmlWriter.WriteEndElement();//for sheetData
            openXmlWriter.WriteEndElement();//for worksheet
            openXmlWriter.Close();

            //write and close for WorkbookPart
            openXmlWriter = OpenXmlWriter.Create(workbookPart);
            var wb = workbookPart.Workbook;
            openXmlWriter.WriteStartElement(wb);
            openXmlWriter.WriteEndElement();//for workbook
            openXmlWriter.Close();
        }

        public void Close()
        {
            document?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if(disposing) 
                document?.Dispose();
        }
    }
}
