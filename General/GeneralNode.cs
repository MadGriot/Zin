namespace Zin.General
{
    public class GeneralNode(string name, int x, int y, int cost = 0)
    {
        public string Name { get; set; } = name;
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public int Cost { get; set; } = cost;
        public List<GeneralNode> Children = new();

        // Search information
        public bool Visited { get; set; }
        public int TotalCost {  get; set; }
        public GeneralNode? Parent { get; set; }

        public void AddChild(GeneralNode node)
        {
            Children.Add(node);
        }

        public void Reset()
        {
            Visited = false;
            TotalCost = int.MaxValue;
            Parent = null;
        }
    }
}
