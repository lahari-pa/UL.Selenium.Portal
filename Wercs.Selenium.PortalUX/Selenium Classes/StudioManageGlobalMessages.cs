using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class StudioManageGlobalMessages : BaseObject
	{
		public const string BasePath = "//div[(.//span[@id='ui-dialog-title-dialog-manage-global-messages'])]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickCloseButton()
		{
			return containerElement.FindElements(By.XPath(".//button/span"))
				.FirstOrDefault(x => x.GetValue().ToLower() == "close").TryClick();
		}

		public bool ClickSaveButton()
		{
			return containerElement.FindElements(By.XPath(".//button/span"))
				.FirstOrDefault(x => x.GetValue().ToLower() == "save").TryClick();
		}

		public bool ClickActionButton(string action)
		{
			try
			{
				var allButtons = containerElement.FindElements(By.XPath(".//table[contains(@class, 'navtable')]//td/div"));

				return allButtons.FirstOrDefault(x => x.Text.ToLower().Trim() == action.ToLower()).TryClick();
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool AddMessage(Message thisMessage)
		{
			Report.Info("Clicking 'Add'");
			if (ClickActionButton("Add"))
			{
				for (int i = 0; i < 30; i++)
				{
					if (containerElement.FindElement(By.XPath("//input[@name='Title']")) != null)
					{
						break;
					}
					i++;
				}
				Report.Info("Setting Title to: " + thisMessage.Title);
				var titleEl = containerElement.FindElement(By.XPath("//input[@name='Title']"), 2);
				titleEl.EnterText(thisMessage.Title);
				Delay.Seconds(1);
				Report.IsTrue(titleEl.GetValue() == thisMessage.Title, "Failed to set title!", "Successfully set title");
				Report.Info("Setting Message to: " + thisMessage.MessageBody);
				var messageEl = containerElement.FindElement(By.XPath("//input[@name='Message']"), 2);
				messageEl.EnterText(thisMessage.MessageBody);
				Delay.Seconds(1);
				Report.IsTrue(messageEl.GetValue() == thisMessage.MessageBody, "Failed to set message!", "Successfully set message");
				Report.Info("Setting Type to: " + thisMessage.Type);
				var typeEl = containerElement.FindElement(By.XPath("//select[@name='Type']"), 2);
				typeEl.Select(thisMessage.Type);
				Delay.Seconds(1);
				Report.IsTrue(typeEl.SelectedOption() == thisMessage.Type, "Failed to set type!", "Successfully set type");
				Report.Info("Setting Active to: " + thisMessage.Active);
				var activeEl = containerElement.FindElement(By.XPath("//input[@name='Active']"), 2);
				activeEl.Check(thisMessage.Active);
				Delay.Seconds(1);
				Report.IsTrue(activeEl.Checked() == thisMessage.Active, "Failed to set active!", "Successfully set active");
				Report.Info("Setting Level to: " + thisMessage.Level);
				var levelEl = containerElement.FindElement(By.XPath("//select[@name='Level']"), 2);
				levelEl.Select(thisMessage.Level);
				Delay.Seconds(1);
				Report.IsTrue(levelEl.SelectedOption() == thisMessage.Level, "Failed to set level!", "Successfully set level");
				Report.Info("Clicking 'save'");
				if (ClickActionButton("Save"))
				{
					return true;
				}
				Report.Info("Failed to click save button");
				return false;
			}
			Report.Info("Failed to click add button");
			return false;
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
