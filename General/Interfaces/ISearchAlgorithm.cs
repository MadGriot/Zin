namespace Zin.General.Interfaces
{
    public interface ISearchAlgorithm
    {
        List<GeneralNode> Search(GeneralNode start, GeneralNode goal);
    }
}
