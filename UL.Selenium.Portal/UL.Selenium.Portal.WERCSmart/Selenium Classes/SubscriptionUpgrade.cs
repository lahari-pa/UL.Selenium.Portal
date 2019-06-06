using System;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SubscriptionUpgrade : SubscriptionEnrollment
	{

		public bool Downgrade_Range(string range, string current, string downgrade)
		{
			Report.Info("Beginning Downgrade_Range");

			Report.Info("Range = " + range);
			Report.Info("Current  = " + current);
			Report.Info("Downgrade to = " + downgrade);

			IWebElement myRange = null;

			switch (range)
			{
				case "Articles":
					myRange = this._selectArticles;
					break;
				case "Enhanced Articles":
					myRange = this._selectEnArticles;
					break;
				case "Formulated Products":
					myRange = this._selectFormProds;
					break;
				default:
					throw new Exception("Failed to Find Correct Range Name");
			}

			if (myRange.SelectedOption() != current)
			{
				Report.Info("Current Range is Incorrect: " + current);
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Current Range");
			Report.Info("Selecting Number of " + range + ": " + downgrade);
			myRange.Select(downgrade);
			Delay.Seconds(1 * Delay.SpeedFactor);
			if (myRange.SelectedOption() == downgrade)
			{
				Report.Info("Able to Downgrade " + range + " to " + downgrade);
				Report.Screenshot();
				return false;
			}
			Report.Success("Unable to Downgrade " + range + " to " + downgrade);
			Report.Screenshot();
			return true;
		}

		public bool Feature_Plan_Selected(string featurePlan)
		{
			Report.Info("Beginning Feature_Plan_Selected: " + featurePlan);

			if (!this.Exists)
			{
				Report.Info("Not on Subscription Upgrade Page");
				Report.Screenshot();
				return false;
			}

			IWebElement myFeature = this.Get_Feature_Plan(featurePlan);

			IWebElement myCheck = myFeature.FindElement(By.XPath(".//input"), 2);

			if (myCheck == null)
			{
				Report.Info("Failed to Find " + featurePlan + " Radio Button");
				Report.Screenshot();
				return false;
			}

			if (!myCheck.Selected)
			{
				Report.Info(featurePlan + " Radio Button is Not Selected");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Feature Plan Selected");
			Report.Screenshot();
			return true;
		}

		public bool Downgrade_Feature_Plan_Check(string currentPlan)
		{
			Report.Info("Beginning Downgrade_Feature_Plan_Check");

			IWebElement myStandard = this.Get_Feature_Plan("Standard");
			IWebElement standardCheck = myStandard.FindElement(By.XPath(".//input"), 2);

			IWebElement myLimitPlus = this.Get_Feature_Plan("Limited Plus");
			IWebElement limitplusCheck = myLimitPlus.FindElement(By.XPath(".//input"), 2);

			IWebElement myLimited = this.Get_Feature_Plan("Limited");
			IWebElement limitedCheck = myLimited.FindElement(By.XPath(".//input"), 2);

			switch (currentPlan)
			{
				case "Limited Plus":
					if (limitedCheck.GetAttribute("disabled") != "true")
					{
						Report.Info("Limited Plan is Not Disabled");
						Report.Screenshot();
						return false;
					}
					Report.Info("Limited Plan is Disabled");
					break;
				case "Standard":
					if (limitedCheck.GetAttribute("disabled") != "true")
					{
						Report.Info("Limited Plan is Not Disabled");
						Report.Screenshot();
						return false;
					}
					Report.Info("Limited Plan is Disabled");
					if (limitplusCheck.GetAttribute("disabled") != "true")
					{
						Report.Info("Limited Plus Plan is Not Disabled");
						Report.Screenshot();
						return false;
					}
					Report.Info("Limited Plus Plan is Disabled");
					break;
				case "Premium":
					if (limitedCheck.GetAttribute("disabled") != "true")
					{
						Report.Info("Limited Plan is Not Disabled");
						Report.Screenshot();
						return false;
					}
					Report.Info("Limited Plan is Disabled");
					if (limitplusCheck.GetAttribute("disabled") != "true")
					{
						Report.Info("Limited Plus Plan is Not Disabled");
						Report.Screenshot();
						return false;
					}
					Report.Info("Limited Plus Plan is Disabled");
					if (standardCheck.GetAttribute("disabled") != "true")
					{
						Report.Info("Standard Plan is Not Disabled");
						Report.Screenshot();
						return false;
					}
					Report.Info("Standard Plan is Disabled");
					break;
				default:
					throw new Exception("Failed to Find Correct Feature Plan");
			}
			Report.Success("Unable to Downgrade " + currentPlan);
			return true;
		}

		public bool Support_Plan_Selected(string supportPlan)
		{
			Report.Info("Beginning Support_Plan_Selected: " + supportPlan);

			if (!this.Exists)
			{
				Report.Info("Not on Subscription Upgrade Page");
				Report.Screenshot();
				return false;
			}

			IWebElement mySupport = null;

			switch (supportPlan)
			{
				case "Gold":
					mySupport = this._selectGold;
					break;
				case "Silver":
					mySupport = this._selectSilver;
					break;
				case "Bronze":
					mySupport = this._selectBronze;
					break;
				case "General Support":
					mySupport = this.Get_General_Support_Plan();
					break;
				default:
					throw new Exception("Failed to Find Correct Support Plan");
			}

			IWebElement myCheck = mySupport.FindElement(By.XPath(".//input"), 2);

			if (myCheck == null)
			{
				Report.Info("Failed to Find " + supportPlan + " Radio Button");
				Report.Screenshot();
				return false;
			}

			if (!myCheck.Selected)
			{
				Report.Info(supportPlan + " Radio Button is Not Selected");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Support Services Plan Selected");
			Report.Screenshot();
			return true;
		}

		public bool Downgrade_Support_Plan_Check(string currentPlan)
		{
			Report.Info("Beginning Downgrade_Support_Plan_Check");

			IWebElement mySilver = this._selectSilver;
			IWebElement silverCheck = mySilver.FindElement(By.XPath(".//input"), 2);

			IWebElement mySupp = null;

			mySupp = this.containerElement.FindElement(By.XPath(".//div[@class='panel-heading bronze']/label"), 2);

			if (mySupp == null)
			{
				Report.Info("Bronze Support Plan Not Found - Checking for General Support");
				mySupp = this.Get_General_Support_Plan();

				if (mySupp == null)
				{
					Report.Info("Failed to Find General Support Plans");
					Report.Screenshot();
					return false;
				}
			}

			IWebElement suppCheck = mySupp.FindElement(By.XPath(".//input"), 2);

			switch (currentPlan)
			{
				case "Silver":
					if (suppCheck.GetAttribute("disabled") != "true")
					{
						Report.Info("Bronze/General Support Plan is Not Disabled");
						Report.Screenshot();
						return false;
					}
					Report.Info("Bronze/General Support Plan is Disabled");
					break;
				case "Gold":
					if (silverCheck.GetAttribute("disabled") != "true")
					{
						Report.Info("Silver Plan is Not Disabled");
						Report.Screenshot();
						return false;
					}
					Report.Info("Silver Plan is Disabled");
					if (suppCheck.GetAttribute("disabled") != "true")
					{
						Report.Info("Bronze/General Support Plan is Not Disabled");
						Report.Screenshot();
						return false;
					}
					Report.Info("Bronze/General Support Plan is Disabled");
					break;
				default:
					throw new Exception("Failed to Find Correct Support Services Plan");
			}
			Report.Success("Unable to Downgrade " + currentPlan);
			return true;
		}

		public bool Sub_Upgrade_Cost_Change(string costText, string rangeType, string rangeValue)
		{
			Report.Info("Beginning Sub_Upgrade_Cost_Change for " + costText);

			IWebElement myCurrentCost = null;

			if (costText == "Estimated Annual Cost")
			{
				myCurrentCost = this.containerElement.FindElement(By.XPath(".//div[@class='col-sm-9']/div[1]/div/p/strong"), 2);
				ScenarioContext.Current.Add("CurrentEstCost", myCurrentCost.Text);
			}
			if (costText == "Estimated Annual Cost per Product")
			{
				myCurrentCost = this.containerElement.FindElement(By.XPath(".//div[@class='col-sm-9']/div[2]/div/p/strong"), 2);
				ScenarioContext.Current.Add("CurrentPerCost", myCurrentCost.Text);
			}

			if (myCurrentCost == null)
			{
				Report.Info("Failed to Find Cost Text for: " + costText);
				Report.Screenshot();
				return false;
			}
			Report.Info("Current " + costText + " = " + myCurrentCost.Text);

			if (rangeType == "Articles")
			{
				if (!this.Select_Articles(rangeValue))
				{
					Report.Info("Failed to Select " + rangeValue + " for " + rangeType);
					Report.Screenshot();
					return false;
				}
			}
			if (rangeType == "Enhanced Articles")
			{
				if (!this.Select_Enhanced_Articles(rangeValue))
				{
					Report.Info("Failed to Select " + rangeValue + " for " + rangeType);
					Report.Screenshot();
					return false;
				}
			}
			if (rangeType == "Formulated Products")
			{
				if (!this.Select_Formulated_Products(rangeValue))
				{
					Report.Info("Failed to Select " + rangeValue + " for " + rangeType);
					Report.Screenshot();
					return false;
				}
			}
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Info("Selected " + rangeValue + " for " + rangeType);
			Report.Info("Checking Cost has Changed");

			IWebElement myNewCost = null;

			if (costText == "Estimated Annual Cost")
			{
				myNewCost = this.containerElement.FindElement(By.XPath(".//div[@class='col-sm-9']/div[1]/div/p/strong"), 2);
				if (myNewCost == null)
				{
					Report.Info("Failed to Find Cost Text for: " + costText);
					Report.Screenshot();
					return false;
				}
				Report.Info("New " + costText + " = " + myNewCost.Text);
				string myCurrent = ScenarioContext.Current["CurrentEstCost"].ToString();
				if (myNewCost.Text == myCurrent)
				{
					Report.Info(costText + " Has Not Changed");
					Report.Screenshot();
					return false;
				}
				Report.Success(costText + " Has Changed");
				Report.Screenshot();
				return true;
			}
			if (costText == "Estimated Annual Cost per Product")
			{
				myNewCost = this.containerElement.FindElement(By.XPath(".//div[@class='col-sm-9']/div[2]/div/p/strong"), 2);
				if (myNewCost == null)
				{
					Report.Info("Failed to Find Cost Text for: " + costText);
					Report.Screenshot();
					return false;
				}
				Report.Info("New " + costText + " = " + myNewCost.Text);
				string myCurrent = ScenarioContext.Current["CurrentPerCost"].ToString();
				if (myNewCost.Text == myCurrent)
				{
					Report.Info(costText + " Has Not Changed");
					Report.Screenshot();
					return false;
				}
				Report.Success(costText + " Has Changed");
				Report.Screenshot();
				return true;
			}
			Report.Info("Incorrect Cost Text: " + costText);
			return false;
		}

	}
}
