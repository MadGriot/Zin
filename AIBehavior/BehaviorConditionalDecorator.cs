namespace Zin.AIBehavior
{
    public class BehaviorConditionalDecorator(string name, Func<bool> condition, BehaviorNode child) : BehaviorNode(name)
    {
        private readonly Func<bool> condition = condition;
        private readonly BehaviorNode child = child;

        public override Status Process()
        {
            if (!condition())
            {
                Status = Status.Success;
                return Status;
            }

            Status = child.Process();
            return Status;
        }

        public override void Reset()
        {
            base.Reset();
            child.Reset();
        }

    }
}
