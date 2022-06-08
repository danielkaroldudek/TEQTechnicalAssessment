# Solution for the TEQ Technical Assessment

This is the solution for the TEQ Technical Assessment which requires to create Email Scheduler.

## Test / Run

```bash
dotnet test
```

## Run

As part of the TEQ Technical Assessment there is no hosting point. The project should be enhanced with an Infrastructure project which will be a worker process (a trigger)
subscribed to Message Queue to get the request to send Email. This process should be also containerized in Docker. As this will be the main application it will
use DI Container (Dependency Injection). Depends on the project complexity and the way of solution it may use strategies to pick the proper implementation based
on configuration or other parameters.

As part of the project there is no direct communication with the 3rd party services. The code is executed against abstraction which should be implemented
in the Infrastructure. The Email Service should be using Adapter for two reasons. The first is as that project will be playing role of the ACL (Anti Corruption Layer).
And second (Adapter) to encapsulate if any of the 3rd party will have different contract.

Communication towards Message Queue / Event Bus is also an abstraction allowing to implement variety of solutions. The basic abstraction will be also part of separated Infrastructure project.

The main application logic is in the Application layer which at this point is only one Command which will be used by the worker triggered when the command reach the Message Queue.

Domain project is holding the domain SMS object which is an aggregate root in this case as well as will hold supporting ValueObjects.

## Test

The tests are written on different level. As per the exercise we have Application layer behavioral (acceptance) tests and unit tests as well as Domain unit tests.
