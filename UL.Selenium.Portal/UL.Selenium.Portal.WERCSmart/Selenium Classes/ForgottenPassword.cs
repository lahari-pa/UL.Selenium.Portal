using System;
using System.Collections.Generic;
using System.Linq;
using Mailosaur;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NTTQA.Selenium.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ForgottenPassword : BaseObject
	{
		public const string BasePath = "//div[@class='login-wrapper']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		/// <summary>
		/// Gets the Continue button
		/// </summary>
		public void Click_Continue()
		{
			var btn = this.containerElement.FindElement(By.XPath(".//a[@id='carouselContinue']"), 2);
			btn.Click();
		}

		/// <summary>
		/// Gets the cancel button on the forgot password page
		/// </summary>
		public void Click_Cancel()
		{
			var btn = this.containerElement.FindElement(By.XPath(".//a[@id='carouselCancel']"), 2);
			btn.Click();
		}

		public void Enter_Email(string email)
		{
			int count = 0;
			while (count < 10)
			{
				try
				{
					this.containerElement.FindElement(By.XPath("//input[@id='forgotEmail']"), 2).EnterText(email);
					return;
				}
				catch (Exception)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					count++;
				}

				throw new Exception("Could not enter email!");
			}

		}

		public bool Login_Button_Exists()
		{
			return this.containerElement.FindElement(By.XPath("//a[@id='btnLogin']"), 2).Displayed;
		}

		///<summary>
		/// Clicking the login button that is found on the forget password screen (after you enter email)
		///</summary>
		public void Click_Login_Button()
		{
			this.containerElement.FindElement(By.XPath("//a[@id='btnLogin']"), 2).Click();
		}

		public List<string> GetErrors()
		{
			try
			{
				return this.containerElement.FindElements(By.XPath("//p[@id='email_error']/span"), 2).Select(x => x.GetValue().Trim()).ToList();
			}
			catch (Exception)
			{
				return new List<string>();
			}


		}

		///<summary>
		/// this is for the success message when a user submits a valid email
		///</summary>
		public string ForgotPasswordSuccessMessage()
		{
			var text = this.containerElement.FindElement(By.XPath("//*[@id='wizardCarousel']/div[1]/div[2]/p"), 2).GetValue();
			int i = 0;
			while (text == "" && i < 10)
			{
				text = this.containerElement.FindElement(By.XPath("//*[@id='wizardCarousel']/div[1]/div[2]/p"), 2).GetValue();
				i++;
				Delay.Seconds(1);
			}
			return text;
		}

		public bool Reset_Password_Link(Link myLink)
		{
			Report.Info("Beginning Reset_Password_Link");

			Report.Info("Link = " + myLink);
			if (myLink.Href.Contains("ResetPassword"))
			{
				Report.Info("Link Found");
				SeleniumBrowser.Navigate(myLink.Href);
				return true;
			}
			Report.Info(myLink.Href + " Not Found");
			return false;
		}


	}

	class ForgottenPasswordQuestions : BaseObject
	{
		public const string BasePath = "//div[@class='login-wrapper register']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		private IWebElement QuestionOne => this.containerElement.FindElement(By.Id("secQuestion1"),1);

		public bool Enter_Answer_One(string answerText)
		{
			Report.Info("Entering Answer One: " + answerText);
			this.QuestionOne.EnterText(answerText);
			return true;
		}

		//Question 2
		[FindsBy(How = How.Id, Using = "secQuestion2")]
		private IWebElement _txtQuestionTwo;

		public bool Enter_Answer_Two(string answerText)
		{
			Report.Info("Entering Answer One: " + answerText);
			this._txtQuestionTwo.EnterText(answerText);
			return true;
		}

		//Cancel Button
		[FindsBy(How = How.Id, Using = "carouselContinue")]
		private IWebElement _btnCancel;

		public bool Cancel_click()
		{
			Report.Info("Attempting to Click Cancel Button");
			return this._btnCancel.TryClick();
		}

		//Continue Button
		[FindsBy(How = How.Id, Using = "carouselContinue")]
		private IWebElement _btnContinue;

		public bool Continue_click()
		{
			Report.Info("Attempting to Click Continue Button");
			return this._btnContinue.TryClick();
		}

		public bool Forgot_Password_Questions(string savedAs)
		{
			Report.Info("Beginning Forgot_Password_Questions");
			if (!this.Exists)
			{
				Report.Info("Not on Questions Page");
				Report.Screenshot();
				return false;
			}
			var user = (WERCSmartUser)Context.GetFromContext(savedAs);
			GeneralUtilities.Wait_for_load_finish();
			Delay.Seconds(5);
			IWebElement questionOne = this.containerElement.FindElement(By.XPath(".//label[@for='secQuestion1']"));
			IWebElement questionTwo = this.containerElement.FindElement(By.XPath(".//label[@for='secQuestion2']"));
			switch (questionOne.Text)
			{
				case "What was your phone number when you were 15 years old?":
					if (!this.Enter_Answer_One(user.PhoneQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.PhoneQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				case "What is the first name of your mentor when you were younger":
					if (!this.Enter_Answer_One(user.MentorQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.MentorQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				case "What was your childhood friend's nickname?":
					if (!this.Enter_Answer_One(user.FriendQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.FriendQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				case "What was your first stuffed animal?":
					if (!this.Enter_Answer_One(user.AnimalQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.AnimalQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				case "What college did you want to attend, but didn't?":
					if (!this.Enter_Answer_One(user.CollegeQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.CollegeQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				default:
					Report.Error("Unable to Find Correct Question");
					return false;
			}
			Report.Info("Answer One Entered");
			switch (questionTwo.Text)
			{
				case "What was your phone number when you were 15 years old?":
					if (!this.Enter_Answer_Two(user.PhoneQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.PhoneQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				case "What is the first name of your mentor when you were younger":
					if (!this.Enter_Answer_Two(user.MentorQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.MentorQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				case "What was your childhood friend's nickname?":
					if (!this.Enter_Answer_Two(user.FriendQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.FriendQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				case "What was your first stuffed animal?":
					if (!this.Enter_Answer_Two(user.AnimalQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.AnimalQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				case "What college did you want to attend, but didn't?":
					if (!this.Enter_Answer_Two(user.CollegeQuestion))
					{
						Report.Info("Failed to Enter Answer One: " + user.CollegeQuestion);
						Report.Screenshot();
						return false;
					}
					break;
				default:
					Report.Error("Unable to Find Correct Question");
					return false;
			}
			Report.Info("Answer Two Entered");
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Info("Answers Entered");
			Report.Screenshot();
			if (!this.Continue_click())
			{
				Report.Info("Failed to Click Continue");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Success("Secutiry Questions Answered");
			return true;
		}

		//New Password
		[FindsBy(How = How.Id, Using = "newPassword")]
		private IWebElement _txtNewPw;

		public bool Enter_New_Password(string newPw)
		{
			Report.Info("Entering New Password: " + newPw);
			this._txtNewPw.EnterText(newPw);
			return true;
		}

		//Verify Password
		[FindsBy(How = How.Id, Using = "verifyPassword")]
		private IWebElement _txtVerifyPw;

		public bool Enter_Verify_Password(string verifyPw)
		{
			Report.Info("Entering Verify Password: " + verifyPw);
			this._txtVerifyPw.EnterText(verifyPw);
			return true;
		}

		public bool New_Password_Form(string newPassword, string verifyPw)
		{
			Report.Info("Beginning New_Password_Form: " + newPassword + " / " + verifyPw);

			if (!this.Enter_New_Password(newPassword))
			{
				Report.Info("Failed to Enter New Password: " + newPassword);
				Report.Screenshot();
				return false;
			}
			if (!this.Enter_Verify_Password(verifyPw))
			{
				Report.Info("Failed to Enter Verify Password: " + verifyPw);
				Report.Screenshot();
				return false;
			}
			Report.Info("Passwords Entered");
			Report.Screenshot();
			if (!this.Continue_click())
			{
				Report.Info("Failed to Click Continue Button");
				Report.Screenshot();
				return false;
			}
			Report.Success("New Password Entered Successfully");
			return true;
		}

		//Login Button
		[FindsBy(How = How.Id, Using = "btnLogin")]
		private IWebElement _btnLogin;

		public bool Login_click()
		{
			Report.Info("Attempting to Click Login Button");
			return this._btnLogin.TryClick() && GeneralUtilities.Wait_for_load_finish();
		}


	}
}
