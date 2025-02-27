using System;
using System.Collections.Generic;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
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
					case "amazon":
						prefix = "0192233";
						break;
					default:
						throw new Exception("UPC Prefix is empty. This will generate a completely random UPC which will not be prefixed.");
				}
			}
			catch (Exception e)
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
			var digits = this.GetRandomDigits(len - str.Length, str);

			while (UPCValidationLogic.IsUPCValid(digits) != true)
			{
				digits = this.GetRandomDigits(len - str.Length, str);
			}
			return digits;
		}

		private string GetRandomDigits(int len = 12, string startswith = "")
		{
			string val = string.Empty;

			val += startswith;


			int end = 10;
			for (int x = 1; x < len; x++)
			{
				end = end * 10;
			}


			int randomNum = new Random().Next(000000000000, end);
			Delay.Seconds(0.05);

			val = val + randomNum.ToString();
			int counted = val.Length;
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
