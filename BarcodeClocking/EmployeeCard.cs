using System;
using System.Collections.Generic;
using System.IO;

namespace BarcodeClocking
{
    class EmployeeCard
    {
        public string employeeID;
        public string firstName;
        public string lastName;
        public string middle;
        public string rate;
        public string employeeType;

        public List<TimeCombo> timeStampsOld = new List<TimeCombo>();
        
        public EmployeeCard(string id, string fN, string lN, string m, string r, string eT)
        {
            this.employeeID = id;
            this.firstName = fN;
            this.lastName = lN;
            this.middle = m;
            this.rate = r;
            this.employeeType = eT;

            LoadTimeStamps();

        }

        private void LoadTimeStamps()
        {
            try
            {
                string[] array = File.ReadAllLines(employeeID + ".txt");
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i];
                    string[] entry = text.Split(new char[]
					{
						'\t'
					}/*, System.StringSplitOptions.RemoveEmptyEntries*/);
                    if (entry.Length > 1)
                    {
                        this.timeStampsOld.Add(new TimeCombo(entry[0], entry[1]));
                    }
                    else if (entry.Length == 1)
                    {
                        this.timeStampsOld.Add(new TimeCombo(entry[0], ""));
                    }
                }
            }
            catch (Exception err)
            {
                File.WriteAllText("employeeCard-" + employeeID + ".txt", "ImportEmployeeCardError: " + err.Message + "\r\n\r\n");

            }
        }
    }
}
