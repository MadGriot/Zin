namespace Zin.AIBehavior
{
    public class BehaviorSequence() : BehaviorNode("BehaviorSequence")
    {
        public override Status Process()
        {
            Status childStatus = Children[CurrentChildIndex].Process();
            if (childStatus is Status.Running or Status.Failure) 
                return childStatus;

            return CurrentChildIndex++ >= Children.Count
                ? (CurrentChildIndex = 0) == 0
                    ? Status.Success 
                        : Status.Success 
                : Status.Running;
        }
    }
}
