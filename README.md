# Miami Heat Scouting - Implementation

Thank you for visiting this repository! This repository contains a .NET 6 RESTful API which is implemented as part of the Miami Heat technical interview assessment. In the wiki of this repository, there will be further details about the tools/technologies that were implemented. In this README file, you would find more details about the overall architecture of this implementation which goes as follows:

**API** - this directory holds the controllers, and more importantly the Startup.cs class file which allows for all the necessary dependencies to be initialized  

**API.Services** - this directory houses the service layer for the API implementation. Services have been created such that the services can be injected at will in other services, and it will not touch the database layer directly.

**API.Data** - this directory houses the database layer. There are repository interfaces and classes which will directly interact with the database through the use of a ScoutContext class.

**API.Common** - this directory houses various **d**ata **t**ransfer **o**bject models, or DTO models which the service and controllers interact with to be able to return the necessary data to the various callers.