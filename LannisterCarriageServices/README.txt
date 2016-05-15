The solution developed was a RESTful API created with ASP.NET Web API 2.

The application was created in following enviroment:

- Microsoft Windows 7 / 8.1 x64;
- Visual Studio 2013 Ultimate;
- .NET Framework 4.5;

To compile and run, open the solution file 'CarriageServices.sln' under the CarriageServices directory and execute the WebProject CarriageServices.

In localhost, the application will run in IIS Express on URI http://localhost:58004/api/CarriageServices

The created API will provide the following methods:

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

* The algorithm that provides the AvaiableRoutes method has some kind of a problem, so I can't provide at this moment all expected returns.

