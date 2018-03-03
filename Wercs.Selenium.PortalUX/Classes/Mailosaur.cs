using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Mailosaur;
using MailboxAPI = Mailosaur.MailboxApi;
using MailosaurBasicEmail = Mailosaur.Email;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;

namespace MySDS.SeleniumClasses
{
	public class Mailosaur
	{
		public bool Switch_Mailboxes(string mailboxName)
		{
			Report.Info("Beginning Switch_Mailboxes, to " + mailboxName);

			var myNav = new MailosaurNavigation();

			if (!myNav.Mailboxes_Click())
			{
				Report.Info("Failed to Click Mailboxes Link");
				Report.Screenshot();
				return false;
			}

			Delay.Seconds(1 * Delay.SpeedFactor);

			var myMail = new MailosaurMailboxes();

			if (!myMail.Go_To_Mailbox(mailboxName))
			{
				Report.Info("Failed to Navigate to Mailbox: " + mailboxName);
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(2 * Delay.SpeedFactor);
			Report.Success(mailboxName + " Opened");
			Report.Screenshot();
			return true;


		}


		public bool Mailosaur_Expected_Links(string order, string expectedProducts)
		{
			Report.Info("Beginning Gmail_Expected_Links");
			Report.Info("Searching in Order: " + order + " for Products(s): " + expectedProducts);

			var myInbox = new MailosaurInbox();


			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!myInbox.Open_Email(order))
			{
				Report.Info("Failed to Open Email: " + order);
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			var myEmail = new MailosaurEmail();
			Report.Info("Email Opened, Searching for Links");
			List<string> listOfProducts = expectedProducts.Split(',').ToList().Select(x => x.Trim()).ToList();
			foreach (string prod in listOfProducts)
			{
				if (!myEmail.Link_Sent(prod))
				{
					Report.Error("Link Does Not Exist");
					return false;
				}
				Delay.Seconds(2);
			}
			Report.Success("Link Exists");
			Report.Screenshot();
			return true;
		}


		public bool Delete_Email(string prefix)
		{
			Report.Info("Beginning Delete_Email");

			var myDelete = new MailosaurEmail();

			if (!myDelete.Delete_Exists())
			{
				var myInbox = new MailosaurInbox();

				if (!myInbox.Open_Email(prefix))
				{
					Report.Info("Failed to Open Email: " + prefix);
					Report.Screenshot();
					return false;
				}
				Report.Success("Email Open");
				Delay.Seconds(1 * Delay.SpeedFactor);
			}

			if (!myDelete.Delete_Click())
			{
				Report.Info("Failed to Click Delete Button");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(15 * Delay.SpeedFactor);
			var myConfirm = new MailosaurDeleteDlg();
			if (myConfirm.Exists)
			{
				if (!myConfirm.ConfirmDeleteClick())
				{
					Report.Info("Failed to Click Confirm");
					Report.Screenshot();
					return false;
				}
				Report.Info("Deletion Confirmed");
				Delay.Seconds(15 * Delay.SpeedFactor);
				var myInbox = new MailosaurInbox();

				if (myInbox.Email_Exists(prefix))
				{
					Report.Info("Failed to Delete Email");
					Report.Screenshot();
					return false;
				}
				Report.Success("Email Deleted");
				Report.Screenshot();
				return true;
			}
			Report.Info("Delete Dialog Failed to Open");
			Report.Screenshot();
			return false;
		}

		public bool Mail_Email_Delete(string prefix)
		{
			var myInbox = new MailosaurInbox();

			Report.Info("Beginning Mail_Email_Delete, for Email with Prefix:" + prefix);

			if (!myInbox.Open_Email(prefix))
			{
				Report.Error("Failed to Open Email with Prefix " + prefix);
				Report.Screenshot();
				return false;
			}
			if (!Delete_Email(prefix))
			{
				Report.Error("Failed to Delete Email with Prefix " + prefix + ", Failed to Click Delete Button");
				Report.Screenshot();
				return false;
			}
			Report.Success("Email with Prefix: " + prefix + " Deleted");
			Report.Screenshot();
			return true;

		}

		public bool Expected_Attachments_Exist(string order, string expectedProducts)
		{
			Report.Info("Beginning Expected_Attachments_Exist");
			Report.Info("Searching in Order: " + order + " for Products(s): " + expectedProducts);

			var myInbox = new MailosaurInbox();
			var myEmail = new MailosaurEmail();

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!myInbox.Open_Email(order))
			{
				Report.Info("Failed to Open Email: " + order);
				Report.Screenshot();
				return false;
			}
			Report.Info("Email Opened, Searching for Links");
			List<string> listOfProducts = expectedProducts.Split(',').ToList().Select(x => x.Trim()).ToList();
			foreach (string prod in listOfProducts)
			{
				if (!myEmail.Does_Attachment_Exist(prod))
				{
					Report.Error("Link Does Not Exist");
					return false;
				}
				Delay.Seconds(2);
			}
			Report.Success("Link Exists");
			Report.Screenshot();
			return true;
		}

		public bool Expected_Products(string order, string expectedProducts)
		{
			Report.Info("Beginning Expected_Products");
			Report.Info("Searching in Order: " + order + " for Products(s): " + expectedProducts);

			var myInbox = new MailosaurInbox();
			var myEmail = new MailosaurEmail();

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!myInbox.Open_Email(order))
			{
				Report.Info("Failed to Open Email: " + order);
				Report.Screenshot();
				return false;
			}
			Report.Info("Email Opened, Searching for Product in Body Text");
			List<string> listOfProducts = expectedProducts.Split(',').ToList().Select(x => x.Trim()).ToList();
			foreach (string prod in listOfProducts)
			{
				if (!myEmail.Correct_Product_Recieved(prod))
				{
					Report.Error("Correct Product Does Not Exist");
					return false;
				}
				Delay.Seconds(2);
			}
			Report.Success("Correct Product Exists");
			Report.Screenshot();
			return true;
		}



