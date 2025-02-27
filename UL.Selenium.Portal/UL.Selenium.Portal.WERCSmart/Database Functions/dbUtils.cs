using System;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Classes.Configuration;

namespace UL.Selenium.Portal.WERCSmart.Database_Functions
{
	public static class DbUtils
	{

		public static string GetConnectionString()
		{
			string connectionString = "";
			switch (TReVorSettings.SoftwareBranch)
			{
				case "Development":
					connectionString = WercsmartConfig.CurrentConfig.ConnectionStrings.DevelopmentConnectionString;
					break;
				case "Staging":
					connectionString = WercsmartConfig.CurrentConfig.ConnectionStrings.DevelopmentConnectionString;
					//Report.Error("Staging connection string is not available yet");
					break;
				default:
					throw new Exception("No suitable connection string was found");
			}

			return connectionString;
		}
	}
}
