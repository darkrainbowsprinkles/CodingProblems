public class Node
{
    string name;
    List<Node> children = [];

    public Node(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public IEnumerable<Node> GetChildren()
    {
        return children;
    }

    public void AddChild(Node child)
    {
        children.Add(child);
    }
}