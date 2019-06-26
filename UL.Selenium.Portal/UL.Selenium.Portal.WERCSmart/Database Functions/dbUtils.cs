using System;
using System.Configuration;
using NTTQA.Selenium.Classes;

namespace UL.Selenium.Portal.WERCSmart.Database_Functions
{
	public static class DbUtils
	{

		public static string GetConnectionString()
		{
			string connectionString = "";
			switch (GlobalParameters.SiteType)
			{
				case "Development":
					connectionString = ConfigurationManager.ConnectionStrings["WERCSmartDev"].ConnectionString;
					break;
				case "Staging":
					connectionString = ConfigurationManager.ConnectionStrings["WERCSmartDev"].ConnectionString;
					//Report.Error("Staging connection string is not available yet");
					break;
				default:
					throw new Exception("No suitable connection string was found");
			}

			return connectionString;
		}
	}
}
