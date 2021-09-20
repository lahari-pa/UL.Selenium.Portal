using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.Utilities.Functions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit;
using UL.Selenium.Portal.WERCSmart.Classes;
using System.IO;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewDistributor")]
	class Steps_Distributor
	{
		[StepDefinition(@"I click outside Provide manufacturer UPC textbox")]
		public void ClickOutSideTextBox()
		{
			//Report.UseSubSteps = true;
			var thisNewProduct = new NewProduct();
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[contains(@id,'DistributorUPC')]"), 2);
			if (!thisNewProduct.WaitForContainerToBeVisible(3))
			{
				Report.Failure("The new product page is not showing");
			}
			Report.Info("clicking outside textbox");
			el.SendKeys(Keys.Tab);
			Report.Info("clicked outside textbox");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I click on I understand checkbox and then Send to Manufacturer")]
		public void ClickCheckbox()
		{
			var thisNewProduct = new NewProduct();
			IWebElement checkBox = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[contains(@type,'checkbox')]"), 2);
			IWebElement SendtoManu = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//a[contains(@id,'sendToManufacturer')]"), 2);
			if (checkBox == null || SendtoManu == null)
			{
				Report.Info("Not able to find checkbox or manufacturer button");
			}
			Report.IsTrue(checkBox.TryClick(), "failed to click Checkbox", "Successfully clicked checkbox");
			Report.IsTrue(SendtoManu.TryClick(), "failed to click Checkbox", "Successfully clicked checkbox");
		}

		[StepDefinition(@"I search for the product in My Distributor: (.*)")]
		public void SearchForTheProductInMyDist(string savedAs)
		{
			//Report.Info("Searching for product with ID: '" + product + "'");
			//var selProdGrid = new ProductsGrid {
			//	SearchIdNameField = product
			//};
			//GeneralUtilities.Wait_for_load_finish();
			//Report.IsTrue(selProdGrid.ProductsInMyDistCount() > 0, "No products were returned for ID: '" + product + "'!", "Product was returned!");
			Report.Info("Searching for Product Saved as " + savedAs);

			if (!Context.Contains(savedAs))
			{
				Report.Failure("The reference: " + savedAs + " was not found in context");
				return;
			}

			string id = "";

			try
			{
				var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
				id = productToSearch.ProductId;
			}
			catch (Exception)
			{
				//do nothing
			}

			//if we didn't get the id try a different object type
			if (id == "")
			{
				try
				{
					var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
					id = productDetails.Id;
				}
				catch (Exception)
				{
					//do nothing
				}

			}

			if (id == "")
			{
				try
				{
					id = Context.GetFromContext(savedAs).ToString();
				}
				catch (Exception)
				{
					Report.Info("Not able to get id from context!");
				}
			}

			Report.Info("Searching for product with ID: '" + id + "'");
			var selProdGrid = new Distributor {
				SearchIdNameField = id
			};
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(selProdGrid.ProductsInMyDistCount() == 1, "No products were returned for ID: '" + id + "'!", "Product was returned!");
		}

		[StepDefinition(@"I click Approve for the most recent product returned in my dist")]
		public void ClickApproveInMyDist()
		{
			Report.Info("Clicking 'Approve' for first product returned");
			var selProdGrid = new Distributor();
			if (selProdGrid.ProductsInMyDistCount() == 0)
			{
				Report.Failure("No products present! Cannot click Row Actions!");
				return;
			}
			Report.Info("Found products in grid, clicking Approve..");
			Report.IsTrue(selProdGrid.ClickActionsApprove(), "Failed to click Approve Option!", "Successfully clicked Approve Option!");
			Report.Screenshot();
		}

		[StepDefinition(
			@"I call Shared Step for dist - UPC - Add UPCName, Container type, Size and Package type \(no retailer data needed\) - Continue for UPC Name: (.*), container type: (.*) and size: (.*)")]
		public void Icallsharedstepfordistupc_Continue(
			string name, string containerType, string size)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var dist = new Distributor();
			Report.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I expand the first upc row");
			dist.ClickExpandOnFirstRow();
			Report.StartStep("I add the following into the UPC Fields");

			//if (upc.ToLower().Contains("savedas"))
			//{
			//	upc = Context.GetFromContext(upc.Replace("savedas", "", StringComparison.OrdinalIgnoreCase).Trim())
			//		.ToString();
			//}

			//if (upc.Contains("Equals"))
			//{
			//	upc = upc.Replace("Equals", "");
			//}

			var upcInfo = new UpcInformation {
				ContainerType = containerType,
				Size = size,
				UPCName = name

			};

			var thisNewProduct = new NewProduct();
			if (thisNewProduct.UPCPackageTypeFieldExists())
			{
				upcInfo.PackageType = thisNewProduct.GetValidOptionForUPCPackageType();
			}


			Report.IsTrue(dist.EditUpcInformation(upcInfo), "Failed to input UPC Information!",
				"Successfully inputted UPC information!");

			Report.StartStep("In the Universal Product Code (UPC) page I click Save");
			MyStepsNewProduct.ThenIClickSaveOrCancelInTheProductPage("save");
		}


		[StepDefinition(@"I create a distibutor request as (.*) and send to manufacturer")]
		public void CreateNewDistributorProduct(string savedAs)
		{
			//Report.UseSubSteps = true;
			var thisNewProduct = new NewProduct();
			var thisStepsNewProduct = new StepsNewProduct();
			var thisHomePage = new StepsHomepage();
			Report.Info("Click Register New Product ");
			thisHomePage.ClickItemInNavigationPanel("Register New Product");
			Report.Info("Confirm header New Product ");
			thisStepsNewProduct.CorrectHeaderShouldBeShowing("New Product");
			Report.Info("Select Request a UPC from a Manufacturer ");
			thisStepsNewProduct.SetRadioOptionInSectionTo("Select the type of product to create:", "Request a UPC from a Manufacturer");
			Report.Info("Click Continue");
			thisStepsNewProduct.ClickContinue();
			Report.Info("Distributor Request - UPC Selection");
			thisStepsNewProduct.CorrectHeaderShouldBeShowing("Distributor Request - UPC Selection");
			Report.Info("Enter Manufacturer's Contact Email");
			thisStepsNewProduct.SetTheSectionOptionTo("Enter Manufacturer's Contact Email", "User_574c25cd650f.kxxyxunf@mailosaur.io");
			Report.Info("Provide Manufacturer's Uniform Product Code (UPC) for the Product");
			thisStepsNewProduct.SetTheSectionOptionTo("Provide Manufacturer's Uniform Product Code (UPC) for the Product", "UPC86463");
			Delay.Seconds(2);
			this.ClickOutSideTextBox();
			Report.Info("Click Continue");
			thisStepsNewProduct.ClickContinue();
			thisStepsNewProduct.SaveProductInformation(savedAs);
			Delay.Seconds(2);
			this.ClickCheckbox();
			GeneralUtilities.Wait_for_load_finish();
		}

	}
}
