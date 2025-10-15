public class ListFrontier : IFrontier
{
    List<Node> list = [];

    public int GetSize()
    {
        return list.Count;
    }
    
    public void Add(Node node)
    {
        list.Add(node);
    }

    public Node Take()
    {
        Node bestNode = GetBestNode();
        list.Remove(bestNode);
        return bestNode;
    }

    Node GetBestNode()
    {
        Node bestNode = new("", int.MaxValue);

        foreach (Node node in list)
        {
            if (node.GetValue() < bestNode.GetValue())
            {
                bestNode = node;
            }
        }

        return bestNode;
    }
}