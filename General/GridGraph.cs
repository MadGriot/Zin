using Stride.Core.Mathematics;

namespace Zin.General
{
    public class GridGraph
    {
        private readonly GeneralNode[,] nodes;

        private readonly int width;
        private readonly int length;
        private readonly float size;

        public GridGraph(int width, int length, float size)
        {
            this.width = width;
            this.length = length;
            this.size = size;

            nodes = new GeneralNode[width, length];

            CreateNodes();
            ConnectNodes();
        }

        private void CreateNodes()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    Vector3 worldPosition = new Vector3(x * size, 0, y * size);

                    nodes[x, y] = new GeneralNode($"Node_{x}_{y}", x, y, worldPosition);
                }
            }
        }

        private void ConnectNodes()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    GeneralNode current = nodes[x, y];

                    AddNeighbor(current, x + 1, y);
                    AddNeighbor(current, x - 1, y);
                    AddNeighbor(current, x, y + 1);
                    AddNeighbor(current, x, y - 1);
                    
                }
            }
        }

        private void AddNeighbor(GeneralNode current, int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= length) return;

            GeneralNode neighbor = nodes[x, y];

            neighbor.Cost = 1;

            current.AddChild(neighbor);
        }

        public GeneralNode GetNode(int x, int y)
        {
            return nodes[x, y];
        }
        public void Reset()
        {
            foreach (GeneralNode node in nodes)
            {
                node.Reset();
            }
        }
    }
}