		public bool Save_PDF_As(string sdsName)
		{
			Report.Info("Beginning Save_PDF_As");
			Report.Info("Saving " + sdsName);

			var myEmail = new MailosaurEmail();
			var myPdf = new EmailPdf();

			if (!myEmail.Email_PDF_Open(sdsName))
			{
				Report.Info("Failed to Click Link");
				Report.Screenshot();
				return false;
			}
			if (!myPdf.Exists)
			{
				Report.Info("Failed to Open Link");
				Report.Screenshot();
				return false;
			}
			if (!myPdf.Click_Save_As())
			{
				Report.Info("Click_Save_Link Unsuccessful");
				Report.Screenshot();
				return false;
			}
			if (!myPdf.Close_PDF_Click())
			{
				Report.Info("Failed to Close PDF");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(2 * Delay.SpeedFactor);

			if (!myEmail.Exists)
			{
				Report.Info("Failed to Close PDF Window");
				Report.Screenshot();
				return false;
			}

			Report.Success("PDF (" + sdsName + ") Saved");
			Report.Screenshot();
			return true;
		}


	}

	public class MailosaurProg
	{
		public string GetMailboxFromEmail(string email, bool bReport = true)
		{
			if (bReport)
			{
				Report.Info("Beginning GetMailboxFromEmail: " + email);
			}

			string pattern = @"\..*@";

			var matches = Regex.Matches(email, pattern);

			string mailbox = matches[0].Value;
			mailbox = mailbox.Substring(1, mailbox.Length - 2);
			if (mailbox == "")
			{
				if (bReport)
				{
					Report.Error("Failed to Find Mailbox");
				}

				return "";
			}
			if (bReport)
			{
				Report.Success("Mailbox Found: " + mailbox);
			}

			return mailbox;
		}

		public List<Email> GetAllEmailsForEmailAddress(string email)
		{
			string mailbox = GetMailboxFromEmail(email, false);

			if (mailbox == "")
			{
				throw new Exception("Unable to Get Mailbox");
			}
			var myMailbox = new MailboxAPI(mailbox, "GgoERRCLiJFc1Ue");

			return myMailbox.GetEmailsByRecipient(email).ToList();
		}

		public bool HasEmailArrived(string emailTo, string emailFrom, string title)
		{
			List<Email> listOfEmails = GetAllEmailsForEmailAddress((emailTo));

			var matchingEmails = listOfEmails.Where(x => x.From[0].Address == emailFrom && x.Subject == title).ToList();

			if (matchingEmails.Count == 0)
			{
				Report.Info("There are no matching emails.");
				return false;
			}
			if (matchingEmails.Count == 1)
			{
				Report.Info("There is one matching email.");
				return true;
			}
			if (matchingEmails.Count > 1)
			{
				Report.Info("There are multiple matching emails. ");
				return true;
			}
			return false;
		}

		public Email GetMostRecentMatchingEmail(string emailTo, string emailFrom, string title)
		{

			List<Email> listOfEmails = GetAllEmailsForEmailAddress((emailTo));
			var mostRecentEmail = listOfEmails.OrderBy(x => x.CreationDate);

			List<Email> matching = listOfEmails.Where(x => x.From[0].Address == emailFrom).ToList();
			List<Email> matching2 = matching.Where(x => x.Subject == title).ToList();
			return matching2.OrderByDescending(x => x.CreationDate).FirstOrDefault();

		}

		public bool WaitForNewEmailToArrive(string email, int emailCountBefore = 0, int secondsToWait = 30)
		{
			Report.Info("Beginning Wait for new email to arrive. Email address: " + email + " Previous count: " + emailCountBefore.ToString());
			List<Email> listOfEmails = GetAllEmailsForEmailAddress(email);

			Report.Info("Found " + listOfEmails.Count.ToString() + " emails.");

			for (int i = 0; i < secondsToWait; i++)
			{
				if (listOfEmails.Count == emailCountBefore)
				{
					Delay.Seconds(1 * Delay.SpeedFactor);
					i++;
					listOfEmails = GetAllEmailsForEmailAddress(email);
				}
				else
				{
					if (listOfEmails.Count > emailCountBefore)
					{
						return true;
					}
					else
					{

					}
				}
			}
			return false;
		}

