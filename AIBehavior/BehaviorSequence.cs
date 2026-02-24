namespace Zin.AIBehavior
{
    public class BehaviorSequence : BehaviorNode
    {
        public BehaviorSequence() : base("BehaviorSequence") { }
        public BehaviorSequence(string name) : base(name) { }
        public override Status Process()
        {
            if (Children.Count == 0)
                return Status.Failure;

            if (CurrentChildIndex >= Children.Count)
            {
                CurrentChildIndex = 0;
                return Status.Success;
            }

            Status status = Children[CurrentChildIndex].Process();

            if (status == Status.Running)
                return Status.Running;

            if (status == Status.Failure)
            {
                CurrentChildIndex = 0;
                return Status.Failure;
            }

            if (status == Status.Ended)
            {
                Status = Status.Ended;
                CurrentChildIndex = 0;
                return Status; // stop processing remaining children
            }

            // Success → move to next child
            CurrentChildIndex++;

            if (CurrentChildIndex >= Children.Count)
            {
                CurrentChildIndex = 0;
                return Status.Success;
            }

            return Status.Running;
        }
    }
}
