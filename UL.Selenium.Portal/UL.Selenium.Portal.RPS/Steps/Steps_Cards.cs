using System;
using System.Collections.Generic;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
	[Binding, Scope(Tag = "Cards")]
	class Steps_Cards
	{
		[RegexStepDefinition(@"I confirm that the cards are in the following order:")]
		public void ConfirmCardOrder(Table table)
		{
			var superTableNav = new SuperTableNav();

			var cardOrderList = new List<string>();
			foreach (TableRow row in table.Rows)
			{
				cardOrderList.Add(row["CardName"]);
			}

			Report.IsTrue(superTableNav.CardsAreInCorrectOrder(cardOrderList), "FAIL. Cards are not in the expected order",
				"PASS. Cards are in the correct order.");
		}

		[RegexStepDefinition(@"I confirm that the (.*) card contains a numeric value")]
		public void ConfirmCardNumericValue(string card)
		{
			var superTableNav = new SuperTableNav();
			Report.IsTrue(superTableNav.CardCountExists(card), String.Format("FAIL. Card count for {0} card does not exist or is not numeric.", card),
				String.Format("Card count for {0} card exists and is numeric!", card));
		}

		[RegexStepDefinition(@"I confirm that the (.*) card contains a graphic")]
		public void ConfirmCardGraphic(string card)
		{
			var superTableNav = new SuperTableNav();
			Report.IsTrue(superTableNav.CardGraphicExists(card), String.Format("FAIL. Card graphic for {0} card does not exist.", card),
				String.Format("PASS. Card graphic for {0} exists.", card));
		}

		[RegexStepDefinition(@"I confirm that the (.*) card (shows|does not show) a percentage value")]
		public void CardShowsPercentageValue(string card, string doesOrNot)
		{
			var superTableNav = new SuperTableNav();
			if (doesOrNot == "shows")
			{
				Report.IsTrue(superTableNav.CardGrowthExists(card), String.Format("FAIL. Card growth does not exist for {0} card", card),
					String.Format("PASS. Card growth exists for {0} card", card));
			}
			else
			{
				Report.IsFalse(superTableNav.CardGrowthExists(card), String.Format("FAIL. Card growth unexpectedly exists for {0} card", card),
					String.Format("PASS. Card growth does not exist for {0} card, as expected.", card));
			}
		}

		[RegexStepDefinition(@"I confirm that the hover text for the (.*) card is: (.*)")]
		public void ConfirmHoverText(string card, string text)
		{
			var superTableNav = new SuperTableNav();
			string toolTipText = superTableNav.CardHoverToolTipGet(card).Trim();
			Report.IsTrue(text.Contains(toolTipText), String.Format("FAIL. {0} card tool tip text does not match what is expected. Expected: {1}. Actual: {2}", card, text, toolTipText),
				String.Format("PASS. {0} card's tool tip text matched what was expected.", card));
		}

		[RegexStepDefinition(@"I confirm that I (see|do not see) the three cards to the right of the Search field and buttons")]
		public void ConfirmSeeOrNotCards(string choice)
		{
			var superTableNav = new SuperTableNav();
			if (choice == "see")
			{
				Report.IsTrue(superTableNav.CardListExists(), "FAIL. Card list does not exist.", "PASS. Card list exists.");
			}
			else
			{
				Report.IsFalse(superTableNav.CardListExists(), "FAIL. Card list exists erroneously.", "PASS. Card list does not exists, as expected.");
			}
		}

		[RegexStepDefinition(@"I confirm that I see card with label: (.*)")]
		public void ConfirmSeeCard(string cardLabel)
		{
			var superTableNav = new SuperTableNav();
			Report.IsTrue(superTableNav.CardExists(cardLabel), String.Format("FAIL. Expected card {0} does not exist.", cardLabel),
				String.Format("PASS. Expected card {0} exists.", cardLabel));
		}
	}
}
