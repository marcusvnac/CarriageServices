Background

Lannister Carriage Services provides commute and transportation services to a number of towns in the great land of Westeros. Because of economical reasons and to avoid ambushes, most routes are "oneway". That is, a route from Volantis to King's Landing does not imply in a route from King's Landing to Volantis. In fact, even if both of these routes do happen to exist, they are distinct and are not necessarily the same distance!


Story Phrase

As a Lannister Carriage Services customer I want to know the available routes between towns as well as their distances so I can choose the best route for my travel.


Business Narrative / Scenario

The purpose of this application is to help Lannister Carriage Services provide its customers information about the routes. In particular, you will compute the distance along a certain route,
the number of different routes between two towns, and the shortest route between two towns.

============================================================================================================================
SOLUTION

The solution developed was a RESTful API with ASP.NET Web API 2.

The application was developed in following enviroment:

- Microsoft Windows 10 x64;
- Visual Studio 2015 Ultimate;
- .NET Framework 4.5;

To compile and run, open the solution file 'CarriageServices.sln' under the CarriageServices directory and execute the WebProject CarriageServices.

In localhost, the application will run in IIS Express on URI http://localhost:58004/api/CarriageServices

The develope API will provide the following methods:

	- AvailableRoutes: Computes all routes between two towns with a number maximum of stops;
			* Parameters: Start town, End town, Maximum Stops
			* HTTP Verb: GET
			* Example Call: http://localhost:58004/api/CarriageServices/AvailableRoutes/C/C/3
			* Return: List of route and cost of each route. Empty if no route is found.

	- Distance: Computes the distance bewteen two towns;
			* Parameter: Route
			* HTTP Verb: GET
			* Example Call: http://localhost:58004/api/CarriageServices/Distance/A-E-B-C-D
			* Return: Integer that represents a distance found. If returned -1, no route is found.

	- ShortestRoute: Computes the shortest route between two towns.
			* Parameter: Start town, End town
			* HTTP Verb: GET
			* Example Call: http://localhost:58004/api/CarriageServices/ShortestRoute/A/C
			* Return: Route and cost of each route. Empty if no route is found.

To use the methods above, initially you need to send the graph informations to API. 
To do this you need to call /api/CarriageServices with POST Http verb, passing the graph informations as parameter, like the exemple below:

POST http://localhost:58004/api/CarriageServices/AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7

After doing that, you will be able to use all business methods provided. 

The unit tests were created with Visual Studio buil-in unit testing framework. To run it, only open Test Explorer window and click Run All after compile the solution.