using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceSpendAnalysisFramework.Repository;
using System.Threading;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using System.Data;
using System.Data.SqlClient;

namespace FinanceSpendAnalysisFramework.PageObjects
{
    public class Payment
    {
        IWebDriver driver;
        PaymentRepo repo = new PaymentRepo();


        public Payment(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LoadPaymentPage(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void EnterPaymentDetails(string custId,string amt, string type,string numberOfDay, string desc)
        {
            
            
            SelectElement custIdSelect = new SelectElement(driver.FindElement(repo.CustId()));
            custIdSelect.SelectByText(custId);

            driver.FindElement(repo.Amt()).SendKeys(amt);

            driver.FindElement(repo.DatePicker()).Click();

            SelectDay(numberOfDay);
            driver.FindElement(repo.Submit()).Click();
        }

        public void SelectDay(string day)
        {
            IWebElement ele = driver.FindElement(By.XPath($"//table[contains(@id, 'Calendar1')]//tr//td//a[contains(text(),'{day}')]"));
            //IWebElement ele = driver.FindElement(By.XPath($"//table[contains(@id, 'Calendar1')]//tr//td//a[contains(text(),'{day}')]/../following-sibling::td[2]/a"));
            ele.Click();
            Console.WriteLine(driver.FindElement(By.XPath($"//table[contains(@id, 'Calendar1')]//tr//td//a[contains(text(),'{day}')]/../following-sibling::td[2]/a")).Text);
        }



        public void ValidatePaymentSubmit(string transactionViewPageTitle)
        {
            string title = driver.Title;

            if (title.Trim() != transactionViewPageTitle)
            {
                throw new Exception($"View Transaction page is not loaded. Current title is {title}");
            }

        }

        public void ValidateDatabaseRecords(string serverName, string databaseName, string userName, string password)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userName};Password={password}";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection is opened");
            

            SqlCommand command;
            SqlDataReader dataReader;
            string sql, output = "";

            sql = "select * from table";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            while(dataReader.Read())
            {
                output += dataReader.GetValue(0);
            }

            Console.WriteLine(output);
            cnn.Close();
        }


        
    }
}
