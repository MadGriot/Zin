
namespace Zin.AIBehavior
{
    public class BehaviorSelector : BehaviorNode
    {
        public BehaviorSelector() : base("BehaviorSelector") { }
        public BehaviorSelector(string name) : base(name) { }
        public override Status Process()
        {
            if (Children.Count == 0)
                return Status.Failure;

            if (CurrentChildIndex >= Children.Count)
            {
                CurrentChildIndex = 0;
                return Status.Failure;
            }

            Status status = Children[CurrentChildIndex].Process();

            if (status == Status.Running)
                return Status.Running;

            if (status == Status.Success)
            {
                CurrentChildIndex = 0;
                return Status.Success;
            }

            // Failure → try next child
            CurrentChildIndex++;

            if (CurrentChildIndex >= Children.Count)
            {
                CurrentChildIndex = 0;
                return Status.Failure;
            }

            return Status.Running;
        }
    }
}
