This repo contains the practical work that I did as a final thesis in the IT College at Tallinn University of Technology. 
It as simple application that uses an alternative Identity system.

Microsoft ASP.NET Core authentication and authorization system Identity is built using Entity Framework in a way that does not exactly 
follow traditional software design patterns. Therefore, it is not possible to efficiently dismantle an application that uses the Identity
system into separate logical layers. Using the Identity system in its original form without modifications, one gets a solution that is 
tightly coupled with the object-relational mapper Entity Framework. Although Entity Framework is the go-to tool for working with 
relational databases, it does not support all the available database engines. This limits the number of data sources that can be used 
with an application that employs Identity. For an example it is not possible to use data files (e.g. CSV, XML), web services, 
NoSQL solutions, and relational databases that Entity Framework does not support. Architecture that is built this way does not fit 
into modern programming paradigm where one part of the application cannot be dependent and tightly coupled to a specific technology.

I created a superior alternative to the Identity system. In the developed sample application the 
authentication and authorization system is implemented as a separate abstraction layer following some well known software design patterns. 
This grants the ability to use, instead of Entity Framework, some other object-relational mapper, data files, or web services 
as the data source for Identity. Although it does not show explicit examples how to do that, using the interfaces for classes 
created in this work, it is possible to use Identity with a data source of one’s liking.