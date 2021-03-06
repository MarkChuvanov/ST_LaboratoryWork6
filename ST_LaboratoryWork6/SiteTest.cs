using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ST_LaboratoryWork6
{
	[TestFixture]
	class SiteTest
	{
		private WebDriver driver;

		[SetUp]
		public void Init ()
		{
			ChromeOptions options = new();
			options.AddArgument("--headless");
			options.AddArgument("--no-sandbox");
			driver = new ChromeDriver(options);
			driver.Navigate().GoToUrl("https://www.championat.com/");
		}

		[Test]
		public void ExistsPage ()
		{
			driver.Navigate().GoToUrl("https://www.championat.com/tennis/_atp/tournament/79338/grid/");
			Assert.IsTrue(driver.Title.Contains("404"));
		}

		[Test]
		public void ExistsElement ()
		{
			Assert.IsTrue(driver.FindElement(By.ClassName("header-bottom__item")) != null);
		}

		[Test]
		public void Search ()
		{
			driver.FindElement(By.ClassName("search-top__btn")).Click();
			driver.FindElement(By.ClassName("search-top__input")).SendKeys("Россия" + "\n");
			Assert.IsFalse(driver.FindElement(By.ClassName("js-search-head")).Text.Contains("0"));
		}

		[Test]
		public void FollowLink ()
		{
			driver.FindElements(By.ClassName("header-menu-item__link"))[4].Click();
			Assert.IsTrue(driver.Title.Contains("Теннис"));
		}

		[TearDown]
		public void Finish ()
		{
			driver.Quit();
		}
	}
}