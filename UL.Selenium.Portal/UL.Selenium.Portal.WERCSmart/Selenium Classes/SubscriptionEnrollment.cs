using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class SubscriptionEnrollment : BaseObject
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
			//this._selectArticles.Select(articles);
			//var el = this.containerElement.FindElement(By.XPath($""), 2);

			List<IWebElement> listofMenus = this.containerElement.FindElements(By.XPath($"//div[@class='col-sm-4']//label"), 2).ToList();
			foreach(var menu in listofMenus)
			{
				string foundTitle = menu.Text.Trim();
				if (foundTitle == "Articles")
				{
					var selectEl = menu.FindElement(By.XPath($".//parent::div//following-sibling::div[@class='panel-body']//select"), 2);
					if (selectEl != null)
					{
						selectEl.Select(articles);
						return true;
					}
					else
					{
						Report.Info($"The selection element was null");
						return false;
					}
				}	
			}
			Report.Info($"The correct panel could not be found");
			return false;
		}

		public bool SetSection(string section, string option)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//h3[normalize-space(text())='Select the range of your products, articles and enhanced articles']//following-sibling::div[1]//select[(./preceding-sibling::label[normalize-space(text())='" + section + "'])]"), 2);
			if (el == null)
			{
				Report.Error("Could not find the section: " + section);
				return false;
			}

			el.Select(option);

			return el.SelectedOption() == option;
		}

		public string GetSectionSelectedOption(string section)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//h3[normalize-space(text())='Select the range of your products, articles and enhanced articles']//following-sibling::div[1]//select[(./preceding-sibling::label[normalize-space(text())='" + section + "'])]"), 2);
			if (el == null)
			{
				Report.Error("Could not find the section: " + section);
				return null;
			}

			return el.SelectedOption();

		}

		public string Get_Selected_Articles()
		{
			return this._selectArticles.SelectedOption();
		}

		public string Get_Articles_info_header()
		{
			return this.containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Articles ']/a"), 2)
				.GetAttribute("data-original-title").ToString();
		}

		public string Get_Articles_info_body()
		{
			return this.containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Articles ']/a"), 2)
				.GetAttribute("data-content").ToString();
		}

		public bool Select_Articles_exists()
		{
			try
			{
				return this._selectArticles.Displayed;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool RefreshContainerElement()
		{
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.Id("enrollment"), 2);
			return this.containerElement != null;
		}

		public List<string> ReturnSelectDropDownItems(string label)
		{
			return new SelectElement(this.containerElement.FindElement(By.XPath(".//label[starts-with(text(),'" + label + "')]//following-sibling::select"), 2)).Options.Select(x => x.Text.Trim()).ToList();
		}

		public bool HoverOverInformationElement(string label)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//label[starts-with(text(),'" + label + "')]//i[contains(@class,'info-circle')]"), 2);
			var actions = new Actions(SeleniumBrowser.WebBrowser);
			actions.MoveToElement(el).Build().Perform();
			Delay.Seconds(Delay.SpeedFactor * 3);
			return true;
		}

		public string Get_Page_Header()
		{
			return this.containerElement.FindElement(By.XPath("//div[contains(@class, 'header-with-back')]/h2"), 2).Text.Trim();
		}

		public List<string> Get_Page_SubHeaders()
		{
			this.RefreshContainerElement();
			return this.containerElement.FindElements(By.XPath("//h3/span/../../h3"), 2).Select(x => x.Text).ToList();
		}

		public string Get_Extra_Text_SubHeader(string subHeader)
		{
			return this.Extract_Before_Return(this.containerElement.FindElement(By.XPath("//h3/span/../../h3[contains(text(), '" + subHeader +
																			   "')]/following-sibling::div/p"), 2).Text);
		}

		public string Get_Extra_Text_Link(string subHeader)
		{
			return this.containerElement.FindElement(By.XPath("//h3/span/../../h3[contains(text(), '" + subHeader + "')]/following-sibling::div/p/a"), 2).Text;
		}

		public void Click_Extra_Text_Link(string subHeader, string link)
		{
			this.containerElement.FindElement(By.XPath("//h3/span/../../h3[contains(text(), '" + subHeader +
												  "')]/following-sibling::div/p/a[contains(text(),'" + link + "')]"), 2).TryClick();
			Delay.Seconds(1);
		}

		//Enhanced Articles
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Enhanced Articles ']/../select")]
		public IWebElement _selectEnArticles;

		public bool Select_Enhanced_Articles(string enArticles)
		{
			Report.Info("Selecting Number of Enhanced Articles: " + enArticles);
			//this._selectEnArticles.Select(enArticles);
			//return true;

			List<IWebElement> listofMenus = this.containerElement.FindElements(By.XPath($"//div[@class='col-sm-4']//label"), 2).ToList();
			foreach (var menu in listofMenus)
			{
				string foundTitle = menu.Text.Trim();
				if (foundTitle == "Enhanced Articles")
				{
					var selectEl = menu.FindElement(By.XPath($".//parent::div//following-sibling::div[@class='panel-body']//select"), 2);
					if (selectEl != null)
					{
						selectEl.Select(enArticles);
						return true;
					}
					else
					{
						Report.Info($"The selection element was null");
						return false;
					}
				}
			}
			Report.Info($"The correct panel could not be found");
			return false;
		}

		public bool Select_Enhanced_Articles_Exists()
		{
			try
			{
				return this._selectEnArticles.Displayed;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string Get_Selected_Enhanced_Articles()
		{
			return this._selectEnArticles.SelectedOption();
		}

		public string Get_Enhanced_Articles_info_header()
		{
			return this.containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Enhanced Articles ']/a"), 2)
				.GetAttribute("data-original-title").ToString();
		}

		public string Get_Enhanced_Articles_info_body()
		{
			return this.containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Enhanced Articles ']/a"), 2)
				.GetAttribute("data-content").ToString();
		}

		//Formulated Products
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-4']/label[text()='Formulated Products ']/../select")]
		public IWebElement _selectFormProds;

		public bool Select_Formulated_Products(string formProds)
		{
			Report.Info("Selecting Number of Formulated Products: " + formProds);
			//this._selectFormProds.Select(formProds);
			//return true;

			List<IWebElement> listofMenus = this.containerElement.FindElements(By.XPath($"//div[@class='col-sm-4']//label"), 2).ToList();
			foreach (var menu in listofMenus)
			{
				string foundTitle = menu.Text.Trim();
				if (foundTitle == "Formulated Products")
				{
					var selectEl = menu.FindElement(By.XPath($".//parent::div//following-sibling::div[@class='panel-body']//select"), 2);
					if (selectEl != null)
					{
						selectEl.Select(formProds);
						return true;
					}
					else
					{
						Report.Info($"The selection element was null");
						return false;
					}
				}
			}
			Report.Info($"The correct panel could not be found");
			return false;
		}

		public bool Select_Formulated_Products_Exists()
		{
			try
			{
				return this._selectFormProds.Displayed;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string Get_Selected_Formulated_Products()
		{
			return this._selectFormProds.SelectedOption();
		}
		public string Get_Formulated_Products_info_header()
		{
			return this.containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Formulated Products ']/a"), 2)
				.GetAttribute("data-original-title").ToString();
		}

		public string Get_Formulated_Products_info_body()
		{
			return this.containerElement.FindElement(By.XPath("//div[@class='col-sm-4']/label[text()='Formulated Products ']/a"), 2)
				.GetAttribute("data-content").ToString();
		}

		public List<string> Get_Feature_Plans()
		{
			var featurePlans = new List<string>();
			var regex = new Regex(@".*\r\n");
			var listOfPlans = this.containerElement.FindElements(By.XPath(".//div[@class='col-sm-3']/div/div/label"), 2).Select(x => x.Text).ToList();
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

		public bool Click_link(string planName, string item, string linkText, string linkURL)
		{
			Report.Info("Beginning click link. Plan name: " + planName + " item: " + item + " linktext: " + linkText + " url: " + linkURL);
			var allPlans = new List<Plan>();
			if (Context.ScenarioContext.ContainsKey("Plans"))
			{
				allPlans = (List<Plan>)Context.GetFromContext("Plans");
			}
			else
			{
				allPlans = this.Get_All_Plans();
				Context.AddToContext("Plans", allPlans);
			}
			Plan thisPlan = allPlans.FirstOrDefault(x => x.Plan_Name == planName);
			if (thisPlan != null)
			{
				if (thisPlan.Info_points.Select(x => x.Info_Header).Contains(item))
				{
					IWebElement PlanLabel = this.containerElement.FindElements(By.XPath(".//div[contains(@class, 'heading')]/label"), 2)
						.FirstOrDefault(x => (this.Extract_Before_Return(x.Text) == thisPlan.Plan_Name));
					try
					{
						ReadOnlyCollection<IWebElement> listOfLis = PlanLabel.FindElements(By.XPath("./../following-sibling::div//li"));
						IWebElement infoText = listOfLis.FirstOrDefault(x => x.Text.Trim() == item.Trim());
						IWebElement infoLink = infoText.FindElement(By.XPath(".//a"), 2);

						if (infoLink != null)
						{
							Report.Info("Trying to click info link...");
							if (!infoLink.TryClick())
							{
								throw new Exception("Failed to click info link.");
							}
							Delay.Seconds(1);
							Report.Info("Clicked info link");
							Report.Screenshot();
							IWebElement expandableDiv = PlanLabel.FindElements(By.XPath("./../following-sibling::div//li"), 2).FirstOrDefault(x => (this.Extract_Before_Return(x.Text) == item)).FindElement(By.XPath(".//div"), 2);
							if (expandableDiv.GetAttribute("aria-expanded") == "true")
							{
								Report.Info("Got extra info. Trying to find url link.");
								IWebElement link = expandableDiv.FindElements(By.XPath(".//a"), 2).FirstOrDefault(x => x.Text.Trim() == linkText && x.GetAttribute("href").Contains(linkURL));
								if (link == null)
								{
									Report.Info("Could not find matching url: " + linkText);
									return false;
								}
								Report.Info("Got url link trying to click");
								if (!link.TryClick())
								{
									throw new Exception("Failed to click link in expanded info section");
								}
								bool tabFound = false;
								int counter = 0;
								Report.Info("Looking for new tab with url: " + linkURL);
								while (!tabFound && counter < 10)
								{
									if (SeleniumBrowser.GetTabURLs().Contains(linkURL))
									{
										Report.Info("tab exists for url: " + linkURL);
										Report.Screenshot();
										SeleniumBrowser.CloseTabWithURL(linkURL);
										return true;
									}

									Delay.Seconds(1);
									counter++;
								}
							}
							else
							{
								throw new Exception("Extra information is not showing.");
							}
						}
						else
						{
							Report.Info("No info link was found");
						}
					}
					catch (Exception e)
					{
						throw new Exception("Error: " + e.Message);
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

			return false;
		}

		public List<string> GetAllPlanNames()
		{
			return SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(".//div[contains(@class, 'subscription')]/div[contains(@class, 'heading')]/label"), 2)
				.Select(x => this.Extract_Before_Return(x.Text)).ToList();

		}

		public string GetFooterSubsCalculatorText()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class, 'panel-footer')]/h3"), 2).Text.Trim();
		}

		public string GetEstimatedAnualCost()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class, 'calculator-total')]/p[text()= 'Estimated Annual Cost: ']/strong"), 2).Text.Trim();

		}

		public string GetEstimatedAnualCostPerProduct()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class, 'calculator-total')]/p[text()= 'Estimated Annual Cost per Product: ']/strong"), 2).Text.Trim();

		}

		public List<string> GetAlertMessage()
		{
			//return this.containerElement.FindElement(By.XPath(".//div[@class ='alert alert-warning' and not(starts-with(@style,'display: none'))]/p"), 2);
			try
			{
				var errors = this.containerElement.FindElements(By.XPath(".//div[@class ='alert alert-warning' and not(starts-with(@style,'display: none'))]/p"), 2);
				return errors.Where(x => x.Displayed).ToList().Select(x => x.GetValue()).ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}




		public List<Plan> Get_All_Plans()
		{
			List<string> featurePlans = this.Get_Feature_Plans();
			var listOfPlans = new List<Plan>();
			var listSubscriptions = this.containerElement.FindElements(By.XPath(".//div[contains(@class, 'subscription')]"), 2).ToList();

			foreach (IWebElement subscription in listSubscriptions)
			{
				var newPlan = new Plan();

				var regex = new Regex(@".*\r\n");

				string allLabel = subscription.FindElement(By.XPath(".//div[contains(@class, 'heading')]/label"), 2).Text.Trim();
				Match match = regex.Match(allLabel);
				if (match.Success)
				{
					newPlan.Plan_Name = match.Value.Replace("\r\n", string.Empty);
				}


				ReadOnlyCollection<IWebElement> spans = subscription.FindElements(By.XPath(".//div[contains(@class, 'heading')]//span"));
				if (spans.Count > 1)
				{
					newPlan.Best_Value = true;
					newPlan.Plan_Sub = subscription.FindElement(By.XPath(".//div[contains(@class, 'heading')]//span[2]"), 2).Text.Trim();
				}
				else
				{
					if (spans.Count == 0)
					{
						newPlan.Plan_Sub = "";
					}
					else
					{
						newPlan.Plan_Sub = subscription.FindElement(By.XPath(".//div[contains(@class, 'heading')]//span[1]"), 2).Text.Trim();
					}

				}

				var infos = subscription.FindElements(By.XPath(".//div[contains(@class, 'body')]//li"), 2).ToList();
				newPlan.Info_points = new List<Info_Point>();
				foreach (IWebElement info in infos)
				{

					var thisInfoPoint = new Info_Point {
						Info_Header = info.Text.Trim()
					};
					//	Report.Info("Looking at: " + thisInfoPoint.Info_Header);
					try
					{
						//expand
						IWebElement infoLink = info.FindElement(By.XPath(".//a"), 2);
						infoLink.TryClick();
						Delay.Seconds(1);

						thisInfoPoint.Info_Detail = info.FindElement(By.XPath(".//div"), 2).Text.Trim();
						thisInfoPoint.Info_Links = new List<Info_Link>();
						var links = info.FindElements(By.XPath(".//div/a"), 2).ToList();
						foreach (IWebElement link in links)
						{
							//refinding because link text is missing
							IWebElement refoundLink =
								SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[contains(@href, '" + link.GetAttribute("href") + "')]"), 2);
							Report.Info("Adding new link: " + link.Text + " " + refoundLink.Text);
							thisInfoPoint.Info_Links.Add(new Info_Link(refoundLink.Text, refoundLink.GetAttribute("href")));
						}

						//contract
						infoLink.TryClick();
						Delay.Seconds(1);
					}

					catch (Exception)
					{
					}
					newPlan.Info_points.Add(thisInfoPoint);
				}

				//newPlan.Info_points
				IWebElement subsIndicator = subscription.FindElement(By.XPath(".//div[contains(@class, 'heading')]//div[@class='subs__indicator']"), 2);

				string backGroundColour = subsIndicator.GetCssValue("background-color");
				if (backGroundColour.Contains("255, 255, 255"))
				{
					newPlan.Selected = false;
				}
				else
				{
					newPlan.Selected = true;
				}


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

		public string Extract_Before_Return(string stringPlusExtra)
		{
			var regex = new Regex(@".*\r\n");
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
			var allPlans = new List<Plan>();
			if (Context.ScenarioContext.ContainsKey("Plans"))
			{
				allPlans = (List<Plan>)Context.GetFromContext("Plans");
			}
			else
			{
				allPlans = this.Get_All_Plans();
				Context.AddToContext("Plans", allPlans);
			}
			Plan thisPlan = allPlans.FirstOrDefault(x => x.Plan_Name == planName);
			if (thisPlan != null)
			{
				if (thisPlan.Info_points.Select(x => x.Info_Header).Contains(item))
				{
					IWebElement PlanLabel = this.containerElement.FindElements(By.XPath(".//div[contains(@class, 'heading')]/label"), 2)
						.FirstOrDefault(x => (this.Extract_Before_Return(x.Text) == thisPlan.Plan_Name));
					try
					{
						ReadOnlyCollection<IWebElement> listOfLis = PlanLabel.FindElements(By.XPath("./../following-sibling::div//li"));
						IWebElement infoText = listOfLis.FirstOrDefault(x => x.Text.Trim() == item.Trim());
						IWebElement infoLink = infoText.FindElement(By.XPath(".//a"), 2);

						if (infoLink != null)
						{
							if (!infoLink.TryClick())
							{
								throw new Exception("Failed to click info link.");
							}
							Delay.Seconds(1);
							IWebElement expandableDiv = PlanLabel.FindElements(By.XPath("./../following-sibling::div//li"), 2).FirstOrDefault(x => (this.Extract_Before_Return(x.Text) == item)).FindElement(By.XPath(".//div"), 2);
							if (expandableDiv.GetAttribute("aria-expanded") == "true")
							{
								string expandableDivText = expandableDiv.Text.Trim();
								if (!infoLink.TryClick())
								{
									throw new Exception("Failed to click info link.");
								}
								return expandableDivText.Trim();
							}
							throw new Exception("Extra information is not showing.");
						}
						throw new Exception("No info link was found");
					}
					catch (Exception)
					{
						throw new Exception("No info link was found");
					}
				}
				throw new Exception("Matching item was not found");
			}
			throw new Exception("Matching plan was not found");
		}


		public bool Select_Range(string articles, string enArticles, string formProds)
		{
			try
			{
				Report.Info("Beginning Select_Range");

				if (!this.Exists)
				{
					Report.Info("Not on Subscription Enrollment Page");
					Report.Screenshot();
					return false;
				}
				Delay.Seconds(0.5 * Delay.SpeedFactor);
				if (!this.Select_Articles(articles))
				{
					Report.Info("Failed to Select Correct Number of Articles: " + articles);
					Report.Screenshot();
					return false;
				}
				Delay.Seconds(0.5 * Delay.SpeedFactor);
				Report.Info("Number of Articles Selected");
				if (!this.Select_Enhanced_Articles(enArticles))
				{
					Report.Info("Failed to Select Correct Number of Enhanced Articles: " + enArticles);
					Report.Screenshot();
					return false;
				}
				Delay.Seconds(0.5 * Delay.SpeedFactor);
				Report.Info("Number of Enhanced Articles Selected");
				if (!this.Select_Formulated_Products(formProds))
				{
					Report.Info("Failed to Select Correct Number of Formulated Products: " + formProds);
					Report.Screenshot();
					return false;
				}
				Report.Info("Number of Formulated Products Selected");
				Delay.Seconds(0.5 * Delay.SpeedFactor);
				Report.Success("Range of Products, Articles and Enhanced Articles Selected");
			}
			catch
			{
				Report.Info($"Catch");
			}
			return true;
		}

		//======================================================================================================== FEATURE PLAN


		public IWebElement Get_Feature_Plan(string feature_plan)
		{
			Report.Info("Beginning Get_Feature_Plan: " + feature_plan);

			//var allProducts = this.containerElement.FindElements(By.XPath(".//div[@class='col-sm-3']/div/div/label"), 2).ToList();

			var allProducts = this.containerElement.FindElements(By.XPath(".//div[@class='col-sm-4']//div[contains(@class,'panel-default ws-subscription')]//div[@class='panel-heading info']//label[.//input]"), 2).ToList();
			foreach (IWebElement feature in allProducts)
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

			if (!this.Exists)
			{
				Report.Info("Not on Subscription Enrollment Page");
				Report.Screenshot();
				return false;
			}

			IWebElement myFeature = this.Get_Feature_Plan(featurePlan);

			if (myFeature == null)
			{
				Report.Info("Failed to Find " + featurePlan + " Feature Plan");
				Report.Screenshot();
				return false;
			}
			Report.Info(featurePlan + " Plan Found - Attempting to Select");
			GeneralUtilities.ScrollToTopOfPage();
			myFeature.TryClick();
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
			//this._selectGold.Click();
			//return true;
			List<IWebElement> listofMenus = this.containerElement.FindElements(By.XPath($"//div[@class='col-sm-4']//label"), 2).ToList();
			foreach (var menu in listofMenus)
			{
				string titleTrimmed = Regex.Replace(menu.Text, @"\r\n.*", "").Trim();
				if (titleTrimmed == "Gold Agent Support")
				{
					menu.Click();
					return true;
				}
			}
			Report.Info($"The correct panel could not be found");
			return false;

		}

		//Silver
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading silver']/label")]
		public IWebElement _selectSilver;
		public bool Silver_click()
		{
			Report.Info("Attempting to Select Silver Support Services Plan");
			//this._selectSilver.Click();
			//return true;

			List<IWebElement> listofMenus = this.containerElement.FindElements(By.XPath($"//div[@class='col-sm-4']//label"), 2).ToList();
			foreach (var menu in listofMenus)
			{
				string titleTrimmed = Regex.Replace(menu.Text, @"\r\n.*", "").Trim();
				if (titleTrimmed == "Silver Agent Support")
				{
					menu.Click();
					return true;
				}
			}
			Report.Info($"The correct panel could not be found");
			return false;
		}

		//Bronze
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel-heading bronze']/label")]
		public IWebElement _selectBronze;
		public bool Bronze_click()
		{
			Report.Info("Attempting to Select Bronze Support Services Plan");
			//this._selectBronze.Click();
			//return true;

			List<IWebElement> listofMenus = this.containerElement.FindElements(By.XPath($"//div[@class='col-sm-4']//label"), 2).ToList();
			foreach (var menu in listofMenus)
			{
				string titleTrimmed = Regex.Replace(menu.Text, @"\r\n.*", "").Trim();
				if (titleTrimmed == "No additional Agent Support Service")
				{
					menu.Click();
					return true;
				}
			}
			Report.Info($"The correct panel could not be found");
			return false;

		}

		public string GetSelectedItemInSection(string section)
		{
			switch (section.ToLower())
			{
				case ("select the feature plan"):
					IWebElement input_1 = this.containerElement.FindElements(By.XPath(".//h3[normalize-space(text())='" + section + "']//following-sibling::div[@class='row']//input"), 2).FirstOrDefault(x => x.Checked());
					return input_1.FindElement(By.XPath("./parent::label"), 2).GetElementText();
				case ("select the support services plan"):
					IWebElement input_2 = this.containerElement.FindElements(By.XPath(".//h3[normalize-space(text())='" + section + "']//following-sibling::div//input"), 2).FirstOrDefault(x => x.Checked());
					return input_2.FindElement(By.XPath("./parent::label"), 2).GetElementText();
			}
			return "";
		}

		public IWebElement Get_General_Support_Plan()
		{
			Report.Info("Beginning Get_General_Support_Plan");

			var allProducts = this.containerElement.FindElements(By.XPath(".//div[@class='col-sm-4']/div/div/label"), 2).ToList();

			foreach (IWebElement feature in allProducts)
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
			IWebElement _selectGenSupport = this.Get_General_Support_Plan();
			if (_selectGenSupport == null)
			{
				return false;
			}
			Report.Info("Attempting to Select General Support Services Plan");
			_selectGenSupport.TryClick();
			return true;
		}

		public bool Select_Support_Services_Plan(string servicesPlan)
		{
			Report.Info("Beginning Select_Support_Services_Plan: " + servicesPlan);
			SeleniumBrowser.ScrollToBottomOfPage();
			//GeneralUtilities.ScrollToBottomOfPage();
			if (!this.Exists)
			{
				Report.Info("Not on Subscription Enrollment Page");
				Report.Screenshot();
				return false;
			}

			switch (servicesPlan)
			{
				case "Gold":
					if (!this.Gold_click())
					{
						Report.Info("Failed to Select Gold Support Services Plan");
						Report.Screenshot();
						return false;
					}

					Report.Success("Gold Support Services Plan Selected");
					break;
				case "Silver":
					if (!this.Silver_click())
					{
						Report.Info("Failed to Select Silver Support Services Plan");
						Report.Screenshot();
						return false;
					}

					Report.Success("Silver Support Services Plan Selected");
					break;
				case "Bronze":
					if (!this.Bronze_click())
					{
						Report.Info("Failed to Select Bronze Support Services Plan");
						Report.Screenshot();
						return false;
					}

					Report.Success("Bronze Support Services Plan Selected");
					break;
				case "General Support":
					if (!this.General_Support_click())
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

		private IWebElement Proceed => this.containerElement.FindElement(By.XPath(".//div[@class='row']/div/button[text()='PROCEED']"), 1);

		public bool Proceed_click()
		{
			Report.Info("Attempting to Click Proceed Button");
			return this.Proceed.TryClick();
		}

		public bool Proceed_button_enabled()
		{
			return this.Proceed.Enabled;
		}

		public bool Select_Enrollment_Options(string articles, string enArticles, string formProds, string featurePlan,
			string servicesPlan)
		{
			Report.Info("Beginning Select_Enrollment_Options");
			Delay.Seconds(5 * Delay.SpeedFactor);
			if (!this.Select_Range(articles, enArticles, formProds))
			{
				Report.Info("Failed to Select Range Options");
				return false;
			}

			if (!this.Select_Feature_Plan(featurePlan))
			{
				Report.Info("Failed to Select Feature Plan");
				return false;
			}

			if (!this.Select_Support_Services_Plan(servicesPlan))
			{
				Report.Info("Failed to Select Support Services Plan");
				return false;
			}

			if (!this.Proceed_click())
			{
				Report.Info("Failed to Click Proceed Button");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(5 * Delay.SpeedFactor);
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

	public class Info_Link
	{
		public string Link_Text { get; set; }
		public string Link_URL { get; set; }

		public Info_Link(string text, string url)
		{
			this.Link_Text = text;
			this.Link_URL = url;
		}
	}


	class SubscriptionEnrollmentDlg : BaseObject
	{
		[FindsBy(How = How.Id, Using = "subscriptionSummary")]
		protected override IWebElement containerElement { get; set; }

		public bool Header_Correct(string headerText)
		{
			Report.Info("Beginning Header_Correct");

			IWebElement myHeader = this.containerElement
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

		private IWebElement ArticlesRow => this.containerElement.FindElement(By.XPath(".//tbody/tr/td[text()='Articles']/../"), 1);

		private IWebElement EnhancedArticlesRow => this.containerElement.FindElement(By.XPath(".//tbody/tr/td[text()='Enhanced Articles']/../"), 1);

		//Formulated Products
		[FindsBy(How = How.XPath, Using = ".//tbody/tr/td[text()='Formulated Products ']/../")]
		private IWebElement FormulatedProductsRow => this.containerElement.FindElement(By.XPath(".//tbody/tr/td[text()='Formulated Products ']/../"), 1);

		public bool Feature_Plan_Check(string plan)
		{
			Report.Info("Beginning Feature_Plan_Check: " + plan);
			IWebElement myFeat = this.containerElement.FindElements(By.XPath(".//div[@class='panel-heading']/span[1]"), 10).FirstOrDefault();
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

			myOption = this.containerElement.FindElements(By.XPath(".//tbody/tr/td[text()='" + option + "']/../td[2]"), 10).FirstOrDefault();
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

			myOption = this.containerElement.FindElements(By.XPath(".//tbody[2]/tr/td[1]"), 10).FirstOrDefault();
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

			if (!this.Exists)
			{
				Report.Info("Failed to Open Subscription Enrollment Dialog");
				Report.Screenshot();
				return false;
			}

			if (!this.Feature_Plan_Check(feature_plan))
			{
				Report.Info("Incorrect Feature Plan");
				Report.Screenshot();
				return false;
			}

			string myArt = this.Get_Option("Articles");

			if (myArt != articles)
			{
				Report.Info("Incorrect Articles Option");
				Report.Info("Expected: " + articles);
				Report.Info("Got: " + myArt);
				Report.Screenshot();
				return false;
			}
			string myEnArt = this.Get_Option("Enhanced Articles");

			if (myEnArt != enArticles)
			{
				Report.Info("Incorrect Enhanced Articles Option");
				Report.Info("Expected: " + enArticles);
				Report.Info("Got: " + myEnArt);
				Report.Screenshot();
				return false;
			}
			string myForm = this.Get_Option("Formulated");

			if (myForm != formProds)
			{
				Report.Info("Incorrect Formulated Products Option");
				Report.Info("Expected: " + formProds);
				Report.Info("Got: " + myForm);
				Report.Screenshot();
				return false;
			}
			string mySupp = this.Get_Service_Plan();

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
			this._btnCheckout.Click();
			return true;
		}

		//Cancel Button
		[FindsBy(How = How.XPath, Using = ".//div[@class='modal-footer']/button[text()='Cancel']")]
		private IWebElement _btnCancel;

		public bool Cancel_click()
		{
			Report.Info("Attempting to Click Cancel Button");
			this._btnCancel.Click();
			return true;
		}

		public bool Subscription_Text(string subText)
		{
			Report.Info("Beginning Subscription_Text");

			IWebElement myText = this.containerElement.FindElements(By.XPath(".//div[@class='col-sm-11']"), 10).FirstOrDefault();

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


	class AgencyServiceAgreementDlg : BaseObject
	{
		[FindsBy(How = How.Id, Using = "showAgencyServiceAgreement")]
		protected override IWebElement containerElement { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#showAgencyServiceAgreement > div > div > div.modal-body")]
		IWebElement Agencypopuptext { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#showAgencyServiceAgreement > div > div > div.modal-footer > button")]
		IWebElement PopupCloseButton { get; set; }

		public string GetBodyText()
		{
			return this.containerElement.FindElement(By.XPath("//div[@class='modal-body']"), 2).Text.Trim();
		}

		public string AgencyPopupText()
		{
			IWebElement el = this.Agencypopuptext;

			if (el == null)
			{
				Report.Error("Could not find body in popup dialog");
				return "";
			}
			return el.Text;
		}

		public void ClickCloseButton()
		{
			//containerElement.FindElement(By.XPath("#showAgencyServiceAgreement > div > div > div.modal-footer > button"), 2).TryClick();

			IWebElement el = this.PopupCloseButton;

			if (el == null)
			{
				return;
			}

			el.Click();
		}
	}

	class SubscriptionPopup : BaseObject
	{
		[FindsBy(How = How.XPath, Using = "//div[starts-with(@class,'popover') and @role='tooltip']")]
		protected override IWebElement containerElement { get; set; }

		public string GetHeaderText()
		{
			if (this.containerElement == null)
			{
				Report.Error("Popup dialo could not be located!");
				return "";
			}
			IWebElement el = this.containerElement.FindElement(By.XPath(".//h3"), 2);

			if (el == null)
			{
				Report.Error("Could not find header in popup dialog");
				return "";
			}
			return el.Text;
		}

		public string GetBodyText()
		{
			if (this.containerElement == null)
			{
				Report.Error("Popup dialo could not be located!");
				return "";
			}
			IWebElement el = this.containerElement.FindElement(By.XPath(".//div[@class='popover-content']"), 2);

			if (el == null)
			{
				Report.Error("Could not find body in popup dialog");
				return "";
			}
			return el.Text;
		}

	}
}
