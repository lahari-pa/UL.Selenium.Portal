using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class MyIngredientsModal : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'modal-dialog') and not(ancestor::div[@id='select-retailers-dialog' or @id='LogOutModal']) and (.//parent::div[contains(@style,'display: block')])]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Click_OK()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "OK").TryClick();
		}

		public bool Click_Next()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='page-link next' and text()='Next']"), 2).TryClick();
		}

		public string IngredientToRemove()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind,'component.name')]"), 2).Text;
		}

		public bool ClickButton(string option)
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text.Trim().ToLower() == option.ToLower()).TryClick();
		}

		public List<MyIngredients.IngredientItem> MyIngredients()
		{
			var rIngredients = new List<MyIngredients.IngredientItem>();
			int count = 1;
			var rows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
			foreach (var row in rows)
			{
				rIngredients.Add(new MyIngredients.IngredientItem() {
					Index = count,
					CASNumber = row.FindElement(By.XPath(".//span[@data-bind='text: component.cas']")).Text,
					ChemicalName = row.FindElement(By.XPath(".//span[@data-bind='text: component.name']")).Text,
					PublicallyDisclosed = row.FindElement(By.XPath(".//input[starts-with(@data-bind,'checked: isDisclosed')]")).Checked(),
					TradeSecret = row.FindElement(By.XPath(".//input[starts-with(@data-bind,'checked: isTradeSecret')]")).Checked(),
					PublicName = row.FindElement(By.XPath(".//select[contains(@data-bind,'value: publicName')]")).SelectedOption()
				});
				count++;
			}
			while (this.Click_Next())
			{
				rows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
				foreach (var row in rows)
				{
					rIngredients.Add(new MyIngredients.IngredientItem() {
						Index = count,
						CASNumber = row.FindElement(By.XPath(".//span[@data-bind='text: component.cas']")).Text,
						ChemicalName = row.FindElement(By.XPath(".//span[@data-bind='text: component.name']")).Text,
						PublicallyDisclosed = row.FindElement(By.XPath(".//input[starts-with(@data-bind,'checked: isDisclosed')]")).Checked(),
						TradeSecret = row.FindElement(By.XPath(".//input[starts-with(@data-bind,'checked: isTradeSecret')]")).Checked(),
						PublicName = row.FindElement(By.XPath(".//select[contains(@data-bind,'value: publicName')]")).SelectedOption()
					});
					count++;
				}
			}
			return rIngredients;
		}
	}
}
