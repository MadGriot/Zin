using Zin.General.Interfaces;

namespace Zin.General.Algorithms
{
    public class DFS : ISearchAlgorithm
    {
        public List<GeneralNode> Search(GeneralNode start, GeneralNode goal)
        {
            Stack<GeneralNode> stack = new();
            HashSet<GeneralNode> visited = new();

            stack.Push(start);

            while (stack.Count > 0)
            {
                GeneralNode current = stack.Pop();

                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                if (current == goal)
                    return new List<GeneralNode> { current };

                foreach (GeneralNode child in current.Children)
                {
                    stack.Push(child);
                }
            }
            return null!;
        }
    }
}
