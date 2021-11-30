using Microsoft.ML;
using System;
using System.IO;
using System.Reflection;

namespace MLSparkModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("retraining!");
            var DATA_FILEPATH = GetAbsolutePath(@"..\..\..\..\yelptrain.csv");
            bool exist = File.Exists(DATA_FILEPATH);
            var mlContext = new MLContext();
            IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentModel.ModelInput>(DATA_FILEPATH, hasHeader: true,separatorChar:',');
            var model = SentimentModel.RetrainPipeline(mlContext,dataView);
            mlContext.Model.Save(model, dataView.Schema, "SentimentModel.zip");
            Console.WriteLine("model saved!");
        }
        public static string GetAbsolutePath(string relativePath)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            FileInfo _dataRoot = new FileInfo(t.Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }
}
