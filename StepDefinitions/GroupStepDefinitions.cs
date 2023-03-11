using LivingDoc.SpecFlowPlugin.Collectors;
using SpecFlowProject.Context;
using SpecFlowProject.Drivers;
using TechTalk.SpecFlow.Infrastructure;
using Xunit.Sdk;

namespace SpecFlowProject.StepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    [Binding]
    public sealed class GroupStepDefinitions
    {
        private readonly GroupContext _groupContext;
        private readonly IGroupsApiClient _groupsApiClient;

        public GroupStepDefinitions(GroupContext groupContext, IGroupsApiClient groupsApiClient)
        {
            _groupContext = groupContext;
            _groupsApiClient = groupsApiClient;
        }
        int capacity;

        [Given(@"a group of charge stations with capacity (\d+) A")]
        public async Task GivenAGroupOfChargeStationsWithCapacityA(int capacity)
        {
            //Read more about FluentAssertions: https://fluentassertions.com/
            capacity.Should().BeGreaterThan(0);

            var result = await _groupsApiClient.CreateGroup(new GroupRequest
            {
                Name = "Test group",
                Amps = capacity
            });

            result.Should().NotBeNull();
            result.Amps.Should().Be(capacity);

            _groupContext.CurrentGroupId = result.Id;
        }

        [When(@"capacity of the group changed to (\d+) A")]
        public async Task WhenCapacityOfTheGroupChangedToA(int capacity)
        {
            capacity.Should().BeGreaterThan(0);
            _groupContext.CurrentGroupId.Should().NotBeNull("A group should be created before the step");

            await _groupsApiClient.UpdateGroup(_groupContext.CurrentGroupId!.Value, new GroupRequest
            {
                Amps = capacity,
                Name = "Test group",
            });
        }

        [Then(@"the group has capacity (\d+) A")]
        public async Task ThenTheGroupHasCapacityA(int capacity)
        {
            capacity.Should().BeGreaterThan(0);
            _groupContext.CurrentGroupId.Should().NotBeNull("A group should be created before the step");

            var result = await _groupsApiClient.GetGroup(_groupContext.CurrentGroupId!.Value);

            result.Should().NotBeNull();
            result.Amps.Should().Be(capacity);
        }


        //Create a group 
        [Given(@"a details of Group with the name of Group A with Capacity of (.*) A")]
        public async void GivenADetailsOfGroupWithTheNameOfGroupAWithCapacityOfA(int p0)
        {
           // capacity.Should().BeGreaterThan(0);
            // ScenarioContext.StepIsPending();
           // var result = await _groupsApiClient.CreateGroup(new GroupRequest
           // { Name = "Barkha Group1",
           //     Amps = capacity
           // });

           // result.Should().NotBeNull();
           // result.Amps.Should().Be(capacity);
           // _groupContext.CurrentGroupId = result.Id;

        }

        [When(@"group is inserted")]
        public void WhenGroupIsInserted()
        {
            // ScenarioContext.StepIsPending();
            

        
    }

        [Then(@"the group with the name Group A and capacity (.*)A should get created")]
        public void ThenTheGroupWithTheNameGroupAAndCapacityAShouldGetCreated(int p0)
        {
            // ScenarioContext.StepIsPending();
        }

        //Create a Charge Station
        [Given(@"a details of Charge Station with the already existing group Group A and Charge Station name as ChargeStation A")]
        public void GivenADetailsOfChargeStationWithTheAlreadyExistingGroupGroupAAndChargeStationNameAsChargeStationA()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"Charge Station with name ChargeStation A does not exist in group Group A")]
        public void WhenChargeStationWithNameChargeStationADoesNotExistInGroupGroupA()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the charge station with the name ChargeStation A should get created")]
        public void ThenTheChargeStationWithTheNameChargeStationAShouldGetCreated()
        {
            // ScenarioContext.StepIsPending();
        }


        //Create a connector 

        [Given(@"a details of Connector with the already existing Charge Station ChargeStation A with Connector name as Connector A")]
        public void GivenADetailsOfConnectorWithTheAlreadyExistingChargeStationChargeStationAWithConnectorNameAsConnectorA()
        {
            // ScenarioContext.StepIsPending();
            Console.WriteLine("ConnectorDetails");
        }

        [When(@"Charge Station with name ChargeStation A is already exist")]
        public void WhenChargeStationWithNameChargeStationAIsAlreadyExist()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the connector with the name Connector A should get created")]
        public void ThenTheConnectorWithTheNameConnectorAShouldGetCreated()
        {
            // ScenarioContext.StepIsPending();
        }


        //Create a already Existing Charge station on other group - 
        [Given(@"a details of Charge Station with the already existing group Group B and Charge Station name as ChargeStation A")]
        public void GivenADetailsOfChargeStationWithTheAlreadyExistingGroupGroupBAndChargeStationNameAsChargeStationA()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"Charge Station with name ChargeStation A does not exist in group Group B")]
        public void WhenChargeStationWithNameChargeStationADoesNotExistInGroupGroupB()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the charge station with the name ChargeStation A should not get created since it is already exsit in Group A")]
        public void ThenTheChargeStationWithTheNameChargeStationAShouldNotGetCreatedSinceItIsAlreadyExsitInGroupA()
        {
            // ScenarioContext.StepIsPending();
        }
        //Create a Charge station without a group 


        [Given(@"a details of Charge Station with the group nane Group S which is not in the system and Charge Station name as ChargeStation C")]
        public void GivenADetailsOfChargeStationWithTheGroupNaneGroupSWhichIsNotInTheSystemAndChargeStationNameAsChargeStationC()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"Charge Station with name ChargeStation C does not exist and Group S does not available")]
        public void WhenChargeStationWithNameChargeStationCDoesNotExistAndGroupSDoesNotAvailable()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the charge station with the name ""ChargeStation C should not get created")]
        public void ThenTheChargeStationWithTheNameChargeStationCShouldNotGetCreated()
        {
            // ScenarioContext.StepIsPending();
        }
        


        //Create a connector without Charging station
        [Given(@"a details of Connector with the Charge station name  ChargeStation S which is not in the system and Connector name as ""(.*)""")]
        public void GivenADetailsOfConnectorWithTheChargeStationNameChargeStationSWhichIsNotInTheSystemAndConnectorNameAs(string p0)
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"Connector with name Connector C does not exist and ChargeStation S does not available")]
        public void WhenConnectorWithNameConnectorCDoesNotExistAndChargeStationSDoesNotAvailable()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the charge station with the name Connector C should not get created")]
        public void ThenTheChargeStationWithTheNameConnectorCShouldNotGetCreated()
        {
            // ScenarioContext.StepIsPending();
        }
        //Create multiple Charging station in 1 group at a same time 
        [Given(@"a details of Charge Station with the already existing group Group A and Charge Station name as ChargeStation D")]
        public void GivenADetailsOfChargeStationWithTheAlreadyExistingGroupGroupAAndChargeStationNameAsChargeStationD()
        {
            // ScenarioContext.StepIsPending();
        }

        [Given(@"other Charge Station name ChargeStation E")]
        public void GivenOtherChargeStationNameChargeStationE()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"Charge Station with name ChargeStation D does not exist in group Group A")]
        public void WhenChargeStationWithNameChargeStationDDoesNotExistInGroupGroupA()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"Charge Station with name ChargeStation E does not exist in group Group A")]
        public void WhenChargeStationWithNameChargeStationEDoesNotExistInGroupGroupA()
        {
            // ScenarioContext.StepIsPending();
        }
        [Then(@"the charge station with the names ChargeStation D and ChargeStation E should not get created")]
        public void ThenTheChargeStationWithTheNamesChargeStationDAndChargeStationEShouldNotGetCreated()
        {
            // ScenarioContext.StepIsPending();
        }


        //Checking the capacity of the group with total capacity of all its connector
        [Given(@"a connectors of charge stations with the capacity of (.*)A, (.*)A, (.*)A")]
        public void GivenAConnectorsOfChargeStationsWithTheCapacityOfAAA(int p0, int p1, int p2)
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"doing a total of capacity of all connectors of the group")]
        public void WhenDoingATotalOfCapacityOfAllConnectorsOfTheGroup()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the total connectors capacity should be of less than or equal to (.*) A")]
        public void ThenTheTotalConnectorsCapacityShouldBeOfLessThanOrEqualToA(int p0)
        {
            // ScenarioContext.StepIsPending();
        }

        //Create a Connector #6 in a Charge station having already 5 connectors in it
        [Given(@"a details of Connector with the Charge station name ChargeStation A which has (.*) connectors in the system and a Connector name as ""(.*)""")]
        public void GivenADetailsOfConnectorWithTheChargeStationNameChargeStationAWhichHasConnectorsInTheSystemAndAConnectorNameAs(int p0, string p1)
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"Connector with name Connector F does not exist in ChargeStation A")]
        public void WhenConnectorWithNameConnectorFDoesNotExistInChargeStationA()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the connector with the name Connector F should not get created")]
        public void ThenTheConnectorWithTheNameConnectorFShouldNotGetCreated()
        {
            // ScenarioContext.StepIsPending();
        }


        //Remove group

        [Given(@"a group of charge station with the name Group A")]
        public void GivenAGroupOfChargeStationWithTheNameGroupA()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"user delete the Group A")]
        public void WhenUserDeleteTheGroupA()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the Group A and all related Charge Stations of the group should get deleted")]
        public void ThenTheGroupAAndAllRelatedChargeStationsOfTheGroupShouldGetDeleted()
        {
            // ScenarioContext.StepIsPending();
        }



        //Remove Connectors
        [Given(@"a connector A with the already existing ChargeStation A")]
        public void GivenAConnectorAWithTheAlreadyExistingChargeStationA()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"User delete the Connector A from the ChargeStation A")]
        public void WhenUserDeleteTheConnectorAFromTheChargeStationA()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the connector A should deleted")]
        public void ThenTheConnectorAShouldDeleted()
        {
            // ScenarioContext.StepIsPending();
        }

        //Removing a Charge station from the group
        [Given(@"a Charge Station with the already existing group Group A and Charge Station name as ChargeStation A")]
        public void GivenAChargeStationWithTheAlreadyExistingGroupGroupAAndChargeStationNameAsChargeStationA()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"User delete the Charge Station with name ChargeStation A from the  Group A")]
        public void WhenUserDeleteTheChargeStationWithNameChargeStationAFromTheGroupA()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the charge station with the names ChargeStation A should  get deleted on this request")]
        public void ThenTheChargeStationWithTheNamesChargeStationAShouldGetDeletedOnThisRequest()
        {
            // ScenarioContext.StepIsPending();
        }

        //Removing Multiple Charge station from a Group
        [Given(@"a Charge Station with the already existing group Group A and Charge Station name as ChargeStation D")]
        public void GivenAChargeStationWithTheAlreadyExistingGroupGroupAAndChargeStationNameAsChargeStationD()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"user delete the Charge Station with name ChargeStation D from the  Group A")]
        public void WhenUserDeleteTheChargeStationWithNameChargeStationDFromTheGroupA()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"Charge Station with name ChargeStation E from the Group A")]
        public void WhenChargeStationWithNameChargeStationEFromTheGroupA()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the charge station with the names ChargeStation D and ChargeStation E should not get deleted on this request")]
        public void ThenTheChargeStationWithTheNamesChargeStationDAndChargeStationEShouldNotGetDeletedOnThisRequest()
        {
            // ScenarioContext.StepIsPending();
        }


        //Update Charge Station by change its Name
        [Given(@"a charge stations with name ChargeStation C in Group A")]
        public void GivenAChargeStationsWithNameChargeStationCInGroupA()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"name of the charge station changed to ChargeStation D")]
        public void WhenNameOfTheChargeStationChangedToChargeStationD()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the Charge station will Available as ChargeStation D with all existing details of connectors")]
        public void ThenTheChargeStationWillAvailableAsChargeStationDWithAllExistingDetailsOfConnectors()
        {
            // ScenarioContext.StepIsPending();
        }


        //Update Connector by changing the AMPs into negative value

        [Given(@"a connector in charge stations with capacity A")]
        public void GivenAConnectorInChargeStationsWithCapacityA()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"capacity of the connector changed to A")]
        public void WhenCapacityOfTheConnectorChangedToA()
        {
            // ScenarioContext.StepIsPending();

        }

        [Then(@"the connector has capacity  A")]
        public void ThenTheConnectorHasCapacityToA()
        {
            // ScenarioContext.StepIsPending();
        }
        //Update Connector by changing the name


        [Given(@"a connectors with name connector C in ChargeStation C")]
        public void GivenAConnectorsWithNameConnectorCInChargeStationC()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"name of the connector changed to Connector D")]
        public void WhenNameOfTheConnectorChangedToConnectorD()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the Connector will Available as connector D with the same capacity")]
        public void ThenTheConnectorWillAvailableAsConnectorDWithTheSameCapacity()
        {
            // ScenarioContext.StepIsPending();
        }


        //Update Group by Changing the Name of the Group

        [Given(@"a group of charge stations with name Group C")]
        public void GivenAGroupOfChargeStationsWithNameGroupC()
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"name of the group changed to Group D")]
        public void WhenNameOfTheGroupChangedToGroupD()
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"the group has Available as Group D with all existing details")]
        public void ThenTheGroupHasAvailableAsGroupDWithAllExistingDetails()
        {
            // ScenarioContext.StepIsPending();
        }
        //Update the Group by changing capacity into negative value
        [Given(@"there are Group (.*) with (.*)A")]
        public void GivenThereAreGroupWithA(int p0, int p1)
        {
            // ScenarioContext.StepIsPending();
        }

        [When(@"I update the (.*)A")]
        public void WhenIUpdateTheA(int p0)
        {
            // ScenarioContext.StepIsPending();
        }

        [Then(@"I capacity should be updated with (.*)A")]
        public void ThenICapacityShouldBeUpdatedWithA(int p0)
        {
            // ScenarioContext.StepIsPending();
        }



    }
}

