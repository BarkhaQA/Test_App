Feature: SmartCharging
Read more about Gherkin language: https://docs.specflow.org/projects/specflow/en/latest/Gherkin/Gherkin-Reference.html
Read more how to create C# code from scenario steps: https://docs.specflow.org/projects/specflow/en/latest/visualstudio/Generating-Skeleton-Code.html

@mytag
Scenario: Change capacity of a group
	Given a group of charge stations with capacity 100 A
	When capacity of the group changed to 50 A
	Then the group has capacity 50 A


@SmokeTest
	Scenario: Create a Group
Given a details of Group with the name of Group A with Capacity of 150 A
When group is inserted
Then the group with the name Group A and capacity 150A should get created

	@SmokeTest
	Scenario: Create a Charge Station
	Given a details of Charge Station with the already existing group Group A and Charge Station name as ChargeStation A
	When Charge Station with name ChargeStation A does not exist in group Group A
	Then the charge station with the name ChargeStation A should get created
	
	@SmokeTest
	Scenario: Create a Connector
	Given a details of Connector with the already existing Charge Station ChargeStation A with Connector name as Connector A
	When Charge Station with name ChargeStation A is already exist 
	Then the connector with the name Connector A should get created

	@NegativeTest
	Scenario: Create a Charge Station without a Group
	Given a details of Charge Station with the group nane Group S which is not in the system and Charge Station name as ChargeStation C
	When Charge Station with name ChargeStation C does not exist and Group S does not available
	Then the charge station with the name "ChargeStation C should not get created

	@NegativeTest
	Scenario: Create multiple Charge Station in a Group
	Given a details of Charge Station with the already existing group Group A and Charge Station name as ChargeStation D
	And other Charge Station name ChargeStation E
	When Charge Station with name ChargeStation D does not exist in group Group A
	And Charge Station with name ChargeStation E does not exist in group Group A
	Then the charge station with the names ChargeStation D and ChargeStation E should not get created

	@NegativeTest
	Scenario: Create a already Existing Charge station on other group
	Given a details of Charge Station with the already existing group Group B and Charge Station name as ChargeStation A
	When Charge Station with name ChargeStation A does not exist in  Group B but exists in Group A
	Then the charge station with the name ChargeStation A should not get created since it is already exists in Group A

	
	@NegativeTest
	Scenario: Create a Connector without a Charge Station
	Given a details of Connector with the Charge station name  ChargeStation S which is not in the system and Connector name as "Connector C"
	When Connector with name Connector C does not exist and ChargeStation S does not available
	Then the connector with the name Connector C should not get created

	@NegativeTest
	Scenario: Create a Connector #6 in a Charge station having already 5 connectors in it
	Given a details of Connector with the Charge station name ChargeStation A which has 5 connectors in the system and a Connector name as "Connector F"
	When Connector with name Connector F does not exist in ChargeStation A
	Then the connector with the name Connector F should not get created
	

	Scenario: Update Group by Changing the Name of the Group
	Given a group of charge stations with name Group C
	When name of the group changed to Group D
	Then the group has Available as Group D with all existing details

	@NegativeTest
	Scenario: Update Connector by changing the AMPs into negative value
	Given a connector in charge stations with capacity 100 A
	When capacity of the connector changed to -50 A
	Then the connector has capacity 100 A

	Scenario: Update Charge Station by change its Name
	Given a charge stations with name ChargeStation C in Group A
	When name of the charge station changed to ChargeStation D
	Then the Charge station will Available as ChargeStation D with all existing details of connectors

	Scenario: Update Connector by changing the name
	Given a connectors with name connector C in ChargeStation C
	When name of the connector changed to Connector D
	Then the Connector will Available as connector D with the same capacity
	
	@NegativeTest @PositiveScenario
	Scenario Outline: Update Group by changing capacity
  Given there are <GroupName> with <Capacity>
  When I update the <ModifyCapacity> 
  Then I capacity should be updated with <UpdatedCapacity>

  Examples:
    | GroupName | Capacity | ModifyCapacity |UpdatedCapacity|
    |   Group 1 |   5A |    7A | 7A|
    |    Group 2 |   10A |   -15A | 10A|



	Scenario: Remove Group
	Given a group of charge station with the name Group A
	When  user delete the Group A
	Then the Group A and all related Charge Stations of the group should get deleted

	Scenario: Removing a Charge station from the group
	Given a Charge Station with the already existing group Group A and Charge Station name as ChargeStation A
	When User delete the Charge Station with name ChargeStation A from the  Group A
	Then the charge station with the names ChargeStation A should  get deleted on this request

	@NegativeTest
	Scenario: Removing Multiple Charge station from a Group
	Given a Charge Station with the already existing group Group A and Charge Station name as ChargeStation D
	And other Charge Station name ChargeStation E
	When user delete the Charge Station with name ChargeStation D from the  Group A
	And Charge Station with name ChargeStation E from the Group A
	Then the charge station with the names ChargeStation D and ChargeStation E should not get deleted on this request

	Scenario: Remove Connectors
	Given a connector A with the already existing ChargeStation A 
	When User delete the Connector A from the ChargeStation A
	Then the connector A should deleted


	Scenario: Checking the Capacity of Group with Charge Station
	Given a group of charge stations with capacity 100 A
	And a connectors of charge stations with the capacity of 10A, 30A, 40A
	When doing a total of capacity of all connectors of the group 
	Then the total connectors capacity should be of less than or equal to 100 A
	
