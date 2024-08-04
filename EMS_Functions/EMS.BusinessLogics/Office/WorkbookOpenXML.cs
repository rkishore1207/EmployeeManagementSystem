using DocumentFormat.OpenXml.Packaging;

namespace EMS.BusinessLogics.Office
{
    public class WorkbookOpenXML : IDisposable
    {
        SpreadsheetDocument document;
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
