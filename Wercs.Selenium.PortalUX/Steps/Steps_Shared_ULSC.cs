using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using NPOI.SS.Formula.Functions;
using ResourcePool;
using System.Text.RegularExpressions;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Database_Functions;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding]
	public class Steps_Shared_ULSC : TechTalk.SpecFlow.Steps
	{
		[StepDefinition(@"I call Shared Step 29665 - Login to WSW as ULSC user")]
		public void GivenICallSharedStep_LoginToWSWAsULSCUser()
		{
			TestReport.UseSubSteps = true;
			StepsUlsc myStepsULSC = new StepsUlsc();
			TestReport.StartStep("I navigate to Studio");
			myStepsULSC.GivenINavigateToStudioULSC();
			TestReport.StartStep("I log in to studio as ULSC user");
			myStepsULSC.GivenILoginToStudioAsULSCUser();
		}



		[StepDefinition (@"I call Shared Step 53079 - WERCSLink go to Services - WERCSmart")]
		public void GivenICallSharedStep_WERCSLinkGoToServices_WERCSmart()
		{
			//click services in left hand navigation list

			//click wercsmart link in left hand naivation list
		}

		[Given(@"I call Shared Step 29148 - Login to ULSC as an Administrator User")]
		public void GivenICallSharedStep_LoginToULSCAsAnAdministratorUser()
		{
			Steps_SHA MyStepsSHA = new Steps_SHA();
			MyStepsSHA.GivenIClickTopMenuItemAndSubMenuItem("UL Secure Connect", "Home");
			GeneralUtilities.StudioWaitForSpinner(120);
			StepsUlsc MyStepsULSC = new StepsUlsc();
			MyStepsULSC.GivenTheULSCLoginPageShouldOpenInANewTab();
			MyStepsULSC.GivenInTheULSCLoginPageIEnterUsernameAndPasswordForTheFollowingAccountTest("ULSCV27");
			MyStepsULSC.GivenITheULSCLoginPageIClickLogin();
		}

	}
}
