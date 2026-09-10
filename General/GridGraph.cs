using Stride.Core.Mathematics;

namespace Zin.General
{
    public class GridGraph
    {
        public GeneralNode[,] Nodes { get; private set; }

        public int Width { get; private set; }
        public int Length { get; private set; }
        public float Size { get; private set; }

        public GridGraph(int width, int length, float size)
        {
            Width = width;
            Length = length;
            Size = size;

            Nodes = new GeneralNode[width, length];

            CreateNodes();
            ConnectNodes();
        }

        private void CreateNodes()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    Vector3 worldPosition = new Vector3(x * Size, 0, y * Size);

                    Nodes[x, y] = new GeneralNode($"Node_{x}_{y}", x, y, worldPosition);
                }
            }
        }

        private void ConnectNodes()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    GeneralNode current = Nodes[x, y];

                    AddNeighbor(current, x + 1, y);
                    AddNeighbor(current, x - 1, y);
                    AddNeighbor(current, x, y + 1);
                    AddNeighbor(current, x, y - 1);
                    
                }
            }
        }

        private void AddNeighbor(GeneralNode current, int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Length) return;

            GeneralNode neighbor = Nodes[x, y];

            neighbor.Cost = 1;

            current.AddChild(neighbor);
        }

        public GeneralNode GetNode(int x, int y)
        {
            return Nodes[x, y];
        }
        public void Reset()
        {
            foreach (GeneralNode node in Nodes)
            {
                node.Reset();
            }
        }
    }
}
