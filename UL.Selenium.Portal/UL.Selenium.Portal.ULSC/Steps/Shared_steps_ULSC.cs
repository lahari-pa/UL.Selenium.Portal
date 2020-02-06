using UL.Automation.Selenium.Classes;
using UL.Automation.Reporting.Functions;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Steps;
using UL.Automation.Reporting;

namespace UL.Selenium.Portal.ULSC.Steps
{
	[Binding]
	public class Steps_Shared_ULSC
	{
		[StepDefinition(@"I call Shared Step 29665 - Login to WSW as ULSC user")]
		public void GivenICallSharedStep_LoginToWSWAsULSCUser()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsULSC = new StepsUlsc();
			Report.StartStep("I navigate to Studio");
			myStepsULSC.GivenINavigateToStudioULSC();
			Delay.Seconds(2);
			Report.StartStep("I log in to studio as ULSC user");
			myStepsULSC.GivenILoginToStudioAsULSCUser();
		}



		[StepDefinition(@"I call Shared Step 53079 - WERCSLink go to Services - WERCSmart")]
		public void GivenICallSharedStep_WERCSLinkGoToServices_WERCSmart()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsULSC = new StepsUlsc();
			myStepsULSC.GivenIShouldSeeTheWERCSLinkDashboard();
			myStepsULSC.GivenInTheWERCSLinkDashboardIClickMenuItemAndSubmenuItem("Services", "WERCSmart");
		}

		[StepDefinition(@"I call Shared Step 29148 - Login to ULSC as an Administrator User")]
		public void GivenICallSharedStep_LoginToULSCAsAnAdministratorUser()
		{
			var MyStepsSHA = new Steps_SHA();
			MyStepsSHA.GivenIClickTopMenuItemAndSubMenuItem("UL Secure Connect", "Home");
			Delay.Seconds(20);
			GeneralUtilities.StudioWaitForSpinner(120);
			var MyStepsULSC = new StepsUlsc();
			MyStepsULSC.GivenTheULSCLoginPageShouldOpenInANewTab();
			MyStepsULSC.GivenInTheULSCLoginPageIEnterUsernameAndPasswordForTheFollowingAccountTest("ULSC_WercsUser");
			MyStepsULSC.GivenITheULSCLoginPageIClickLogin();
		}

		[StepDefinition(@"I call Shared Step 54595 - WERCSLink Dashboard > Services > My Products")]
		public void GivenICallSharedStep54595WERCSLinkDashboardServicesMyProducts()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsULSC = new StepsUlsc();
			myStepsULSC.GivenIShouldSeeTheWERCSLinkDashboard();
			myStepsULSC.GivenInTheWERCSLinkDashboardIClickMenuItemAndSubmenuItem("Services", "WERCSmart");
			myStepsULSC.GivenInTheWERCSLinkPage_ClickTheMyProductLinkFromTheWERCSmartAreaOfTheServicesPage("My Products",
				"WERCSmart");
		}


	}
}
