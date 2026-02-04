namespace Zin.AIBehavior
{
    public class BehaviorConditionNode(string name, Func<bool> condition) : BehaviorNode(name)
    {
        public Func<bool> Condition { get; set; } = condition;
        public override Status Process() => Condition() ? Status.Success :Status.Failure;
    }
}
