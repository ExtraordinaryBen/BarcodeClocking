using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;

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
