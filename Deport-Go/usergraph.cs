using System;
using System.Collections.Generic;
using System.Linq;

class BusRouteGraph
{
    private Dictionary<string, List<(string, int)>> adjacencyList;

    public BusRouteGraph()
    {
        adjacencyList = new Dictionary<string, List<(string, int)>>();
    }

    public void AddEdge(string from, string to, int distance)
    {
        if (!adjacencyList.ContainsKey(from))
            adjacencyList[from] = new List<(string, int)>();

        adjacencyList[from].Add((to, distance));

        if (!adjacencyList.ContainsKey(to))
            adjacencyList[to] = new List<(string, int)>();

        adjacencyList[to].Add((from, distance));
    }

    public bool ContainsCity(string city)
    {
        return adjacencyList.ContainsKey(city);
    }

    public (int, List<string>) Dijkstra(string start, string end)
    {
        Dictionary<string, int> distances = new Dictionary<string, int>();
        Dictionary<string, string> previousCities = new Dictionary<string, string>();
        HashSet<string> visited = new HashSet<string>();
        PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();

        foreach (var city in adjacencyList.Keys)
            distances[city] = int.MaxValue;

        distances[start] = 0;
        priorityQueue.Enqueue(start, 0);

        while (priorityQueue.Count > 0)
        {
            string currentCity = priorityQueue.Dequeue();

            if (currentCity == end)
                break;

            if (visited.Contains(currentCity))
                continue;

            visited.Add(currentCity);

            foreach (var (neighbor, distance) in adjacencyList[currentCity])
            {
                int newDistance = distances[currentCity] + distance;

                if (newDistance < distances[neighbor])
                {
                    distances[neighbor] = newDistance;
                    previousCities[neighbor] = currentCity;
                    priorityQueue.Enqueue(neighbor, newDistance);
                }
            }
        }

        List<string> path = new List<string>();
        string cityPointer = end;
        while (previousCities.ContainsKey(cityPointer))
        {
            path.Insert(0, cityPointer);
            cityPointer = previousCities[cityPointer];
        }
        path.Insert(0, start);

        return (distances[end], path);
    }

    public void UserGraph()
    {
        AddRoutes();

        Console.Write("Enter starting city: ");
        string startCity = Console.ReadLine();

        Console.Write("Enter destination city: ");
        string endCity = Console.ReadLine();

        if (!ContainsCity(startCity) || !ContainsCity(endCity))
        {
            Console.WriteLine("Invalid cities entered. Please try again.");
            return;
        }

        var (distance, path) = Dijkstra(startCity, endCity);
        Console.WriteLine($"\nShortest distance: {distance} km");
        Console.WriteLine("Optimal path: " + string.Join(" -> ", path));
    }

    private void AddRoutes()
    {
        AddEdge("Colombo", "Kadawatha", 18);
        AddEdge("Kadawatha", "Katunayaka", 21);
        AddEdge("Katunayaka", "Dankotuwa", 23);
        AddEdge("Dankotuwa", "Wennappuwa", 8);
        AddEdge("Wennappuwa", "Marawila", 6);
        AddEdge("Marawila", "Madampe", 12);
        AddEdge("Madampe", "Chilaw", 14);
        AddEdge("Chilaw", "Udappu", 18);
        AddEdge("Udappu", "Mahakumbukkadalawa", 20);
        AddEdge("Mahakumbukkadalawa", "Madurankuli", 15);
        AddEdge("Madurankuli", "Palaviya", 10);
        AddEdge("Palaviya", "Thabbowa", 13);
        AddEdge("Thabbowa", "Saliyawewa", 14);
        AddEdge("Saliyawewa", "Nochchiyagama", 20);
        AddEdge("Nochchiyagama", "Anuradhapura", 17);

        AddEdge("Colombo", "Kadawatha", 18);
        AddEdge("Kadawatha", "Gampaha", 15);
        AddEdge("Gampaha", "Pothuhera", 26);
        AddEdge("Pothuhera", "Ibbagamuwa", 20);
        AddEdge("Ibbagamuwa", "Gokarella", 15);
        AddEdge("Gokarella", "Melsiripura", 12);
        AddEdge("Melsiripura", "Galewela", 25);
        AddEdge("Galewela", "Madatugama", 15);
        AddEdge("Madatugama", "Maradankadawala", 20);
        AddEdge("Maradankadawala", "Thirappane", 18);
        AddEdge("Thirappane", "Nachchaduwa", 15);
        AddEdge("Nachchaduwa", "Anuradhapura", 15);

        AddEdge("Colombo", "Kadawatha", 18);
        AddEdge("Kadawatha", "Gampaha", 15);
        AddEdge("Gampaha", "Mirigama", 24);
        AddEdge("Mirigama", "Alawwa", 18);
        AddEdge("Alawwa", "Pothuhera", 20);
        AddEdge("Pothuhera", "Kurunegala", 14);
        AddEdge("Kurunegala", "Mahakeliya", 12);
        AddEdge("Mahakeliya", "Wariyapola", 10);
        AddEdge("Wariyapola", "Maho", 18);
        AddEdge("Maho", "Ambanpola", 15);
        AddEdge("Ambanpola", "Galgamuwa", 14);
        AddEdge("Galgamuwa", "Thabuttegama", 20);
        AddEdge("Thabuttegama", "Talawa", 15);
        AddEdge("Talawa", "Anuradhapura", 13);
    }
}