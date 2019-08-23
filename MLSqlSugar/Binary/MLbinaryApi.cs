using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using MLSqlSugar.Multiclass;

namespace MLSqlSugar.Binary
{
    public class MLbinaryApi
    {
        //训练数据存档位置
        private string _modelpath = Path.Combine(
            Environment.CurrentDirectory, "binarymodel.zip");
        //定义ML的基本参数
        private MLContext _ml;
        private DataOperationsCatalog.TrainTestData _dataView;
        private ITransformer _trainedModel, _testModel;
        private PredictionEngine<BGoods, ResBGoods> _predEngine;


        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="list"></param>
        public void InitData(List<BGoods> list)
        {
            //加载数据
            LoadData(list);
            //训练数据
            var pipe = TrainData();   
            //测试并保存训练数据
            EvaluateAndSaveModel();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="list"></param>
        private void LoadData(List<BGoods> list)
        {
            _ml = new MLContext();
            //加载数据
            IDataView dataView = _ml.Data.LoadFromEnumerable(list);
            //拆分数据集进行模拟训练和测试
            _dataView = _ml.Data.TrainTestSplit(dataView, 0.2);
        }

        /// <summary>
        /// 训练数据
        /// </summary>
        /// <returns></returns>
        private IEstimator<ITransformer> TrainData()
        {
            var pipeline = _ml.Transforms.Text
                    .FeaturizeText(inputColumnName: nameof(BGoods.fname)
                        , outputColumnName: "Features")
                    .Append(_ml.BinaryClassification
                        .Trainers.SdcaLogisticRegression(labelColumnName: "Label"
                            , featureColumnName: "Features"));

            //定型模型
            _trainedModel = pipeline.Fit(_dataView.TrainSet);

            return pipeline;
        }

        /// <summary>
        /// 评估模型
        /// </summary>
        public void EvaluateAndSaveModel()
        {
            //用测试数据进行预测
            var testMetrics = _ml.BinaryClassification
                .Evaluate(_trainedModel.Transform(_dataView.TestSet),"Label");
            Console.WriteLine("Model quality metrics evaluation");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Accuracy: {testMetrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {testMetrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1Score: {testMetrics.F1Score:P2}");
            Console.WriteLine("=============== End of model evaluation ===============");
            //保存模型
            _ml.Model.Save(_trainedModel, _dataView.TrainSet.Schema, _modelpath);
        }

        /// <summary>
        /// 初始化并加载保存的模型
        /// </summary>
        public void InitFinalModel()
        {
            _ml = new MLContext(0);
            _testModel = _ml.Model.Load(_modelpath, out var modelInputSchema);
        }

        /// <summary>
        /// 进行预测
        /// </summary>
        /// <param name="good"></param>
        /// <returns></returns>
        public ResBGoods Predict(BGoods good)
        {
            _predEngine = _ml.Model.CreatePredictionEngine
                <BGoods, ResBGoods>(_testModel);

            return _predEngine.Predict(good);
        }
    }
}
