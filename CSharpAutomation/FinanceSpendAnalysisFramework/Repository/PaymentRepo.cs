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
    public class PaymentRepo
    {
        public By CustId() => By.Id("lst_CustId");
        public By Amt() => By.Id("txtAmount");
        public By DatePicker() => By.Id("Calendar1");
        public By Submit() => By.Id("btnSubmit");
    }
}
