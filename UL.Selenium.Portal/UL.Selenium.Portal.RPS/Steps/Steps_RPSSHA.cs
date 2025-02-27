using Reqnroll;
using System;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using static UL.Selenium.Portal.RPS.Selenium_Classes.RecentActivities;
using WERCSClasses = UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using WERCSmartSteps = UL.Selenium.Portal.WERCSmart.Steps;

namespace UL.Selenium.Portal.RPS.Steps
{

    [Binding, Scope(Tag = "RPSSHA")]
    class Steps_RPSSHA
    {
        [RegexStepDefinition(@"In The SHA products grid I filter for product saved as: (.*) and check that last activity date matches the one found in RPS")]
        public void InSHAProductsGridFilterByProductAndCompareLastActivityDateToRPS(string savedAs)
        {

            var WERCSShared = new WERCSmartSteps.Steps_Shared();
            var recentInformation = (RecentProductData)Context.GetFromContext(savedAs);
            if (savedAs.Contains("RecentProduct"))
            {
                WERCSClasses.New_Product.ProductInformation rpsProduct = new WERCSClasses.New_Product.ProductInformation();
                rpsProduct.Id = recentInformation.ID;
                Context.AddToContext("savedAsProdInfo", rpsProduct);
            }
            if (savedAs.Contains("ProductSearch"))
            {

            }
            WERCSShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "savedAsProdInfo");
            var mySHAManager = new StudioSHAManager();
            var listOfProducts = mySHAManager.GetTopXProducts(1);
            var shaLastDate = listOfProducts[0].LastActivityDate;
            var expectedDateString = recentInformation.MostRecentActivity;
            var foundconvert = Convert.ToDateTime(shaLastDate).ToString("yyyy-MM-dd").Replace("*", "");
            Report.Info($"The converted last activity found date is: {foundconvert}");
            Report.Info($"The expected last activity date is: {expectedDateString}");
            Report.IsTrue(foundconvert == expectedDateString, "The last activity date found in SHA did not match the Most Recent Activity date found in RPS for the product ID: " + recentInformation.ID, "The last activity date found in SHA matched the Most Recent Activity date found in RPS for the product ID: " + recentInformation.ID);

            var submtest = new WERCSClasses.Homepage();






        }

    }
}


