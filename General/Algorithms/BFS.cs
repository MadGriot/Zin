using Zin.General.Interfaces;

namespace Zin.General.Algorithms
{
    public class BFS : ISearchAlgorithm
    {
        public List<GeneralNode> Search(GeneralNode start, GeneralNode goal)
        {
            Queue<GeneralNode> queue = new();

            start.Visited = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                GeneralNode current = queue.Dequeue();

                Console.WriteLine($"BFS: {current.Name}");

                if (current == goal)
                {
                    return BuildPath(start, goal);
                }

                foreach (GeneralNode child in current.Children)
                {
                    if (!child.Visited)
                    {
                        child.Visited = true;
                        child.Parent = current;

                        queue.Enqueue(child);
                    }
                }
            }

            return new List<GeneralNode>();
        }

        private List<GeneralNode> BuildPath(GeneralNode start, GeneralNode goal)
        {
            List<GeneralNode> path = new();

            GeneralNode? current = goal;

            while (current != null)
            {
                path.Add(current);

                if (current == start)
                    break;

                current = current.Parent;
            }

            path.Reverse();

            return path;
        }
    }
}
