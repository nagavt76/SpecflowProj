Feature: FinanceSpendAnalyzer
	In order to analyze payments analysis
	As a customer
	I want to do payments and analyze the spends in periodic manner

@regression
@payment
Scenario Outline: Add Payment successfully
	Given Finance Spend Analyzer app is launched with '<Url>'
	When I Enter Payment detais '<CustId>' '<Amt>' '<Type>' '<NumberOfDay>' '<Desc>'
	Then Payment should be successfull and display Monthly Sppend View page with Title '<ViewPageTitle>'
	Examples: 
	| CustId | Amt | Type | NumberOfDay | Desc                       | Url                                  | ViewPageTitle |
	| 2      | 100 | D    | 25          | Purchased in shoppers stop | http://localhost:49846/WebForm1.aspx | Sample Page   |

@viewTran
Scenario Outline: Validate View Page Content
	Given Finance Spend Analyzer app is launched with '<Url>'
	When I Enter Payment detais '<CustId>' '<Amt>' '<Type>' '<Date>' '<Desc>'
	Then it should display recently added transaction in Monthly Spend View Page
	Examples: 
	| CustId | Amt | Type | Date       | Desc                       | Url                |
	| 1      | 100 | D    | 24-04-2018 | Purchased in shoppers stop | https://google.com |

@BackToPayments
Scenario Outline: Back to Payments Page from View Page Content
	Given Finance Spend Analyzer app is launched with '<Url>'
	When I Enter Payment detais '<CustId>' '<Amt>' '<Type>' '<Date>' '<Desc>'
	And Go back from View Transactions page
	Then it should launch Payments home page again
	Examples: 
	| CustId | Amt | Type | Date       | Desc                       | Url                |
	| 1      | 100 | D    | 24-04-2018 | Purchased in shoppers stop | https://google.com |

@payment
Scenario Outline: Field Validations
	Given Finance Spend Analyzer app is launched with '<Url>'
	When I Enter Payment detais '<CustId>' '<Amt>' '<Type>' '<Date>' '<Desc>' with Invalid dataa
	Then it displays Error message '<Validationmessage>'
	Examples: 
	| CustId | Amt | Type | Date       | Desc                       | Url                | Validationmessage         |
	| abc    | 100 | D    | 24-04-2018 | Purchased in shoppers stop | https://google.com | Invalid Custer Id         |
	| 1      | abc | D    | 24-04-2018 | Purchased in shoppers stop | https://google.com | Invalid Amount            |
	| 1      | 100 | Abc  | 24-04-2018 | Purchased in shoppers stop | https://google.com | Invalid Transaction  Type |
	
@PaymentWithServerDown
Scenario Outline: Add Payment when API is down
	Given Finance Spend Analyzer app is launched with '<Url>'
	And ensure that payment API is down
	When I Enter Payment detais '<CustId>' '<Amt>' '<Type>' '<Date>' '<Desc>'
	Then It should display valid error message '<ErrorMessage>'
	Examples: 
	| CustId | Amt | Type | Date       | Desc                       | Url                | ErrorMessage |
	| 1      | 100 | D    | 24-04-2018 | Purchased in shoppers stop | https://google.com | ErrorMessage |

@viewTranWhenAPIisDown
Scenario Outline: Validate View Page Content When API is down
	Given Finance Spend Analyzer app is launched with '<Url>'
	And ensure that retrieval API is down
	When I Enter Payment detais '<CustId>' '<Amt>' '<Type>' '<Date>' '<Desc>'
	Then It should display valid error message '<ErrorMessage>'
	Examples: 
	| CustId | Amt | Type | Date       | Desc                       | Url                |
	| 1      | 100 | D    | 24-04-2018 | Purchased in shoppers stop | https://google.com |