namespace Zin.AIBehavior
{
    public class BehaviorTree : BehaviorNode
    {
        public BehaviorTree() : base("BehaviorTree")
        {
        }

        public BehaviorTree(string name) : base(name)
        {
        }

        public override Status Process()
        {
            Status status = Children[CurrentChildIndex].Process();
            if (status == Status.Ended || status == Status.Failure)
            {
                Reset(); // reset for next turn
            }
            return status;
        }
        public void PrintTree()
        {
            string treePrintout = "";
            Stack<BehaviorNodeLevel> nodeStack = new();
            BehaviorNode currentNode = this;
            nodeStack.Push(new BehaviorNodeLevel { Level = 0, BehaviorNode = currentNode });

            while (nodeStack.Count != 0)
            {
                BehaviorNodeLevel nextNode = nodeStack.Pop();
                treePrintout += new string('-', nextNode.Level) + nextNode.BehaviorNode?.Name + "\n";
                if (nextNode.BehaviorNode == null) continue;
                for (int i = (nextNode.BehaviorNode.Children.Count - 1); i >= 0; i--)
                {
                    nodeStack.Push(new BehaviorNodeLevel { Level = nextNode.Level + 1, BehaviorNode = nextNode.BehaviorNode.Children[i] });
                }

                Console.WriteLine(treePrintout);
            }

        }

        public void ResetTree() => Reset();
    }
}
