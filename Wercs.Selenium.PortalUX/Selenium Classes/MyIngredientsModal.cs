using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class MyIngredientsModal : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'modal-dialog') and not(ancestor::div[@id='select-retailers-dialog' or @id='LogOutModal']) and (.//parent::div[contains(@style,'display: block')])]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Click_OK()
		{
			return containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "OK").TryClick();
		}

		public bool Click_Next()
		{
			return containerElement.FindElement(By.XPath(".//a[@class='page-link next' and text()='Next']"), 2).TryClick();
		}

		public string IngredientToRemove()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind,'component.name')]"), 2).Text;
		}

		public bool ClickButton(string option)
		{
			return containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text.Trim().ToLower() == option.ToLower()).TryClick();
		}

		public List<Ingredient> MyIngredients()
		{
			var rIngredients = new List<Ingredient>();
			var rows = containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
			foreach (var row in rows)
			{
				rIngredients.Add(new Ingredient() {
					CASNumber = row.FindElement(By.XPath(".//span[@data-bind='text: component.cas']")).Text,
					ComponentName = row.FindElement(By.XPath(".//span[@data-bind='text: component.name']")).Text,
					PublicallyDisclosed = row.FindElement(By.XPath(".//input[starts-with(@data-bind,'checked: isDisclosed')]")).Checked(),
					TradeSecret = row.FindElement(By.XPath(".//input[starts-with(@data-bind,'checked: isTradeSecret')]")).Checked(),
					PublicName = row.FindElement(By.XPath(".//select[contains(@data-bind,'value: publicName')]")).SelectedOption()
				});
			}
			while (this.Click_Next())
			{
				rows = containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
				foreach (var row in rows)
				{
					rIngredients.Add(new Ingredient() {
						CASNumber = row.FindElement(By.XPath(".//span[@data-bind='text: component.cas']")).Text,
						ComponentName = row.FindElement(By.XPath(".//span[@data-bind='text: component.name']")).Text,
						PublicallyDisclosed = row.FindElement(By.XPath(".//input[starts-with(@data-bind,'checked: isDisclosed')]")).Checked(),
						TradeSecret = row.FindElement(By.XPath(".//input[starts-with(@data-bind,'checked: isTradeSecret')]")).Checked(),
						PublicName = row.FindElement(By.XPath(".//select[contains(@data-bind,'value: publicName')]")).SelectedOption()
					});
				}
			}
			return rIngredients;
		}
	}
}
