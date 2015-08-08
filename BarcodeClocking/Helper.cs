// Copyright © 2015 Lower Columbia College Computer Science Club

// This file is part of Barcode Clocking.

// Barcode Clocking is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Barcode Clocking is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.

// You should have received a copy of the GNU Affero General Public License
// along with Barcode Clocking.  If not, see <http://www.gnu.org/licenses/>.

// If you have any questions or comments, please contact the current Club
// President or Club Vice President.

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
