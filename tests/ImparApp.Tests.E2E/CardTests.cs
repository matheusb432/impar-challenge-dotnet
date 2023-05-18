using ImparApp.Tests.E2E.Utils;

namespace ImparApp.Tests.E2E
{
    [TestClass]
    public sealed class CardTests
    {
        private static IWebDriver _driver = null!;

        public static readonly string Url = PageUrls.CardsUrl;

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            _driver = new ChromeDriver();

            WebDriverUtils.SetDriverScreenSize(_driver);
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }

        [TestInitialize]
        public void InitializeTest() => _driver = WebDriverUtils.InitializeTest(_driver);

        [TestCleanup]
        public void CleanupTest() { }

        [TestMethod]
        public void CreateCard_ShouldCreateAndRedirectToList()
        {
            CreateFlow(_driver);

            Assert.AreEqual(PageUrls.CardsUrl, _driver.Url);
        }

        [TestMethod]
        public void UpdateCard_ShouldCreateAndUpdateCard()
        {
            UpdateFlow(_driver);

            Assert.AreEqual(PageUrls.CardsUrl, _driver.Url);
        }

        [TestMethod]
        public void DeleteCard_ShouldCreateAndDeleteCard()
        {
            var name = CreateFlow(_driver);
            DeleteFlow(_driver, name);

            Assert.AreEqual(PageUrls.CardsUrl, _driver.Url);
        }

        public static string CreateFlow(IWebDriver driver)
        {
            var name = $"Card - {WebDriverUtils.RandomString(5)}";
            driver.Navigate().GoToUrl(PageUrls.CardsUrl);

            driver.FindElementWithWait(By.Name("header-new-card")).Click();
            driver.FindElementWithWait(By.Id("cardName")).SendKeys(name);
            driver.FindElementWithWait(By.Id("cardStatus")).SendKeys("status test");

            driver.FindElement(By.Id("cardPhoto")).Clear();
            driver
                .FindElement(By.Id("cardPhoto"))
                .SendKeys("C:\\impar-app\\test-assets\\dotnet.png");

            driver.FindElementWithWait(By.Name("form-submit")).Click();

            Thread.Sleep(100);

            WebDriverUtils.WaitUntilRedirected(_driver, PageUrls.CardsUrl);

            return name;
        }

        public static string UpdateFlow(IWebDriver driver)
        {
            var name = CreateFlow(driver);

            driver.FindElementWithWait(By.Id("searchCards")).Clear();
            driver.FindElementWithWait(By.Id("searchCards")).SendKeys(name);
            driver.FindElementWithWait(By.Id("searchCards")).SendKeys(Keys.Enter);
            driver.FindElementWithWait(By.Id("searchCards")).SendKeys(Keys.Enter);
            driver.FindElementWithWait(By.Name("edit-card-item0")).Click();

            var editedName = $"{name} -- edit";

            driver.FindElementWithWait(By.Id("cardName")).SendKeys(editedName);
            driver.FindElementWithWait(By.Name("form-submit")).Click();
            Thread.Sleep(100);
            WebDriverUtils.WaitUntilRedirected(_driver, PageUrls.CardsUrl);
            return name;
        }

        public static void DeleteFlow(IWebDriver driver, string name)
        {
            driver.FindElementWithWait(By.Id("searchCards")).Clear();
            driver.FindElementWithWait(By.Id("searchCards")).SendKeys(name);
            driver.FindElementWithWait(By.Id("searchCards")).SendKeys(Keys.Enter);
            driver.FindElementWithWait(By.Name("delete-card-item0")).Click();
            driver.FindElementWithWait(By.Name("modal-confirm")).Click();
        }
    }
}
