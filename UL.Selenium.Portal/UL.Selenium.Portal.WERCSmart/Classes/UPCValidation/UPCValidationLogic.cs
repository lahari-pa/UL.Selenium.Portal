using System.Text;
using System.Text.RegularExpressions;

namespace UL.Selenium.Portal.WERCSmart.Classes.UPCValidation
{
	public static class UPCValidationLogic
	{
		public static bool IsUPCValid(string value)
		{
			string regex = string.Format("^(?!0{{{0}}})[0-9]{{{0}}}$", value.Length.ToString());

			if (string.IsNullOrEmpty(value) || (12 > value.Length && 14 > value.Length) || !Regex.IsMatch(value, regex))
			{
				return false;
			}

			int intOddTotal = 0, intEvenTotal = 0;
			bool bOdd = true;
			string[] sUPC = Regex.Split(value, "");

			int i;
			for (i = 1; i <= sUPC.Length - 3; i++)
			{
				if (Encoding.ASCII.GetBytes(sUPC[i])[0] < 48 || Encoding.ASCII.GetBytes(sUPC[i])[0] > 57)
				{
					return false;
				}
				if (bOdd)
				{
					intOddTotal += int.Parse(sUPC[i]);
					bOdd = false;
				}
				else
				{
					intEvenTotal += int.Parse(sUPC[i]);
					bOdd = true;
				}
			}

			if (15 == sUPC.Length)
			{
				intEvenTotal = intEvenTotal * 3;
				intEvenTotal = intOddTotal + intEvenTotal;
			}
			else
			{
				intOddTotal = intOddTotal * 3;
				intEvenTotal = intOddTotal + intEvenTotal;
			}

			int intRemainder = intEvenTotal % 10;
			intRemainder = 10 - intRemainder;

			if (10 == intRemainder)
			{
				intRemainder = 0;
			}

			if (int.TryParse(sUPC[i], out int intUpc) && intRemainder == int.Parse(sUPC[i]))
			{
				return true;
			}
			return false;
		}
	}
}
