using Zin.General.Interfaces;

namespace Zin.General.Algorithms
{
    public class AStar : ISearchAlgorithm
    {
        public List<GeneralNode> Search(GeneralNode start, GeneralNode goal)
        {
            List<GeneralNode> frontier = new();

            start.TotalCost = 0;

            frontier.Add(start);

            while (frontier.Count > 0)
            {
                GeneralNode current = GetLowestFCostNode(frontier, goal);

                frontier.Remove(current);

                if (current.Visited)
                    continue;

                current.Visited = true;

                int hCost = Heuristic(current, goal);
                int fCost = current.TotalCost + hCost;

                Console.WriteLine(
                    "A*: " + current.Name +
                    " | G: " + current.TotalCost +
                    " | H: " + hCost +
                    " | F: " + fCost);

                if (current == goal)
                {
                    return BuildPath(start, goal);
                }

                foreach (GeneralNode child in current.Children)
                {
                    int newGCost = current.TotalCost + child.Cost;

                    if (newGCost < child.TotalCost)
                    {
                        child.TotalCost = newGCost;
                        child.Parent = current;

                        frontier.Add(child);
                    }
                }
            }
            return new List<GeneralNode>();
        }

        private GeneralNode GetLowestFCostNode(List<GeneralNode> frontier, GeneralNode goal)
        {
            GeneralNode lowest = frontier[0];

            foreach (GeneralNode node in frontier)
            {
                int currentF = node.TotalCost + Heuristic(node, goal);

                int lowestF = lowest.TotalCost + Heuristic(lowest, goal);

                if (currentF < lowestF)
                {
                    lowest = node;
                }
            }
            return lowest;
        }
        private int Heuristic(GeneralNode current, GeneralNode goal)
        {
            return Math.Abs(current.X - goal.X) + Math.Abs(current.Y - goal.Y);
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
