using Newtonsoft.Json;
using System;
using System.IO;
using UL.Selenium.Portal.WERCSmart.Classes.Configuration.Sections;

namespace UL.Selenium.Portal.WERCSmart.Classes.Configuration
{
	public class WercsmartConfig
	{
		public ConnectionStringsSection ConnectionStrings { get; set; }

		// ========== STATIC ATTRIBUTES ========== //

		public static WercsmartConfig CurrentConfig { get; private set; }

		private const string _jsonConfigurationFileName = "wercsmartConfig.json";

		static WercsmartConfig()
		{
			LoadConfiguration();
		}

		internal static void LoadConfiguration()
		{
			string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _jsonConfigurationFileName);

			if (!File.Exists(jsonFilePath))
			{
				jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", _jsonConfigurationFileName);

				if (!File.Exists(jsonFilePath))
				{
					jsonFilePath = Path.Combine(Environment.CurrentDirectory, _jsonConfigurationFileName);

					if (!File.Exists(jsonFilePath))
					{
						jsonFilePath = null;
					}
				}
			}

			CurrentConfig = !string.IsNullOrEmpty(jsonFilePath)
				? JsonConvert.DeserializeObject<WercsmartConfig>(File.ReadAllText(jsonFilePath))
				: new WercsmartConfig();
		}
	}
}