		public bool Check_Email_Has_Arrived(string prefix, string recipient)
		{
			Report.Info("Beginning Check_Email_Has_Arrived: " + prefix);

			string mailbox = GetMailboxFromEmail(recipient);

			if (mailbox == "")
			{
				Report.Error("Unable to Get Mailbox");
				return false;
			}

			var myMailbox = new MailboxAPI(mailbox, "GgoERRCLiJFc1Ue");

			var myEmails = myMailbox.GetEmailsByRecipient(recipient);

			while (myEmails.Length == 0)
			{
				for (int i = 0; i < 20; i++)
				{
					if (prefix == "My-SDS forgotten log on details")
					{
						Delay.Seconds(5 * Delay.SpeedFactor);
					}
					Report.Info("Attempt " + i);
					myEmails = myMailbox.GetEmailsByRecipient(recipient);
					if (myEmails.Length == 1)
					{
						Report.Success("Inbox Not Empty");
						break;
					}
					Report.Info("Inbox Empty");
					Delay.Seconds(0.5 * Delay.SpeedFactor);
				}
				if (myEmails.Length == 0)
				{
					Report.Info("Failed to Find Emails in Inbox");
					return false;
				}
			}
			Report.Info("Emails in Inbox - Searching for Email with Prefix : " + prefix);
			var myEmail = myEmails.FirstOrDefault(x => x.Subject == prefix);

			while (myEmail == null)
			{
				for (int i = 0; i < 20; i++)
				{
					if (prefix == "My-SDS forgotten log on details")
					{
						Delay.Seconds(5 * Delay.SpeedFactor);
					}
					Report.Info("Attempt " + i);
					myEmail = myEmails.FirstOrDefault(x => x.Subject == prefix);
					if (myEmail != null)
					{
						Report.Success("Email with Prefix: " + prefix + " Found");
						return true;
					}
					Report.Info("Email with Prefix: " + prefix + " NOT Found");
					Delay.Seconds(0.5 * Delay.SpeedFactor);
				}
				Report.Error("Failed to Find Email With Prefix: " + prefix);
				return false;
			}

			Report.Info("Email with Prefix: " + prefix + " is in Inbox");
			return true;
		}

		public bool Links_Recieved(string links, string prefix, string recipient)
		{
			Report.Info("Beginning Links_Recieved: " + links);

			string mailbox = GetMailboxFromEmail(recipient);

			if (mailbox == "")
			{
				Report.Error("Unable to Get Mailbox");
				return false;
			}

			var myMailbox = new MailboxAPI(mailbox, "GgoERRCLiJFc1Ue");

			var myEmails = myMailbox.GetEmailsByRecipient(recipient);
			Report.Info("Email Found");

			var myEmail = myEmails.FirstOrDefault(x => x.Subject == prefix);

			List<string> listOfProducts = links.Split(',').ToList().Select(x => x.Trim()).ToList();
			foreach (string prod in listOfProducts)
			{
				Report.Info("Link = " + prod);
				if (!myEmail.Html.Body.Contains(prod))
				{
					Report.Error(prod + " Does Not Exist");
					return false;
				}
				Report.Info(prod + " Exists");
				Delay.Seconds(0.25 * Delay.SpeedFactor);
			}
			Report.Success("Link(s) Exists");
			Report.Screenshot();
			return true;
		}

		public bool Delete_Email(string prefix, string recipient)
		{
			Report.Info("Beginning Delete_Email: " + prefix);

			string mailbox = GetMailboxFromEmail(recipient);

			if (mailbox == "")
			{
				Report.Error("Unable to Get Mailbox");
				return false;
			}

			var myMailbox = new MailboxAPI(mailbox, "GgoERRCLiJFc1Ue");

			var myEmails = myMailbox.GetEmailsByRecipient(recipient);
			Report.Info("Email Found");

			var myEmail = myEmails.FirstOrDefault(x => x.Subject == prefix);

			Report.Info("Attempting to Delete Email");
			if (myEmail != null)
			{
				myMailbox.DeleteEmail(myEmail.Id);
			}

			Delay.Seconds(5 * Delay.SpeedFactor);

			//if (Check_Email_Has_Arrived(prefix, recipient))
			//{
			//    Report.Info("Email NOT Deleted");
			//    return false;
			//}
			Report.Success("Email Deleted");
			return true;
		}


