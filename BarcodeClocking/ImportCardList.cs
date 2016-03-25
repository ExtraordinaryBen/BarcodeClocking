// Copyright © 2016 Lower Columbia College Computer Science Club

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
using System.Windows.Forms;
using System.Data.SQLite;

namespace BarcodeClocking
{
    class ImportCardList
    {
        List<EmployeeCard> employeeList = new List<EmployeeCard>();

        public ImportCardList(string filename)
        {
			try
			{
				string[] array = System.IO.File.ReadAllLines(filename + ".txt");
				foreach(string entry in array)
                {
                    string[] item = entry.Split(new char[]
					{
						'\t'
					});
                    if(item.Length == 6)
                        employeeList.Add(new EmployeeCard(item[0], item[1], item[2], item[3], item[4], item[5]) );
                    else if(item.Length == 5)
                        employeeList.Add(new EmployeeCard(item[0], item[1], item[2], "", item[3], item[4]) ); 
                }
                UpdateSql();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("There was an error while trying to import the old card list.\n\n" + ex.Message, "ImportCardList Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}

		}

        private void UpdateSql()
        {
            string dBconnection = "DataSource=" + SQLiteDatabase.fileName;

            try
            {

                using (SQLiteConnection con = new SQLiteConnection(dBconnection))
                {
                    con.Open();

                    using (SQLiteTransaction tr = con.BeginTransaction())
                    {
                    
                        foreach (EmployeeCard employee in employeeList)
                        {
                            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO employees (employeeID, firstName, LastName, MiddleName, hourlyRate, employeeType, currentClockInId) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", con);
                            insertSQL.Parameters.AddWithValue("@p1", employee.employeeID);
                            insertSQL.Parameters.AddWithValue("@p2", employee.firstName);
                            insertSQL.Parameters.AddWithValue("@p3", employee.lastName);
                            insertSQL.Parameters.AddWithValue("@p4", employee.middle);
                            insertSQL.Parameters.AddWithValue("@p5", employee.rate);
                            insertSQL.Parameters.AddWithValue("@p6", employee.employeeType);
                            insertSQL.Parameters.AddWithValue("@p7", "0");
                            try
                            {
                                insertSQL.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            } 

                            foreach (TimeCombo entry in employee.timeStampsOld)
                            {

                                SQLiteCommand insertTSMP = new SQLiteCommand("INSERT INTO timeStamps (employeeID, clockIn, clockOut) VALUES (@p1, @p2, @p3)", con);
                                insertTSMP.Parameters.AddWithValue("@p1", employee.employeeID);
                                insertTSMP.Parameters.AddWithValue("@p2", entry.clockedIn);
                                if(entry.clockedOut != "")
                                    insertTSMP.Parameters.AddWithValue("@p3", entry.clockedOut);
                                else
                                    insertTSMP.Parameters.AddWithValue("@p3", DBNull.Value);

                                try
                                {
                                    insertTSMP.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message);
                                } 

                            }

                            SQLiteCommand mycommand = new SQLiteCommand(con);
                            mycommand.CommandText = "select id from timeStamps where employeeID = " + employee.employeeID + " and clockOut is null or clockOut='';";
                            object currentTimeStampID = mycommand.ExecuteScalar();

                            if (currentTimeStampID != null)
                            {
                                mycommand.CommandText = "update employees set currentClockInId=" + currentTimeStampID.ToString() + " where employeeID=" + employee.employeeID + ";";
                                mycommand.ExecuteNonQuery();
                            }
                        }
                        
                        tr.Commit();
                    }
                    con.Close();

                }
                
            }
            catch(Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "ImportCardError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

    }
}
