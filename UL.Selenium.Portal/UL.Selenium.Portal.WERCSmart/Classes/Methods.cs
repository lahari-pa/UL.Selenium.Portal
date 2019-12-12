using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UL.Selenium.Portal.WERCSmart.Classes
{
	public static class Methods
	{
		public static bool IsNullOrEmpty(this object compObj)
		{
			if(compObj.GetType() == typeof(string))
			{
				return string.IsNullOrEmpty((string) compObj);
			}

			return compObj == null;
		}
	}
}
