public class StackFrontier : IFrontier
{
    Stack<Node> stack = [];

    public int GetSize()
    {
        return stack.Count;
    }
    
    public void Add(Node node)
    {
        stack.Push(node);
    }

    public Node Take()
    {
        return stack.Pop();
    }
}