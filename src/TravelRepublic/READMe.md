## Requirements

All our applications are highly transactional and as such we place huge value on scalable, maintainable, good quality code using the most relevant design patterns.

This is your chance to showcase SOLID principles. We expect to see good abstractions, we would like to see some test coverage, but don’t feel that you must follow TDD.

We expect the best engineers to complete this test in around 2-3 hours, feel free to take a little more time if you need it or add some comments on what you would do with unlimited time.

Invoke the FlightBuilder.GetFlights method to get some test flights and filter out those that:
 
1. Depart before the current date/time
2. Have any segment with an arrival date before the departure date
3. Spend more than 2 hours on the ground – i.e. those with a total combined gap of over two hours between the arrival date of one segment and the departure date of the next

##Solution

Solution approached in TDD way

# Testing Strategy
## Unit Testing
TravelRepublic Unit tests  demonstrates my unit tests style including the mock I use.
I normally use unit test for more in-depth use cases that needs covering.

# Possible Improvement

Should we need to create a new filter, all we would need to do is to implement the `IFlightFilter` 
interface and add that rule in the `GetFlightSelector` method.

