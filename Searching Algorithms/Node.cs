public class Node
{
    string name;
    int value;
    Node? parent;
    List<Node> children = [];

    public Node(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

    public string GetName()
    {
        return name;
    }

    public int GetValue()
    {
        return value;
    }

    public IEnumerable<Node> GetChildren()
    {
        return children;
    }

    public void AddChild(Node child)
    {
        children.Add(child);
    }

    public Node? GetParent()
    {
        return parent;
    }

    public void SetParent(Node parent)
    {
        this.parent = parent;
    }
}