# .NetFrameworkDDD
DDD Project based on .Net Framework 4.8.1

*Run using IIS Express and Application as Startup Project. Set Application project Start Action as "Don't open a page."*
*Postman collection available in Postman folder.*

Contains:
* Basic CRUD operations using Entity Framework 6
* Dependency injection with Unity
* Entity-Dto mapping using Automapper
* Language handling using Resources file
* Password hashing
* GUID and creation/modification dates generated directly in SQL
* JWT Authentication with custom RequiresAuthorization tag
* Unit testing

Designed with Microsoft guidelines: 
* https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/net-core-microservice-domain-model
* https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice
