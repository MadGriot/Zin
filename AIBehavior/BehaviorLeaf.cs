namespace Zin.AIBehavior
{
    public class BehaviorLeaf : BehaviorNode
    {
        public delegate Status Tick();
        public Tick? ProcessMethod;

        public BehaviorLeaf() : base("BehaviorLeaf")
        {
        }

        public BehaviorLeaf(string name, Tick processMethod) : base(name)
        {
            ProcessMethod = processMethod;
        }
        public override Status Process()
        {   
            return (ProcessMethod != null) ? ProcessMethod() : Status.Failure;
        }
    }
}
