using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Classes;
using Global = SeleniumUtilities.Global;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class SubscriptionEnrollment : BaseDialog
	{
		[FindsBy(How = How.Id, Using = "enrollment")]
		protected override IWebElement containerElement { get; set; }

		//======================================================================================================== RANGE OF PRODUCTS, ARTICLES AND ENHANCE ARTICLES

		//Articles
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Articles ']/../select")]
		private IWebElement _selectArticles;

		public bool Select_Articles(string articles)
		{
			Report.Info("Selecting Number of Articles: " + articles);
			_selectArticles.Select(articles);
			return true;
		}

		//Enhanced Articles
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Enhanced Articles ']/../select")]
		private IWebElement _selectEnArticles;

		public bool Select_Enhanced_Articles(string enArticles)
		{
			Report.Info("Selecting Number of Enhanced Articles: " + enArticles);
			_selectEnArticles.Select(enArticles);
			return true;
		}

		//Formulated Products
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Formulated Products ']/../select")]
		private IWebElement _selectFormProds;

		public bool Select_Formulated_Products(string formProds)
		{
			Report.Info("Selecting Number of Formulated Products: " + formProds);
			_selectFormProds.Select(formProds);
			return true;
		}

		public bool Select_Range(string articles, string enArticles, string formProds)
		{
			Report.Info("Beginning Select_Range");

			if (!Exists)
			{
				Report.Info("Not on Subscription Enrollment Page");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			if (!Select_Articles(articles))
			{
				Report.Info("Failed to Select Correct Number of Articles: " + articles);
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			Report.Info("Number of Articles Selected");
			if (!Select_Enhanced_Articles(enArticles))
			{
				Report.Info("Failed to Select Correct Number of Enhanced Articles: " + enArticles);
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			Report.Info("Number of Enhanced Articles Selected");
			if (!Select_Formulated_Products(formProds))
			{
				Report.Info("Failed to Select Correct Number of Formulated Products: " + formProds);
				Report.Screenshot();
				return false;
			}
			Report.Info("Number of Formulated Products Selected");
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			Report.Success("Range of Products, Articles and Enhanced Articles Selected");
			return true;
		}

		//======================================================================================================== FEATURE PLAN


		public IWebElement Get_Feature_Plan(string feature_plan)
		{
			Report.Info("Beginning Get_Feature_Plan: " + feature_plan);

			List<IWebElement> allProducts = containerElement.FindElements(By.XPath(".//div[@class='col-sm-3']/div/div/label")).ToList();

			foreach (var feature in allProducts)
			{
				string featureNew = feature.Text;
				string featureTrimmed = Regex.Replace(featureNew, @"\r\n.*", "").Trim();

				if (feature_plan == "Standard")
				{
					string featureStandard = Regex.Replace(featureNew, @"\r\nBEST VALUE\r\n.*", "").Trim();

					Report.Info("Feature Plan = " + featureStandard);

					if (featureStandard == feature_plan)
					{
						Report.Success("Feature Plan Found");
						return feature;
					}
				}

				Report.Info("Feature Plan = " + featureTrimmed);

				if (featureTrimmed == feature_plan)
				{
					Report.Success("Feature Plan Found");
					return feature;
				}
				Report.Info("Feature Plan Doesn't Match");
			}
			Report.Info("Failed to Find Feature Plan");
			return null;

		}

		public bool Select_Feature_Plan(string featurePlan)
		{
			Report.Info("Beginning Select_Feature_Plan: " + featurePlan);

			if (!Exists)
			{
				Report.Info("Not on Subscription Enrollment Page");
				Report.Screenshot();
				return false;
			}

			IWebElement myFeature = null;

			switch (featurePlan)
			{
				case "Premium":
					myFeature = Get_Feature_Plan("Premium");
					if (myFeature == null)
					{
						Report.Info("Failed to Find Premium Feature Plan");
						Report.Screenshot();
						return false;
					}

					myFeature.Click();
					Report.Success("Premium Feature Plan Selected");
					break;
				case "Standard":
					myFeature = Get_Feature_Plan("Standard");
					if (myFeature == null)
					{
						Report.Info("Failed to Find Standard Feature Plan");
						Report.Screenshot();
						return false;
					}
					myFeature.Click();
					Report.Success("Standard Feature Plan Selected");
					break;
				case "Limited Plus":
					myFeature = Get_Feature_Plan("Limited Plus");
					if (myFeature == null)
					{
						Report.Info("Failed to Find Limited Plus Feature Plan");
						Report.Screenshot();
						return false;
					}
					myFeature.Click();
					Report.Success("Limited Plus Feature Plan Selected");
					break;
				case "Limited":
					myFeature = Get_Feature_Plan("Limited");
					if (myFeature == null)
					{
						Report.Info("Failed to Find Limited Feature Plan");
						Report.Screenshot();
						return false;
					}
					myFeature.Click();
					Report.Success("Limited Feature Plan Selected");
					break;
				default:
					Report.Error("Unable to Find Correct Feature Plan");
					return false;
			}
			Report.Success("Feature Plan Selected");
			Report.Screenshot();
			return true;
		}

		//==================================================================================================== SUPPORT SERVICE PLAN

		//Gold
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading gold']/label")]
		private IWebElement _selectGold;
		public bool Gold_click()
		{
			Report.Info("Attempting to Select Gold Support Services Plan");
			_selectGold.Click();
			return true;
		}

		//Silver
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading silver']/label")]
		private IWebElement _selectSilver;
		public bool Silver_click()
		{
			Report.Info("Attempting to Select Silver Support Services Plan");
			_selectSilver.Click();
			return true;
		}

		//Bronze
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading bronze']/label")]
		private IWebElement _selectBronze;
		public bool Bronze_click()
		{
			Report.Info("Attempting to Select Bronze Support Services Plan");
			_selectBronze.Click();
			return true;
		}

		public IWebElement Get_General_Support_Plan()
		{
			Report.Info("Beginning Get_General_Support_Plan");

			List<IWebElement> allProducts = containerElement.FindElements(By.XPath(".//div[@class='col-sm-4']/div/div/label")).ToList();

			foreach (var feature in allProducts)
			{
				string featureNew = feature.Text;
				string featureTrimmed = Regex.Replace(featureNew, @"\r\n.*", "").Trim();

				Report.Info("Feature Plan = " + featureTrimmed);

				if (featureTrimmed == "General Support")
				{
					Report.Success("General Support Services Plan Found");
					return feature;
				}
				Report.Info("General Support Services Plan Doesn't Match");
			}
			Report.Info("Failed to Find General Support Services Plan");
			return null;
		}

		public bool General_Support_click()
		{
			IWebElement _selectGenSupport = Get_General_Support_Plan();
			if (_selectGenSupport == null)
			{
				return false;
			}
			Report.Info("Attempting to Select General Support Services Plan");
			_selectGenSupport.Click();
			return true;
		}

		public bool Select_Support_Services_Plan(string servicesPlan)
		{
			Report.Info("Beginning Select_Support_Services_Plan: " + servicesPlan);

			if (!Exists)
			{
				Report.Info("Not on Subscription Enrollment Page");
				Report.Screenshot();
				return false;
			}

			switch (servicesPlan)
			{
				case "Gold":
					if (!Gold_click())
					{
						Report.Info("Failed to Select Gold Support Services Plan");
						Report.Screenshot();
						return false;
					}

					Report.Success("Gold Support Services Plan Selected");
					break;
				case "Silver":
					if (!Silver_click())
					{
						Report.Info("Failed to Select Silver Support Services Plan");
						Report.Screenshot();
						return false;
					}

					Report.Success("Silver Support Services Plan Selected");
					break;
				case "Bronze":
					if (!Bronze_click())
					{
						Report.Info("Failed to Select Bronze Support Services Plan");
						Report.Screenshot();
						return false;
					}

					Report.Success("Bronze Support Services Plan Selected");
					break;
				case "General Support":
					if (!General_Support_click())
					{
						Report.Info("Failed to Select General Support Services Plan");
						Report.Screenshot();
						return false;
					}

					Report.Success("General Support Services Plan Selected");
					break;
				default:
					Report.Error("Unable to Find Correct Support Services Plan");
					return false;
			}
			Report.Success("Support Services Plan Selected");
			return true;
		}

		//Proceed Button
		[FindsBy(How = How.XPath, Using = ".//div[@class='row']/div/button[text()='PROCEED']")]
		private IWebElement _btnProceed;

		public bool Proceed_click()
		{
			Report.Info("Attempting to Click Proceed Button");
			_btnProceed.Click();
			return true;
		}

		public bool Select_Enrollment_Options(string articles, string enArticles, string formProds, string featurePlan,
			string servicesPlan)
		{
			Report.Info("Beginning Select_Enrollment_Options");
			Delay.Seconds(5 * Delay.SpeedFactor);
			if (!Select_Range(articles, enArticles, formProds))
			{
				Report.Info("Failed to Select Range Options");
				return false;
			}

			if (!Select_Feature_Plan(featurePlan))
			{
				Report.Info("Failed to Select Feature Plan");
				return false;
			}

			if (!Select_Support_Services_Plan(servicesPlan))
			{
				Report.Info("Failed to Select Support Services Plan");
				return false;
			}

			if (!Proceed_click())
			{
				Report.Info("Failed to Click Proceed Button");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(2 * Delay.SpeedFactor);
			var myEnroll = new SubscriptionEnrollmentDlg();
			if (!myEnroll.Exists)
			{
				Report.Info("Failed to Open Enrollment Dialog");
				Report.Screenshot();
				return false;
			}
			Report.Success("Enrollment Options Selected");
			return true;
		}


	}


	class SubscriptionEnrollmentDlg : BaseDialog
	{
		[FindsBy(How = How.Id, Using = "subscriptionSummary")]
		protected override IWebElement containerElement { get; set; }

		public bool Header_Correct(string headerText)
		{
			Report.Info("Beginning Header_Correct");

			IWebElement myHeader = containerElement
				.FindElements(By.XPath(".//div[@class='modal-header']/h2[text()='" + headerText + "']"), 10).FirstOrDefault();

			if (myHeader == null)
			{
				Report.Info("Failed to Find Header Text");
				Report.Screenshot();
				return false;
			}
			if (!myHeader.Displayed)
			{
				Report.Info("Incorrect Dialog Open");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Dialog Opened: " + headerText);
			return true;
		}

		//Articles
		[FindsBy(How = How.XPath, Using = ".//tbody/tr/td[text()='Articles']/../")]
		private IWebElement _rowArticles;

		//Enhanced Articles
		[FindsBy(How = How.XPath, Using = ".//tbody/tr/td[text()='Enhanced Articles']/../")]
		private IWebElement _rowEnArticles;

		//Formulated Products
		[FindsBy(How = How.XPath, Using = ".//tbody/tr/td[text()='Formulated Products ']/../")]
		private IWebElement _rowFormProds;

		public bool Feature_Plan_Check(string plan)
		{
			Report.Info("Beginning Feature_Plan_Check: " + plan);

			IWebElement myFeat = containerElement.FindElements(By.XPath(".//div[@class='panel-heading']/span[1]"), 10)
				.FirstOrDefault();

			if (myFeat == null)
			{
				Report.Info("Failed to Find Feature Plan");
				return false;
			}

			if (myFeat.Text != plan)
			{
				Report.Info("Feature Plan is Incorrect: " + myFeat.Text);
				return false;
			}
			Report.Success("Feature Plan is Correct");
			Report.Screenshot();
			return true;

		}

		public string Get_Option(string option)
		{
			Report.Info("Beginning Get_Option: " + option);

			IWebElement myOption = null;

			myOption = containerElement.FindElements(By.XPath(".//tbody/tr/td[text()='" + option + "']/../td[2]"), 10).FirstOrDefault();
			if (myOption == null)
			{
				Report.Info("Failed to Find Chosen " + option + " Option");
				Report.Screenshot();
				return "";
			}
			Report.Success("Option Found: " + myOption.Text);
			return myOption.Text;
		}

		public string Get_Service_Plan()
		{
			Report.Info("Beginning Get_Service_Plan");

			IWebElement myOption = null;

			myOption = containerElement.FindElements(By.XPath(".//tbody[2]/tr/td[1]"), 10).FirstOrDefault();
			if (myOption == null)
			{
				Report.Info("Failed to Find Chosen Support Services Plan");
				Report.Screenshot();
				return "";
			}

			if (myOption.Text.Trim() != "Support Services Plan")
			{
				Report.Info("Failed to Find Chosen Support Services Plan");
				Report.Screenshot();
				return "";
			}
			IWebElement myOptionText = null;
			myOptionText = myOption.FindElements(By.XPath("../td[2]"), 10).FirstOrDefault();
			if (myOptionText == null)
			{
				Report.Info("Failed to Find Chosen Support Services Plan Text");
				Report.Screenshot();
				return "";
			}
			Report.Success("Option Found: " + myOptionText.Text);
			return myOptionText.Text;
		}

		public bool Check_Options(string feature_plan, string articles, string enArticles, string formProds, string supportPlan)
		{
			Report.Info("Beginning Check_Options");

			if (!Exists)
			{
				Report.Info("Failed to Open Subscription Enrollment Dialog");
				Report.Screenshot();
				return false;
			}

			if (!Feature_Plan_Check(feature_plan))
			{
				Report.Info("Incorrect Feature Plan");
				Report.Screenshot();
				return false;
			}

			string myArt = Get_Option("Articles");

			if (myArt != articles)
			{
				Report.Info("Incorrect Articles Option");
				Report.Info("Expected: " + articles);
				Report.Info("Got: " + myArt);
				Report.Screenshot();
				return false;
			}
			string myEnArt = Get_Option("Enhanced Articles");

			if (myEnArt != enArticles)
			{
				Report.Info("Incorrect Enhanced Articles Option");
				Report.Info("Expected: " + enArticles);
				Report.Info("Got: " + myEnArt);
				Report.Screenshot();
				return false;
			}
			string myForm = Get_Option("Formulated");

			if (myForm != formProds)
			{
				Report.Info("Incorrect Formulated Products Option");
				Report.Info("Expected: " + formProds);
				Report.Info("Got: " + myForm);
				Report.Screenshot();
				return false;
			}
			string mySupp = Get_Service_Plan();

			if (mySupp != supportPlan)
			{
				Report.Info("Incorrect Support Services Plan");
				Report.Info("Expected: " + supportPlan);
				Report.Info("Got: " + mySupp);
				Report.Screenshot();
				return false;
			}
			Report.Success("Chosen Options Correct");
			Report.Screenshot();
			return true;
		}

		//Checkout Button
		[FindsBy(How = How.XPath, Using = ".//div[@class='modal-footer']/button[text()='Checkout']")]
		private IWebElement _btnCheckout;

		public bool Checkout_click()
		{
			Report.Info("Attempting to Click Checkout Button");
			_btnCheckout.Click();
			return true;
		}

		//Cancel Button
		[FindsBy(How = How.XPath, Using = ".//div[@class='modal-footer']/button[text()='Cancel']")]
		private IWebElement _btnCancel;

		public bool Cancel_click()
		{
			Report.Info("Attempting to Click Cancel Button");
			_btnCancel.Click();
			return true;
		}

		public bool Subscription_Text(string subText)
		{
			Report.Info("Beginning Subscription_Text");

			IWebElement myText = containerElement.FindElements(By.XPath(".//div[@class='col-sm-11']"), 10).FirstOrDefault();

			if (myText == null)
			{
				Report.Info("Subscription Text Not Found");
				Report.Screenshot();
				return false;
			}
			Report.Info("Subscription Text = " + myText.Text.Trim());
			if (myText.Text.Trim() != subText)
			{
				Report.Info("Subscription Text Incorrect");
				Report.Screenshot();
				return false;
			}
			Report.Success("Subscription Text Correct");
			Report.Screenshot();
			return true;
		}



	}





}
