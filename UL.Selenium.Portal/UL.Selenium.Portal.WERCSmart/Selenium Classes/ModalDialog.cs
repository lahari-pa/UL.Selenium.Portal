using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using UL.Automation.WebDriver.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ModalDialog : SeleniumBaseObject
	{
		public const string BasePath = "//div[contains(@class, 'modal-dialog') and not(ancestor::div[@id='select-retailers-dialog' or @id='LogOutModal']) and (.//parent::div[contains(@style,'display: block')])]";

		protected override By ContainerElementLocator => By.XPath(BasePath);

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

		public bool Click_Continue()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "CONTINUE").TryClick();
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
				IWebElement CancelButton = this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
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
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-body']")).FirstOrDefault(x => x.Displayed)?.Text;
		}

		public List<string> GetAllText()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-body']")).Where(x => x.Displayed).Select(x => x.Text).ToList();
		}

		public string GetTitle()
		{
			return this.containerElement.FindElements(By.XPath("//*[@class='modal-title']")).FirstOrDefault(x => x.Displayed)?.Text;
		}

		public void EnterLoginPassword(string password)
		{
			this.containerElement.FindElement(By.XPath(".//input[@name='loginPassword']"), 2).EnterText(password);
		}

		public bool LoginPasswordFieldPresent()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@name='loginPassword']"), 2);
			return el != null && el.Displayed;
		}

		public void EnterNewPassword(string password)
		{
			SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//input[@id='newPassword']"), 2).EnterText(password);
		}

		public void EnterVerifyPassword(string password)
		{
			SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//input[@id='verifyPassword']"), 2).EnterText(password);
		}

		public bool ClickContinue()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/a"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "continue").TryClick();
		}

		public bool ClickSave()
		{
			return this.ContainerElement.FindElements(By.XPath("//div[@class='modal-footer']/a"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "save").TryClick();
		}

		public bool ClickApprove()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "approve").TryClick();
		}

		public bool ClickButton(string button)
		{
			return this.ContainerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2).FirstOrDefault(x => x.Text == button).TryClick();
		}
		public bool ClickTheButtonInThePopupView(string popupTitle, string buttonTitle)
		{
			IWebElement button = this.ContainerElement.FindElement(By.XPath($".//div[@class='modal-content']//h4[text()='{popupTitle}']/../following-sibling::div[@class='modal-footer']//button[text()='{buttonTitle}'] | .//div[@class='modal-content']//h3[text()='{popupTitle}']/../following-sibling::div[@class='modal-footer']//button[text()='{buttonTitle}']"), 2);
			return button.TryClick();
		}

		public bool ClickRemoveButtonInDialogModal()
		{
			IWebElement removeButton = this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2).FirstOrDefault(x => x.Text == "REMOVE");
			return removeButton.TryClick();
		}

		public bool Click_Yes()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "YES").TryClick();
		}

		public bool Click_No()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "NO").TryClick();
		}

		public List<string> GetRetailers()
		{
			ReadOnlyCollection<IWebElement> retailers = this.ContainerElement.FindElements(By.XPath(".//td/span"));

			var retailerList = new List<string>();
			foreach (IWebElement retailer in retailers)
			{
				retailerList.Add(retailer.GetValue());
			}

			return retailerList;
		}

		public bool SelectRetailer(string retailer)
		{
			IWebElement matchingRetailer = this.ContainerElement.FindElement(By.XPath($".//td/span[contains(text(),'{retailer}')]"));

			if (matchingRetailer == null)
			{
				Report.Info($"Could not find matching retailer. Retailers found were: { this.GetRetailers()}");
				return false;
			}
			else
			{
				IWebElement retailerCheckbox = matchingRetailer.FindElement(By.XPath("../..//input"), 2);
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

		public List<string> AlertWarningRows()
		{
			return this.containerElement.FindElements(By.XPath(".//div[@class='alert alert-warning']/p"), 2).Select(x => x.Text).ToList();
		}

		public bool EnterValidation(string code)
		{
			IWebElement inputValidation = this.containerElement.FindElement(By.XPath(".//input[@type='text']"), 2);
			if (inputValidation == null)
			{
				return false;
			}
			else
			{
				inputValidation.EnterText(code);
				return true;
			}
		}

		public bool Click_Validate()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2).FirstOrDefault(x => x.Text == "VALIDATE").TryClick();
		}

		public bool CheckProductInformationIn3rdPartyAccessCodeWindowInProductsGrid(string id, string productType, string productAccessCode)
		{

			IWebElement accessCode = this.containerElement.FindElement(By.XPath(".//div[@data-bind='html: html']"), 2);
			string accessCodeText = accessCode.Text;

			if (!accessCodeText.Contains(id))
			{

				Report.Info("Product ID does not match");
				return false;

			}
			else if (!accessCodeText.Contains(productType))
			{

				Report.Info("Product Type does not match");
				return false;

			}
			else if (!accessCodeText.Contains("Access Code: " + productAccessCode))
			{

				Report.Info("Product ID does not match");
				return false;

			}

			return true;

		}
		public bool DeselectRetailer(string retailer)
		{
			IWebElement matchingRetailer = this.ContainerElement.FindElement(By.XPath($".//td/span[contains(text(),'{retailer}')]"));

			if (matchingRetailer == null)
			{
				Report.Info($"Could not find matching retailer. Retailers found were: { this.GetRetailers()}");
				return false;
			}
			else
			{
				IWebElement retailerCheckbox = matchingRetailer.FindElement(By.XPath("../..//input"), 2);
				if (retailerCheckbox == null)
				{
					Report.Info(("Found retailer but could not find checkbox"));
					Report.Screenshot();
					return false;
				}
				else
				{
					return retailerCheckbox.TryClick();
				}

			}
		}

	}
}
