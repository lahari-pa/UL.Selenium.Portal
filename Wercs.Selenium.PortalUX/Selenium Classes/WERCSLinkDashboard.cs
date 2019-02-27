using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	public class WERCSLinkDashboard : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			Delay.Seconds(2);
			Report.Info("Wait for dashboard page");
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}
				Delay.Seconds(1);
			}
			if (urls.Count < 2)
			{
				return false;
			}
			//var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Dashboard"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Dashboard");
					Delay.Seconds(3);
					Report.Screenshot();
					break;
				}
			}
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}
			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool ClickMenuAndSubMenuOption(string menu, string submenu = "")
		{
			if (submenu.ToLower() == "wercsmart")
			{
				submenu = "WERC";
			}
			var menuOptions = containerElement.FindElements(By.XPath(".//nav/ul/li/a/span"), 2);
			if (menuOptions.Count == 0)
			{
				Report.Error("No menu options were found");
				return false;
			}

			var matchingMenuOption =
				menuOptions.FirstOrDefault(x => x.GetValue().ToLower() == menu.ToLower());

			if (matchingMenuOption == null)
			{
				Report.Error("No matching menu option was found for: " + menu);
				return false;
			}


			if (submenu.Length == 0)
			{
				return true;
			}


			var submenuOptions =
				matchingMenuOption.FindElements(By.XPath("../../ul[contains(@class, 'subnav')]/li/a/span"), 2);

			var matchingSubMenuOption =
				submenuOptions.FirstOrDefault(x => x.GetValue().ToLower() == submenu.ToLower());

			if (matchingSubMenuOption == null)
			{
				Report.Error("No matching sub menu option was found for: " + submenu);
				return false;
			}

			var parentUL = matchingSubMenuOption.FindElement(By.XPath("../../ul"), 2);

			if (parentUL.GetAttribute("aria-expanded") == "false")
			{
				matchingMenuOption.Click();
				Delay.Seconds(1);
				submenuOptions = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//ul[contains(@class, 'subnav')]/li/a/span"), 2);

				matchingSubMenuOption =
					submenuOptions.FirstOrDefault(x => x.GetValue().ToLower() == submenu.ToLower());

				if (matchingSubMenuOption == null)
				{
					Report.Error("No matching sub menu option was found for: " + submenu);
					return false;
				}

				parentUL = matchingSubMenuOption.FindElement(By.XPath("../../ul"), 2);
				if (parentUL.GetAttribute("aria-expanded") == "false")
				{
					menuOptions = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//nav/ul/li/a/span"), 2);
					if (menuOptions.Count == 0)
					{
						Report.Error("No menu options were found");
						return false;
					}

					matchingMenuOption = menuOptions.FirstOrDefault(x => x.GetValue().ToLower() == menu.ToLower());
					matchingMenuOption.Click();
					Delay.Seconds(1);
				}


			}

			return matchingSubMenuOption.TryClick();
		}

		public bool ClickLink(string linkTitle)
		{
			var allLinks = containerElement.FindElements(By.XPath(".//a"));

			var matchingLink = allLinks.FirstOrDefault(x => x.GetAttribute("title").ToLower() == linkTitle.ToLower());

			if (matchingLink == null)
			{
				Report.Error("No matching link was found for: " + linkTitle);
				return false;
			}

			return matchingLink.TryClick();
		}

		public bool ClickLeftLink(string linkTitle)
		{
			var allLinks = containerElement.FindElements(By.XPath(".//ul[@class='nav']//a/span"));

			var matchingLink = allLinks.FirstOrDefault(x => x.GetValue().ToLower() == linkTitle.ToLower());

			if (matchingLink == null)
			{
				Report.Error("No matching link was found for: " + linkTitle);
				return false;
			}

			return matchingLink.TryClick();
		}

		public bool ClickMainPageLink(string linkTitle)
		{
			var allLinks = containerElement.FindElements(By.XPath(".//a[not(ancestor::ul)]"));

			var matchingLink = allLinks.FirstOrDefault(x => x.GetAttribute("title").ToLower() == linkTitle.ToLower());

			if (matchingLink == null)
			{
				Report.Error("No matching link was found for: " + linkTitle);
				return false;
			}

			return matchingLink.TryClick();
		}

		public bool TopLeftTitleExists(string expectedTitle)
		{
			var topLeftTitle = containerElement.FindElements(By.XPath(".//h3"));
			if (topLeftTitle.Count != 1)
			{
				Report.Error("Count of titles is not as expected. Found: " + topLeftTitle.Count);
				return false;
			}
			return expectedTitle == topLeftTitle[0].GetValue().Trim();
		}

		public List<string> getSectionTitles()
		{
			List<string> sections = new List<string>();
			var sectionTitles = containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2);
			if (sectionTitles.Count == 0)
			{
				Report.Error("No section titles were found");
			}
			else
			{
				sections = sectionTitles.Select(x => x.GetValue().Trim()).ToList();
			}

			return sections;
		}

		/*And I confirm the WERCSmart area shows the WERCSmart logo, name and Registered trade mark
		And I confirm that in the WERCSmart area the description text below the WERCSMart logo reads Provide data for WERCSmart®review and recipientsGet resources, enter data, manage and submit requestedinformation in WERCSmart®
		And I confirm that in the WERCSmart area the My Products link is shown below the WERCSmart description
		And I confirm that in the WERCSmart area the My Products link shows the flask icon
		And I confirm that in the WERCSmart area the heading "New Product Assessments" shows below the My products link
		And I confirm that in the WERCSmart area the Register new Product link is shown below the New Products Assessments heading on the left hand side of the section
		And I confirm that in the WERCSmart area the Register new product link shows the File icon
		And I confirm that in the WERCSmart area the Information &amp; Insights| The WERCS logo is show below the New Product Assessment links at the bottom of the section
		*/

		public string getSectionBlurb(string section)
		{
			List<string> sections = new List<string>();
			var sectionTitles = containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2);
			if (sectionTitles.Count == 0)
			{
				Report.Error("No section titles were found");
				return null;
			}
			else
			{
				var matchingSection = sectionTitles.FirstOrDefault(x => x.GetValue().Trim().ToLower() == section.ToLower());
				if (matchingSection == null)
				{
					Report.Error("No matching section was found: " + section);
					return null;
				}

				var blurbsUnderSection = matchingSection.FindElements(By.XPath("../../../following-sibling::div[contains(@class,'row')]/div[contains(@class, 'col-md-12')]/i|../../../following-sibling::div[contains(@class,'row')]/div[contains(@class, 'col-md-12')]/span|../../../following-sibling::div[contains(@class,'row')]/div[contains(@class, 'col-md-12')]/sup"), 2);

				string blurb = "";

				foreach (var thisBlub in blurbsUnderSection)
				{
					blurb = blurb + " " + thisBlub.GetValue().Trim();
				}

				return blurb.Trim();
			}
		}

		public List<string> getSectionImages(string section)
		{
			List<string> images = new List<string>();
			var sectionTitles = containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2);
			if (sectionTitles.Count == 0)
			{
				Report.Error("No section titles were found");
				return null;
			}
			else
			{
				var matchingSection = sectionTitles.FirstOrDefault(x => x.GetValue().Trim().ToLower() == section.ToLower());
				if (matchingSection == null)
				{
					Report.Error("No matching section was found: " + section);
					return null;
				}

				var imagesList = matchingSection.FindElements(By.XPath("../../../..//img"));

				if (imagesList.Count == 0)
				{
					Report.Info("No images were found");
				}
				else
				{
					string regexPattern = @"(?<=images\/)(.*)(?=\.)";
					Regex regex = new Regex(regexPattern);
					foreach (var thisImage in imagesList)
					{
						string src = thisImage.GetAttribute("src");
						Match match = regex.Match(src);
						if (match.Success)
						{
							images.Add(match.Value);
						}

					}
				}

			}

			return images;
		}

		public List<string> getSectionSubheadings(string section)
		{
			List<string> subHeadings = new List<string>();
			var sectionTitles =
				containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2);
			if (sectionTitles.Count == 0)
			{
				Report.Error("No section titles were found");
				return null;
			}
			else
			{
				var matchingSection =
					sectionTitles.FirstOrDefault(x => x.GetValue().Trim().ToLower() == section.ToLower());
				if (matchingSection == null)
				{
					Report.Error("No matching section was found: " + section);
					return null;
				}

				var subHeaders = matchingSection.FindElements(By.XPath("../../../..//span[@class='pullup']"));

				if (subHeaders.Count == 0)
				{
					Report.Info("No sub headers were found");
				}
				else
				{
					foreach (var thisSubHeader in subHeaders)
					{
						subHeadings.Add(thisSubHeader.GetValue());
					}
				}

			}

			return subHeadings;
		}

		public List<WERCSLinkLink> getSectionLinks(string section)
		{
			List<WERCSLinkLink> links = new List<WERCSLinkLink>();
			var sectionTitles = containerElement.FindElements(By.XPath(".//div[contains(@class,'vert-offset-top-3')]/span"), 2);
			if (sectionTitles.Count == 0)
			{
				Report.Error("No section titles were found");
				return null;
			}
			else
			{
				var matchingSection = sectionTitles.FirstOrDefault(x => x.GetValue().Trim().ToLower() == section.ToLower());
				if (matchingSection == null)
				{
					Report.Error("No matching section was found: " + section);
					return null;
				}

				var linksUnderSection = matchingSection.FindElements(By.XPath("../../../following-sibling::div//a"), 2);

				foreach (var thisLink in linksUnderSection)
				{
					var linkTitle = thisLink.FindElement(By.XPath("./span"), 2);
					var linkEm = thisLink.FindElement(By.XPath("../em"), 2);

					if (linkTitle != null && linkEm != null)
					{
						WERCSLinkLink newLink = new WERCSLinkLink();
						newLink.LinkTitle = linkTitle.GetValue();
						newLink.Icon = linkEm.GetAttribute("class").Replace("fa fa-", "").Replace("level-ov", "").Trim();
						newLink.Href = thisLink.GetAttribute("href");
						links.Add(newLink);
					}
				}
				return links;
			}
		}

		public List<string> DashboardWidgetTitles()
		{
			return this.containerElement.FindElements(By.XPath(".//div[starts-with(@class,'grid-stack-item-content')]//div[@class='panel-title']"), 2).Select(x => x.Text).ToList();
		}

		public bool WercsLinkNavigationButtonDisplayed()
		{
			var els = this.containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2).ToList();
			return  els.Any(x => x != null && x.Displayed);
		}

		public bool ClickWercsLinkNavigationButton()
		{
			var els = this.containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2).ToList();
			return els.First(x => x != null && x.Displayed).TryClick();
		}

		public List<SideBarNavLink> GetSideBarNavLinks()
		{
			var rList = new List<SideBarNavLink>();
			var sidebarItems = this.containerElement.FindElements(By.XPath(".//ul[@class='nav']/li/a"), 2).ToList();
			foreach (var item in sidebarItems)
			{
				var thisLink = this.GetSideBarNavLink(item);
				rList.Add(thisLink);
			}
			return rList;
		}

		public SideBarNavLink GetSideBarNavLink(string title)
		{
			var rLink = new SideBarNavLink();
			var els = this.containerElement.FindElements(By.XPath(".//ul[@class='nav']/li/a"), 2);
			foreach (var el in els)
			{
				if (el.Text == title)
				{
					rLink = this.GetSideBarNavLink(el);
				}
			}
			return rLink;
		}

		public SideBarNavLink GetSideBarNavLink(IWebElement el)
		{
			var thisLink = new SideBarNavLink();
			var titleEl = el.FindElement(By.XPath("./span"), 2);
			thisLink.Title = titleEl?.Text;
			thisLink.TitleDisplayed = titleEl?.Displayed ?? false;
			var primaryUl = el.FindElement(By.XPath("./following-sibling::ul[@id='multilevel'"), 2);
			thisLink.Expanded = primaryUl.GetAttribute("aria-expanded") == "true";
			var rsubLinks = new List<SideBarNavLink.SubLink>();
			var subEls = el.FindElements(By.XPath("./following-sibling::ul[@id='multilevel' and @aria-expanded='true']/li/a"), 2);
			for (var i = 0; i < subEls.Count; i++)
			{
				// Add sub sub link titles
				var subSubEls = this.containerElement.FindElements(By.XPath(".//ul[@id='level" + (i + 1).ToString() + "']/li/a"), 2);
				var rSubSubLinks = subSubEls.Select(subSubEl => new SideBarNavLink.SubLink.SubSubLink {
						Title = subSubEl.Text
					})
					.ToList();
				rsubLinks.Add(new SideBarNavLink.SubLink { Index = i + 1, Title = subEls[i].Text, SubSubLinks = rSubSubLinks });
			}
			// Add complete sub links to this link
			thisLink.SubLinks = rsubLinks;
			return thisLink;
		}


		public string UserButtonText()
		{
			return this.containerElement.FindElement(By.XPath(".//li[@class='btn-group']/a"), 2)?.Text;
		}

		public bool ClickUserButton()
		{
			return this.containerElement.FindElement(By.XPath(".//li[starts-with(@class,'btn-group')]/a"), 2).TryClick();
		}

		public bool ResetDashboardIconDisplayed()
		{
			var el = this.containerElement.FindElement(By.XPath(".//a[@id='dashboard-widgets']"), 2);
			return  el != null && el.Displayed;
		}

		public bool ClickResetDashboardIcon()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@id='dashboard-widgets']"), 2).TryClick();
		}

		public bool ResetDashboardDropdownItemDisplayed()
		{
			var el = this.containerElement.FindElement(By.XPath(".//a[@id='dashboard-reset']"), 2);
			return  el != null && el.Displayed;
		}

		public bool SignOutDropDownItemDisplayed()
		{
			var el = this.containerElement.FindElement(By.XPath(".//a[@id='logoutDialog']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickSignOut()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@id='logoutDialog']"), 2).TryClick();
		}

		public bool ULLogoDisplayed()
		{
			var el = this.containerElement.FindElement(By.XPath(".//a[@class='navbar-brand']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickULLogo()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='navbar-brand']"), 2).TryClick();
		}

		public bool AnyServicesGrid()
		{
			var els = this.containerElement.FindElements(By.XPath("//div[starts-with(@class,'well well-sm brand')]"), 2);
			return els != null && els.Any();
		}

		public bool StatusCheckPageDisplayed(string title)
		{
			var el = this.containerElement.FindElement(By.XPath("//div[@id='status-check-page']//h2[contains(text(),'" + title + "')]"), 2);
			return el != null && el.Displayed;
		}
	}

	public class WERCSLinkLink
	{
		public string LinkTitle { get; set; }

		public string Href { get; set; }

		public string Icon { get; set; }

	}

	public class SideBarNavLink : WERCSLinkDashboard
	{

		public string Title { get; set; }

		public bool TitleDisplayed { get; set; }

		public bool Expanded { get; set; }

		public List<SubLink> SubLinks { get; set; }

		public bool Click()
		{
			var els = this.containerElement.FindElements(By.XPath(".//ul[@class='nav']//li/a"), 2);
			foreach (var el in els)
			{
				if (el.Text == this.Title)
				{
					return el.TryClick();
				}
			}
			return false;
		}

		public class SubLink : SideBarNavLink
		{
			public int Index { get; set; }

			public new bool Click()
			{
				var els = this.containerElement.FindElements(By.XPath(".//ul[@id='multilevel' and @aria-expanded='true']/li/a"), 2);
				foreach (var el in els)
				{
					if (el.Text == this.Title)
					{
						return el.TryClick();
					}
				}
				return false;
			}

			public List<SubSubLink> SubSubLinks {get;set;}

			public class SubSubLink : SubLink
			{
				public new bool Click()
				{
					var els = this.containerElement.FindElements(By.XPath(".//ul[@id='level" + this.Index + "']/li/a"), 2);
					foreach (var el in els)
					{
						if (el.Text == this.Title)
						{
							return el.TryClick();
						}
					}
					return false;
				}
			}

		}

	}


}
