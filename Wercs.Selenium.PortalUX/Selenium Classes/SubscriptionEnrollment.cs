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
		private IWebElement _select_articles;

		public bool Select_Articles(string articles)
		{
			Report.Info("Selecting Number of Articles: " + articles);
			_select_articles.Select(articles);
			return true;
		}

		//Enhanced Articles
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Enhanced Articles ']/../select")]
		private IWebElement _select_en_articles;

		public bool Select_Enhanced_Articles(string en_articles)
		{
			Report.Info("Selecting Number of Enhanced Articles: " + en_articles);
			_select_en_articles.Select(en_articles);
			return true;
		}

		//Formulated Products
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Formulated Products ']/../select")]
		private IWebElement _select_form_prods;

		public bool Select_Formulated_Products(string form_prods)
		{
			Report.Info("Selecting Number of Formulated Products: " + form_prods);
			_select_form_prods.Select(form_prods);
			return true;
		}

		public bool Select_Range(string articles, string en_articles, string form_prods)
		{
			Report.Info("Beginning Select_Range");

			if (!Exists)
			{
				Report.Info("Not on Subscription Enrollment Page");
				Report.Screenshot();
				return false;
			}

			if (!Select_Articles(articles))
			{
				Report.Info("Failed to Select Correct Number of Articles: " + articles);
				Report.Screenshot();
				return false;
			}
			Report.Info("Number of Articles Selected");
			if (!Select_Enhanced_Articles(en_articles))
			{
				Report.Info("Failed to Select Correct Number of Enhanced Articles: " + en_articles);
				Report.Screenshot();
				return false;
			}
			Report.Info("Number of Enhanced Articles Selected");
			if (!Select_Formulated_Products(form_prods))
			{
				Report.Info("Failed to Select Correct Number of Formulated Products: " + form_prods);
				Report.Screenshot();
				return false;
			}
			Report.Info("Number of Formulated Products Selected");

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
				Report.Info("Feature Plan = " + feature.Text);

				if (feature.GetInnerHTML() == feature_plan)
				{
					Report.Success("Feature Plan Found");
					return feature;
				}
				Report.Info("Feature Plan Doesn't Match");
			}
			Report.Info("Failed to Find Feature Plan");
			return null;

		}

		public bool Select_Feature_Plan(string feature_plan)
		{
			Report.Info("Beginning Select_Feature_Plan: " + feature_plan);

			if (!Exists)
			{
				Report.Info("Not on Subscription Enrollment Page");
				Report.Screenshot();
				return false;
			}

			IWebElement myFeature = null;

			switch (feature_plan)
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
		private IWebElement _select_gold;
		public bool Gold_click()
		{
			Report.Info("Attempting to Select Gold Support Services Plan");
			_select_gold.Click();
			return true;
		}

		//Silver
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading silver']/label")]
		private IWebElement _select_silver;
		public bool Silver_click()
		{
			Report.Info("Attempting to Select Silver Support Services Plan");
			_select_silver.Click();
			return true;
		}

		//Bronze
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading bronze']/label")]
		private IWebElement _select_bronze;
		public bool Bronze_click()
		{
			Report.Info("Attempting to Select Bronze Support Services Plan");
			_select_bronze.Click();
			return true;
		}

		//General
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading']/label[contains(text(), 'General Support']")]
		private IWebElement _select_gen_support;
		public bool General_Support_click()
		{
			Report.Info("Attempting to Select General Support Services Plan");
			_select_gen_support.Click();
			return true;
		}

		public bool Select_Support_Services_Plan(string services_plan)
		{
			Report.Info("Beginning Select_Support_Services_Plan: " + services_plan);

			if (!Exists)
			{
				Report.Info("Not on Subscription Enrollment Page");
				Report.Screenshot();
				return false;
			}

			switch (services_plan)
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
		private IWebElement _btn_proceed;

		public bool Proceed_click()
		{
			Report.Info("Attempting to Click Proceed Button");
			_btn_proceed.Click();
			return true;
		}

		public bool Select_Enrollment_Options(string articles, string en_articles, string form_prods, string feature_plan,
			string services_plan)
		{
			Report.Info("Beginning Select_Enrollment_Options");

			if (!Select_Range(articles, en_articles, form_prods))
			{
				Report.Info("Failed to Select Range Options");
				return false;
			}

			if (!Select_Feature_Plan(feature_plan))
			{
				Report.Info("Failed to Select Feature Plan");
				return false;
			}

			if (!Select_Support_Services_Plan(services_plan))
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
			var myEnroll = new SubscriptionEnrollment_Dlg();
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


	class SubscriptionEnrollment_Dlg : BaseDialog
	{
		[FindsBy(How = How.XPath, Using = "//div[@class='modal-content']")]
		protected override IWebElement containerElement { get; set; }

		public bool Header_Correct(string header_text)
		{
			Report.Info("Beginning Header_Correct");

			IWebElement myHeader = containerElement
				.FindElements(By.XPath(".//div[@class='modal-header']/h2[text()='" + header_text + "']"), 10).FirstOrDefault();

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
			Report.Success("Correct Dialog Opened: " + header_text);
			return true;
		}

		//Articles
		[FindsBy(How = How.XPath, Using = ".//tbody/tr/td[text()='Articles']/../")]
		private IWebElement _row_articles;

		//Enhanced Articles
		[FindsBy(How = How.XPath, Using = ".//tbody/tr/td[text()='Enhanced Articles']/../")]
		private IWebElement _row_en_articles;

		//Formulated Products
		[FindsBy(How = How.XPath, Using = ".//tbody/tr/td[text()='Formulated Products ']/../")]
		private IWebElement _row_form_prods;

		//Feature Plan
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading']/span[1]")]
		private IWebElement _row_feature_plan;

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

		public bool Check_Options(string feature_plan, string articles, string en_articles, string form_prods, string support_plan)
		{
			Report.Info("Beginning Check_Options");

			if (!Exists)
			{
				Report.Info("Failed to Open Subscription Enrollment Dialog");
				Report.Screenshot();
				return false;
			}

			if (_row_feature_plan.Text != feature_plan)
			{
				Report.Info("Incorrect Feature Plan");
				Report.Info("Expected: " + feature_plan);
				Report.Info("Got: " + _row_feature_plan.Text);
				Report.Screenshot();
				return false;
			}

			string myArt = Get_Option(articles);

			if (myArt != articles)
			{
				Report.Info("Incorrect Articles Option");
				Report.Info("Expected: " + articles);
				Report.Info("Got: " + myArt);
				Report.Screenshot();
				return false;
			}
			string myEnArt = Get_Option(en_articles);

			if (myEnArt != en_articles)
			{
				Report.Info("Incorrect Enhanced Articles Option");
				Report.Info("Expected: " + en_articles);
				Report.Info("Got: " + myEnArt);
				Report.Screenshot();
				return false;
			}
			string myForm = Get_Option(form_prods);

			if (myForm != form_prods)
			{
				Report.Info("Incorrect Formulated Products Option");
				Report.Info("Expected: " + form_prods);
				Report.Info("Got: " + myForm);
				Report.Screenshot();
				return false;
			}
			string mySupp = Get_Option(support_plan);

			if (mySupp != support_plan)
			{
				Report.Info("Incorrect Support Services Plan");
				Report.Info("Expected: " + support_plan);
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
		private IWebElement _btn_checkout;

		public bool Checkout_click()
		{
			Report.Info("Attempting to Click Checkout Button");
			_btn_checkout.Click();
			return true;
		}

		//Cancel Button
		[FindsBy(How = How.XPath, Using = ".//div[@class='modal-footer']/button[text()='Cancel']")]
		private IWebElement _btn_cancel;

		public bool Cancel_click()
		{
			Report.Info("Attempting to Click Cancel Button");
			_btn_cancel.Click();
			return true;
		}

		public bool Subscription_Text(string sub_text)
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
			if (myText.Text.Trim() != sub_text)
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
