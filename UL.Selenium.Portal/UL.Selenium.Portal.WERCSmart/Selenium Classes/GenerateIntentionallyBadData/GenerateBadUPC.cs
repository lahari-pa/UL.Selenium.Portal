using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Recipient_and_UPC_Details;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.GenerateIntentionallyBadData
{
	public static class GenerateBadUPC
	{
		static int _iteration;
		static int _last = -1;

		public static string Generate(int upcLength = 14)
		{
			string val = string.Empty;
			for (int i = 0; i < upcLength; i++)
			{
				var next = new Random().Next(10);
				while(NextNumberIsNotRandom(next))
				{
					next = new Random().Next(10);
				};
				_last = next;
				val += next;
			}

			// Make sure UPC is invalid, else run this method again
			if (UPCValidationLogic.IsUPCValid(val))
			{
				_iteration++;
				Report.Info(string.Format("Failed to generate an invalid UPC. Generated UPC was {0}, Attempt # {1}.", val, _iteration.ToString()));
				Generate(upcLength);
			}
			else
			{
				Report.Info(string.Format("Generated bad UPC {0}", val));
			}
			return val;
		}
		private static bool NextNumberIsNotRandom(int next)
		{
			if (next == _last)
			{
				return true;
			}
			return false;
		}
	}
}
