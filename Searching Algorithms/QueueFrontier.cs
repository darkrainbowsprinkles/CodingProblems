public class QueueFrontier : IFrontier
{
    Queue<Node> queue = [];

    public int GetSize()
    {
        return queue.Count;
    }
    
    public void Add(Node node)
    {
        queue.Enqueue(node);
    }

    public Node Take()
    {
        return queue.Dequeue();
    }
}