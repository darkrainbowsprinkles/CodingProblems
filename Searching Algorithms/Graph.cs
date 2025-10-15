public class Graph
{
    Dictionary<string, Node> nodesLookup = [];

    public void AddNodes(string[] names, int[] values)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Node newNode = new(names[i], values[i]);
            nodesLookup[names[i]] = newNode;
        }
    }

    public void AddChildren(string parent, string[] children)
    {
        foreach (string child in children)
        {
            Node parentNode = nodesLookup[parent];
            Node childNode = nodesLookup[child];
            parentNode.AddChild(childNode);
        }
    }
    
    public List<Node> DepthFirstSearch(string start, string goal)
    {
        return Search(new StackFrontier(), "DFS", start, goal);
    }

    public List<Node> BreadthFirstSearch(string start, string goal)
    {
        return Search(new QueueFrontier(), "BFS", start, goal);
    }

    public List<Node> GreedyBestFirstSearch(string start, string goal)
    {
        return Search(new ListFrontier(), "Greedy Best First Search", start, goal);
    }
    
    List<Node> Search(IFrontier frontier, string searchName, string start, string goal)
    {
        Node startNode = nodesLookup[start];
        Node goalNode = nodesLookup[goal];
        HashSet<Node> visited = [];

        frontier.Add(startNode);

        while (frontier.GetSize() != 0)
        {
            Node currentNode = frontier.Take();

            VisitNode(frontier, visited, currentNode);

            if (currentNode == goalNode)
            {
                break;
            }
        }

        List<Node> path = GetPath(goalNode);

        PrintSearch(searchName, visited, path);

        return path;
    }

    void VisitNode(IFrontier frontier, HashSet<Node> visited, Node currentNode)
    {
        visited.Add(currentNode);

        foreach (Node child in currentNode.GetChildren())
        {
            if (visited.Contains(child))
            {
                continue;
            }

            child.SetParent(currentNode);
            frontier.Add(child);
        }
    }

    List<Node> GetPath(Node goalNode)
    {
        List<Node> path = [];
        Node? currentNode = goalNode;

        while (currentNode != null)
        {
            path.Add(currentNode);
            currentNode = currentNode.GetParent();
        }

        path.Reverse();
        return path;
    }

    void PrintSearch(string searchName, HashSet<Node> visited, List<Node> path)
    {
        Console.WriteLine($"----{searchName}----");
        PrintGraph();

        if (searchName == "Greedy Best First Search")
        {
            PrintValues();
        }

        PrintNodes(visited, "Visited:", ",");
        PrintNodes(path, "Path:", "->");
    }

    void PrintNodes(IEnumerable<Node> nodes, string title, string separator)
    {
        Node[] nodesArray = [.. nodes];
        Console.Write(title);
        PrintNodeArray(nodesArray, separator);
    }

    void PrintNodeArray(Node[] nodes, string separator)
    {
        Console.Write("[");

        for (int i = 0; i < nodes.Length; i++)
        {
            Console.Write(nodes[i].GetName());

            if (i < nodes.Length - 1)
            {
                Console.Write(separator);
            }
        }

        Console.WriteLine("]");
    }
    
    void PrintValues()
    {
        Console.Write("Values h(n): [");

        Node[] nodes = nodesLookup.Values.ToArray();

        for (int i = 0; i < nodes.Length; i++)
        {
            Console.Write($"{nodes[i].GetName()}:{nodes[i].GetValue()}");

            if (i < nodes.Length - 1)
            {
                Console.Write(",");
            }
        }

        Console.WriteLine("]");
    }

    void PrintGraph()
    {
        Console.WriteLine("Graph:");

        foreach (var pair in nodesLookup)
        {
            Console.Write($"{pair.Key}:");
            PrintNodeArray(pair.Value.GetChildren().ToArray(), ",");
        }
    }
}