		public bool Client_Create_Link_Exists(string recipient, string prefix)
		{
			Report.Info("Client_Link_Exists");

			string mailbox = GetMailboxFromEmail(recipient);

			if (mailbox == "")
			{
				Report.Error("Unable to Get Mailbox");
				return false;
			}

			var myMailbox = new MailboxAPI(mailbox, "GgoERRCLiJFc1Ue");

			var myEmails = myMailbox.GetEmailsByRecipient(recipient);
			Report.Info("Email Found");

			var myEmail = myEmails.FirstOrDefault(x => x.Subject == prefix);

			if (myEmail != null)
			{
				Report.Info("Client Registration Email Found");

				var myLink = myEmail.Html.Links.ToList();

				foreach (var link in myLink)
				{
					Report.Info("Link = " + link);
					if (link.Href.Contains("ClientRegistration"))
					{
						Report.Info("Link Found");
						return true;
					}
					Report.Info("Incorrect Link: " + link);
					Delay.Seconds(0.25 * Delay.SpeedFactor);
				}
				Report.Info("Client Link Not Found");
				return false;
			}
			Report.Info("Email Not Found");
			return false;
		}






	}


	public class MailosaurLogIn : BaseObject
	{
		//Find Manage Company Form container by using Css Selector path.
		[FindsBy(How = How.XPath, Using = "//*[@id='mailosaur-content']/div/div[@class='login-wrapper']")]
		protected override IWebElement containerElement { get; set; }

		//Email Address
		[FindsBy(How = How.Id, Using = "email")]
		private IWebElement _emailaddressInput;

		public bool EnterEmailAddress(string emailAddress)
		{
			Report.Info("Entering Email Address: " + emailAddress);
			ExtensionMethods.EnterText(this._emailaddressInput, emailAddress);
			return true;
		}

		//Password
		[FindsBy(How = How.Id, Using = "password")]
		private IWebElement _passwordInput;

		public bool EnterPassword(string password)
		{
			Report.Info("Entering Password: " + password);
			ExtensionMethods.EnterText(this._passwordInput, password);
			return true;
		}

		//Log in Button
		[FindsBy(How = How.XPath, Using = ".//div/button[text()='Log in']")]
		private IWebElement _loginClick;

		public bool LogInClick()
		{
			Report.Info("Attempting to click Log In Button");
			this._loginClick.Click();
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			return true;
		}

