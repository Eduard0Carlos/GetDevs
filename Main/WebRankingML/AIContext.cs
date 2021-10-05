using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebRankingML
{
    public static class AIContext
    {
        public static IEnumerable<ReusmeResult> Rank(int groupId, IDataView data)
        {
            var mlContext = new MLContext();
            DataViewSchema schema;
            ITransformer predictionPipeline = mlContext.Model.Load("../WebRankingML/AIRanking/RankingModel.zip", out schema);

            var predictions = predictionPipeline.Transform(data);

            IEnumerable<ReusmeResult> serchieQueries = mlContext.Data.CreateEnumerable<ReusmeResult>(predictions, reuseRowObject: false);

            return serchieQueries.OrderByDescending(item => item.Score).ToList();
        }
    }
}
