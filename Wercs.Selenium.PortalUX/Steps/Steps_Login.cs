using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SafewareReporting;
using SeleniumUtilities;

using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
    [Binding, Scope(Tag = "Login")]
    class Steps_Login
    {
        [Given(@"I click on the Forgot Your Password Link")]
        [When(@"I click on the Forgot Your Password Link")]
        [Then(@"I click on the Forgot Your Password Link")]
        [StepDefinition(@"I click on the Forgot Your Password Link")]
        public void GivenIClickOnTheForgotYourPasswordLink()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                var Sel_Login = new Login();
                Sel_Login.Click_Forgotten_Password();
               
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I click on the New to WERCSmart Link")]
        public void GivenIClickOnTheNewToWercsmartLink()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Given I click on the new to WERCSmart link");
            try
            {
                var Sel_Login = new Login();
                Sel_Login.Click_New_To_Wercsmart();

            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"From the Language drop down I select (.*)")]
        public void WhenFromTheLanguageDropDownISelect(string Language)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                Report.Info("Attempting to select " + Language + " from the Language Select drop down");
                var Sel_Login = new Login();
                Sel_Login.Change_Language(Language);
                Report.Screenshot();
                Report.Success("Language selected!");
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I should see for the (.*): (.*)")]
        public void ThenIShouldSeeForTheDialog(string Dialog, string ExpectedText)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                var Sel_Login = new Login();
                Report.Info("Expecting to find: '" + ExpectedText + "' for the '" + Dialog + "' text");
                string Showing = "";
                switch (Dialog)
                {
                    case ("sign in"):
                        Showing = Sel_Login.Form_Header_Text();
                        break;
                    case ("email label"):
                        Showing = Sel_Login.Email_Header_Text();
                        break;
                    case ("password label"):
                        Showing = Sel_Login.Password_Header_Text();
                        break;
                    case ("forgotten password"):
                        Showing = Sel_Login.Forgotten_Password_Text();
                        break;
                    case ("login button"):
                        Showing = Sel_Login.Login_Button_Text();
                        break;
                    default:
                        throw new Exception("Dialog: '" + Dialog + "' was not found in the tree!");
                }
                Report.Info("Found: '" + Showing + "' for the '" + Dialog + "' text");
                Report.Screenshot();
                Report.IsTrue(ExpectedText.Trim() == Showing.Trim(), "Text was incorrect!", "Sign In text was showing as expected!");
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I ensure that the (email|password) input field is not populated")]
        public void ThenIEnsureThatTheInputFieldIsNotPopulated(string InputField)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                var Sel_Login = new Login();
                Report.Info("Ensuring that the " + InputField + " input field is empty");
                switch (InputField)
                {
                    case ("email"):
                        Sel_Login.Email_Field = "";
                        break;
                    case ("password"):
                        Sel_Login.Password_Field = "";
                        break;
                }

                Report.Success("Input field: '" + InputField + "' should no longer be populated");
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I select the Login button")]
        public void WhenISelectTheLoginButton()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                var Sel_Login = new Login();
                Report.Info("Clicking the 'Login' button");
                Sel_Login.Click_Login();
                Report.Info("Login button clicked successfully");
                
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I should see the following error message for (email|password): (.*)")]
        public void ThenIShouldSeeTheFollowingErrorMessageForField(string Field, string Error)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                var Sel_Login = new Login();
                Report.Info("Getting the validation message for field: '" + Field + "'");
                string ErrorShowing = "";
                switch (Field)
                {
                    case "email":
                        ErrorShowing = Sel_Login.Email_Validation();
                        break;
                    case "password":
                        ErrorShowing = Sel_Login.Password_Validation();
                        break;
                }
                Report.Info("Expecting to find message: '" + Error + "'");
                Report.Info("Actual message was: '" + ErrorShowing + "'");
                Report.IsTrue(ErrorShowing.Trim() == Error.Trim(), "Error message was not as expected!", "Error message was showing correctly!");
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }
        
        [StepDefinition(@"I populate the (email|password) input field with: (.*)")]
        public void GivenIPopulateTheInputFieldWith(string InputField, string Text)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                var Sel_Login = new Login();
                if (Text.Contains("<GUID>"))
                    Text = Text.Replace("<GUID>", Guid.NewGuid().ToString().Substring(0,6));

                Report.Info("Inputting '" + Text + "' into the " + InputField + " input field");
                
                switch (InputField)
                {
                    case ("email"):
                        Sel_Login.Email_Field = Text;
                        break;
                    case ("password"):
                        Sel_Login.Password_Field = Text;
                        break;
                }

                Report.Success("Text: '" + Text + "' was inputted into the input field: '" + InputField + "'");
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I should see a server error with message: (.*)")]
        public void IShouldSeeAServerErrorWithMessage(string ExpectedMessage)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                Report.Info("Expecting to see a server error with message: '" + ExpectedMessage + "'");
                var Sel_ServerError = new ServerErrorDialog();
                if (!Sel_ServerError.Wait_for_load(10))
                {
                    throw new Exception("Server Error Dialog did not appear!");
                }
                Delay.Seconds(Delay.SpeedFactor*2);
                var ActualText = Sel_ServerError.Error_Text();
                Report.Info("Actual error text was: '" + ActualText + "'");
                Report.IsTrue(ActualText.Trim() == ExpectedMessage.Trim(), "Message text did not match! Expected: '" + ExpectedMessage + "', but got: '" + ActualText + "'!", "Message text matched successfully!");
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }
     }
}
