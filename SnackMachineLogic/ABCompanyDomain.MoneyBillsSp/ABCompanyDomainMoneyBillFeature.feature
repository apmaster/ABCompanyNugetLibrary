Feature: ABCompanyDomainMoneyBillFeature
	The aim for this feature is to process dollar transactions for purchases from the 
	snack machine. 

Scenario: Add money bills produces the correct result
	Given there are two single dollar bills 
	And it gets inserted into the snack machine
	When the snack machine recieves the last dollar 
	Then the snack machine should display $2.00 
