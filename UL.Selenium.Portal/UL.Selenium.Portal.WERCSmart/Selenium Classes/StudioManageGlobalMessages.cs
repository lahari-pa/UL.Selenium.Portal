using System;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioManageGlobalMessages : SeleniumBaseObject
	{
		public const string BasePath = "//div[(.//span[@id='ui-dialog-title-dialog-manage-global-messages'])]";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool ClickCloseButton()
		{
			return this.containerElement.FindElements(By.XPath(".//button/span"))
				.FirstOrDefault(x => x.GetValue().ToLower() == "close").TryClick();
		}

		public bool ClickSaveButton()
		{
			return this.containerElement.FindElements(By.XPath(".//button/span"))
				.FirstOrDefault(x => x.GetValue().ToLower() == "save").TryClick();
		}

		public bool ClickActionButton(string action)
		{
			try
			{
				ReadOnlyCollection<IWebElement> allButtons = this.containerElement.FindElements(By.XPath(".//table[contains(@class, 'navtable')]//td/div"));

				return allButtons.FirstOrDefault(x => x.Text.ToLower().Trim() == action.ToLower()).TryClick();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool AddMessage(Message thisMessage)
		{
			Report.Info("Clicking 'Add'");
			if (this.ClickActionButton("Add"))
			{
				for (int i = 0; i < 30; i++)
				{
					if (this.containerElement.FindElement(By.XPath("//input[@name='Title']")) != null)
					{
						break;
					}
					i++;
				}
				Report.Info("Setting Title to: " + thisMessage.Title);
				IWebElement titleEl = this.containerElement.FindElement(By.XPath("//input[@name='Title']"), 2);
				titleEl.EnterText(thisMessage.Title);
				Delay.Seconds(1);
				Report.IsTrue(titleEl.GetValue() == thisMessage.Title, "Failed to set title!", "Successfully set title");
				Report.Info("Setting Message to: " + thisMessage.MessageBody);
				IWebElement messageEl = this.containerElement.FindElement(By.XPath("//input[@name='Message']"), 2);
				messageEl.EnterText(thisMessage.MessageBody);
				Delay.Seconds(1);
				Report.IsTrue(messageEl.GetValue() == thisMessage.MessageBody, "Failed to set message!", "Successfully set message");
				Report.Info("Setting Type to: " + thisMessage.Type);
				IWebElement typeEl = this.containerElement.FindElement(By.XPath("//select[@name='Type']"), 2);
				typeEl.Select(thisMessage.Type);
				Delay.Seconds(1);
				Report.IsTrue(typeEl.SelectedOption() == thisMessage.Type, "Failed to set type!", "Successfully set type");
				Report.Info("Setting Active to: " + thisMessage.Active);
				IWebElement activeEl = this.containerElement.FindElement(By.XPath("//input[@name='Active']"), 2);
				activeEl.Check(thisMessage.Active);
				Delay.Seconds(1);
				Report.IsTrue(activeEl.Checked() == thisMessage.Active, "Failed to set active!", "Successfully set active");
				Report.Info("Setting Level to: " + thisMessage.Level);
				IWebElement levelEl = this.containerElement.FindElement(By.XPath("//select[@name='Level']"), 2);
				levelEl.Select(thisMessage.Level);
				Delay.Seconds(1);
				Report.IsTrue(levelEl.SelectedOption() == thisMessage.Level, "Failed to set level!", "Successfully set level");
				Report.Info("Clicking 'save'");
				if (this.ClickActionButton("Save"))
				{
					return true;
				}
				Report.Info("Failed to click save button");
				return false;
			}
			Report.Info("Failed to click add button");
			return false;
		}

		public bool WaitForMessageTableToShow()
		{
			IWebElement messageTable= this.containerElement.WaitUntilElementVisible(By.XPath(".//table[@id='tblGlobalMessages']"), 30);
			return messageTable != null;
		}

	}

	public class Message
	{
		public string Title { get; set; } = "";
		public string MessageBody { get; set; } = "";
		public string Type { get; set; } = "";
		public bool Active { get; set; } = false;
		public string Level { get; set; } = "";

	}
}
