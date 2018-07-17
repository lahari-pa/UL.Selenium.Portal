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
			if (ClickActionButton("Add"))
			{
				for(int i=0; i<30 ;i++)
				{
					if (containerElement.FindElement(By.XPath("//input[@name='Title']"))!= null)
					{
						break;
					}
					i++;
				}
				containerElement.FindElement(By.XPath("//input[@name='Title']")).EnterText(thisMessage.Title);
				containerElement.FindElement(By.XPath("//input[@name='Message']")).EnterText(thisMessage.MessageBody);
				containerElement.FindElement(By.XPath("//select[@name='Type']")).Select(thisMessage.Type);
				containerElement.FindElement(By.XPath("//input[@name='Active']")).Check(thisMessage.Active);
				containerElement.FindElement(By.XPath("//select[@name='Level']")).Select(thisMessage.Level);

				if (ClickActionButton("Save"))
				{
					return true;
				}
				else
				{
					Report.Info("Failed to click save button");
					return false;
				}



			}
			else
			{
				Report.Info("Failed to click add button");
				return false;
			}
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
