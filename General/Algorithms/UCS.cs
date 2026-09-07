using Zin.General.Interfaces;

namespace Zin.General.Algorithms
{
    public class UCS : ISearchAlgorithm
    {
        public List<GeneralNode> Search(GeneralNode start, GeneralNode goal)
        {
            List<GeneralNode> frontier = new();
            start.TotalCost = 0;
            frontier.Add(start);

            while (frontier.Count > 0)
            {
                GeneralNode current = GetLowestCostNode(frontier);

                frontier.Remove(current);
                if (current.Visited)
                    continue;

                current.Visited = true;

                Console.WriteLine(
                    "UCS: " + current.Name +
                    " Cost: " + current.TotalCost);

                if (current == goal)
                {
                    return BuildPath(start, goal);
                }

                foreach (GeneralNode child in current.Children)
                {
                    int newCost = current.TotalCost + child.Cost;

                    if (newCost < child.TotalCost)
                    {
                        child.TotalCost = newCost;
                        child.Parent = current;

                        frontier.Add(child);
                    }
                }

            }
            return new List<GeneralNode>();
        }

        private GeneralNode GetLowestCostNode(List<GeneralNode> frontier)
        {
            GeneralNode lowest = frontier[0];

            foreach (GeneralNode node in frontier)
            {
                if (node.TotalCost < lowest.TotalCost)
                {
                    lowest = node;
                }
            }

            return lowest;
        }

        private List<GeneralNode> BuildPath(GeneralNode start, GeneralNode goal)
        {
            List<GeneralNode> path = new List<GeneralNode>();
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
