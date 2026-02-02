namespace Zin.AIBehavior
{
    public class BehaviorNode
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public List<BehaviorNode> Children { get; protected set; } = new();
        public int CurrentChildIndex { get; set; } = 0;

        public BehaviorNode()
        {
            Name = "BehaviorNode";
        }

        public BehaviorNode(string name)
        {
            Name = name;
        }

        public virtual Status Process()
        {
            return Status.Success;
        }
        public void AddChild(BehaviorNode child)
        {
            Children.Add(child);
        }
    }
}
