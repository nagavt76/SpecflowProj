using System;
using TechTalk.SpecFlow;
using FinanceSpendAnalysisFramework.PageObjects;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowRunner.Bindings
{
    [Binding]
    public class FinanceSpendAnalyzerSteps
    {
        static IWebDriver driver;
        static Payment paymentPage;
        Client restclient = new Client();

        string serverName = "";
        string databaseName = "";
        string userName = "";
        string password = "";

        [BeforeFeature, Scope(Feature = "FinanceSpendAnalyzer")]
        public static void Setup()
        {
            driver = new ChromeDriver();
            paymentPage = new Payment(driver);
        }

        [AfterFeature, Scope(Feature = "FinanceSpendAnalyzer")]
        public static void FeatureClenup()
        {
            driver.Quit();
        }

        [Given(@"Finance Spend Analyzer app is launched with '(.*)'")]
        public void GivenFinanceSpendAnalyzerAppIsLaunchedWith(string url)
        {
            paymentPage.LoadPaymentPage(url);
        }
        
        [When(@"I Enter Payment detais '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenIEnterPaymentDetais(string custId, string amt, string type, string NumberOfDay, string desc)
        {
            paymentPage.EnterPaymentDetails(custId, amt, type, NumberOfDay, desc);
        }
        
        [Then(@"Payment should be successfull and display Monthly Sppend View page with Title '(.*)'")]
        public void ThenPaymentShouldBeSuccessfullAndDisplayMonthlySppendViewPageWithTitle(string title)
        {
            Console.WriteLine("Title is: "+driver.Title);
            paymentPage.ValidatePaymentSubmit(title);
        }

        [Given(@"I have Rest API Available with '(.*)'")]
        public void GivenIHaveRestAPIAvailableWith(string url)
        {
            restclient.EndPoint = $"{url}";

            restclient.Method = Verb.GET;

            var pdata = restclient.PostData;
        }

        [When(@"I call Rest API with Parameters '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenICallRestAPIWithParameters(string custId, string amt, string type, string Date, string desc)
        {
            try
            {
                string response = restclient.Request();
                Console.WriteLine(response);
            }
            catch (Exception e)
            {
                throw new Exception("There is error while making call to API");
            }
        }

        [When(@"I call Rest API with Wrong Parameters '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenICallRestAPIWithWrongParameters(string custId, string amt, string type, string Date, string desc)
        {
            try
            {
                string response = restclient.Request($"{custId}_Invalid");
                Console.WriteLine(response);
            }
            catch
            { }
        }

        [Then(@"Server Response is Unsuccessful")]
        public void ThenServerResponseIsUnsuccessful()
        {
            if (restclient.responseCode == HttpStatusCode.OK)
            {
                throw new Exception("Rest request is bot throwing error when it is down");

            }
        }



        [Then(@"Server Response is successful")]
        public void ThenServerResponseIsSuccessful()
        {
            Console.WriteLine($"API Response code is: {restclient.responseCode}");
            if (restclient.responseCode != HttpStatusCode.OK)
            {
                throw new Exception("Rest request is not successful");
            }
            restclient.ReadJsonResponse();
        }

        [When(@"I call Rest API with Json populated from '(.*)' '(.*)' (.*) '(.*)' '(.*)' '(.*)'")]
        public void WhenICallRestAPIWithJsonPopulatedFrom(string url, string custId, int amt, string type, string date, string desc)
        {
            //Client.UpdatePaymentApi(url);
            restclient.Request();
            restclient.BuildJson(custId,  amt,  type,  date,  desc);
        }

        [Then(@"it should store data in database successfully")]
        public void ThenItShouldStoreDataInDatabaseSuccessfully()
        {
            //paymentPage.ValidateDatabaseRecords( serverName,  databaseName,  userName,  password);
        }

    }
}
