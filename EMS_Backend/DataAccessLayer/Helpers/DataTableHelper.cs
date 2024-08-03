using DataAccessLayer.Models;
using System.Data;
using System.Numerics;

namespace DataAccessLayer.Helpers
{
    public static class DataTableHelper
    {
        /// <summary>
        /// Get the user defined data table for payslip
        /// </summary>
        /// <param name="payslips"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetPayslipDataTable(List<PayslipEntity> payslips)
        {
            var payslipTable = GetPayslipTable();

            foreach (var payslip in payslips)
                payslipTable.Rows.Add(Guid.NewGuid(), payslip.Allowance.Id, payslip.Designation.Id, payslip.Price, payslip.AllowanceType.Id);
            return payslipTable;
        }

        #region DataTables Creation
        private static DataTable GetPayslipTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("UID", typeof(Guid));
            table.Columns.Add("AllowanceId", typeof(int));
            table.Columns.Add("DesignationId", typeof(int));
            table.Columns.Add("Price", typeof(long));
            table.Columns.Add("AllowanceTypeId", typeof(int));
            return table;
        }
        #endregion
    }
}
