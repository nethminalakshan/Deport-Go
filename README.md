
# Deport-Go

Deport-Go is a C# console application designed to manage users and provide shortest route calculations between cities using a bus route graph. The project implements a custom linked list for user management and uses Dijkstra's algorithm for finding optimal paths on a bus route network.

## Features

- **User Management**
  - Add users to the list (front, back, or at specified index)
  - Delete users by username
  - Verify user credentials (username + password)
  - Search user details by username
  - Print user list in tabular format
  - Sort users by NIC, username, or phone number using selection sort, quick sort, and insertion sort respectively

- **Bus Route Graph**
  - Add routes between cities with distances
  - Compute shortest path and distance between two cities using Dijkstra's algorithm
  - Interactive console input for starting city and destination city with route output

## Project Structure

- `BusRouteGraph` (usergraph.cs)  
  Implements a weighted undirected graph of bus routes and Dijkstra's shortest path algorithm.

- `userlist` (userlist.cs)  
  Custom singly linked list to manage user nodes, including adding, deleting, sorting, and searching users.

- `usernode` (usernode.cs)  
  Represents a user node with properties such as username, password, email, phone, address, and NIC.

- `Deport-Go.sln`  
  Visual Studio solution file for the Deport-Go project.

## How to Run

1. Open the solution `Deport-Go.sln` in Visual Studio.
2. Build the project to restore dependencies and compile.
3. Run the console application.
4. For the bus route feature, you will be prompted to enter a starting city and a destination city.
5. The application will output the shortest distance and optimal path.
6. For user management, use the methods in `userlist` class to add, remove, print, verify, and sort users.

## Example Usage

```csharp
var graph = new BusRouteGraph();
graph.UserGraph(); // Interactive console interface for shortest path

var users = new userlist();
users.AddFront("John Doe", "jdoe", "pass123", "jdoe@example.com", "0712345678", "Some Address", "123456789V");
users.Print();
bool isValid = users.verification("jdoe", "pass123");
Console.WriteLine("User valid? " + isValid);
````

## Dependencies

* .NET Framework compatible with Visual Studio 2022 (version 17)
* No external libraries required

## Future Improvements

* Integration of GPS data for real-time route updates
* Use of a database to manage users and routes dynamically
* Application of Machine Learning and AI techniques for route optimization and predictive analytics

