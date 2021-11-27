﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace MLNetDemo
{
    public partial class CancerModel
    {
        /// <summary>
        /// model input class for CancerModel.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"recurrence-events")]
            public string Recurrence_events { get; set; }

            [ColumnName(@"age")]
            public string Age { get; set; }

            [ColumnName(@"menopause")]
            public string Menopause { get; set; }

            [ColumnName(@"tumor-size")]
            public string Tumor_size { get; set; }

            [ColumnName(@"inv-nodes")]
            public string Inv_nodes { get; set; }

            [ColumnName(@"node-caps")]
            public string Node_caps { get; set; }

            [ColumnName(@"deg-malig")]
            public float Deg_malig { get; set; }

            [ColumnName(@"breast")]
            public string Breast { get; set; }

            [ColumnName(@"breast-quad")]
            public string Breast_quad { get; set; }

            [ColumnName(@"irradiat")]
            public string Irradiat { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for CancerModel.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName("PredictedLabel")]
            public string Prediction { get; set; }

            public float[] Score { get; set; }
        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("CancerModel.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}