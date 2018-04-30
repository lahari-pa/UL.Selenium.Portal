using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Classes;
using Global = SeleniumUtilities.Global;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	public class SubscriptionEnrollment : BaseDialog
	{
		[FindsBy(How = How.Id, Using = "enrollment")]
		protected override IWebElement containerElement { get; set; }

		//======================================================================================================== RANGE OF PRODUCTS, ARTICLES AND ENHANCE ARTICLES

		//Articles
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Articles ']/../select")]
		public IWebElement _selectArticles;

		public bool Select_Articles(string articles)
		{
			Report.Info("Selecting Number of Articles: " + articles);
			_selectArticles.Select(articles);
			return true;
		}

		public string Get_Selected_Articles()
		{
			return _selectArticles.SelectedOption();
		}

		public string Get_Articles_info_header()
		{
			return containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Articles ']/a"))
				.GetAttribute("data-original-title").ToString();
		}

		public string Get_Articles_info_body()
		{
			return containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Articles ']/a"))
				.GetAttribute("data-content").ToString();
		}

		public bool Select_Articles_exists()
		{
			try
			{
				return _selectArticles.Displayed;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public string Get_Page_Header()
		{
			return containerElement.FindElement(By.XPath("//div[contains(@class, 'header-with-back')]/h2")).Text.Trim();
		}

		public List<string> Get_Page_SubHeaders()
		{
			return containerElement.FindElements(By.XPath("//h3/span/../../h3")).Select(x => x.Text).ToList();
		}

		//Enhanced Articles
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Enhanced Articles ']/../select")]
		public IWebElement _selectEnArticles;

		public bool Select_Enhanced_Articles(string enArticles)
		{
			Report.Info("Selecting Number of Enhanced Articles: " + enArticles);
			_selectEnArticles.Select(enArticles);
			return true;
		}

		public bool Select_Enhanced_Articles_Exists()
		{
			try
			{
				return _selectEnArticles.Displayed;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public string Get_Selected_Enhanced_Articles()
		{
			return _selectEnArticles.SelectedOption();
		}

		public string Get_Enhanced_Articles_info_header()
		{
			return containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Enhanced Articles ']/a"))
				.GetAttribute("data-original-title").ToString();
		}

		public string Get_Enhanced_Articles_info_body()
		{
			return containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Enhanced Articles ']/a"))
				.GetAttribute("data-content").ToString();
		}

		//Formulated Products
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Formulated Products ']/../select")]
		public IWebElement _selectFormProds;

		public bool Select_Formulated_Products(string formProds)
		{
			Report.Info("Selecting Number of Formulated Products: " + formProds);
			_selectFormProds.Select(formProds);
			return true;
		}

		public bool Select_Formulated_Products_Exists()
		{
			try
			{
				return _selectFormProds.Displayed;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public string Get_Selected_Formulated_Products()
		{
			return _selectFormProds.SelectedOption();
		}
		public string Get_Formulated_Products_info_header()
		{
			return containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Formulated Products ']/a"))
				.GetAttribute("data-original-title").ToString();
		}

		public string Get_Formulated_Products_info_body()
		{
			return containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Formulated Products ']/a"))
				.GetAttribute("data-content").ToString();
		}

		public List<string> Get_Feature_Plans()
		{
			List<string> featurePlans = new List<string>();
			Regex regex = new Regex(@".*\r\n");
			var listOfPlans = containerElement.FindElements(By.XPath(".//div[@class='col-sm-3']/div/div/label")).Select(x => x.Text).ToList();
			foreach (string thisPlan in listOfPlans)
			{
				Match match = regex.Match(thisPlan);
				if (match.Success)
				{
					featurePlans.Add(match.Value.Replace("\r\n", string.Empty));
				}
			}

			return featurePlans;

		}

		public List<Plan> Get_All_Plans()
		{
			List<string> featurePlans = Get_Feature_Plans();
			List<Plan> listOfPlans = new List<Plan>();
			var listSubscriptions = containerElement.FindElements(By.XPath(".//div[contains(@class, 'subscription')]")).ToList();

			foreach (var subscription in listSubscriptions)
			{
				Plan newPlan = new Plan();

				Regex regex = new Regex(@".*\r\n");

				string allLabel = subscription.FindElement(By.XPath(".//div[contains(@class, 'heading')]/label")).Text.Trim();
				Match match = regex.Match(allLabel);
				if (match.Success)
				{
					newPlan.Plan_Name = match.Value.Replace("\r\n", string.Empty);
				}


				var spans = subscription.FindElements(By.XPath(".//div[contains(@class, 'heading')]//span"));
				if (spans.Count > 1)
				{
					newPlan.Best_Value = true;
					newPlan.Plan_Sub = subscription.FindElement(By.XPath(".//div[contains(@class, 'heading')]//span[2]")).Text.Trim();
				}
				else
				{
					newPlan.Plan_Sub = subscription.FindElement(By.XPath(".//div[contains(@class, 'heading')]//span[1]")).Text.Trim();
				}

				var infos = subscription.FindElements(By.XPath(".//div[contains(@class, 'body')]//li")).ToList();
				newPlan.Info_points = new List<Info_Point>();
				foreach (var info in infos)
				{
					Info_Point thisInfoPoint = new Info_Point();
					thisInfoPoint.Info_Header = info.Text.Trim();
					//	Report.Info("Looking at: " + thisInfoPoint.Info_Header);
					try
					{
						thisInfoPoint.Info_Detail = info.FindElement(By.XPath(".//div")).Text.Trim();
						thisInfoPoint.Info_Links = new List<Info_Link>();
						var links = info.FindElements(By.XPath(".//div/a")).ToList();
						foreach (var link in links)
						{
							thisInfoPoint.Info_Links.Add(new Info_Link(link.Text, link.GetAttribute("href")));
						}

					}
					catch (Exception e)
					{
					}
					newPlan.Info_points.Add(thisInfoPoint);
				}

				//newPlan.Info_points
				var subsIndicator = subscription.FindElements(By.XPath(".//div[contains(@class, 'heading')]//div[@class='subs__indicator']"));
				newPlan.Selected = subsIndicator.Select(x => x.GetCssValue("background") != "#fff;").Count() > 0;

				if (featurePlans.Contains(newPlan.Plan_Name))
				{
					newPlan.Plan_Type = "Feature";
				}
				else
				{
					newPlan.Plan_Type = "Support";
				}

				listOfPlans.Add(newPlan);

			}

			return listOfPlans;
		}

		public string Extract_Plan(string stringPlusExtra)
		{
			Regex regex = new Regex(@".*\r\n");
			Match match = regex.Match(stringPlusExtra);
			if (match.Success)
			{
				return match.Value.Replace("\r\n", string.Empty);
			}
			else
			{
				return "";
			}
		}

		public string Click_Info_By_Plan_Item_Return_Hidden(string planName, string item)
		{
			Plan thisPlan = Get_All_Plans().FirstOrDefault(x => x.Plan_Name == planName);
			if (thisPlan != null)
			{
				if (thisPlan.Info_points.Select(x => x.Info_Header).Contains(item))
				{
					var PlanLabel = containerElement.FindElements(By.XPath(".//div[contains(@class, 'heading')]/label"))
						.FirstOrDefault(x => (Extract_Plan(x.Text) == thisPlan.Plan_Name));
					try
					{
						var listOfLis = PlanLabel.FindElements(By.XPath("./../following-sibling::div//li"));
						var infoText = listOfLis.FirstOrDefault(x => x.Text.Trim() == item.Trim());
						var infoLink = infoText.FindElement(By.XPath(".//a"));

						if (infoLink != null)
						{
							if (!infoLink.TryClick())
							{
								throw new Exception("Failed to click info link.");
							}
							Delay.Seconds(1);
							var expandableDiv = PlanLabel.FindElements(By.XPath("./../following-sibling::div//li")).FirstOrDefault(x => (Extract_Plan(x.Text) == item)).FindElement(By.XPath(".//div"));
							if (expandableDiv.GetAttribute("aria-expanded") == "true")
							{
								string expandableDivText = expandableDiv.Text.Trim();
								if (!infoLink.TryClick())
								{
									throw new Exception("Failed to click info link.");
								}
								return expandableDivText.Trim();
							}
							else
							{
								throw new Exception("Extra information is not showing.");
							}
						}
						else
						{
							throw new Exception("No info link was found");
						}
					}
					catch (Exception e)
					{
						throw new Exception("No info link was found");
					}
				}
				else
				{
					throw new Exception("Matching item was not found");
				}
			}
			else
			{
				throw new Exception("Matching plan was not found");
			}


			return "";
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

			IWebElement myFeature = Get_Feature_Plan(featurePlan);

			if (myFeature == null)
			{
				Report.Info("Failed to Find " + featurePlan + " Feature Plan");
				Report.Screenshot();
				return false;
			}
			Report.Info(featurePlan + " Plan Found - Attempting to Select");
			myFeature.Click();
			Delay.Seconds(0.5 * Delay.SpeedFactor);
			Report.Success(featurePlan + " Feature Plan Selected");
			Report.Screenshot();
			return true;
		}

		//==================================================================================================== SUPPORT SERVICE PLAN

		//Gold
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading gold']/label")]
		public IWebElement _selectGold;
		public bool Gold_click()
		{
			Report.Info("Attempting to Select Gold Support Services Plan");
			_selectGold.Click();
			return true;
		}

		//Silver
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading silver']/label")]
		public IWebElement _selectSilver;
		public bool Silver_click()
		{
			Report.Info("Attempting to Select Silver Support Services Plan");
			_selectSilver.Click();
			return true;
		}

		//Bronze
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading bronze']/label")]
		public IWebElement _selectBronze;
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

	public class Plan
	{
		public string Plan_Type { get; set; }
		public string Plan_Name { get; set; }
		public string Plan_Sub { get; set; }
		public bool Best_Value { get; set; } = false;
		public bool Selected { get; set; } = false;
		public List<Info_Point> Info_points { get; set; }
		public string Hidden_Info { get; set; }
	}

	public class Info_Point
	{
		public string Info_Header { get; set; }
		public string Info_Detail { get; set; }
		public List<Info_Link> Info_Links { get; set; }
	}
}

public class Info_Link
{
	public string Link_Text { get; set; }
	public string Link_URL { get; set; }

	public Info_Link(string text, string url)
	{
		Link_Text = text;
		Link_URL = url;
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