		public bool Mailosaur_Do_Log_In(string email, string password)
		{
			Report.Info("Beginning Mailosaur_Log_In: " + email + " / " + password);

			Delay.Seconds(1 * Delay.SpeedFactor);

			if (!this.Exists)
			{
				Report.Info("Not on Mailosaur Log In Page");
				Report.Screenshot();
				return false;
			}
			if (!EnterEmailAddress(email))
			{
				Report.Info("Failed to Enter Email Address: " + email);
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(0.25 * Delay.SpeedFactor);
			if (!EnterPassword(password))
			{
				Report.Info("Failed to Enter Password: " + password);
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(0.25 * Delay.SpeedFactor);
			if (!LogInClick())
			{
				Report.Info("Failed to Click Log In Button");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(2.5 * Delay.SpeedFactor);

			var myMailbox = new MailosaurMailboxes();

			if (myMailbox.Exists)
			{
				Report.Success("Logged In");
				Report.Screenshot();
				return true;
			}
			Report.Info("Failed to Log In");
			Report.Screenshot();
			return false;
		}



	}

	public class MailosaurNavigation : BaseObject
	{
		//Find Manage Company Form container by using Css Selector path.
		[FindsBy(How = How.Id, Using = "ms-navbar")]
		protected override IWebElement containerElement { get; set; }

		public bool Log_Out(string accountName)
		{
			Report.Info("Beginning Log_Out");

			if (!this.Exists)
			{
				Report.Info("Navigation Bar Unavailable");
				Report.Screenshot();
				return false;
			}

			var myAccount = ExtensionMethods.FindElements(this.containerElement, By.XPath(".//ul/li/a[text()='" + accountName + " ']"), 10).FirstOrDefault();

			if (myAccount == null)
			{
				Report.Info("Failed to Find Account Name: " + myAccount);
				Report.Screenshot();
				return false;
			}
			Report.Success(accountName + " Account Found - Attempting to Click");

			ExtensionMethods.ClickWithScroll(myAccount);
			Delay.Seconds(0.5 * Delay.SpeedFactor);

			var myLogOut = ExtensionMethods.FindElements(this.containerElement, By.XPath(".//ul/li/a[text()='Log out']"), 10).FirstOrDefault();

			if (myLogOut == null)
			{
				Report.Info("Failed to Find Log Out Link");
				Report.Screenshot();
				return false;
			}
			Report.Success("Log Out Link Found - Attempting to Click");

			ExtensionMethods.ClickWithScroll(myLogOut);
			Delay.Seconds(2.5 * Delay.SpeedFactor);

			var myLogin = new MailosaurLogIn();

			if (myLogin.Exists)
			{
				Report.Success("Logged Out Successfully");
				Report.Screenshot();
				return true;
			}
			Report.Info("Failed to Log Out");
			Report.Screenshot();
			return false;

		}

		//Return to Mailboxes
		[FindsBy(How = How.XPath, Using = ".//li/a[text()='Mailboxes']")]
		private IWebElement _mailboxesClick;

		public bool Mailboxes_Click()
		{
			Report.Info("Attempting to click Mailboxes Link");
			this._mailboxesClick.Click();
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			return true;
		}


	}


	public class MailosaurMailboxes : BaseObject
	{
		//Find Manage Company Form container by using Css Selector path.
		[FindsBy(How = How.XPath, Using = "//*[@id='mailosaur-content']/div/div[@class='paper']")]
		protected override IWebElement containerElement { get; set; }

		//New mailbox
		[FindsBy(How = How.XPath, Using = ".//div[2]/a[text()='New mailbox']")]
		private IWebElement _newmailboxClick;

		public bool New_Mailbox_Click()
		{
			Report.Info("Attempting to click New Mailbox Button");
			this._newmailboxClick.Click();
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			return true;
		}

		public bool Go_To_Mailbox(string mailboxName)
		{
			Report.Info("Beginning Go_To_Mailbox: " + mailboxName);

			if (!this.Exists)
			{
				Report.Info("Not on Mailboxes Page");
				Report.Screenshot();
				return false;
			}

			var myMailbox = ExtensionMethods.FindElements(this.containerElement, By.XPath(".//div/a[text()='" + mailboxName + "']"), 10).FirstOrDefault();

			if (myMailbox == null)
			{
				Report.Info("Failed to Find Mailbox: " + mailboxName);
				Report.Screenshot();
				return false;
			}
			Report.Success(mailboxName + " Mailbox Found - Attempting to Click");

			ExtensionMethods.ClickWithScroll(myMailbox);
			Delay.Seconds(0.5 * Delay.SpeedFactor);

			var myInbox = new MailosaurInbox();

			if (myInbox.Exists)
			{
				Report.Success("Mailbox Open for " + mailboxName);
				Report.Screenshot();
				return true;
			}
			Report.Info("Failed to Open Mailbox for " + mailboxName);
			Report.Screenshot();
			return false;
		}


	}

	public class MailosaurInbox : BaseObject
	{
		//Find Manage Company Form container by using Css Selector path.
		[FindsBy(How = How.XPath, Using = "//div[@class='mailbox-viewer']")]
		protected override IWebElement containerElement { get; set; }

		public bool Email_Exists(string prefix)
		{
			Report.Info("Beginning Email_Exists for Prefix: " + prefix);

			if (this.Exists)
			{
				IWebElement tableInbox = this.containerElement.FindElement(By.XPath(".//div[@class='email-list']"));

				IWebElement rowEmail = ExtensionMethods.FindElements(tableInbox, By.XPath(".//div[@class='subject']"), 10).FirstOrDefault(p => ExtensionMethods.GetValue(p).Contains(prefix));

				if (rowEmail != null)
				{
					Report.Info("Email Found: " + prefix);
					Report.Screenshot();
					return true;
				}

				Report.Info("Email " + prefix + " not found");
				Report.Screenshot();
				return false;
			}
			Report.Info("Inbox Not Found");
			Report.Screenshot();
			return false;
		}

		public bool Open_Email(string prefix)
		{
			Report.Info("Beginning Open_Email with Prefix: " + prefix);

			if (this.Exists)
			{
				Delay.Seconds(2 * Delay.SpeedFactor);

				IWebElement tableInbox = this.containerElement.FindElement(By.XPath(".//div[@class='email-list']"));

				IWebElement rowEmail = ExtensionMethods.FindElements(tableInbox, By.XPath(".//div[@class='subject']"), 10).FirstOrDefault(p => ExtensionMethods.GetValue(p).Contains(prefix));

				if (rowEmail != null)
				{
					Report.Info("Email Found: " + prefix);
					Report.Screenshot();
					rowEmail.Click();
					Delay.Seconds(2 * Delay.SpeedFactor);
					Report.Success("Email Opened");
					Report.Screenshot();
					return true;
				}

				Report.Info("Email " + prefix + " not found");
				Report.Screenshot();
				return false;


			}
			Report.Info("Email " + prefix + " not found: Email Not in Inbox");
			Report.Screenshot();
			return false;
		}

		public bool Delete_All_Emails()
		{
			Report.Info("Beginning Delete_All_Emails");

			if (!DeleteAllClick())
			{
				Report.Info("Failed to Click Empty Inbox Button");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(1 * Delay.SpeedFactor);
			var myConfirm = new MailosaurDeleteDlg();
			if (myConfirm.Exists)
			{
				if (!myConfirm.ConfirmEmptyClick())
				{
					Report.Info("Failed to Click Confirm Empty Mailbox");
					Report.Screenshot();
					return false;
				}
				Delay.Seconds(5 * Delay.SpeedFactor);
				Report.Info("Deletion Confirmed");
				Report.Screenshot();
				return true;
			}
			Report.Info("Delete Dialog Failed to Open");
			Report.Screenshot();
			return false;
		}

		//Delete Button
		[FindsBy(How = How.XPath, Using = ".//button[@class='js-empty btn btn-link btn-viewer']/i")]
		private IWebElement _deleteAllClick;

		public bool DeleteAllClick()
		{
			Report.Info("Attempting to click Empty Inbox Button");
			this._deleteAllClick.Click();
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			return true;
		}

		public bool Email_Does_Not_Exist(string order)
		{
			Report.Info("Beginning Email_Does_Not_Exist");
			Report.Info("Delay of 2 Seconds");
			Delay.Seconds(2 * Delay.SpeedFactor);

			Report.Info("Checking That Email with Prefix: " + order + " Does Not Exist");

			IWebElement rowEmail = ExtensionMethods.FindElements(this.containerElement, By.XPath(".//div[@class='subject']"), 10).FirstOrDefault(p => ExtensionMethods.GetValue(p).Contains(order));

			Delay.Seconds(1.5 * Delay.SpeedFactor);
			if (rowEmail == null)
			{
				Report.Success("Email: " + order + " Does Not Exist");
				Report.Screenshot();
				Delay.Seconds(3);
				return true;
			}
			Report.Info("Email " + order + " Exists When Shouldn't");
			Report.Screenshot();
			return false;

		}

	}

	public class MailosaurEmail : BaseObject
	{
		//Find Manage Company Form container by using Css Selector path.
		[FindsBy(How = How.XPath, Using = "//div[@class='workspace-inner']")]
		protected override IWebElement containerElement { get; set; }

		//Delete Button
		[FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-link js-delete']/i")]
		private IWebElement _deleteClick;

		public bool Delete_Click()
		{
			Report.Info("Attempting to click Delete Button");
			this._deleteClick.Click();
			return true;
		}

		public bool Mailosaur_Delete()
		{
			Report.Info("Attempting to click Delete Button");
			this._deleteClick.Click();
			Delay.Seconds(6 * Delay.SpeedFactor);
			var myConfirm = new MailosaurDeleteDlg();
			if (myConfirm.Exists)
			{
				if (!myConfirm.ConfirmDeleteClick())
				{
					Report.Info("Failed to Click Confirm");
					Report.Screenshot();
					return false;
				}

				Delay.Seconds(10 * Delay.SpeedFactor);

				Report.Success("Email Deleted");
				Report.Screenshot();
				return true;
			}
			Report.Info("Delete Dialog Failed to Open");
			Report.Screenshot();
			return false;
		}

		//Links Tab
		[FindsBy(How = How.XPath, Using = ".//div[@class='email-actions']/ul/li[@data-tab='links']")]
		private IWebElement _linksClick;

		public bool Links_Click()
		{
			Report.Info("Attempting to click Links Tab");
			this._linksClick.Click();
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			return true;
		}

		public bool Delete_Exists()
		{
			Report.Info("Beginning Delete_Exists");

			IWebElement fLink = ExtensionMethods.FindElements(this.containerElement, By.XPath(".//button[@class='btn btn-link js-delete']/i"), 10).FirstOrDefault();

			if (fLink == null)
			{
				Report.Error("Delete Button Does Not Exist");
				return false;
			}
			Report.Success("Delete Button Exists");
			Report.Screenshot();
			return true;
		}

		public bool Link_Sent(string link)
		{
			Report.Info("Beginning Link_Sent");

			IWebElement fLink = this.containerElement.FindElement(By.XPath(".//div/div[@class='email-content clearfix']/a[contains(text(), '" + link + "')]"));

			if (fLink == null)
			{
				Report.Error("Failed to Find Link");
				return false;
			}
			Report.Success("Link: " + link + " Exists");
			Report.Screenshot();
			return true;

		}

		public bool Does_Attachment_Exist(string sds)
		{
			Report.Info("Beginning Does_Attachment_Exist");

			IWebElement fLink = this.containerElement.FindElement(By.XPath(".//div/div[@class='email-content clearfix']/a[contains(text(), '" + sds + "')]"));

			if (fLink == null)
			{
				Report.Error("Failed to Find Link");
				return false;
			}
			Report.Success("Attachment: " + sds + " Exists");
			Report.Screenshot();
			return true;

		}

		public bool Correct_Product_Recieved(string product)
		{
			Report.Info("Beginning Correct_Product_Recieved");
			Report.Info("Checking for " + product);

			IWebElement fLink = this.containerElement.FindElement(By.XPath(".//div/div[@class='email-content clearfix']/a[contains(text(), '" + product + "')]"));

			if (fLink == null)
			{
				Report.Error("Failed to Find Link");
				return false;
			}
			Report.Success("Product: " + product + " Recieved");
			Report.Screenshot();
			return true;
		}

		public bool Email_Forgot_Password_Link(int millisecondsDelay = 60000)
		{
			Report.Info("Beginning Email_Forgot_Password_Link");

			IWebElement fLink = ExtensionMethods.FindElements(this.containerElement, By.XPath(".//div/div[@class='email-content clearfix']/a[contains(@href, 'ResetPassword.aspx')]"), 10).FirstOrDefault();

			Delay.Seconds(0.5 * Delay.SpeedFactor);
			if (fLink == null)
			{
				if (!Links_Click())
				{
					Report.Info("Failed to Navigate to Links Page");
					Report.Screenshot();
					return false;
				}
				Delay.Seconds(2 * Delay.SpeedFactor);
				IWebElement myForgot = ExtensionMethods.FindElements(this.containerElement, By.XPath(".//td/a[contains(@href, 'ResetPassword.aspx')]"), 10).FirstOrDefault();
				if (myForgot == null)
				{
					Report.Error("Failed to find Reset Password Link");
					Report.Screenshot();
					return false;
				}
				Report.Info("Link Found - Attempting to Click");
				myForgot.Click();
				Report.Success("Clicked Reset Password Link");
				Report.Screenshot();
				return true;
			}
			Report.Info("Link Found - Attempting to Click");
			fLink.Click();
			Report.Success("Clicked Reset Password Link");
			Report.Screenshot();
			return true;

		}

		public bool Mailosaur_SDS_Link(string sdsName)
		{
			Report.Info("Beginning Mailosaur_SDS_Link");

			IWebElement fLink = this.containerElement.FindElement(By.XPath(".//div/div[@class='email-content clearfix']/a[text()= '" + sdsName + "']"));

			Delay.Seconds(2 * Delay.SpeedFactor);
			if (fLink == null)
			{
				Report.Error("Failed to Find Link");
				Report.Screenshot();
				return false;
			}
			else
			{
				Report.Info("Link Found - Attempting to Click");
				fLink.Click();
				Report.Success("Clicked Link");
				Report.Screenshot();
				return true;
			}
		}

		public bool Email_PDF_Open(string sdsName)
		{
			Report.Info("Beginning Email_PDF_Open");

			IWebElement fLink = this.containerElement.FindElement(By.XPath(".//div/div[@class='email-content clearfix']/a[@role= 'link']"));

			Delay.Seconds(1);
			if (fLink == null)
			{
				Report.Error("Failed to Find Link");
				Report.Screenshot();
				return false;
			}
			else
			{
				Report.Info("Link Found - Attempting to Click");
				fLink.Click();
				Report.Success("Clicked Link");
				Report.Screenshot();
				return true;
			}
		}

		public bool Email_Body_Text(string bodytext, int millisecondsDelay = 6000)
		{
			Report.Info("Beginning Email_Body_Text");

			IWebElement fLink = this.containerElement.FindElement(By.XPath(".//div/div[@class='email-content clearfix'][contains(text(), '" + bodytext + "')]"));

			Delay.Seconds(15);
			if (fLink == null)
			{
				Report.Error("Failed to Find Body Text");
				Report.Screenshot();
				return false;
			}
			Report.Success("Body Text: " + bodytext + " is Equal to: " + fLink);
			Report.Screenshot();
			return true;
		}

		//Download All Button
		[FindsBy(How = How.XPath, Using = "/.//div[@aria-label='Download all attachments']")]
		private IWebElement _downloadAllClick;

		public bool Download_All_Click()
		{
			Report.Info("Attempting to click Download All Button");
			this._downloadAllClick.Click();
			return true;
		}

		public bool Download_Attachments(string expectedFile = "orderlogs.zip")
		{
			Report.Info("Downloading attachments");


			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads") + "\\" + expectedFile;

			if (File.Exists(path))
			{
				try
				{
					File.Delete(path);
				}
				catch
				{
					Report.Info("File deletion " + path + " error");
					Report.Screenshot();
					return false;
				}
			}
			if (!Download_All_Click())
			{
				Report.Error("Failed to download attachments");
				Report.Screenshot();
				return false;
			}
			Report.Info("Download All Button Clicked");
			Report.Screenshot();
			Delay.Seconds(3 * Delay.SpeedFactor);
			Report.Info("Looking for " + path);
			if (!File.Exists(path))
			{
				Report.Info("Failed to download attachments - items do not exist");
				Report.Screenshot();
				return false;
			}
			if (!Mailosaur_Delete())
			{
				Report.Error("Failed to delete email");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(2 * Delay.SpeedFactor);
			Report.Success("Downloaded attachments");
			return true;

		}


		public bool Client_Create_Link_Exists()
		{
			Report.Info("Beginning Client_Create_Link_Exists");

			IWebElement fLink =
				ExtensionMethods.FindElements(this.containerElement, By.XPath(".//div/div[@class='email-content clearfix']/a"), 10).FirstOrDefault(p => ExtensionMethods.GetValue(p).Contains("Simply click this link to create"));

			Delay.Seconds(2 * Delay.SpeedFactor);
			if (fLink == null)
			{
				Report.Info("Failed to find Client Login Link");
				return false;
			}

			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Success("Client Login Link Exists");
			Report.Screenshot();
			return true;
		}

		public bool Client_Create_Link()
		{
			Report.Info("Beginning Client_Create_Link");

			IWebElement fLink =
				ExtensionMethods.FindElements(this.containerElement, By.XPath(".//div/div[@class='email-content clearfix']/a"), 10).FirstOrDefault(p => ExtensionMethods.GetValue(p).Contains("link"));

			Delay.Seconds(1 * Delay.SpeedFactor);
			if (fLink == null)
			{
				Report.Error("Failed to find Client Create Link");
				Report.Screenshot();
				return false;
			}
			Report.Info("Link Found - Attempting to Click");
			fLink.Click();
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Success("Clicked Client Create Link");
			Report.Screenshot();
			return true;

		}

		public bool Client_Login_Link()
		{
			Report.Info("Beginning Client_Login_Link");

			IWebElement fLink =
				ExtensionMethods.FindElements(this.containerElement, By.XPath(".//div/div[@class='email-content clearfix']/a"), 10).FirstOrDefault(p => ExtensionMethods.GetValue(p).Contains("Here"));

			Delay.Seconds(5 * Delay.SpeedFactor);
			if (fLink == null)
			{
				Report.Error("Failed to find Client Login Link");
				Report.Screenshot();
				return false;
			}
			Report.Info("Link Found - Attempting to Click");
			fLink.Click();
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Success("Clicked Client Login Link");
			Report.Screenshot();
			return true;

		}

		public bool Email_Reset_Password_Link()
		{
			Report.Info("Beginning Email_Reset_Password_Link");

			IWebElement fLink = ExtensionMethods.FindElements(this.containerElement, By.XPath(".//div/div[@class='email-content clearfix']/a[contains(@href, 'RecipientPasswordReset')]"), 10).FirstOrDefault();

			Delay.Seconds(0.5 * Delay.SpeedFactor);
			if (fLink == null)
			{
				if (!Links_Click())
				{
					Report.Info("Failed to Navigate to Links Page");
					Report.Screenshot();
					return false;
				}
				Delay.Seconds(2 * Delay.SpeedFactor);
				Report.Info("On Links Page");
				IWebElement myReset = ExtensionMethods.FindElements(this.containerElement, By.XPath(".//td/a[contains(@href, 'RecipientPasswordReset')]"), 10).FirstOrDefault();

				if (myReset == null)
				{
					Report.Error("Failed to find Reset Link");
					Report.Screenshot();
					return false;
				}
				Report.Info("Link Found - Attempting to Click");
				myReset.Click();
				Report.Success("Clicked Reset Link");
				Report.Screenshot();
				return true;
			}
			Report.Info("Link Found - Attempting to Click");
			fLink.Click();
			Report.Success("Clicked Reset Link");
			Report.Screenshot();
			return true;

		}


	}

	public class MailosaurDeleteDlg : BaseObject
	{
		//Find Manage Company Form container by using Css Selector path.
		[FindsBy(How = How.XPath, Using = "//div[@class='modal-content']")]
		protected override IWebElement containerElement { get; set; }

		//Confirm Delete Button
		[FindsBy(How = How.XPath, Using = ".//div/button[text()='Yes, delete it']")]
		private IWebElement _confirmClick;

		public bool ConfirmDeleteClick()
		{
			Report.Info("Attempting to click Confirm Delete Button");
			this._confirmClick.Click();
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			return true;
		}

		//Confirm Empty Button
		[FindsBy(How = How.XPath, Using = ".//div/button[text()='Yes, empty it']")]
		private IWebElement _emptyClick;

		public bool ConfirmEmptyClick()
		{
			Report.Info("Attempting to click Confirm Empty Button");
			this._emptyClick.Click();
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			return true;
		}

		//Cancel Delete Button
		[FindsBy(How = How.XPath, Using = ".//div[@class='modal-footer']div/button[text()='Cancel']")]
		private IWebElement _cancelClick;

		public bool CancelDeleteClick()
		{
			Report.Info("Attempting to click Cancel Delete Button");
			this._cancelClick.Click();
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			return true;
		}





	}

	public class EmailLink : BaseObject
	{
		public const string BasePath = ".//embed[@id='plugin']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		[FindsBy(How = How.XPath, Using = ".//embed[@id='plugin']")]
		private IWebElement Plugin { get; set; }



		public void Save_As()
		{
			ExtensionMethods.SaveAs(this.Plugin);
		}

		public bool Click_Save_As()
		{
			Report.Info("Beginning Click_Save_As");

			Save_As();

			Report.Success("Save As Clicked Successfully");
			return true;
		}

	}

	public class EmailPdf : BaseObject
	{
		public const string BasePath = "//div[@class='aLF-aPX-aPF aLF-aPX-bhI']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		[FindsBy(How = How.XPath, Using = "//div[@class='aLF-aPX-aPF aLF-aPX-bhI']")]
		private IWebElement Plugin { get; set; }

		public void Save_As()
		{
			ExtensionMethods.SaveAs(this.Plugin);
		}

		public bool Click_Save_As()
		{
			Report.Info("Beginning Click_Save_As");

			Save_As();

			Report.Success("Save As Clicked Successfully");
			Report.Screenshot();
			return true;
		}

		//Back Button
		[FindsBy(How = How.CssSelector, Using = ".//div[@aria-label='Close']")]
		private IWebElement _closePdfClick;

		public bool Close_PDF_Click()
		{
			Report.Info("Attempting to Close PDF");
			this._closePdfClick.Click();
			return true;
		}

	}

}
