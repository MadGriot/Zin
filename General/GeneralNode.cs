namespace Zin.General
{
    public class GeneralNode(string name, int cost = 0)
    {
        public string Name { get; set; } = name;
        public int Cost { get; set; } = cost;
        public List<GeneralNode> Children = new();

        public void AddChild(GeneralNode node)
        {
            Children.Add(node);
        }

    }
}
