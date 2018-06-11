using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceSpendAnalysisFramework.Repository
{
    class ViewTransactionsRepo
    {
        
        [FindsBy(How = How.XPath, Using = "//td[contains(.,'Smith')]")]
        public IWebElement CustId { get; set; }
    }
}
