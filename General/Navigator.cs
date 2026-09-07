using Zin.General.Interfaces;

namespace Zin.General
{
    public class Navigator(ISearchAlgorithm searchAlgorithm)
    {
        private ISearchAlgorithm searchAlgorithm = searchAlgorithm;

        public void SetAlgorithm(ISearchAlgorithm searchAlgorithm)
        {
            this.searchAlgorithm = searchAlgorithm;
        }

        public List<GeneralNode> FindPath(GeneralNode start, GeneralNode goal)
        {
            ResetGraph(start);
            return searchAlgorithm.Search(start, goal);
        }

        private void ResetGraph(GeneralNode generalNode)
        {
            generalNode.Reset();

            foreach (GeneralNode child in generalNode.Children)
            {
                ResetGraph(child);
            }
        }
    }
}
