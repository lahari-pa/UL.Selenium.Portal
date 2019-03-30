using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.ULSC.Selenium_Classes
{
	class Services : BaseObject
	{
		public const string BasePath = "//section";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_For_Load(int secondsToWait = 30)
		{
			var counter = 0;
			var loaded = false;
			while (counter < secondsToWait && !loaded)
			{
				loaded = this.SectionContainer("", true) != null;
				Delay.Seconds(1);
				counter++;
			}
			return loaded;
		}

		public IWebElement SectionContainer(string heading, bool firstSection = false)
		{
			if (!firstSection)
			{
				var match = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2)
					?.FirstOrDefault(x => x.Text == heading);
				return match?.FindElement(By.XPath("./ancestor::div[starts-with(@id,'well')][1]"), 2);
			}
			return this.containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2).FirstOrDefault();
		}

		public List<string> SectionHeadings()
		{
			var sectionHeadings = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2);
			if (sectionHeadings.Count != 0)
			{
				return sectionHeadings.Select(x => x.GetValue().Trim()).ToList();
			}
			Report.Error("No section titles were found");
			return new List<string>();
		}

		public string SectionDescription(string heading)
		{
			var el = this.SectionContainer(heading);
			if (el == null)
			{
				Report.Error($"No Services section was found with heading: {heading}!");
				return null;
			}
			var description = "";
			var descRows = el.FindElements(By.XPath("./div[contains(@class,'row')]/div[contains(@class,'col-md-12') and ./span]"), 2);
			foreach (var row in descRows)
			{
				var textEls = row.FindElements(By.XPath("./*"), 2);
				description = textEls.Aggregate(description, (desc, textEl) => desc + textEl.Text.Trim());
			}
			return description;
		}

		public List<string> SectionImages(string heading)
		{
			var el = this.SectionContainer(heading);
			if (el == null)
			{
				Report.Error($"No Services section was found with heading: {heading}!");
				return null;
			}
			var images = new List<string>();
			var regex = new Regex(@"(?<=images\/)(.*)(?=\.)");
			var srcs = el.FindElements(By.XPath(".//img"), 2);
			foreach (var srcEl in srcs)
			{
				var src = srcEl?.GetAttribute("src");
				if (src == null)
				{
					continue;
				}
				var match = regex.Match(src);
				if (match.Success)
				{
					images.Add(match.Value);
				}
			}
			return images;

			// older code
			//var images = new List<string>();
			//var sectionTitles = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2);
			//if (sectionTitles.Count == 0)
			//{
			//	Report.Error("No section titles were found");
			//	return null;
			//}
			//var matchingSection = sectionTitles.FirstOrDefault(x => x.GetValue().Trim().ToLower() == section.ToLower());
			//if (matchingSection == null)
			//{
			//	Report.Error("No matching section was found: " + section);
			//	return null;
			//}
			//var imagesList = matchingSection.FindElements(By.XPath("../../../..//img"));
			//if (imagesList.Count == 0)
			//{
			//	Report.Info("No images were found");
			//}
			//else
			//{
			//	const string regexPattern = @"(?<=images\/)(.*)(?=\.)";
			//	var regex = new Regex(regexPattern);
			//	foreach (var thisImage in imagesList)
			//	{
			//		var src = thisImage.GetAttribute("src");
			//		var match = regex.Match(src);
			//		if (match.Success)
			//		{
			//			images.Add(match.Value);
			//		}
			//	}
			//}
			//return images;
		}

		public List<string> SectionSubHeadings(string heading)
		{
			//var sectionTitles = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2);
			//if (sectionTitles.Count == 0)
			//{
			//	Report.Error("No section titles were found");
			//	return null;
			//}
			//var matchingSection = sectionTitles.FirstOrDefault(x => x.GetValue().Trim().ToLower() == heading.ToLower());
			//if (matchingSection == null)
			//{
			//	Report.Error("No matching section was found: " + heading);
			//	return null;
			//}
			var el = this.SectionContainer(heading);
			if (el == null)
			{
				Report.Error($"No Services section was found with heading: {heading}!");
				return null;
			}
			var subHeadingEls = el.FindElements(By.XPath("//span[@class='pullup']"));
			if (subHeadingEls.Count != 0)
			{
				return subHeadingEls.Select(x => x.Text).ToList();
			}
			Report.Info("No sub headers were found");
			return new List<string>();
		}

		public List<ServiceLink> SectionLinks(string heading)
		{

			//var sectionTitles = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2);
			//if (sectionTitles.Count == 0)
			//{
			//	Report.Error("No section titles were found");
			//	return null;
			//}
			//var matchingSection = sectionTitles.FirstOrDefault(x => x.GetValue().Trim().ToLower() == heading.ToLower());
			//if (matchingSection == null)
			//{
			//	Report.Error("No matching section was found: " + heading);
			//	return null;
			//}

			var el = this.SectionContainer(heading);
			if (el == null)
			{
				Report.Error($"No Services section was found with heading: {heading}!");
				return null;
			}
			var links = new List<ServiceLink>();
			var linkEls = el.FindElements(By.XPath(".//div[./em and ./a]"), 2);
			foreach (var thisLink in linkEls)
			{
				if (thisLink == null)
				{
					continue;
				}
				var newLink = new ServiceLink {
					Title = thisLink.FindElement(By.XPath("./a/span"), 2)?.Text,
					Icon = thisLink.FindElement(By.XPath("./em"), 2)?.GetAttribute("class").Replace("fa fa-", "").Replace("level-ov", "").Trim(),
					Href = thisLink.FindElement(By.XPath("./a"), 2)?.GetAttribute("href")
				};
				links.Add(newLink);
			}
			return links;
		}

		public WercsLinkService GetSection(string title)
		{
			var match = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2)?.FirstOrDefault(x => x.Text == title);
			var sectionEl = match?.FindElement(By.XPath("./ancestor::div[starts-with(@id,'well')][1]"), 2);
			return sectionEl == null ? null : this.GetSection(sectionEl);
		}

		public WercsLinkService GetSection(IWebElement el)
		{
			var rService = new WercsLinkService {
				Heading = el.FindElement(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2)?.Text
			};
			rService.Description = this.SectionDescription(rService.Heading);
			rService.Images = this.SectionImages(rService.Heading);
			rService.SubHeadings = this.SectionSubHeadings(rService.Heading);
			rService.Links = this.SectionLinks(rService.Heading);
			return rService;
		}

		public List<WercsLinkService> GetSections()
		{
			var rList = new List<WercsLinkService>();
			var sectionEls = this.containerElement.FindElements(By.XPath(".//div[starts-with(@id,'well')]"), 2);
			foreach (var el in sectionEls)
			{
				rList.Add(this.GetSection(el));
			}
			return rList;
		}

		/// <summary>
		/// Information displayed in the main area sections on the Services page
		/// </summary>
		public class WercsLinkService
		{
			public List<ServiceLink> Links { get; set; }

			public string Heading { get; set; }

			public List<string> Images { get; set; }

			public List<string> SubHeadings { get; set; }

			public string Description { get; set; }
		}

		/// <summary>
		/// Link item in a main area section on the Services page
		/// </summary>
		public class ServiceLink
		{
			public string Title { get; set; }

			public string Icon { get; set; }

			public string Href { get; set; }

			public string ParentHeading { get; set; }
		}

	}
}
