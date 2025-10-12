public class Graph
{
    Dictionary<string, Node> nodes = [];

    public void AddNodes(string[] names)
    {
        foreach (string name in names)
        {
            Node newNode = new(name);
            nodes[name] = newNode;
        }
    }

    public void AddChildren(string parent, string[] children)
    {
        foreach (string child in children)
        {
            Node parentNode = nodes[parent];
            Node childNode = nodes[child];
            parentNode.AddChild(childNode);
        }
    }
    
    public List<Node> DepthFirstSearch(string start, string goal)
    {
        return BlindSearch(new StackFrontier(), "DFS", start, goal);
    }

    public List<Node> BreadthFirstSearch(string start, string goal)
    {
        return BlindSearch(new QueueFrontier(), "BFS", start, goal);
    }

    List<Node> BlindSearch(IFrontier frontier, string searchName, string start, string goal)
    {
        Node startNode = nodes[start];
        Node goalNode = nodes[goal];

        HashSet<Node> visited = [];
        Dictionary<Node, Node?> parents = [];

        frontier.Add(startNode);

        parents[startNode] = null;

        while (frontier.GetSize() != 0)
        {
            Node currentNode = frontier.Take();

            VisitNode(frontier, visited, parents, currentNode);

            if (currentNode == goalNode)
            {
                break;
            }
        }

        List<Node> path = GetPath(parents, goalNode);

        Console.WriteLine($"----{searchName}----");
        PrintGraph();
        PrintNodes(visited, "Visited:", ",");
        PrintNodes(path, "Path:", "->");

        return path;
    }

    void VisitNode(IFrontier frontier, HashSet<Node> visited, Dictionary<Node, Node?> parents, Node currentNode)
    {
        visited.Add(currentNode);

        foreach (Node child in currentNode.GetChildren())
        {
            if (visited.Contains(child))
            {
                continue;
            }

            parents[child] = currentNode;
            frontier.Add(child);
        }
    }

    List<Node> GetPath(Dictionary<Node, Node?> parents, Node goalNode)
    {
        List<Node> path = [];
        Node? currentNode = goalNode;

        while (currentNode != null)
        {
            path.Add(currentNode);
            currentNode = parents[currentNode];
        }

        path.Reverse();
        return path;
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

    void PrintGraph()
    {
        Console.WriteLine("Graph:");

        foreach (var pair in nodes)
        {
            Console.Write($"{pair.Key}:");
            PrintNodeArray(pair.Value.GetChildren().ToArray(), ",");
        }
    }
}