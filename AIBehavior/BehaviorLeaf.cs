namespace Zin.AIBehavior
{
    public class BehaviorLeaf : BehaviorNode
    {
        public Func<Status>? Tick { get; set; }

        public BehaviorLeaf(string name = "BehaviorLeaf", Func<Status>? tick = null)
            : base(name) => Tick = tick;
        public override Status Process() => Tick?.Invoke() ?? Status.Failure;
    }
}
