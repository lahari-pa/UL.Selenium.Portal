using System.Collections.Generic;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	public class PesticideDetailsUS : NewProduct
	{
		public bool ClickAddRow()
		{
			IWebElement table = this.Table();
			Report.Info("Adding a new row to the EPA Registration table on the Pesticide Details - US page");
			IWebElement addRowBtn = table?.FindElement(By.XPath(@".//button[@data-bind='click: addRow']"), 2);
			return addRowBtn.TryClick();
		}

		public bool EditRegistrationNumber(string epaNumber, int row)
		{
			IWebElement table = this.Table();
			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> inputs = table.FindElements(By.XPath(@".//input[@class='form-control']"));
			if (inputs.Count == 0)
			{
				Report.Error("There were no rows displayed in the Pesticide Details - EPA Registration table");
				Report.Screenshot();
				return false;
			}
			inputs[row].EnterText(epaNumber);
			Delay.Seconds(1);
			return inputs[row].GetValue().Trim() == epaNumber;
		}

		public class EPARegistration
		{
			public string EPANumber { get; set; }

			public string ActiveIngredient { get; set; }

			public string PercentActiveIngredient { get; set; }

			public bool ActiveIngredientEditable { get; set; }

			public bool PercentActiveIngredientEditable { get; set; }

			public int Row { get; set; }

			public bool ClickRemove()
			{
				IWebElement epaTable = new NewProduct().Table();
				if (epaTable == null)
				{
					return false;
				}
				IList<IWebElement> removeEls = epaTable.FindElements(By.XPath("//a[@class = 'close']"), 2);
				if (removeEls.Count < this.Row)
				{
					return false;
				}
				return removeEls[this.Row - 1].TryClick();
			}

			public bool EditRegistration(string newEpaNumber)
			{
				return new PesticideDetailsUS().EditRegistrationNumber(newEpaNumber, this.Row - 1);
			}
		}

		public List<EPARegistration> EPARegistrationData {
			get
			{
				var rEpa = new List<EPARegistration>();
				IWebElement table = this.Table();
				if (table == null)
				{
					Report.Failure("The EPA Table was not visible on the page");
					Report.Screenshot();
					return null;
				}
				IList<IWebElement> rows = table.FindElements(By.XPath(@".//tr[@class='rpds-rowcolor-0']"), 2);
				int i = 1;
				foreach (IWebElement EpaRow in rows)
				{
					string regNo = EpaRow.FindElement(By.XPath("./td[@class='col-xs-5']/input"), 2).GetValue();
					string activeIngredient = EpaRow.FindElement(By.XPath("./td[@class='col-xs-3'][1]/div")).GetValue();
					string percentActiveIngredient = EpaRow.FindElement(By.XPath("./td[@class='col-xs-3'][2]/div")).GetValue();
					bool activeIngredientEditable = EpaRow.FindElement(By.XPath("./td[@class='col-xs-3'][1]/input"), 2) != null;
					bool percentActiveIngredientEditable = EpaRow.FindElement(By.XPath("./td[@class='col-xs-3'][2]/input"), 2) != null;
					int row = i;
					rEpa.Add(new EPARegistration() {
						ActiveIngredient = activeIngredient,
						EPANumber = regNo,
						Row = row,
						PercentActiveIngredient =
							percentActiveIngredient,
						ActiveIngredientEditable = activeIngredientEditable,
						PercentActiveIngredientEditable = percentActiveIngredientEditable
					});
					i++;
				}
				return rEpa;
			}
			set
			{
				for (int i = 0; i < value.Count; i++)
				{
					EPARegistration epaRegistration = value[i];
					this.ClickAddRow();
					this.EditRegistrationNumber(epaRegistration.EPANumber, 0);
					// because the Add Row always creates a row at the top, the resulting Row numbers will be reverse of those specified in the list:
					epaRegistration.Row = value.Count - i;
				}
			}
		}

	}
}
