using System;
using System.Text.RegularExpressions;
using Mailosaur;
using UL.Automation.Selenium.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.Generic;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Utilities;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "WERCSmart_ChooseGoodGuide")]
	class Steps_ChooseGoodGuide
	{
		[StepDefinition(@"on the ChooseGoodGuide site the GoodGuide home page should load")]
		public void ThenTheGoodGuideHomePageShouldLoad()
		{
			Report.IsTrue(new ChooseGoodGuide_Homepage().Wait_for_load(60), "Failed to load the home page", "Successfully loaded the home page");
			Delay.Seconds(3);
		}

		[StepDefinition(@"Click the (.*) Menu down arrow")]
		public void GivenClickTheMenuDownArrow(string menu)
		{
			Report.IsTrue(new TopMenu().ClickDropDownNextToSelectBox(menu), "Failed to click the menu down arrow for: " + menu, "Successfully clicked the menu down arrow for: " + menu);
		}

		[StepDefinition(@"In the (.*) Menu I select: (.*)")]
		public void GivenInTheMenuISelectItem(string menu, string menuItem)
		{
			Report.IsTrue(new TopMenu().ClickItemFromSelectBox(menu, menuItem), "Failed to click: " + menuItem + " in menu" + menu, "Successfully clicked: " + menuItem + " in menu" + menu);
			Delay.Seconds(10);
		}

		[StepDefinition(@"on the top navigation bar I click on (.*)")]
		public void GivenOnTheTopNavigationBarIClick(string menu)
		{
			Report.IsTrue(new TopMenu().ClickSelectBox(menu), "Failed to click menu" + menu, "Successfully clicked menu" + menu);
		}




		[StepDefinition(@"in the Product Identification page I select Product Line/Brand: (.*) and if it does not exist I create it")]
		public void GivenInTheProductIdentificationPageISelectProductLineBrandAndIfItDoesNotExistICreateIt(string productLine)
		{
			var thisGgNewProduct = new GGNewProduct();
			if (!thisGgNewProduct.ProductLineExists(productLine))
			{
				if (!thisGgNewProduct.AddNewProductLineBrandName(productLine))
				{
					throw new Exception("Failed to add new product line: " + productLine);
				}
			}

			Report.IsTrue(thisGgNewProduct.SelectProductLineBrand(productLine), "Failed to select product line: " + productLine,
				"Succeeded in selecting product line: " + productLine);
		}

		[StepDefinition(@"in the Product Identification page I select Category: (.*)")]
		public void GivenInTheProductIdentificationPageISelectCategory(string category)
		{
			Report.IsTrue(new GGNewProduct().SelectCategory(category), "Failed to select category: " + category,
				"Succeeded in selecting category: " + category);
		}

		[StepDefinition(@"in the Product Identification page I select SubCategory: (.*)")]
		public void GivenInTheProductIdentificationPageISelectSubCategory(string subcategory)
		{
			Report.IsTrue(new GGNewProduct().SelectSubCategory(subcategory), "Failed to select subcategory: " + subcategory,
				"Succeeded in selecting subcategory: " + subcategory);
		}

		[StepDefinition(@"I click the 'Get Started Now' button")]
		public void ClickGetStartedNowButton()
		{
			Report.IsTrue(new ChooseGoodGuide_Homepage().ClickGetStarted(), "Failed to click the 'Get Started Now' button!", "Successfully clicked the 'Get Started Now' button!");
		}

		[StepDefinition(@"in the GoodGuide New Product page I select: (.*)")]
		public void GivenInTheGoodGuideNewProductPageISelect(string item)
		{
			Report.IsTrue(new GGNewProduct().SelectAddProductOption(item), "Failed to select: " + item, "Successfully selected: " + item);
		}

		[StepDefinition(@"in the GoodGuide New Product page I click button: (.*)")]
		public void GivenInTheGoodGuideNewProductPageIClickButton(string button)
		{
			switch (button.ToLower())
			{
				case "save and next":
					Report.IsTrue(new GGNewProduct().ClickSaveAndNext(), "Failed to click save and close", "Successfully clicked save and close");
					break;
				default:
					throw new Exception("Failed to provide valid button to click");
			}

		}

		[StepDefinition(@"in the GoodGuide site I add the following ingredients:")]
		public void ThenInTheGoodGuideSiteIAddTheFollowingIngredients(Table ingredientInformation)
		{
			IEnumerable<Ingredients.Ingredient> Ingredients = ingredientInformation.CreateSet<Ingredients.Ingredient>();

			foreach (Ingredients.Ingredient item in Ingredients)
			{
				Report.IsTrue(new GGNewProduct().AddIngredient(item), "Failed to add ingredient: " + (item.CASNumber == "" ? item.ComponentName : item.CASNumber) + "!", "Successfully added ingredient: " + (item.CASNumber == "" ? item.ComponentName : item.CASNumber));
			}
		}

		[StepDefinition(@"in the UPC Grid in the (.*) drop down I select: (.*)")]
		public void GivenInTheUPCGridInTheDropDownISelect(string dropDown, string item)
		{
			var thisGgNewProduct = new GGNewProduct();
			switch (dropDown)
			{
				case "GoodGuide":
					Report.IsTrue(thisGgNewProduct.UPCGridGoodGuide(item), "Failed to select item", "Correctly selected item");
					break;
				case "Colour":
					Report.IsTrue(thisGgNewProduct.UPCGridColour(item), "Failed to select item", "Correctly selected item");
					break;
				case "Scent":
					Report.IsTrue(thisGgNewProduct.UPCGridScent(item), "Failed to select item", "Correctly selected item");
					break;
				default:
					throw new Exception("Must provide valid drop down");
			}
		}

		[StepDefinition(@"in the UPC Grid in the (.*) upload I select: (.*)")]
		public void GivenInTheUPCGridInTheUploadISelect(string uploadType, string filePath)
		{
			var thisGgNewProduct = new GGNewProduct();
			Report.IsTrue(thisGgNewProduct.UPCUpload(uploadType, filePath), "Failed to upload image",
				"Successfully uploaded image");
			Delay.Seconds(3);
		}

		[StepDefinition(@"in the Data Acceptance section I answer: (.*) to would you like to submit product info")]
		public void ThenInTheDataAcceptanceSectionIAnswerToWouldYouLikeToSubmitProductInfo(string answer)
		{
			Report.IsTrue(new GGNewProduct().WouldYouLikeToSubmitProductInfo(answer.ToLower()),
				"Failed to set answer to: " + answer, "Successfully set answer to: " + answer);
		}

		[StepDefinition(@"in the Data Acceptance section I click on Accept")]
		public void ThenInTheDataAcceptanceSectionIClickOnAccept()
		{
			Report.IsTrue(new GGNewProduct().DataAcceptanceClickOK(),
				"Failed to click on accept button", "Successfully clicked on accept button");
		}




		[StepDefinition(@"In the GoodGuide site I add the following into the UPC Fields")]
		public void ThenIAddTheFollowingIntoTheUpcFields(Table table)
		{
			var thisGgNewProduct = new GGNewProduct();
			if (!thisGgNewProduct.WaitForUPCAdd(30))
			{
				throw new Exception("Add UPC fields not showing as expected.");
			}
			UpcInformation upcInfo = table.CreateInstance<UpcInformation>();
			Report.Info("UPC Number: " + upcInfo.UpcNumber);
			Report.Info("Container Type: " + upcInfo.ContainerType);
			Report.Info("Size: " + upcInfo.Size);

			Report.IsTrue(thisGgNewProduct.InputUpcInformation(upcInfo), "Failed to input UPC Information!", "Successfully inputted UPC information!");
		}

		[StepDefinition(@"in the GoodGuide site I should be in the UPC Grid")]
		public void ThenInTheGoodGuideSiteIShouldBeInTheUPCGrid()
		{
			Report.IsTrue(new GGNewProduct().UPCGridWaitForLoad(60), "UPC Grid is not showing as expected.",
				"UPC Grid is showing as expected");
		}

		[StepDefinition(@"in the UPC Grid I click (.*)")]
		public void GivenInTheUPCGridIClickButton(string button)
		{
			Report.IsTrue(new GGNewProduct().UPCGridClickButton(button.ToLower()), "Unable to click button: " + button,
				"Clicked button: " + button);
		}

		[StepDefinition(@"in the GoodGuide My Products page I set the search criteria as follows:")]
		public void GivenInTheGoodGuideMyProductsPageISetTheSearchCriteriaAsFollows(Table table)
		{
			//we know there will only be one row
			string searchBy = table.Rows[0]["Search By"].Trim();
			string filter = table.Rows[0]["Filter"].Trim();
			if (filter.ToLower().Contains("saved as"))
			{
				filter = Context.GetFromContext(filter.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}
			string upc = table.Rows[0]["UPC"].Trim();
			string status = table.Rows[0]["Status"].Trim();

			Report.IsTrue(new MyProducts().SetSearchCriteria(searchBy, filter, upc, status),
				"Failed to set search criteria: " + searchBy + ", " + filter + ", " + upc + ", " + status,
				"Set search criteria successfully.");
		}

		[StepDefinition(@"in the GoodGuide My Products page I click on Filter")]
		public void GivenInTheGoodGuideMyProductsPageIClickOnFilter()
		{
			Report.IsTrue(new MyProducts().ClickFilter(), "Failed to click filter button", "Successfully clicked on filter");
		}

		[StepDefinition(@"in the GoodGuide My Products page I (should|should not) see product with (.*): (.*)")]
		public void ThenInTheGoodGuideMyProductsPageIShouldSeeProductWithItemValue(string shouldOrNot, string columnName, string value)
		{
			if (value.ToLower().Contains("saved as"))
			{
				value = Context.GetFromContext(value.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}
			Report.Info("Looking for value: " + value);

			if (shouldOrNot == "should")
			{
				Report.IsTrue(new MyProducts().FindAndClickProduct(columnName, value), "Product was not showing as expected.",
					"Product found");
			}
			else
			{
				Report.IsTrue(!(new MyProducts().FindAndClickProduct(columnName, value)), "Product was showing.",
					"Product not found");
			}

		}

		[StepDefinition(@"in the GoodGuide My Products page I delete product with (.*): (.*)")]
		public void ThenInTheGoodGuideMyProductsPageIDeleteProductWithItemValue(string columnName, string value)
		{
			var thisMyProducts = new MyProducts();
			if (!thisMyProducts.Wait_for_load(60))
			{
				throw new Exception("My Products page has not loaded");
			}

			if (value.ToLower().Contains("saved as"))
			{
				value = Context.GetFromContext(value.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}
			Report.IsTrue(thisMyProducts.ClickDeleteProduct(columnName, value), "Product was not showing as expected.",
				"Product found");

			var thisDeleteProduct = new DeleteProduct();
			if (!thisDeleteProduct.Wait_for_load(60))
			{
				throw new Exception("Delete confirmation page has not loaded");
			}

			Report.IsTrue(thisDeleteProduct.ClickDelete(), "Failed to click confirm delete",
				"Clicked confirm delete");

			Report.IsTrue(thisDeleteProduct.WaitForDialogToDisappear(60), "Delete confirm dialog has not disappeared",
				"Delete dialog has disappeared.");
		}



		[StepDefinition(@"in the GoodGuide site I click the 'Add UPC' button")]
		public void GivenInTheGoodGuideSiteIClickTheAddUPCButton()
		{
			Report.IsTrue(new GGNewProduct().ClickAddUPC(), "Failed to click Add UPC button",
				"Successfully clicked add UPC button");
		}


		[StepDefinition(@"in the Company/Brand Information page I upload (.*): (.*)")]
		public void GivenInTheCompanyBrandInformationPageIUploadAt(string uploadType, string uploadPath)
		{
			Report.IsTrue(new GGNewProduct().UploadFile(uploadType, uploadPath), "Upload failed", "Upload succeeded");
		}


		[StepDefinition(@"in the Physical Property page I select physical state: (.*)")]
		public void ThenInThePhysicalPropertyPageISelectPhysicalState(string physicalState)
		{
			Report.IsTrue(new GGNewProduct().SetPhysicalState(physicalState),
				"Failed to set physical state to: " + physicalState, "Correctly set physical state");
		}

		[StepDefinition(@"in the Physical Property page I enter product pH: (.*)")]
		public void ThenInThePhysicalPropertyPageIEnterProductPH(string ph)
		{
			Report.IsTrue(new GGNewProduct().EnterPHValue(ph), "Failed to set product ph to: " + ph, "Correctly set product PH");
		}

		[StepDefinition(@"in the Marks of Distinction page I should see rating: (.*)")]
		public void ThenInTheMarksOfDistinctionPageIShouldSeeRating(int rating)
		{
			Report.IsTrue(new GGNewProduct().GetRating() == rating, "Rating is not showing as: " + rating, "Rating is showing correctly.");
		}

		[StepDefinition(@"in the Marks of Distinction page for Would you like to continue with the product submission process I select: (Yes|No)")]
		public void GivenInTheMarksOfDistinctionPageForWouldYouLikeToContinueWithTheProductSubmissionProcessISelectYesOrNo(string yesOrNo)
		{
			Report.IsTrue(new GGNewProduct().SetContinue(yesOrNo), "Failed to set continue to: " + yesOrNo, "Successfully set continue to: " + yesOrNo);
		}



		[StepDefinition(@"in the Product Identification page I should see message: (.*)")]
		public void ThenInTheProductIdentificationPageIShouldSeeMessage(string message)
		{
			string actualMessage = new GGNewProduct().ProductIdentificationGetInfo().Trim();
			Report.IsTrue(actualMessage == message.Trim(), "Expecting message: " + message + " but got: " + actualMessage,
				"Message is showing as expected: " + actualMessage);
		}



		[StepDefinition(@"in the GoodGuide site the (.*) page should load")]
		public void ThenSectionShouldLoad(string section)
		{
			var thisGgNewProduct = new GGNewProduct();
			switch (section)
			{
				case "New Product":
					thisGgNewProduct.WaitForNewProductRadio(60);
					Report.IsTrue(thisGgNewProduct.WaitForSection(section), section + " has failed to appear", section + " is showing as expected.");
					break;
				case "My Products":
					Report.IsTrue(new MyProducts().Wait_for_load(60), section + " has failed to appear", section + " is showing as expected.");
					break;
				default:
					Report.IsTrue(thisGgNewProduct.WaitForSection(section, 120), section + " has failed to appear", section + " is showing as expected.");
					break;
			}
			Delay.Seconds(3);

		}

		[StepDefinition(@"I generate a random product name and save as (.*)")]
		public void GivenIGenerateARandomProductNameAndSaveAs(string saveAs)
		{
			Context.AddToContext(saveAs, Guid.NewGuid().ToString());
		}


		[StepDefinition(@"in the Product Identification page I enter product name: (.*)")]
		public void GivenInTheProductIdentificationPageIEnterProductName(string name)
		{
			if (name.ToLower().Contains("saved as"))
			{
				name = Context.GetFromContext(name.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}
			Report.IsTrue(new GGNewProduct().EnterProductName(name), "Product name has not been entered correctly", "Product name has been entered correctly");
		}



		[StepDefinition(@"I click the 'Create Company Account' button")]
		public void ClickCreateCompanyAccountButton()
		{
			Report.IsTrue(new ChooseGoodGuide_AccountCreation().ClickCreateCompanyAccount, "Failed to click the 'Create Company Account' button!", "Successfully clicked the 'Create Company Account' button!");
		}

		[StepDefinition(@"I enter the (Email): (.*)")]
		public void EnterInformationIntoField(string field, string value)
		{
			var accountCreation = new ChooseGoodGuide_AccountCreation();
			switch (field)
			{
				case ("Email"):
					{
						value = MailosaurFunctions.CreateEmail(value);
						Context.AddToContext("AccountEmailAddress", value);
						accountCreation.Email = value;
						Report.IsTrue(accountCreation.Email == value, "Failed to enter the email address: " + value, "Successfully entered the email address: " + value);
						return;
					}
			}
		}

		[StepDefinition(@"I click the (Next|Cancel) button")]
		public void ClickNextCancelButton(string button)
		{
			var accountCreation = new ChooseGoodGuide_AccountCreation();
			switch (button)
			{
				case ("Next"):
					{
						Report.IsTrue(accountCreation.ClickNext, "Failed to click " + button + "!", "Successfully clicked " + button + "!");
						return;
					}
				default:
					{
						Report.IsTrue(accountCreation.ClickCancel, "Failed to click " + button + "!", "Successfully clicked " + button + "!");
						return;
					}
			}
		}

		[StepDefinition(@"I create an account with the following parameters:")]
		public void CreateChooseGoodGuideAccount(Table parameters)
		{
			new Steps_ConflictMinerals().GivenInTheConflictMineralsPageICreateEnterCompanyDetailsAsFollows(parameters);
		}

		[StepDefinition(@"I setup the Company Contact Person as follows:")]
		public void SetupCompanyContactPerson(Table parameters)
		{
			var accountCreation = new ChooseGoodGuide_AccountCreation();
			foreach (TechTalk.SpecFlow.TableRow thisRow in parameters.Rows)
			{
				switch (thisRow["Field"])
				{
					case "Contact":
						accountCreation.Contact = thisRow["Value"].Trim();
						break;
					case "Phone Number":
						accountCreation.ContactPhoneNumber = thisRow["Value"].Trim();
						break;
					case "Additional Emails":
						accountCreation.ContactAdditionalEmails = thisRow["Value"].Trim();
						break;
					case "Password":
						accountCreation.ContactPassword = thisRow["Value"].Trim();
						accountCreation.ContactReEnterPassword = thisRow["Value"].Trim();
						break;
					case ("What city were you born in?"):
						accountCreation.WhatCityWereYouBornIn = thisRow["Value"].Trim();
						break;
					case ("What was the Model of your first car?"):
						accountCreation.WhatWasTheModelOfYourFirstCar = thisRow["Value"].Trim();
						break;
					case ("What is your favorite sport?"):
						accountCreation.WhatIsYourFavouriteSport = thisRow["Value"].Trim();
						break;
					case ("What is your favorite food or drink?"):
						accountCreation.WhatIsYourFavouriteFoodOrDrink = thisRow["Value"].Trim();
						break;
					case ("What is your favorite vacation destination?"):
						accountCreation.WhatIsYourFavouriteVacationDestination = thisRow["Value"].Trim();
						break;
					case ("Secure Password"):
						accountCreation.EnterSecurePassword = thisRow["Value"].Trim();
						break;


					default:
						throw new Exception("Field value as not one of the expected ones");

				}
			}
		}

		[StepDefinition(@"The contact person page should appear")]
		public void ContactPersonPageAppears()
		{
			Report.IsTrue(new ChooseGoodGuide_AccountCreation().WaitForCreateCompanyAccountFormPage(30), "Failed to find the company contact person page after 30 seconds!", "Successfully found the company contact person page!");
		}

		[StepDefinition(@"I get the verification code from the email")]
		public void ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount()
		{
			var matchingEmail = (Email)Context.ScenarioContext["Matching"];
			string bodyText = matchingEmail.Text.Body;
			Group code = Regex.Match(bodyText, @"Your verification code is: (.*)").Groups[1];

			Report.Info("Found a verification code: '" + code + "' in the email!");
			Context.AddToContext("VerificationCode", code);
		}

		[StepDefinition(@"I wait for the congratulations page to appear")]
		public void WaitForCongratsPageToAppear()
		{
			Report.IsTrue(new ChooseGoodGuide_AccountCreation().WaitForCongratulationsPage(120), "Congratulations page has not loaded", "Congratulations page has loaded as expected");
		}

		[StepDefinition(@"I confirm that I have received a (GoodGuide|ULToys) account email to account: (.*)")]
		public void ThenIConfirmThatIHaveReceivedACARPAccountEmailToAccount(string emailType, string emailToFind)
		{
			string emailTitle = emailType == "GoodGuide" ? "Welcome to GoodGuide!" : "Welcome to WERCSmart! Thank you for creating an account!";
			Report.Info("Expecting an email with title: " + emailTitle);
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			bool passed = MailosaurFunctions.CheckEmailHasArrived(emailTitle, emailToFind);
			if (!passed)
			{
				passed = MailosaurFunctions.CheckEmailHasArrived(emailTitle, emailToFind);
			}
			Report.IsTrue(passed, "Email has not arrived as expected", "Email has arrived as expected");
		}


		[StepDefinition(@"the GoodGuide Company Details page should load")]
		public void GoodGuideCompanyDetailsPageShouldLoad()
		{
			Report.IsTrue(new ChooseGoodGuide_AccountCreation().GoodGuideDashboardLoads(), "GoodGuide dashboard failed to load!", "GoodGuide dashboard loaded successfully!");
		}

		[StepDefinition(@"the ULToys My Company Details page should load")]
		public void ULToysCompanyDetailsPageShouldLoad()
		{
			Report.IsTrue(new ChooseGoodGuide_AccountCreation().UlToysDashboardLoads(), "ULToys dashboard failed to load!", "ULToys dashboard loaded successfully!");
		}

		[StepDefinition(@"I navigate to ChooseGoodGuide")]
		public void GivenINavigateToChooseGoodGuide()
		{
			SeleniumBrowser.WebBrowser.Url = TestVariables.GetVariableSavedAs("ChooseGGUrl");
			SeleniumBrowser.WebBrowser.WaitForPageLoad();
		}

		[StepDefinition(@"I login to ChooseGoodGuide as Administrator")]
		public void GivenILoginToChooseGoodGuideAsAdministrator()
		{
			var thisChooseGGLogin = new ConflictMinerals();
			var myStepsGG = new Steps_ChooseGoodGuide();
			var thisGgNewProduct = new GGNewProduct();
			TReVorTestUsers shaUser = TestUsers.GetUserSavedAs("ChooseGGUser");
			thisChooseGGLogin.EmailAddress = shaUser.Username;
			thisChooseGGLogin.Password = shaUser.Password;
			thisChooseGGLogin.ClickLogin();
			Report.Info("My products desktop is loaded");
			var thisMyProducts = new MyProducts();
			Report.IsTrue(thisMyProducts.Wait_for_load(60), "Failed to load My products page", " is showing My Products as expected.");
		}

		[StepDefinition(@"I call Shared Step 68883\(Login to ChooseGoodGuide\)")]
		public void LoginToChooseGG()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsGG = new Steps_ChooseGoodGuide();
			Report.StartStep("I navigate to ChooseGoodGuide");
			myStepsGG.GivenINavigateToChooseGoodGuide();
			Report.StartStep("I log in to ChooseGoodGuide as administrator");
			myStepsGG.GivenILoginToChooseGoodGuideAsAdministrator();
		}
	}
}
