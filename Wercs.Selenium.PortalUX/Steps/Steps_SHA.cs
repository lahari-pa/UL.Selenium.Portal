using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.Formula.Functions;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;


namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "SHA")]
	class Steps_SHA
	{
		[Given(@"I navigate to Studio")]
		public void GivenINavigateToStudio()
		{
			SeleniumBrowser.WebBrowser.Url = GlobalParametersPortal.SHAUrl;
			SeleniumBrowser.WebBrowser.WaitForPageLoad();
		
		}

		[Given(@"I navigate to Portal")]
		public void GivenINavigateToPortal()
		{
			SeleniumBrowser.WebBrowser.Url = GlobalParameters.TestUrl;
			SeleniumBrowser.WebBrowser.WaitForPageLoad();
		}


		[Given(@"I login to Studio as Administrator")]
		public void GivenILoginToStudioAsAdministrator()
		{
			StudioLogin thisStudioLogin = new StudioLogin();
			thisStudioLogin.Username = "QASHA";
			thisStudioLogin.Password = "Welcome1!";
			thisStudioLogin.ClickSignIn();
			StudioDesktop thisStudioDesktop = new StudioDesktop();
			Report.IsTrue(thisStudioDesktop.Wait_for_load(), "Studio desktop is not showing as expected.",
				"Studio desktop is showing as expected");
		}

		[Given(@"I click top menu item: (.*) and submenu item: (.*)")]
		public void GivenIClickTopMenuItemAndSubMenuItem(string menuItem, string submenuItem)
		{
			StudioTopMenu thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(30), "Top menu has not loaded", "Top menu has loaded");
			Report.IsTrue(thisTopMenu.ClickSubMenu(menuItem, submenuItem), "Failed to click: " + menuItem,
				"Successfully clicked: " + menuItem);
		}

		[Given(@"In SHA Manager Page I click top menu item: (.*)")]
		public void GivenInSHAManagerPageIClickTopMenuItem(string menuItem)
		{
			StudioSHAManager thisShaManager = new StudioSHAManager();
			Report.IsTrue(thisShaManager.ClickTopMenuItem(menuItem),"Failed to click: " + menuItem,
				"Successfully clicked: " + menuItem);
		}

		[Given(@"In SHA Manager Page I click sub menu item: (.*)")]
		public void GivenInSHAManagerPageIClickSubMenuItem(string menuItem)
		{
			StudioSHAManager thisShaManager = new StudioSHAManager();
			for (int i = 0; i < 5; i++)
			{
				Report.Info("Attempt " + i.ToString());
				if (thisShaManager.ClickActionsMenuOption(menuItem))
				{
					Report.Success("Successfully clicked: " + menuItem);
					return;
				}
				Delay.Seconds(1);
			}
			Report.Failure("Failed to click: " + menuItem);
		}

		[Given(@"In the the Manage Global Messages dialog I add and save the following messages:")]
		public void GivenIAddTheFollowingMessages(Table table)
		{
			StudioManageGlobalMessages thisStudioManageGlobalMessages = new StudioManageGlobalMessages();
			Report.IsTrue(thisStudioManageGlobalMessages.Wait_for_load(),
				"Manage Global Messages dialog is not showing", "Manage global messages dialog is showing");
			List<Message> ListOfMessages = new List<Message>();
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Message thisMessage = new Message();
				thisMessage.Title = thisRow["Title"];

				if (thisRow["Message"] == "generated")
				{
					thisMessage.MessageBody = System.Guid.NewGuid().ToString();
				}
				else
				{
					thisMessage.MessageBody = thisRow["Message"];
				}

				thisMessage.Type = thisRow["Type"];
				thisMessage.Active = (thisRow["Active"].ToLower() == "true");
				thisMessage.Level = thisRow["Level"];
				ListOfMessages.Add(thisMessage);
				Report.IsTrue(thisStudioManageGlobalMessages.AddMessage(thisMessage), "Successfully added message",
					"Failed to add message");
			}

			Context.AddToContext("Messages", ListOfMessages);
		}

		[Given(@"I close the Manage Global Messages dialog")]
		public void GivenICloseTheManageGlobalMessagesDialog()
		{
			StudioManageGlobalMessages thisStudioManageGlobalMessages = new StudioManageGlobalMessages();
			Report.IsTrue(thisStudioManageGlobalMessages.ClickCloseButton(), "Failed to close messages dialog",
				"Successfully closed messages dialog");
		}


	}
}
