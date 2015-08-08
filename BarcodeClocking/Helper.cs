using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeClocking
{
    class Helper
    {
        static public bool EmployeeExists(string employeeID, SQLiteDatabase sql)
        {
            // notify user if card wasn't found
            if (sql.GetDataTable("select * from employees where employeeID=" + employeeID.Trim() + ";").Rows.Count == 1)
                return true;
            else
                return false;
        }

    }

    public class StringFormats
    {
        public const string sqlTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string timeStampFormat = "MM/dd/yyyy hh:mm:ss tt";
    }
}
