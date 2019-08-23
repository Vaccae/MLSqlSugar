using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;

namespace MLSqlSugar.Multiclass
{
    /// <summary>
    /// 多类分类训练API
    /// </summary>
    public class MLMultiApi
    {
        //训练数据存档位置
        private string _modelpath = Path.Combine(
            Environment.CurrentDirectory, "stypemodel.zip");
        //定义ML的基本参数
        private MLContext _ml;
        private DataOperationsCatalog.TrainTestData _dataView;
        private IDataView _tranDataView;
        private ITransformer _trainedModel, _testModel;
        private PredictionEngine<Goods, ResGoods> _predEngine;

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="list"></param>
        public void InitData(IEnumerable<Goods> list)
        {
            //加载数据
            LoadData(list);
            //训练数据
            var pipe = TrainData();
            BuildAndTrainModel(_tranDataView, pipe);
            //测试并保存训练数据
            EvaluateAndSaveModel();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="list"></param>
        private void LoadData(IEnumerable<Goods> list)
        {
            _ml = new MLContext(0);
            //加载数据
            _tranDataView = _ml.Data.LoadFromEnumerable(list);
            //拆分数据集进行模拟训练和测试
            _dataView = _ml.Data.TrainTestSplit(_tranDataView, 0.2);
        }

        /// <summary>
        /// 训练数据
        /// </summary>
        /// <returns></returns>
        private IEstimator<ITransformer> TrainData()
        {
            //将stype转换为数字键类型Label（分类算法所接受的格式）
            //并将其添加为新的数据集列
            var pipeline = _ml.Transforms.Conversion
                .MapValueToKey(inputColumnName: "stype"
                    , outputColumnName: "Label")
            //将fname转换为名为fnameFeaturized的值的数字向量，
            //并将特征化附加到管道
            .Append(_ml.Transforms.Text
                    .FeaturizeText(inputColumnName: "fname"
                        , outputColumnName: "fnameFeaturized"))
                //                .Append(_ml.Transforms.Text
                //                .FeaturizeText(inputColumnName: "incode"
                //                    , outputColumnName: "incodeFeaturized"))
                //Concatenate() 方法将所有特征合并到“特征”列 。
                //默认情况下，学习算法仅处理“特征”列的特征 
                .Append(_ml.Transforms.Concatenate(
                    "Features", "fnameFeaturized"));

            return pipeline;
        }

        /// <summary>
        /// 训练数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pipeline"></param>
        /// <returns></returns>
        private IEstimator<ITransformer> BuildAndTrainModel(
            IDataView data, IEstimator<ITransformer> pipeline)
        {
            //SdcaMaximumEntropy 即多类分类训练算法
            var trainingPipeline = pipeline.Append(_ml.MulticlassClassification
                    .Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(_ml.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            //定型模型
            _trainedModel = trainingPipeline.Fit(data);
            //定义训练的模型进行预测
            _predEngine = _ml.Model.CreatePredictionEngine
                <Goods, ResGoods>(_trainedModel);

            Goods good=new Goods();
            good.incode = "00090";
            good.fname = "神行鞋垫";

            var prediction = _predEngine.Predict(good);
            Console.WriteLine("stype:" + prediction.stype + " percent:"+ prediction.Percent + " score:"+ prediction.Score[0] + "," + prediction.Score[1]);

            return trainingPipeline;
        }

        /// <summary>
        /// 评估模型
        /// </summary>
        public void EvaluateAndSaveModel()
        {
            //用测试数据进行预测
            var testMetrics = _ml.MulticlassClassification
                .Evaluate(_trainedModel.Transform(_dataView.TestSet));
            Console.WriteLine($"Metrics for Multi-class Classification model - Test Data     ");
            Console.WriteLine($"MicroAccuracy:    {testMetrics.MicroAccuracy:0.###}");
            Console.WriteLine($"MacroAccuracy:    {testMetrics.MacroAccuracy:0.###}");
            Console.WriteLine($"LogLoss:          {testMetrics.LogLoss:#.###}");
            Console.WriteLine($"LogLossReduction: {testMetrics.LogLossReduction:#.###}");
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
        public ResGoods Predict(Goods good)
        {
            _predEngine = _ml.Model.CreatePredictionEngine
                <Goods, ResGoods>(_testModel);

            return _predEngine.Predict(good);
        }
    }
}
