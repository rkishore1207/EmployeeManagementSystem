using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace EMS.BusinessLogics.Office
{
    public class WorkbookOpenXML : IDisposable
    {
        SpreadsheetDocument document;
        WorkbookPart workbookPart;
        WorkbookStylesPart workbookStyles;
        WorksheetPart worksheetPart;

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
