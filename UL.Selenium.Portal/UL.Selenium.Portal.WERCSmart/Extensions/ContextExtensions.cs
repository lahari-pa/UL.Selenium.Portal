using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TReVor.Core.Classes.Software;

namespace UL.Selenium.Portal.WERCSmart.Extensions
{
	public static class ContextExtensions
	{
		public static int GetTestCaseId(this TechTalk.SpecFlow.ScenarioContext scenarioContext)
		{
			int testCaseId = 0;
			var scenarioTitle = scenarioContext.ScenarioInfo.Title;
			var regexMatches = Regex.Match(scenarioTitle, @"\[(\d+)\]", RegexOptions.IgnoreCase);

			if (regexMatches.Success && int.TryParse(regexMatches.Groups[1].Value, out testCaseId))
			{
				return testCaseId;
			}

			if (scenarioContext.ScenarioInfo.Tags.Any(x => Regex.IsMatch(x, @"(tfstestcase:)(\d+)", RegexOptions.IgnoreCase)))
			{
				var matchedTag = scenarioContext.ScenarioInfo.Tags.FirstOrDefault(x => Regex.IsMatch(x, @"(tfstestcase:)(\d+)", RegexOptions.IgnoreCase));
				if (int.TryParse(Regex.Match(matchedTag, @"(tfstestcase:)(\d+)", RegexOptions.IgnoreCase).Groups[1].Value, out testCaseId))
				{
					return testCaseId;
				}
			}

			return testCaseId;
		}
	}
}
