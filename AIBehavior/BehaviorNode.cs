namespace Zin.AIBehavior
{
    public class BehaviorNode(string name = "BehaviorNode")
    {
        public string Name { get; set; } = name;
        public Status Status { get; set; }
        public List<BehaviorNode> Children { get; protected set; } = new();
        public int CurrentChildIndex { get; set; } = 0;

        public virtual Status Process() => Status.Success;
        public void AddChild(BehaviorNode child) => Children.Add(child);
    }
}
