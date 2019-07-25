using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.ULSC.Selenium_Classes
{
	class SideBarNavigation : BaseObject
	{
		public const string BasePath = "//nav[@class='sidebar']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		/// <summary>
		/// Returns a list of all NavLink objects currently displayed in the side bar
		/// </summary>
		public List<NavLink> GetNavLinks()
		{
			var rList = new List<NavLink>();
			var sidebarItems = this.containerElement.FindElements(By.XPath(".//ul[@class='nav']/li"), 2).ToList();
			foreach (IWebElement item in sidebarItems)
			{
				NavLink thisLink = this.GetNavLink(item);
				rList.Add(thisLink);
			}
			return rList;
		}

		/// <summary>
		/// Take string parameter corresponding to an expected navigation link title.
		/// Returns the NavLink object in the side bar which matches the title text.
		/// Returns null if no NavLinks match this criteria.
		/// </summary>
		public NavLink GetNavLink(string title)
		{
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath(".//ul[@class='nav']/li"), 2);
			foreach (IWebElement el in els)
			{
				if (el.FindElement(By.XPath("./a"))?.Text == title)
				{
					return this.GetNavLink(el);
				}
			}
			return null;
		}

		/// <summary>
		/// Take IWebElement parameter corresponding to the list item (li) in the side bar nav for a main menu item
		/// Returns the NavLink object contained within that element
		/// </summary>
		public NavLink GetNavLink(IWebElement el)
		{
			var thisLink = new NavLink {
				Title = el.FindElement(By.XPath("./a"), 2)?.GetAttribute("title"),
				TitleDisplayed = el.FindElement(By.XPath("./a/span"), 2)?.Displayed ?? false,
				Expanded = false,
				Href = el.FindElement(By.XPath("./a"), 2)?.GetAttribute("href"),
				Icon = el.FindElement(By.XPath("./a/em"), 2).GetAttribute("class").Replace("fa fa-", "")
			};
			IWebElement multilevelUl = el.FindElement(By.XPath("./a/following-sibling::ul[starts-with(@id,'multilevel')]"), 2);
			var rsubLinks = new List<NavSubLink>();
			// Only add sub links if the multilevel ul exists
			if (multilevelUl != null)
			{
				thisLink.Expanded = multilevelUl.GetAttribute("aria-expanded") == "true";
				// Only add sub links if multilevel ul is expanded
				if (thisLink.Expanded)
				{
					IList<IWebElement> subEls = multilevelUl.FindElements(By.XPath("./li/a"), 2);
					for (int i = 0; i < subEls.Count; i++)
					{
						if (!subEls[i].Displayed)
						{
							continue;
						}
						IWebElement levelxUl = el.FindElement(By.XPath("//ul[@id='level" + (i + 1).ToString() + "']"), 2);
						var rSubSubLinks = new List<NavSubSubLink>();
						// Only add sub sub links if the levelx ul exists and is expanded
						if (levelxUl != null && levelxUl.GetAttribute("aria-expanded") == "true")
						{
							// Add sub sub links to the list belonging to this sub link
							IList<IWebElement> subSubEls = levelxUl.FindElements(By.XPath("./li/a"), 2);
							rSubSubLinks = subSubEls.Select(ss => new NavSubSubLink {
								Title = ss.Text,
								ParentLevel = i + 1,
								Href = ss.GetAttribute("href"),
								Icon = ss.FindElement(By.XPath("./em"), 2)?.GetAttribute("class").Replace("fa fa-", "")
							})
								.ToList();
						}
						// Add sub link to the list belonging to this link
						rsubLinks.Add(new NavSubLink {
							Level = i + 1,
							Title = subEls[i].Text,
							Expanded = levelxUl != null && levelxUl.GetAttribute("aria-expanded") == "true",
							SubSubLinks = rSubSubLinks,
							Href = subEls[i].GetAttribute("href"),
							Icon = subEls[i].FindElement(By.XPath("./em"), 2)?.GetAttribute("class").Replace("fa fa-", "")
						});
					}
					// Add all sub links to this link
				}
			}
			thisLink.SubLinks = rsubLinks;
			return thisLink;
		}

		/// <summary>
		/// Returns TryClick on the link object in the WERCSLink side bar
		/// </summary>
		public bool ClickNavItem(NavLink link)
		{
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath(".//ul[@class='nav']//li/a"), 2);
			foreach (IWebElement el in els)
			{
				if (el.Text == link.Title)
				{
					return el.TryClick();
				}
			}
			return false;
		}

		/// <summary>
		/// Returns TryClick on the sublink object in the WERCSLink side bar
		/// </summary>
		public bool ClickNavItem(NavSubLink link)
		{
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath(".//ul[starts-with(@id,'multilevel')]/li/a"), 2);
			foreach (IWebElement el in els)
			{
				if (el.Text == link.Title)
				{
					return el.TryClick();
				}
			}
			return false;
		}

		/// <summary>
		/// Returns TryClick on the subsublink object in the WERCSLink side bar
		/// </summary>
		public bool ClickNavItem(NavSubSubLink link)
		{
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath(".//ul[@id='level" + link.ParentLevel + "']/li/a"), 2);
			foreach (IWebElement el in els)
			{
				if (el.Text == link.Title)
				{
					return el.TryClick();
				}
			}
			return false;
		}

		/// <summary>
		/// Describes a navigation link item appearing in the WERCSLink side bar
		/// </summary>
		public class BaseNav
		{
			public string Title { get; set; }

			public string Href { get; set; }

			public string Icon { get; set; }
		}

		/// <summary>
		/// Describes a top level navigation link item appearing in the WERCSLink side bar. EG. Services
		/// </summary>
		public class NavLink : BaseNav
		{
			public bool TitleDisplayed { get; set; }

			public bool Expanded { get; set; }

			public List<NavSubLink> SubLinks { get; set; }
		}

		/// <summary>
		/// Describes a second level navigation link item appearing in the WERCSLink side bar. EG WERCSmart (Services)
		/// </summary>
		public class NavSubLink : BaseNav
		{
			public int Level { get; set; }

			public bool Expanded { get; set; }

			public List<NavSubSubLink> SubSubLinks { get; set; }
		}

		/// <summary>
		/// Describes a third level navigation link item appearing in the WERCSLink side bar. EG My Products (Services/WERCSmart)
		/// </summary>
		public class NavSubSubLink : BaseNav
		{
			public int ParentLevel { get; set; }
		}

	}
}
