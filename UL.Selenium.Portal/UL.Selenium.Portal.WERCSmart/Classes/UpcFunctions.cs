using System;
using System.Collections.Generic;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Classes.UPCValidation;


namespace UL.Selenium.Portal.WERCSmart.Classes
{
	public class UpcFunctions
	{
		private int _last;

		public string GenerateUPC(bool good = true)
		{
			var digits = this.GetRandomDigits();

			while (UPCValidationLogic.IsUPCValid(digits) != good)
			{
				digits = this.GetRandomDigits();
			}
			return digits;
		}

		public string GeneratePrefixedUPCForRetailer(string retailer)
		{
			string prefix = string.Empty;
			try
				{
				switch (retailer.ToLower())
				{
					case "cvs":
						prefix = "050428";
						break;
					default:
						throw new Exception("UPC Prefix is empty. This will generate a completely random UPC which will not be prefixed.");
				}
			}
			catch(Exception e)
			{
				Report.Info(e.Message);
			}
			return this.GenerateUPCStartingWith(prefix);
		}

		public List<string> GeneratePrefixedUPCForRetailer(string retailer, int count)
		{
			string prefix = string.Empty;
			try
			{
				switch (retailer.ToLower())
				{
					case "cvs":
						prefix = "050428";
						break;
					default:
						throw new Exception("UPC Prefix is empty. This will generate a completely random UPC which will not be prefixed.");
				}
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
			}
			return this.GenerateMultipleUPCsStartingWith(prefix, count);
		}

		public string GenerateUPCStartingWith(string str, int len = 12)
		{
			var digits = this.GetRandomDigits( len - str.Length, str);

			while (UPCValidationLogic.IsUPCValid(digits) != true)
			{
				digits = this.GetRandomDigits(len - str.Length, str);
			}
			return digits;
		}

		private string GetRandomDigits(int len = 12, string startswith = "")
		{
			string val = string.Empty;

			for (int i = 0; i < len; i++)
			{
				if (i == 0)
				{
					val += startswith;
				}

				var next = new Random().Next(10);
				while (this.NextNumberIsNotRandom(next))
				{
					next = new Random().Next(10);
				};
				_last = next;
				val += next;
			}
			return val;
		}

		private bool NextNumberIsNotRandom(int next)
		{
			if (next == _last)
			{
				return true;
			}
			return false;
		}

		public List<string> GenerateMultipleUPCsStartingWith(string pre, int num)
		{
			var uPCs = new List<string>();
			for (int i = 0; i < num; i++)
			{
				string UPC = new UpcFunctions().GenerateUPCStartingWith(pre);
				uPCs.Add(UPC);
			}
			return uPCs;
		}
	}
}
