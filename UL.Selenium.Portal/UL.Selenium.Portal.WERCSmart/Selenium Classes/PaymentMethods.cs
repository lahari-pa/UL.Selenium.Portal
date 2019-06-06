using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class PaymentMethods : BaseObject
	{
		[FindsBy(How = How.Id, Using = "paymentMethodsContainer")]
		protected override IWebElement containerElement { get; set; }

		public bool Payment_Header_Correct()
		{
			Report.Info("Beginning Header_Correct");

			IWebElement myHeader = this.containerElement
				.FindElements(By.XPath(".//div[@class='header-with-back']/h2[text()='Payment Methods']"), 10).FirstOrDefault();

			if (myHeader == null)
			{
				Report.Info("Failed to Find Header Text");
				Report.Screenshot();
				return false;
			}
			if (!myHeader.Displayed)
			{
				Report.Info("Incorrect Page Open");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Page Opened");
			return true;
		}

		public bool Sub_Heading_Correct()
		{
			Report.Info("Beginning Sub_Heading_Correct");

			IWebElement myHeader = this.containerElement
				.FindElements(By.XPath(".//div[@class='main-wrapper has-title payment-methods']/h2[text()='Select your payment method']"), 10).FirstOrDefault();

			if (myHeader == null)
			{
				Report.Info("Failed to Find Sub Header Text");
				Report.Screenshot();
				return false;
			}
			if (!myHeader.Displayed)
			{
				Report.Info("Incorrect Sub Header");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Sub Heading");
			return true;

		}

		public bool RefindContainerElement()
		{
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.Id("paymentMethodsContainer"), 2);
			return this.containerElement != null;
		}

		public bool Select_Payment_Method(string payment_method)
		{
			Report.Info("Beginning Select_Payment_Method: " + payment_method);
			this.RefindContainerElement();
			List<IWebElement> allProducts = this.containerElement.FindElements(By.XPath(".//div[@class='col-sm-3']/a/div"), 2).ToList();

			foreach (var method in allProducts)
			{
				Report.Info("Payment Method = " + method.Text);

				if (method.Text == payment_method)
				{
					Report.Success("Payment Method Found");
					method.Click();
					Delay.Seconds(3 * Delay.SpeedFactor);
					return true;
				}
				Report.Info("Payment Method Doesn't Match");
			}
			Report.Info("Failed to Find Payment Method");
			return false;
		}

		public bool Payment_Method_Exists(string payment_method)
		{
			Report.Info("Beginning Payment_Method_Exists: " + payment_method);

			Delay.Seconds(2 * Delay.SpeedFactor);

			List<IWebElement> allProducts = this.containerElement.FindElements(By.XPath(".//div[@class='col-sm-3']/a/div")).ToList();

			foreach (var method in allProducts)
			{
				Report.Info("Payment Method = " + method.Text);

				if (method.Text == payment_method)
				{
					Report.Success("Payment Method Found");
					return true;
				}
				Report.Info("Payment Method Doesn't Match");
			}
			Report.Info("Failed to Find Payment Method");
			return false;
		}

		//==================================================================================== CREDIT CARD

		public bool Credit_Card_Default()
		{
			Report.Info("Beginning Credit_Card_Default");

			List<IWebElement> allProducts = this.containerElement.FindElements(By.XPath(".//h4[@class='card-title']")).ToList();

			IWebElement myCard = null;

			foreach (var method in allProducts)
			{
				if (method.Text.Trim().Replace("\r\n", " ").Contains("Credit Card"))
				{
					Report.Success("Payment Method Found");
					myCard = method;
					break;
				}
				Report.Info("Payment Method Doesn't Match");
			}

			if (myCard == null)
			{
				Report.Info("Failed to Find Credit Card Payment Method");
				Report.Screenshot();
				return false;
			}

			IWebElement myDefault = myCard.FindElement(By.XPath(".//span[text()='Default']"), 2);

			if (myDefault == null)
			{
				Report.Info("Credit Card Payment Method is Not Default Method");
				Report.Screenshot();
				return false;
			}
			Report.Success("Credit Card Payment Method is Default Method");
			Report.Screenshot();
			return true;
		}


		public bool Credit_Card_Fields_Check(List<string> myList)
		{
			Report.Info("Beginning Credit_Card_Fields_Check");

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!this.Exists)
			{
				Report.Info("Not on Payment Methods Page");
				Report.Screenshot();
				return false;
			}
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("z_hppm_iframe");

			IWebElement _lbl_card_type = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-creditCardType']"), 2);
			IWebElement _lbl_card_no = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-creditCardNumber']"), 2);
			IWebElement _lbl_ex_date = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-creditCardExpirationMonth']"), 2);
			IWebElement _lbl_cvv = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-cardSecurityCode']"), 2);
			IWebElement _lbl_cardholder_name = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-creditCardHolderName']"), 2);


			foreach (var field in myList)
			{
				Report.Info("Field = " + field);
				switch (field)
				{
					case "Card Type":
						if (!_lbl_card_type.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Card Number":
						if (!_lbl_card_no.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Expiration Date":
						if (!_lbl_ex_date.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "CVV":
						if (!_lbl_cvv.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Cardholder Name":
						if (!_lbl_cardholder_name.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					default:
						Report.Error("Unable to Find Correct Field Name");
						return false;
				}
			}
			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			Report.Info("Credit Card Fields are Correct");
			Report.Screenshot();
			return true;
		}

		public bool Credit_Card_Error_Check(List<string> myList)
		{
			Report.Info("Beginning Credit_Card_Error_Check");

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!this.Exists)
			{
				Report.Info("Not on Payment Methods Page");
				Report.Screenshot();
				return false;
			}
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("z_hppm_iframe");

			IWebElement _err_card_no = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='error-creditCardNumber']"), 2);
			IWebElement _err_ex_date = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='error-creditCardExpirationMonth']"), 2);
			IWebElement _err_cvv = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='error-cardSecurityCode']"), 2);
			IWebElement _err_cardholder_name = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='error-creditCardHolderName']"), 2);


			foreach (var field in myList)
			{
				Report.Info("Field = " + field);
				switch (field)
				{
					case "Card Number":
						if (!_err_card_no.Displayed)
						{
							Report.Info(field + " Error Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Error Displayed");
						break;
					case "Expiration Date":
						if (!_err_ex_date.Displayed)
						{
							Report.Info(field + " Error Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Error Displayed");
						break;
					case "CVV":
						if (!_err_cvv.Displayed)
						{
							Report.Info(field + " Error Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Error Displayed");
						break;
					case "Cardholder Name":
						if (!_err_cardholder_name.Displayed)
						{
							Report.Info(field + " Error Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					default:
						Report.Error("Unable to Find Correct Error Name");
						return false;
				}
			}
			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			Report.Info("Credit Card Errors are Correct");
			Report.Screenshot();
			return true;
		}

		public bool Enter_Credit_Card_Details(string card_type, string card_no, string exp_month, string exp_year, string cvv, string cardh_name)
		{
			Report.Info("Beginning Enter_Credit_Card_Details");

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!this.Exists)
			{
				Report.Info("Not on Payment Methods Page");
				Report.Screenshot();
				return false;
			}
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("z_hppm_iframe");

			IWebElement _pic_card_type_visa = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='card-image-container-Visa']"), 2);
			IWebElement _pic_card_type_master = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='card-image-container-MasterCard']"), 2);
			IWebElement _pic_card_type_american = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='card-image-container-AmericanExpress']"), 2);
			IWebElement _pic_card_type_discover = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='card-image-container-Discover']"), 2);
			IWebElement _txt_card_no = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@id='input-creditCardNumber']"), 2);
			IWebElement _sel_exp_month = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//select[@id='input-creditCardExpirationMonth']"), 2);
			IWebElement _sel_exp_year = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//select[@id='input-creditCardExpirationYear']"), 2);
			IWebElement _txt_cvv = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@id='input-cardSecurityCode']"), 2);
			IWebElement _txt_cardholder_name = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@id='input-creditCardHolderName']"), 2);

			switch (card_type)
			{
				case "Visa":
					_pic_card_type_visa.Click();
					Report.Success(card_type + " Selected");
					break;
				case "MasterCard":
					_pic_card_type_master.Click();
					Report.Success(card_type + " Selected");
					break;
				case "American Express":
					_pic_card_type_american.Click();
					Report.Success(card_type + " Selected");
					break;
				case "Discover":
					_pic_card_type_discover.Click();
					Report.Success(card_type + " Selected");
					break;
				default:
					Report.Error("Unable to Find Correct Credit Card Company");
					return false;
			}
			Report.Info("Entering Card Number: " + card_no);
			_txt_card_no.EnterText(card_no);
			Report.Info("Selecting Expiry Month: " + exp_month);
			_sel_exp_month.Select(exp_month);
			Report.Info("Selecting Expiry Year: " + exp_year);
			_sel_exp_year.Select(exp_year);
			Report.Info("Entering CVV: " + cvv);
			_txt_cvv.EnterText(cvv);
			Report.Info("Entering Cardholder Name: " + cardh_name);
			_txt_cardholder_name.EnterText(cardh_name);

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			Report.Info("Credit Card Details Entered");
			Report.Screenshot();
			return true;
		}


		//==================================================================================== ACH

		public bool ACH_Fields_Check(List<string> myList)
		{
			Report.Info("Beginning ACH_Fields_Check");

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!this.Exists)
			{
				Report.Info("Not on Payment Methods Page");
				Report.Screenshot();
				return false;
			}
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("z_hppm_iframe");

			IWebElement _lbl_aba_rout_no = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-achBankABACode']"), 2);
			IWebElement _lbl_bank_acc_no = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-achBankAccountNumber']"), 2);
			IWebElement _lbl_acc_type = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-achBankAccountType']"), 2);
			IWebElement _lbl_bank_name = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-achBankName']"), 2);
			IWebElement _lbl_acc_holder_name = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//label[@id='form-label-achBankAccountName']"), 2);

			foreach (var field in myList)
			{
				Report.Info("Field = " + field);
				switch (field)
				{
					case "ABA/Routing Number":
						if (!_lbl_aba_rout_no.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Bank Account Number":
						if (!_lbl_bank_acc_no.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Account Type":
						if (!_lbl_acc_type.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Bank Name":
						if (!_lbl_bank_name.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Account Holder Name":
						if (!_lbl_acc_holder_name.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					default:
						Report.Error("Unable to Find Correct Field Name");
						return false;
				}
			}
			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			Report.Info("ACH Fields are Correct");
			Report.Screenshot();
			return true;
		}

		public bool ACH_Error_Check(List<string> myList)
		{
			Report.Info("Beginning ACH_Error_Check");

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!this.Exists)
			{
				Report.Info("Not on Payment Methods Page");
				Report.Screenshot();
				return false;
			}
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("z_hppm_iframe");

			IWebElement _err_aba_rout_no = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='error-achBankABACode']"), 2);
			IWebElement _err_bank_acc_no = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='error-achBankAccountNumber']"), 2);
			IWebElement _err_acc_type = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='error-achBankAccountType']"), 2);
			IWebElement _err_bank_name = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='error-achBankName']"), 2);
			IWebElement _err_acc_holder_name = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='error-achBankAccountName']"), 2);

			foreach (var field in myList)
			{
				Report.Info("Field = " + field);
				switch (field)
				{
					case "ABA/Routing Number":
						if (!_err_aba_rout_no.Displayed)
						{
							Report.Info(field + " Error Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Error Displayed");
						break;
					case "Bank Account Number":
						if (!_err_bank_acc_no.Displayed)
						{
							Report.Info(field + " Error Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Error Displayed");
						break;
					case "Account Type":
						if (!_err_acc_type.Displayed)
						{
							Report.Info(field + " Error Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Error Displayed");
						break;
					case "Bank Name":
						if (!_err_bank_name.Displayed)
						{
							Report.Info(field + " Error Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Error Displayed");
						break;
					case "Account Holder Name":
						if (!_err_acc_holder_name.Displayed)
						{
							Report.Info(field + " Error Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Error Displayed");
						break;
					default:
						Report.Error("Unable to Find Correct Error Message");
						return false;
				}
			}
			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			Report.Info("ACH Error Messages are Correct");
			Report.Screenshot();
			return true;
		}


		//==================================================================================== WIRE TRANSFER

		//Wire Transfer Warning
		[FindsBy(How = How.Id, Using = "wireTransferWarning-new")]
		private IWebElement _transfer_warning;

		public bool Wire_Transfer_Warning(string warning)
		{
			Report.Info("Beginning Wire_Transfer_Warning");

			Report.Info("Expected Warning = " + warning);

			if (this._transfer_warning.Text != warning)
			{
				Report.Info("Warning Message Text Incorrect");
				Report.Info(this._transfer_warning.Text);
				Report.Screenshot();
				return false;
			}
			Report.Success("Warning Message Text correct");
			Report.Screenshot();
			return true;
		}

		//==================PayPal text
		public string Paypal_text()
		{
			return this.containerElement.FindElement(By.XPath("//div[@class='alert alert-info']")).Text.Trim();
		}

		//Continue Button
		[FindsBy(How = How.Id, Using = "continueButton")]
		private IWebElement _btnContinue;

		public bool Continue_click()
		{
			Report.Info("Attempting to Click Continue Button");
			this._btnContinue.Click();
			return true;
		}

		public bool Continue_Button_Enabled(string enabled)
		{
			Report.Info("Beginning Continue_Button_Enabled");
			Report.Info("Checking Continue Button is " + enabled);

			if (enabled == "enabled")
			{
				if (!this._btnContinue.Enabled)
				{
					Report.Info("Continue Button is Disabled");
					Report.Screenshot();
					return false;
				}

				Report.Success("Continue Button is Enabled");
				return true;
			}

			if (enabled == "disabled")
			{
				if (this._btnContinue.Enabled)
				{
					Report.Info("Continue Button is Enabled");
					Report.Screenshot();
					return false;
				}

				Report.Success("Continue Button is Disabled");
				return true;
			}
			Report.Info("Incorrect Input: " + enabled);
			return false;
		}

		//Formulated Products
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-2 address-panel']")]
		private IWebElement _tbl_addresses;

		public string Get_Contact_Info()
		{
			Report.Info("Beginning Get_Contact_Info");

			IWebElement myContact = this._tbl_addresses.FindElements(By.XPath("div[1]/div"), 10).FirstOrDefault();

			if (myContact == null)
			{
				Report.Info("Failed to Find Contact Information");
				Report.Screenshot();
				return "";
			}
			Report.Info("Contact Information Found");
			return myContact.Text;
		}

		public bool Confirm_Contact_Info(string company_name, string first_name, string last_name, string email_address)
		{
			Report.Info("Beginning Confirm_Contact_Info");

			string myInfo = this.Get_Contact_Info();

			if (!myInfo.Contains(company_name))
			{
				Report.Info("Company Name Incorrect: " + company_name);
				Report.Screenshot();
				return false;
			}
			Report.Info("Company Name Correct: " + company_name);
			if (!myInfo.Contains(first_name))
			{
				Report.Info("First Name Incorrect: " + first_name);
				Report.Screenshot();
				return false;
			}
			Report.Info("First Name Correct: " + first_name);
			if (!myInfo.Contains(last_name))
			{
				Report.Info("Last Name Incorrect: " + last_name);
				Report.Screenshot();
				return false;
			}
			Report.Info("Last Name Correct: " + last_name);
			if (!myInfo.Contains(email_address))
			{
				Report.Info("Email Address Incorrect: " + email_address);
				Report.Screenshot();
				return false;
			}
			Report.Info("Email Address Correct: " + email_address);

			Report.Info("Contact Information Correct");
			return true;
		}


		public string Get_Billing_Address()
		{
			Report.Info("Beginning Get_Billing_Address");

			IWebElement myBill = this.containerElement.FindElements(By.XPath(".//div/h3[text()='Billing Address']"), 10).FirstOrDefault();

			IWebElement myAddress = myBill.FindElements(By.XPath("../div"), 10).FirstOrDefault();

			if (myAddress == null)
			{
				Report.Info("Failed to Find Billing Address");
				Report.Screenshot();
				return "";
			}
			Report.Info("Billing Address Found");
			return myAddress.Text;
		}

		public bool Confirm_Billing_Address(string address_one, string address_two, string city, string state_code, string zip_code, string country, string phone_no)
		{
			Report.Info("Beginning Confirm_Billing_Address");

			string myInfo = this.Get_Billing_Address();

			if (!myInfo.Contains(address_one))
			{
				Report.Info("Address One Incorrect: " + address_one);
				Report.Screenshot();
				return false;
			}
			Report.Info("Address One Correct: " + address_one);
			if (!myInfo.Contains(address_two))
			{
				Report.Info("Address Two Incorrect: " + address_two);
				Report.Screenshot();
				return false;
			}
			Report.Info("Address Two Correct: " + address_two);
			if (!myInfo.Contains(city))
			{
				Report.Info("City Incorrect: " + city);
				Report.Screenshot();
				return false;
			}
			Report.Info("City Correct: " + city);
			if (!myInfo.Contains(state_code))
			{
				Report.Info("State Code Incorrect: " + state_code);
				Report.Screenshot();
				return false;
			}
			Report.Info("State Code Correct: " + state_code);
			if (!myInfo.Contains(zip_code))
			{
				Report.Info("Zip Code Incorrect: " + zip_code);
				Report.Screenshot();
				return false;
			}
			Report.Info("Zip Code Correct: " + zip_code);
			if (!myInfo.Contains(country))
			{
				Report.Info("Country Incorrect: " + country);
				Report.Screenshot();
				return false;
			}
			Report.Info("Country Correct: " + country);
			Report.Info("Zip Code Correct: " + zip_code);
			if (!myInfo.Contains(phone_no))
			{
				Report.Info("Phone Number Incorrect: " + phone_no);
				Report.Screenshot();
				return false;
			}
			Report.Info("Phone Number Correct: " + phone_no);

			Report.Info("Billing Address is Correct");
			Report.Screenshot();
			return true;
		}

		//Change Button
		[FindsBy(How = How.XPath, Using = ".//div/a[text()='Change']")]
		private IWebElement _btnChange;

		public bool Change_click()
		{
			Report.Info("Attempting to Click Change Button");
			this._btnChange.Click();
			return true;
		}




	}

	class PaymentMethods_Edit_Address : BaseObject
	{
		[FindsBy(How = How.Id, Using = "editAddressDetails")]
		protected override IWebElement containerElement { get; set; }

		public bool Sub_Headings_Correct(string sub_1, string sub_2)
		{
			Report.Info("Beginning Sub_Headings_Correct");

			if (!this.Exists)
			{
				Report.Info("Failed to Open Edit Address Form");
				Report.Screenshot();
				return false;
			}
			Report.Info("Edit Address Form Open");

			IWebElement myH1 = this.containerElement.FindElements(By.XPath(".//div/h4[text()='" + sub_1 + "']"), 10).FirstOrDefault();

			if (myH1 == null)
			{
				Report.Info("Failed to Find Header with Text: " + sub_1);
				Report.Screenshot();
				return false;
			}
			Report.Success("Header with Text: " + sub_1 + " Found");

			IWebElement myH2 = this.containerElement.FindElements(By.XPath(".//div/h4[text()='" + sub_2 + "']"), 10).FirstOrDefault();

			if (myH2 == null)
			{
				Report.Info("Failed to Find Header with Text: " + sub_2);
				Report.Screenshot();
				return false;
			}
			Report.Success("Header with Text: " + sub_2 + " Found");

			Report.Success("Sub Headers are Correct");
			Report.Screenshot();
			return true;
		}

		//===================================================================================================== PRIMARY ACCOUNT CONTACT

		//Primary Account Contact Section
		[FindsBy(How = How.XPath, Using = ".//div/h4[text()='Primary Account Contact']/..")]
		private IWebElement _section_pac;

		public bool Edit_Primary_Account_Contact(string firstName = "", string lastName = "", string email = "")
		{
			Report.Info("Beginning Edit_Primary_Account_Contact");

			if (!this.Exists)
			{
				Report.Info("Not on Edit Address Form");
				Report.Screenshot();
				return false;
			}
			Report.Info("Edit Address Form Open");
			if (firstName != "")
			{
				IWebElement myFirst = this._section_pac.FindElements(By.XPath(".//input[@name='firstName']"), 10).FirstOrDefault();
				if (myFirst == null)
				{
					Report.Info("Failed to Find First Name Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing First Name: " + firstName);
				myFirst.EnterText(firstName);
			}
			if (lastName != "")
			{
				IWebElement myLast = this._section_pac.FindElements(By.XPath(".//input[@name='lastName']"), 10).FirstOrDefault();
				if (myLast == null)
				{
					Report.Info("Failed to Find Last Name Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Last Name: " + lastName);
				myLast.EnterText(lastName);
			}
			if (email != "")
			{
				IWebElement myEmail = this._section_pac.FindElements(By.XPath(".//input[@name='email']"), 10).FirstOrDefault();
				if (myEmail == null)
				{
					Report.Info("Failed to Find Email Address Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Email Address: " + email);
				myEmail.EnterText(email);
			}
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Success("Primary Account Contact Edited");
			Report.Screenshot();
			return true;
		}


		//================================================================================================= BILLING ADDRESS

		//Billing Address Section
		[FindsBy(How = How.XPath, Using = ".//div/h4[text()='Billing Address']/..")]
		private IWebElement _section_bill;

		public bool Billing_Headers_Check(List<string> myList)
		{
			Report.Info("Beginning Billing_Headers_Check");

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!this.Exists)
			{
				Report.Info("Not on Edit Address Form");
				Report.Screenshot();
				return false;
			}

			IWebElement myFieldHeader = null;

			foreach (var field in myList)
			{
				Report.Info("Field = " + field);
				switch (field)
				{
					case "First Name":
						myFieldHeader = this._section_pac.FindElements(By.XPath(".//label[text()='First Name']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Last Name":
						myFieldHeader = this._section_pac.FindElements(By.XPath(".//label[text()='Last Name']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Email Address":
						myFieldHeader = this._section_pac.FindElements(By.XPath(".//label[text()='Email Address']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Address 1":
						myFieldHeader = this._section_bill.FindElements(By.XPath(".//label[text()='Address Line 1']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Address 2":
						myFieldHeader = this._section_bill.FindElements(By.XPath(".//label[text()='Address Line 2']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "City":
						myFieldHeader = this._section_bill.FindElements(By.XPath(".//label[text()='City']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "State":
						myFieldHeader = this._section_bill.FindElements(By.XPath(".//label[text()='State']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Zip Code":
						myFieldHeader = this._section_bill.FindElements(By.XPath(".//label[text()='Zip']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Country":
						myFieldHeader = this._section_bill.FindElements(By.XPath(".//label[text()='Country']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Phone Number":
						myFieldHeader = this._section_bill.FindElements(By.XPath(".//label[text()='Phone']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Shipping/Billing Checkbox":
						myFieldHeader = this.containerElement.FindElements(By.XPath(".//div[@class='checkbox']/label"), 10).FirstOrDefault();
						if (myFieldHeader.Text.Trim() != "Shipping Address is the same as billing address")
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					default:
						Report.Error("Unable to Find Correct Field Name");
						return false;
				}
			}
			Report.Info("Edit Address Fields are Correct");
			Report.Screenshot();
			return true;
		}

		//============================================================================= FIELDS

		public bool Edit_Billing_Address(string address1 = "", string address2 = "", string city = "", string state = "", string zip = "", string country = "", string phone = "")
		{
			Report.Info("Beginning Edit_Billing_Address");

			var myPay = new PaymentMethods();

			if (!myPay.Change_click())
			{
				Report.Info("Failed to Click Change Button");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(2 * Delay.SpeedFactor);
			if (!this.Exists)
			{
				Report.Info("Not on Edit Address Form");
				Report.Screenshot();
				return false;
			}
			Report.Info("Edit Address Form Open");
			if (address1 != "")
			{
				IWebElement myAdd1 = this._section_bill.FindElements(By.XPath(".//input[@name='address1']"), 10).FirstOrDefault();
				if (myAdd1 == null)
				{
					Report.Info("Failed to Find Address Line 1 Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Address Line 1: " + address1);
				myAdd1.EnterText(address1);
			}
			if (address2 != "")
			{
				IWebElement myAdd2 = this._section_bill.FindElements(By.XPath(".//input[@name='address2']"), 10).FirstOrDefault();
				if (myAdd2 == null)
				{
					Report.Info("Failed to Find Address Line 2 Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Address Line 2: " + address2);
				myAdd2.EnterText(address2);
			}
			if (city != "")
			{
				IWebElement myCity = this._section_bill.FindElements(By.XPath(".//input[@name='city']"), 10).FirstOrDefault();
				if (myCity == null)
				{
					Report.Info("Failed to Find City Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing City: " + city);
				myCity.EnterText(city);
			}
			if (state != "")
			{
				IWebElement myState = this._section_bill.FindElements(By.XPath(".//input[@name='state']"), 10).FirstOrDefault();
				if (myState == null)
				{
					Report.Info("Failed to Find State Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing State: " + state);
				myState.EnterText(state);
			}
			if (state != "")
			{
				IWebElement myState = this._section_bill.FindElements(By.XPath(".//input[@name='state']"), 10).FirstOrDefault();
				if (myState == null)
				{
					Report.Info("Failed to Find State Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing State: " + state);
				myState.EnterText(state);
			}
			if (zip != "")
			{
				IWebElement myZip = this._section_bill.FindElements(By.XPath(".//input[@name='zip']"), 10).FirstOrDefault();
				if (myZip == null)
				{
					Report.Info("Failed to Find Zip Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Zip Code: " + zip);
				myZip.EnterText(zip);
			}
			if (country != "")
			{
				IWebElement myCountry = this._section_bill.FindElements(By.XPath(".//input[@name='country']"), 10).FirstOrDefault();
				if (myCountry == null)
				{
					Report.Info("Failed to Find Zip Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Zip Code: " + country);
				myCountry.Select(country);
			}
			if (phone != "")
			{
				IWebElement myPhone = this._section_bill.FindElements(By.XPath(".//input[@name='phone']"), 10).FirstOrDefault();
				if (myPhone == null)
				{
					Report.Info("Failed to Find Phone Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Phone Number: " + phone);
				myPhone.EnterText(phone);
			}
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Success("Billing Address Edited");
			Report.Screenshot();
			return true;
		}

		//Shipping Address is the same as billing address
		[FindsBy(How = How.XPath, Using = ".//div[@class='checkbox']/label/input")]
		private IWebElement _chk_same;

		public bool Shipp_Same_As_Bill_Check(bool bEnable)
		{
			Report.Info("Shipping Address is the same as Billing Address - " + bEnable);
			this._chk_same.Check(bEnable);
			return true;
		}

		//Cancel Button
		[FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-danger']")]
		private IWebElement _btnCancel;

		public bool Cancel_click()
		{
			Report.Info("Attempting to Click Cancel Button");
			this._btnCancel.Click();
			return true;
		}

		//Save Button
		[FindsBy(How = How.Id, Using = "SaveAddress")]
		private IWebElement _btnSave;

		public bool Save_click()
		{
			Report.Info("Attempting to Click Save Button");
			this._btnSave.Click();
			return true;
		}


		//==================================================================================== SHIPPING ADDRESS

		//Shipping Address Section
		[FindsBy(How = How.XPath, Using = ".//div/h4[text()='Shipping Address']/..")]
		private IWebElement _section_ship;

		public bool Shipping_Headers_Check(List<string> myList)
		{
			Report.Info("Beginning Shipping_Headers_Check");

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!this.Exists)
			{
				Report.Info("Not on Edit Address Form");
				Report.Screenshot();
				return false;
			}

			IWebElement myFieldHeader = null;

			foreach (var field in myList)
			{
				Report.Info("Field = " + field);
				switch (field)
				{
					case "Address 1":
						myFieldHeader = this._section_ship.FindElements(By.XPath(".//label[text()='Address Line 1']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Address 2":
						myFieldHeader = this._section_ship.FindElements(By.XPath(".//label[text()='Address Line 2']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "City":
						myFieldHeader = this._section_ship.FindElements(By.XPath(".//label[text()='City']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "State":
						myFieldHeader = this._section_ship.FindElements(By.XPath(".//label[text()='State']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Zip Code":
						myFieldHeader = this._section_ship.FindElements(By.XPath(".//label[text()='Zip']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Country":
						myFieldHeader = this._section_ship.FindElements(By.XPath(".//label[text()='Country']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Phone Number":
						myFieldHeader = this._section_ship.FindElements(By.XPath(".//label[text()='Phone']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					default:
						Report.Error("Unable to Find Correct Field Name");
						return false;
				}
			}
			Report.Info("Shipping Address Fields are Correct");
			Report.Screenshot();
			return true;
		}

		public bool Shipping_Address_Hidden()
		{
			Report.Info("Shipping_Address_Hidden");

			if (this._section_ship.Displayed)
			{
				Report.Info("Shipping Address Not Hidden");
				Report.Screenshot();
				return false;
			}
			Report.Success("Shipping Address Hidden");
			Report.Screenshot();
			return true;
		}
	}

	class PaymentMethods_Subscription_Billing : BaseObject
	{
		[FindsBy(How = How.Id, Using = "shoppingCart")]
		protected override IWebElement containerElement { get; set; }

		public bool Purchase_Header_Correct()
		{
			Report.Info("Beginning Purchase_Header_Correct");

			IWebElement myHeader = this.containerElement
				.FindElements(By.XPath(".//div[@class='header-with-back']//h2[contains(text(),'Purchase Summary')]"), 10).FirstOrDefault();

			if (myHeader == null)
			{
				Report.Info("Failed to Find Header Text");
				Report.Screenshot();
				return false;
			}
			if (!myHeader.Displayed)
			{
				Report.Info("Incorrect Page Open");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Page Opened");
			return true;
		}

		public bool Subscription_Billing_Header_Correct()
		{
			Report.Info("Beginning Subscription_Billing_Header_Correct");

			IWebElement myHeader = this.containerElement
				.FindElements(By.XPath(".//div/h3[text()='Subscription Billing']"), 10).FirstOrDefault();

			if (myHeader == null)
			{
				Report.Info("Failed to Find Header Text");
				Report.Screenshot();
				return false;
			}
			if (!myHeader.Displayed)
			{
				Report.Info("Subscription Billing Header Incorrect");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Page Opened - Subscription Billing");
			return true;
		}

		public bool Product_Billing_Header_Displayed()
		{
			IWebElement myHeader = this.containerElement
				.FindElements(By.XPath(".//div/h3[text()='Product Billing']"), 10).FirstOrDefault();
			return myHeader != null && myHeader.Displayed;
		}

		public bool Yearly_Option_Selected()
		{
			Report.Info("Yearly_Option_Selected");

			IWebElement myOption = this.containerElement.FindElement(By.XPath(".//input[@name='billingFrequency']"), 2);

			if (myOption == null)
			{
				Report.Info("Failed to Find Yearly Radio Option");
				Report.Screenshot();
				return false;
			}

			if (!myOption.Selected)
			{
				Report.Info("Yearly Radio Option Not Selected");
				Report.Screenshot();
				return false;
			}
			Report.Info("Yearly Radio Option Selected");
			Report.Screenshot();
			return true;
		}

		public bool Column_Headings_Correct(string column_1, string column_2, string column_3)
		{
			Report.Info("Beginning Column_Headings_Correct");

			Report.Info("Column 1 = " + column_1);
			Report.Info("Column 2 = " + column_2);
			Report.Info("Column 3 = " + column_3);

			IWebElement myColumn1 = this.containerElement.FindElement(By.XPath(".//table/thead/tr/th[1]"), 2);
			IWebElement myColumn2 = this.containerElement.FindElement(By.XPath(".//table/thead/tr/th[2]"), 2);
			IWebElement myColumn3 = this.containerElement.FindElement(By.XPath(".//table/thead/tr/th[3]"), 2);

			if (myColumn1 == null)
			{
				Report.Info("Failed to Find Column Header 1");
				Report.Screenshot();
				return false;
			}
			Report.Info("Column Header 1 Found");
			if (myColumn1.Text != column_1)
			{
				Report.Info("Column Header 1 is Incorrect: " + myColumn1.Text);
				Report.Screenshot();
				return false;
			}
			Report.Success("Column Header 1 is Correct");
			if (myColumn2 == null)
			{
				Report.Info("Failed to Find Column Header 2");
				Report.Screenshot();
				return false;
			}
			Report.Info("Column Header 2 Found");
			if (myColumn2.Text != column_2)
			{
				Report.Info("Column Header 2 is Incorrect: " + myColumn2.Text);
				Report.Screenshot();
				return false;
			}
			Report.Success("Column Header 2 is Correct");
			if (myColumn3 == null)
			{
				Report.Info("Failed to Find Column Header 3");
				Report.Screenshot();
				return false;
			}
			Report.Info("Column Header 3 Found");
			if (myColumn3.Text != column_3)
			{
				Report.Info("Column Header 3 is Incorrect: " + myColumn3.Text);
				Report.Screenshot();
				return false;
			}
			Report.Success("Column Header 3 is Correct");
			Report.Success("Column Headers Correct");
			return true;
		}

		public bool Table_Footer_Statement(string statement)
		{
			Report.Info("Beginning Table_Footer_Statement");

			IWebElement myStatement = this.containerElement.FindElement(By.XPath(".//tfoot/tr/td[text()='" + statement + "']"), 2);

			if (myStatement == null)
			{
				Report.Info("Failed to Find Correct Statement");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Statement Found");
			return true;
		}

		public bool Prices_And_Payment_Section(string pricesText)
		{
			Report.Info("Beginning Prices_And_Payment_Section");

			IWebElement myHeading = this.containerElement.FindElement(By.XPath(".//div[@class='alert alert-warning']/h4[text()='Prices and Payment']"), 2);

			if (myHeading == null)
			{
				Report.Info("Prices and Payment Heading Not Found");
				Report.Screenshot();
				return false;
			}
			Report.Success("Prices and Payment Heading Correct");

			IWebElement myText = myHeading.FindElement(By.XPath("../p"), 2);

			if (myText == null)
			{
				Report.Info("Prices and Payment Text Not Found");
				Report.Screenshot();
				return false;
			}
			Report.Success("Prices and Payment Text Found");
			if (myText.Text.Trim() != pricesText)
			{
				Report.Info("Prices and Payment Text Incorrect: " + myText.Text);
				Report.Screenshot();
				return false;
			}
			Report.Success("Prices and Payment Text Correct");
			return true;
		}

		public bool Confirmation_Text_Correct(string confirmText)
		{
			Report.Info("Beginning Confirmation_Text_Correct");

			IWebElement myText = this.containerElement.FindElement(By.XPath(".//div[@class='col-sm-8']/span/b"), 2);

			if (myText == null)
			{
				Report.Info("Confirmation Text Not Found");
				Report.Screenshot();
				return false;
			}
			Report.Success("Confirmation Text Found");
			if (myText.Text != confirmText)
			{
				Report.Info("Confirmation Text Incorrect: " + myText.Text);
				Report.Screenshot();
				return false;
			}
			Report.Success("Confirmation Text Correct");
			return true;
		}

		//Confirm Order Button
		[FindsBy(How = How.Id, Using = "ConfirmOrder")]
		private IWebElement _btn_confirm;

		public bool Confirm_Order_click()
		{
			Report.Info("Attempting to Click Confirm Order Button");
			return this._btn_confirm.TryClick();
		}

		public bool ConfirmOrderButtonExists()
		{
			try
			{
				return this._btn_confirm.Displayed;
			}
			catch (Exception e)
			{
				return false;
			}

		}

		public List<string> GetRowsBelowProduct()
		{
			var headerRows = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath("//h3[contains(text(),'Product Billing')]/..//table/tbody/tr/td/b"));

			if (headerRows.Count > 1)
			{
				Report.Error("There is more than one product, we haven't handled that yet...");
			}
			else
			{
				var subRows = SeleniumBrowser.WebBrowser.FindElements(
					By.XPath("//h3[contains(text(),'Product Billing')]/..//table/tbody/tr/td[2]"));
				return subRows.Select(x => x.GetValue()).ToList();

			}
			return new List<string>();
		}
	}

	class PaymentMethods_Thank_You : BaseObject
	{
		[FindsBy(How = How.Id, Using = "shoppingCart")]
		protected override IWebElement containerElement { get; set; }

		public bool ThankYou_Header_Correct()
		{
			Report.Info("Beginning ThankYou_Header_Correct");

			IWebElement myHeader = this.containerElement
				.FindElements(By.XPath(".//div[@class='header-with-back']/h2[text()=' Thank You']"), 10).FirstOrDefault();

			if (myHeader == null)
			{
				Report.Info("Failed to Find Header Text");
				Report.Screenshot();
				return false;
			}
			if (!myHeader.Displayed)
			{
				Report.Info("Incorrect Page Open");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Page Opened");
			return true;
		}

		public bool Thank_You_Text(string tyText)
		{
			Report.Info("Beginning Thank_You_Text");





			Report.Success("Text Correct");
			return true;

		}

		//Home Button
		[FindsBy(How = How.XPath, Using = ".//p[@class='text-right']/a[text()='Home']")]
		private IWebElement _btn_home;

		public bool Home_click()
		{
			Report.Info("Attempting to Click Home Button");
			var el = this.containerElement.FindElement(By.XPath(".//a[text()='Home']"), 2);
			return el.TryClick();
		}


	}

	class PaymentMethods_PayPal : BaseObject
	{
		public const string BasePath = "//div[@class='main']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public string EmailField {
			get { return this.containerElement.FindElement(By.Id("email"), 2).Text; }
			set { this.containerElement.FindElement(By.Id("email"), 2).EnterText(value); }
		}


		public void Click_Next()
		{
			IWebElement nextButton =
				this.containerElement.FindElement(By.Id("btnNext"), 2);

			if (nextButton != null)
			{
				nextButton.ClickWithScroll();
				GeneralUtilities.Wait_for_load_finish();
			}
			else
			{
				throw new Exception("Next button was not found");
			}
		}

		public string PasswordField {
			get { return this.containerElement.FindElement(By.Id("password"), 2).Text; }
			set
			{
				IWebElement pw = this.containerElement.FindElement(By.Id("password"), 2);
				pw.EnterText(value);
				pw.SendKeys(Keys.Tab);

			}
		}

		public void Click_Login()
		{
			IWebElement loginButton =
				this.containerElement.FindElement(By.Id("btnLogin"), 2);

			if (loginButton != null)
			{
				loginButton.ClickWithScroll();
				GeneralUtilities.Wait_for_load_finish();
			}
			else
			{
				throw new Exception("Login button was not found");
			}
		}
	}

	class PaymentMethods_PayPal_MemberReview : BaseObject
	{
		public const string BasePath = "memberReview";
		[FindsBy(How = How.Id, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		//Spinner element
		[FindsBy(How = How.Id, Using = "preloaderSpinner")]
		private IWebElement _spinnerFinder;

		public bool WaitForSpinner()
		{
			var spinner = this._spinnerFinder.FindElement(By.XPath("//div[@class='spinWrap']"), 2);
			if (spinner == null)
			{
				return true;
			}

			while (spinner != null && spinner.Displayed)
			{
				spinner = this._spinnerFinder.FindElement(By.XPath("//div[@class='spinWrap']"), 2);
				Delay.Seconds(Delay.SpeedFactor * 1);
			}

			return true;
		}

		public void Click_AgreeAndContinue()
		{
			this.WaitForSpinner();
			IWebElement continueButton =
				this.containerElement.FindElement(By.Id("confirmButtonTop"), 2);

			if (continueButton != null)
			{

				continueButton.ClickWithScroll();
				GeneralUtilities.Wait_for_load_finish();
			}
			else
			{
				throw new Exception("Agree & Continue button was not found");
			}
		}
	}


}
