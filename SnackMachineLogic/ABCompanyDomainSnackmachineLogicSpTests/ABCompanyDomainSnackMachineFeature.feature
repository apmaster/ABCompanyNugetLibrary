Feature: SnackMachine
	The SnackMachine needs to process transactions using dollar bills.
	The transaction should  handle all possible combinations using dollar
	bills. 

Scenario: Use Case no Dollar Bill is returned
	Given Empty Transaction
	Then The Change should be Zero.

Scenario: Use Case Insert Dollar Bill in Transaaction
     Given Insert Money in Transaction
	 Then The Change Should not be zero

Scenario: Use Case Cannot Insert More than One Dollar Bill at one time
     Given Insert more than one dollar bill at once
	 Then System should throw and exception

Scenario: Use Case Dollar Bill in transaction enters SnackMachine after purchase
     Given A transaction is made for a purchase
	 Then Money gets added to the Snackmachine after the purchase
