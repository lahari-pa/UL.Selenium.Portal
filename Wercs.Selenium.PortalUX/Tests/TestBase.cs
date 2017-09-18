using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Core.Tests;
using Wercs.Selenium.PortalUX.Properties;

namespace Wercs.Selenium.PortalUX.Tests
{
	/// <summary>
	/// Base lass for test classes to inherit.
	/// </summary>
	[TestClass]
	[DeploymentItem(@"Resources\chromedriver.exe", "Resources")]
	[DeploymentItem(@"Resources\IEDriverServer.exe", "Resources")]
	public class TestBase : CoreTestBase
	{
		/// <summary>
		/// Startup operations for the entire test run.
		/// </summary>
		/// <param name="testContext">
		/// Test context information object.
		/// </param>
		[AssemblyInitialize]
		public static void AssemblyInit(TestContext testContext)
		{
			CoreAssemblyInit(testContext);
		}

		/// <summary>
		/// Cleanup operations for the entire test run.
		/// </summary>
		[AssemblyCleanup]
		public static void AssemblyCleanup()
		{
			CoreAssemblyCleanup();
		}

		/// <summary>
		/// Set up individual test environments for each test.
		/// </summary>
		[TestInitialize]
		public override void InitTest()
		{
			TestContext.Properties.Add(nameof(Settings.Default.Browser), Settings.Default.Browser);
			base.InitTest();
		}

		/// <summary>
		/// Tear down individual test environments for each test.
		/// </summary>
		[TestCleanup]
		public override void CleanupTest()
		{
			base.CleanupTest();
		}
	}
}
