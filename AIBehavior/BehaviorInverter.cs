namespace Zin.AIBehavior
{
    public class BehaviorInverter : BehaviorNode
    {
        public BehaviorInverter() : base("BehaviorInverter") { }
        public BehaviorInverter(string name) : base(name) { }
        public override Status Process()
        {
            if (Children.Count == 0)
                return Status.Failure;

            Status status = Children[CurrentChildIndex].Process();

            return status switch
            {
                Status.Running => Status.Running,
                Status.Success => Status.Failure,
                Status.Failure => Status.Success,
                _ => Status.Invalid,
            };
        }
    }
}
