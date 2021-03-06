﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlowRunner.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("WebService", Description="\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
        "f two numbers", SourceFile="Features\\WebService.feature", SourceLine=0)]
    public partial class WebServiceFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WebService.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WebService", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void GetResponseFromAPI(string custId, string amt, string type, string date, string desc, string url, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get response from API", @__tags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("I have Rest API Available with \'{0}\'", url), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When(string.Format("I call Rest API with Json populated from \'{0}\' \'{1}\' {2} \'{3}\' \'{4}\' \'{5}\'", url, custId, amt, type, date, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("Server Response is successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Get response from API, 11", new string[] {
                "regression"}, SourceLine=12)]
        public virtual void GetResponseFromAPI_11()
        {
#line 7
this.GetResponseFromAPI("11", "200", "credit", "2018-04-03T18:30:00.000+0000", "credited", "http://services.groupkt.com/state/get/IND/all", ((string[])(null)));
#line hidden
        }
        
        public virtual void NotGettingResponseWhenAPIResourceIsNotAvailable(string custId, string amt, string type, string date, string desc, string url, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Not getting response when API Resource is  not available", @__tags);
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given(string.Format("I have Rest API Available with \'{0}\'", url), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.When(string.Format("I call Rest API with Wrong Parameters \'{0}\' \'{1}\' \'{2}\' \'{3}\' \'{4}\'", custId, amt, type, date, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("Server Response is Unsuccessful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Not getting response when API Resource is  not available, 1", new string[] {
                "regression"}, SourceLine=21)]
        public virtual void NotGettingResponseWhenAPIResourceIsNotAvailable_1()
        {
#line 16
this.NotGettingResponseWhenAPIResourceIsNotAvailable("1", "100", "D", "24-04-2018", "Purchased in shoppers stop", "http://Invalid_restapi.demoqa.com/utilities/weatherfull/city/hyderabad", ((string[])(null)));
#line hidden
        }
        
        public virtual void ValidatePaymentAPIByComparingWithDatabase(string custId, string amt, string type, string date, string desc, string url, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Payment API by comparing with database", @__tags);
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given(string.Format("I have Rest API Available with \'{0}\'", url), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.When(string.Format("I call Rest API with Json populated from \'{0}\' \'{1}\' \'{2}\' \'{3}\' \'{4}\' \'{5}\'", url, custId, amt, type, date, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("it should store data in database successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Validate Payment API by comparing with database, 11", new string[] {
                "regression"}, SourceLine=30)]
        public virtual void ValidatePaymentAPIByComparingWithDatabase_11()
        {
#line 25
this.ValidatePaymentAPIByComparingWithDatabase("11", "200", "credit", "24-04-2018", "credited", "http://restapi.demoqa.com/utilities/weatherfull/city/hyderabad", ((string[])(null)));
#line hidden
        }
        
        public virtual void ValidatePaymentAPIByComparingWithRetrievalAPI(string custId, string amt, string type, string date, string desc, string url, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Payment API by comparing with retrieval API", exampleTags);
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given(string.Format("I have Rest API Available with \'{0}\'", url), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.When(string.Format("I call Rest API with Json populated from \'{0}\' \'{1}\' \'{2}\' \'{3}\' \'{4}\' \'{5}\'", url, custId, amt, type, date, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("it should store data in database successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Validate Payment API by comparing with retrieval API, 1", SourceLine=39)]
        public virtual void ValidatePaymentAPIByComparingWithRetrievalAPI_1()
        {
#line 33
this.ValidatePaymentAPIByComparingWithRetrievalAPI("1", "100", "D", "24-04-2018", "Purchased in shoppers stop", "http://restapi.demoqa.com/utilities/weatherfull/city/hyderabad", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
