Feature: WebService
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@regression
Scenario Outline: Get response from API
	Given I have Rest API Available with '<Url>'
	When I call Rest API with Json populated from '<Url>' '<CustId>' <Amt> '<Type>' '<Date>' '<Desc>'
	Then Server Response is successful
Examples: 
| CustId | Amt | Type   | Date                         | Desc     | Url                                           |
| 11     | 200 | credit | 2018-04-03T18:30:00.000+0000 | credited | http://services.groupkt.com/state/get/IND/all |

@regression
Scenario Outline: Not getting response when API Resource is  not available
	Given I have Rest API Available with '<Url>'
	When I call Rest API with Wrong Parameters '<CustId>' '<Amt>' '<Type>' '<Date>' '<Desc>'
	Then Server Response is Unsuccessful
Examples: 
| CustId | Amt | Type | Date       | Desc                       | Url                |
| 1      | 100 | D    | 24-04-2018 | Purchased in shoppers stop | http://Invalid_restapi.demoqa.com/utilities/weatherfull/city/hyderabad |

@regression
Scenario Outline: Validate Payment API by comparing with database 
	Given I have Rest API Available with '<Url>'
	When I call Rest API with Json populated from '<Url>' '<CustId>' '<Amt>' '<Type>' '<Date>' '<Desc>'
	Then it should store data in database successfully
Examples: 
| CustId | Amt | Type   | Date       | Desc     | Url                                        |
| 11     | 200 | credit | 24-04-2018 | credited | http://restapi.demoqa.com/utilities/weatherfull/city/hyderabad |

Scenario Outline: Validate Payment API by comparing with retrieval API 
	Given I have Rest API Available with '<Url>'
	When I call Rest API with Json populated from '<Url>' '<CustId>' '<Amt>' '<Type>' '<Date>' '<Desc>'
	
	Then it should store data in database successfully
Examples: 
| CustId | Amt | Type | Date       | Desc                       | Url                                                            |
| 1      | 100 | D    | 24-04-2018 | Purchased in shoppers stop | http://restapi.demoqa.com/utilities/weatherfull/city/hyderabad |