using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ModalDialog : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'modal-dialog') and not(ancestor::div[@id='select-retailers-dialog' or @id='LogOutModal']) and (.//parent::div[contains(@style,'display: block')])]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Click_OK()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "OK").TryClick();
		}

		public bool Click_Cancel()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "CANCEL").TryClick();
		}

		public bool Click_Close()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "close").TryClick();
		}

		public bool Click_Skip()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "SKIP").TryClick();
		}

		public bool Click_Closex()
		{
			return this.containerElement.FindElements(By.XPath("//button[@class='close']//span"), 2).FirstOrDefault(x => x.Text.Contains("×")).TryClick();
		}

		public bool CancelButtonExists()
		{
			try
			{
				var CancelButton = this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
					.FirstOrDefault(x => x.Text == "CANCEL");
				return (CancelButton.Enabled && CancelButton.Displayed);
			}
			catch (Exception)
			{
				return false;
			}

		}

		public string GetText()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-body']")).FirstOrDefault(x => x.Displayed)
				.Text;
		}

		public List<string> GetAllText()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-body']")).Where(x => x.Displayed).Select(x => x.Text).ToList();
		}

		public string GetTitle()
		{
			return this.containerElement.FindElements(By.XPath("//*[@class='modal-title']")).FirstOrDefault(x => x.Displayed)
				.Text;
		}

		public void EnterLoginPassword(string password)
		{
			this.containerElement.FindElement(By.XPath(".//input[@name='loginPassword']"), 2).EnterText(password);
		}

		public void EnterNewPassword(string password)
		{
			this.containerElement.FindElement(By.XPath(".//input[@id='newPassword']"), 2).EnterText(password);
		}

		public void EnterVerifyPassword(string password)
		{
			this.containerElement.FindElement(By.XPath(".//input[@id='verifyPassword']"), 2).EnterText(password);
		}

		public bool ClickContinue()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/a"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "continue").TryClick();
		}

		public bool ClickSave()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/a"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "save").TryClick();
		}

		public bool ClickApprove()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "approve").TryClick();
		}

		public bool ClickButton(string button)
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2).FirstOrDefault(x => x.Text == button).TryClick();
		}

		public bool Click_Yes()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "YES").TryClick();
		}

		public List<string> GetRetailers()
		{
			var retailers = this.containerElement.FindElements(By.XPath("//table/tbody/tr/td[2]"));

			List<string> retailerList = new List<string>();
			foreach (var retailer in retailers)
			{
				retailerList.Add(retailer.GetValue());
			}

			return retailerList;
		}

		public bool SelectRetailer(string retailer)
		{
			var retailers = this.containerElement.FindElements(By.XPath("//table/tbody/tr/td[2]"));

			var matchingRetailer = retailers.FirstOrDefault(x => x.GetValue() == retailer);

			if (matchingRetailer == null)
			{
				Report.Info("Could not find matching retailer. Retailers found were: " + String.Join(",", this.GetRetailers()));
				return false;
			}
			else
			{
				var retailerCheckbox = matchingRetailer.FindElement(By.XPath("..//input"), 2);
				if (retailerCheckbox == null)
				{
					Report.Info(("Found retailer but could not find checkbox"));
					Report.Screenshot();
					return false;
				}
				else
				{
					return retailerCheckbox.TryCheck();
				}

			}
		}
	}
}
