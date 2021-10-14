using Domain.Entities;
using Microsoft.ML;
using Shared.Results;
using System.Collections.Generic;
using System.Linq;

namespace WebRankingML
{
    public static class AIContext
    {
        public static IEnumerable<ResumeResult> Rank(IDataView data)
        {
            var mlContext = new MLContext();
            DataViewSchema schema;
            ITransformer predictionPipeline = mlContext.Model.Load("../WebRankingML/AIRanking/RankingModel.zip", out schema);

            var predictions = predictionPipeline.Transform(data);

            IEnumerable<ResumeResult> serchieQueries = mlContext.Data.CreateEnumerable<ResumeResult>(predictions, reuseRowObject: false);

            return serchieQueries.OrderByDescending(item => item.Score).ToList();
        }

        public static IDataView PrepareData(List<ResumeAI> data)
        {
            return new MLContext().Data.LoadFromEnumerable(data);
        }
    }
}
