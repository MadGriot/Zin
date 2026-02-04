
namespace Zin.AIBehavior
{
    public class BehaviorSelector() : BehaviorNode("BehaviorSelector")
    {
        public override Status Process()
        {
            Status childStatus = Children[CurrentChildIndex].Process();

            if (childStatus is Status.Running)
                return Status.Running;

            if (childStatus is Status.Success)
            {
                CurrentChildIndex = 0;
                return Status.Success;
            }

            return CurrentChildIndex++ >= Children.Count
                ? (CurrentChildIndex = 0) == 0
                    ? Status.Failure
                        : Status.Failure
                : Status.Running;
        }
    }
}
