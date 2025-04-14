using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.SpecflowRewrite
{
	class HeaderNavbar: SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.XPath("//div[contains(@class,'navbar-fixed-top')]");
		private IWebElement BrandLink => this.FindElement(By.XPath(".//a[@class='navbar-brand']"), 1);
		public List<HeaderDropdownButton> HeaderDropdownButtonsList => [.. this.FindElements(By.XPath(".//a[@data-toggle='dropdown']"), 1).Select(x => new HeaderDropdownButton(x))];
		public HeaderDropdownButton HeaderDropdownButtonByLabel(string buttonLabel) => this.HeaderDropdownButtonsList.FirstOrDefault(x => x.Label.Equals(buttonLabel, System.StringComparison.Ordinal));
		#endregion

		#region Class Methods
		#region BrandLink Methods
		public bool BrandLinkExists()
		{
			Report.Info($"Attempting to confirm brand link exists.");
			return this.BrandLink != null;
		}

		public bool BrandLinkClick()
		{
			Report.Info($"Attempting to click brand link.");
			return this.BrandLink.TryClick();
		}

		public string BrandLinkText()
		{
			Report.Info($"Attempting to get brand link text.");
			return this.BrandLink.Text.Trim();
			;
		}
		#endregion

		#region Header Dropdown Buttons List Methods
		public bool HeaderDropdownButtonsListExists()
		{
			Report.Info($"Attempting to confirm header dropdown buttons list exists.");
			return !this.HeaderDropdownButtonsList.IsNullOrEmpty();
		}

		public List<string> HeaderDropdownButtonLabelsList()
		{
			Report.Info($"Attempting to get header dropdown button labels list.");
			return [.. this.HeaderDropdownButtonsList.Select(x => x.Label)];
		}

		public bool HeaderDropdownButtonWithLabelExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm header dropdown button with '{buttonLabel}' label exists.");
			return this.HeaderDropdownButtonByLabel(buttonLabel) != null;
		}
		#endregion
		#endregion
	}

	class HeaderDropdownButton(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string Label => this.ContainerElement?.Text.Trim();
		private IWebElement CounterBadge => this.ContainerElement.FindElement(By.XPath(".//span[contains(@class,'badge')]"), 1);
		public bool Expanded => this.ContainerElement.GetAttribute("aria-expanded").Equals("true", System.StringComparison.Ordinal);
		private List<IWebElement> DropdownOptionsLinksList => [.. this.ContainerElement.FindElements(By.XPath(".//following-sibling::ul[@class='dropdown-menu']//a"), 1)];
		private IWebElement DropdownOptionLinkByLabel(string linkLabel) => this.DropdownOptionsLinksList.FirstOrDefault(x => x.Text.Equals(linkLabel, System.StringComparison.Ordinal));
		#endregion

		#region Class Methods
		public bool Click()
		{
			Report.Info($"Attempting to click '{this.Label}' header dropdown button.");
			return this.ContainerElement.TryClick();
		}

		public bool CounterBadgeExists()
		{
			Report.Info($"Attempting to confirm '{this.Label}' header dropdown button counter badge exists.");
			return this.CounterBadge != null;
		}

		public string CounterBadgeText()
		{
			Report.Info($"Attempting to get '{this.Label}' header dropdown button counter badge value.");
			return this.CounterBadge?.Text.Trim();
		}

		public bool DropdownOptionsLinksListExists()
		{
			Report.Info($"Attempting to confirm '{this.Label}' header dropdown button dropdown options link list exists.");
			return !this.DropdownOptionsLinksList.IsNullOrEmpty();
		}

		public List<string> DropdownOptionsLinksLabelsList()
		{
			Report.Info($"Attempting to get '{this.Label}' header dropdown button dropdown options link Labels list.");
			return [.. this.DropdownOptionsLinksList.Select(x => x.Text.Trim())];
		}

		public bool DropdownOptionLinkWithLabelExists(string linkLabel)
		{
			Report.Info($"Attempting to confirm '{this.Label}' header dropdown button '{linkLabel}' dropdown option link exists.");
			return this.DropdownOptionLinkByLabel(linkLabel) != null;
		}

		public bool DropdownOptionLinkWithLabelClick(string linkLabel)
		{
			Report.Info($"Attempting to click '{this.Label}' header dropdown button '{linkLabel}' dropdown option link.");
			return this.DropdownOptionLinkByLabel(linkLabel).TryClick();
		}
		#endregion
	}

	// Alerts Menu may need to be updated for additional utility
	class DropdownAlertsMenu : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.XPath(".//div[@class='dropdown-menu alerts-menu']");
		private IWebElement DropdownHeader => this.FindElement(By.XPath(".//h3[@class='dropdown-header']"), 1);
		private IWebElement AlertsTable => this.FindElement(By.Id("AlertsTable"), 1);
		public List<AlertsTableRow> AlertsTableRowsList => [.. this.AlertsTable.FindElements(By.XPath(".//tr"), 1).Select(x => new AlertsTableRow(x))];
		public AlertsTableRow AlertsTableRowBySubjectEdited(string subjectEdited) => this.AlertsTableRowsList.FirstOrDefault(x => x.SubjectEdited.Equals(subjectEdited, System.StringComparison.Ordinal));
		private IWebElement ViewAllButton => this.FindElement(By.Id("AlertViewBtn"), 1);
		public List<AnnouncementsTableRow> AnnouncementsTableRowsList => [.. this.FindElements(By.XPath(".//div[@id='AnnouncementsPartial']//tr"), 1).Select(x => new AnnouncementsTableRow(x))];
		public AnnouncementsTableRow AnnouncementsTableRowByMessage(string messageText) => this.AnnouncementsTableRowsList.FirstOrDefault(x => x.Message.Equals(messageText, System.StringComparison.Ordinal));
		#endregion

		#region Class Methods
		#region Dropdown Header Methods
		public bool DropdownHeaderExists()
		{
			Report.Info($"Attempting to confirm dropdown header exists.");
			return this.DropdownHeader != null;
		}

		public string DropdownHeaderText()
		{
			Report.Info($"Attempting to get dropdown header text.");
			return this.DropdownHeader?.Text.Trim();
		}
		#endregion

		#region Alerts Table Methods
		public bool AlertsTableDisplayed()
		{
			Report.Info($"Attempting to confirm alerts table is displayed.");
			return this.AlertsTable?.Displayed ?? false;
		}

		public bool AlertsTableRowsListExists()
		{
			Report.Info($"Attempting to confirm alerts table rows list exists.");
			return !this.AlertsTableRowsList.IsNullOrEmpty();
		}

		public bool AlertsTableRowBySubjectEditedExists(string subjectEdited)
		{
			Report.Info($"Attempting to confirm alerts table row with '{subjectEdited}' subject text exists.");
			return this.AlertsTableRowBySubjectEdited(subjectEdited) != null;
		}
		#endregion

		#region Announcements Table Methods
		public bool AnnouncementsTableRowsListExists()
		{
			Report.Info($"Attempting to confirm announcements table rows list exists.");
			return !this.AnnouncementsTableRowsList.IsNullOrEmpty();
		}

		public bool AnnouncementsTableRowByMessageExists(string messageText)
		{
			Report.Info($"Attempting to confirm announcements table row with '{messageText}' message exists.");
			return this.AnnouncementsTableRowByMessage(messageText) != null;
		}
		#endregion

		#region Footer Buttons Methods
		public bool ViewAllButtonExists()
		{
			Report.Info($"Attempting to confirm 'View All' button exists.");
			return this.ViewAllButton != null;
		}

		public bool ViewAllButtonClick()
		{
			Report.Info($"Attempting to click 'View All' button.");
			return this.ViewAllButton.TryClick();
		}
		#endregion
		#endregion
	}

	class AlertsTableRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string SubjectEdited => this.ContainerElement.FindElement(By.XPath(".//span[@data-bind='text: SubjectEdited']"), 1)?.Text.Trim();
		public string DateStamp => this.ContainerElement.FindElement(By.XPath(".//p[contains(@data-bind,'DateStamp')]"), 1)?.Text.Trim();
		private IWebElement DismissButton => this.ContainerElement.FindElement(By.XPath(".//button[@aria-label='Dismiss']"), 1);
		private IWebElement ReviewButton => this.ContainerElement.FindElement(By.XPath(".//a[contains(@class,'hmc-resolve')]"), 1);
		#endregion

		#region Class Methods
		#region Dismiss Button Methods
		public bool DismissButtonExists()
		{
			Report.Info($"Attempting to confirm '{this.SubjectEdited}' alerts table row dismiss button exists.");
			return this.DismissButton != null;
		}

		public bool DismissButtonClick()
		{
			Report.Info($"Attempting to click '{this.SubjectEdited}' alerts table row dismiss button.");
			return this.DismissButton.TryClick();
		}
		#endregion

		#region Review Button Methods
		public bool ReviewButtonExists()
		{
			Report.Info($"Attempting to confirm '{this.SubjectEdited}' alerts table row review button exists.");
			return this.ReviewButton != null;
		}

		public bool ReviewButtonClick()
		{
			Report.Info($"Attempting to click '{this.SubjectEdited}' alerts table row review button.");
			return this.ReviewButton.TryClick();
		}
		#endregion
		#endregion
	}

	class AnnouncementsTableRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string DateTimeStamp => this.ContainerElement.FindElement(By.XPath(".//span[@data-bind='text: Date']"), 1)?.Text.Trim();
		public string Message => this.ContainerElement.FindElement(By.XPath(".//span[@data-bind='text: Message']"), 1)?.Text.Trim();
		#endregion

		#region Class Methods

		#endregion
	}
}
