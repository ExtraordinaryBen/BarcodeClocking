using System;

namespace BarcodeClocking
{
	internal class TimeCombo
	{
		public string clockedIn
		{
			get;
			set;
		}

		public string clockedOut
		{
			get;
			set;
		}

		public TimeCombo()
		{
			this.clockedIn = default(string);
			this.clockedOut = default(string);
		}

		public TimeCombo(System.DateTime timeIn, System.DateTime timeOut)
		{
			this.clockedIn = timeIn.ToString(StringFormats.sqlTimeFormat);
			this.clockedOut = timeOut.ToString(StringFormats.sqlTimeFormat);
		}

		public TimeCombo(string timeIn, string timeOut)
		{
			this.clockedIn = System.DateTime.FromBinary(long.Parse(timeIn)).ToString(StringFormats.sqlTimeFormat);
            if (timeOut != "")
                this.clockedOut = System.DateTime.FromBinary(long.Parse(timeOut)).ToString(StringFormats.sqlTimeFormat);
            else
                this.clockedOut = timeOut;
        }

		public override string ToString()
		{
			return this.clockedIn + "\t" + this.clockedOut + "\r\n";
		}
	}
}
