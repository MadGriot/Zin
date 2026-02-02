namespace Zin.AIBehavior
{
    public record struct BehaviorNodeLevel
    {
        public int Level { get; set; }
        public BehaviorNode? BehaviorNode { get; set; }
    }
}
