using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NPOI.OpenXmlFormats.Dml.Diagram;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.SpecflowRewrite
{
    class LandingPage : SeleniumBaseObject
    {
		#region Class Objects
		#region Navbar Objects
		protected override By ContainerElementLocator => By.XPath("//body[.//div[@class='login-container']]");
		private IWebElement CustomerServiceCenterLink => this.FindElement(By.XPath(".//a[text() = 'Customer Support Center']"), 1);
		private IWebElement BrandLink => this.FindElement(By.XPath(".//a[@class='navbar-brand']"), 1);
		private List<IWebElement> NavbarLinksList => [.. this.FindElements(By.XPath(".//ul[contains(@class,'navbar-nav pull-right')]"), 1)];
		private IWebElement NavbarLink(string linkLabel) => this.NavbarLinksList.FirstOrDefault(x => x.Text.Trim().Equals(linkLabel, System.StringComparison.Ordinal));
		#endregion

		#region Hero Objects
		private IWebElement HeroTextH1 => this.FindElement(By.XPath(".//div[@class='hero-text-container']//h1"), 1);
		private IWebElement HeroTextP => this.FindElement(By.XPath(".//div[@class='hero-text-container']//p"), 1);
		private IWebElement CompareSubsctritionPlansButton => this.FindElement(By.XPath(".//a[text()='Compare subscription plans']"), 1);
		#endregion

		#region Retailer Carousel Object

		#endregion
		#endregion

		#region Class Methods
		#region Customer Service Center Link Methods
		public bool CustomerServiceCenterLinkExists()
		{
			Report.Info($"Attempting to confirm 'Customer Service Center' link exists.");
			return !this.CustomerServiceCenterLink.IsNullOrEmpty();
		}

		public bool CustomerServiceCenterLinkClick()
		{
			Report.Info($"Attempting to click 'Customer Service Center' link.");
			return this.CustomerServiceCenterLink.TryClick();
		}
		#endregion

		#region Brand Link Methods
		public bool BrindLinkExists()
		{
			Report.Info($"Attempting to confirm Brand link exists.");
			return !this.BrandLink.IsNullOrEmpty();
		}

		public bool BrandLinkClick()
		{
			Report.Info($"Attempting to click Brand link.");
			return this.BrandLink.TryClick();
		}

		public string BrandLinkText()
		{
			Report.Info($"Attempting to get Brand link text.");
			return this.BrandLink.Text;
		}
		#endregion

		#region Navbar Links Methods
		public bool NavbarLinksListExists()
		{
			Report.Info($"Attempting to confirm navbar links list exists.");
			return !this.NavbarLinksList.IsNullOrEmpty();
		}

		public int NavbarLinksCount()
		{
			Report.Info($"Attempting to get navbar links list count.");
			return this.NavbarLinksList.Count;
		}

		public List<string> NavbarLinksLabelsList()
		{
			Report.Info($"Attempting to get navbar links list labels.");
			return [.. this.NavbarLinksList.Select(x => x.Text.Trim())];
		}

		public bool NavbarLinkExists(string linkLabel)
		{
			Report.Info($"Attempting to confirm '{linkLabel}' navbar link exists.");
			return !this.NavbarLink(linkLabel).IsNullOrEmpty();
		}

		public bool NavbarLinkClick(string linkLabel)
		{
			Report.Info($"Attempting to click '{linkLabel}' navbar link.");
			return this.NavbarLink(linkLabel).TryClick();
		}
		#endregion

		#region Hero Methods
		public bool HeroTextH1Exists()
		{
			Report.Info($"Attempting to confirm hero text h1 exists.");
			return !this.HeroTextH1.IsNullOrEmpty();
		}

		public string HeroTextH1Text()
		{
			Report.Info($"Attempting to get hero text h1 text.");
			return this.HeroTextH1.Text;
		}

		public bool HeroTextPExists()
		{
			Report.Info($"Attempting to confirm hero text p exists.");
			return !this.HeroTextP.IsNullOrEmpty();
		}

		public string HeroTextPText()
		{
			Report.Info($"Attempting to get hero text p text.");
			return this.HeroTextP.Text;
		}

		public bool CompareSubscriptionPlansButtonExists()
		{
			Report.Info($"Attempting to confirm 'Compare Subscription Plans' button exists.");
			return !this.CompareSubsctritionPlansButton.IsNullOrEmpty();
		}

		public bool CompareSubscriptionPlansButtonClick()
		{
			Report.Info($"Attempting to click 'Compare Subscription Plans' button.");
			return this.CompareSubsctritionPlansButton.TryClick();
		}
		#endregion
		#endregion
	}
}
