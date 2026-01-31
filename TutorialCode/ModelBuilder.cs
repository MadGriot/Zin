using Microsoft.ML;

namespace Zin.TutorialCode
{
    public static class ModelBuilder
    {
        private static MLContext Context = new();

        //Main method
        public static void CreateModel(string inputDataFileName, string outputModelFileName)
        {
            // Load data
            var dataView = Context.Data.CreateDatabaseLoader();

            // Build training pipeline

            //Train Model

            //QUICK evaluationi of the model

            // Save the output model
        }
    }
}
