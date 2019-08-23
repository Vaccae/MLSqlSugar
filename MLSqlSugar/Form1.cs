using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MLSqlSugar.Binary;
using MLSqlSugar.Multiclass;

namespace MLSqlSugar
{
    public partial class Form1 : Form
    {

        #region 文本框操作

        //定义文本框
        private static TextBox _tbMsg;

        //定义Action
        private Action<string> TextShowAction = new Action<string>(TextShow);

        //定义更新UI函数
        private static void TextShow(string sMsg)
        {
            //当文本行数大于500后清空
            if (_tbMsg.Lines.Length > 500)
            {
                _tbMsg.Clear();
            }

            string ShowMsg = DateTime.Now + "  " + sMsg + "\r\n";
            _tbMsg.AppendText(ShowMsg);

            //让文本框获取焦点 
            _tbMsg.Focus();
            //设置光标的位置到文本尾 
            _tbMsg.Select(_tbMsg.TextLength, 0);
            //滚动到控件光标处 
            _tbMsg.ScrollToCaret();
        }

        #endregion

        private enum MLType
        {
            多类分类,
            二元分类
        }

        private int _mltype;

        public Form1()
        {
            InitializeComponent();

            _tbMsg = tbMsg;
        }

        private void tsmnuGetGoodsData_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<Goods> goods = MultiDbApi.GetMultiData();
                TextShow("获取数据成功！共" + goods.Count() + "条数据");

                MLMultiApi mlMulti = new MLMultiApi();
                TextShow("开始训练数据");
                mlMulti.InitData(goods);
                TextShow("训练完成");
                _mltype = (int)MLType.多类分类;
            }
            catch (Exception ex)
            {
                TextShow(ex.Message);
            }
        }


        private void btnCs_Click(object sender, EventArgs e)
        {
            try
            {
                string text = textBox1.Text;
                switch (_mltype)
                {
                    case (int)MLType.多类分类:
                        MLMultiApi mlMulti = new MLMultiApi();
                        TextShow("加载模型");
                        mlMulti.InitFinalModel();
                        TextShow(text);
                        Goods goods = new Goods();
                        goods.fname = text;
                        ResGoods res = mlMulti.Predict(goods);
                        string name = MultiDbApi.GetStypeName(res.stype);   
                        TextShow("预测结果：" + res.stype + " " + name);
                        TextShow("概率：" + res.Percent + " 分数：" + res.Score[0] + " " + res.Score[1]);
                  
                        break;
                    case (int)MLType.二元分类:
                        MLbinaryApi mLbinary=new MLbinaryApi();
                        TextShow("加载二元分类模型");
                        mLbinary.InitFinalModel();
                        TextShow(text);
                        BGoods binarygood=new BGoods();
                        binarygood.fname = text;
                        ResBGoods resbinary = mLbinary.Predict(binarygood);
                        TextShow($"预测: {(Convert.ToBoolean(resbinary.isyuce) ? "杂货类" : "非杂货类")}");
                        TextShow($"概率: {resbinary.Gailv}|分数:{resbinary.Score}");
                        break;
                }
            }
            catch (Exception ex)
            {
                TextShow(ex.Message);
            }
        }

        private void tsmnubinaryinit_Click(object sender, EventArgs e)
        {
            try
            {
                List<BGoods> goods = binaryDBApi.GetBinaryData();
                TextShow("获取数据成功！共" + goods.Count + "条数据");

                var goodycount = goods.FindAll(t => t.isshengxian).ToList();
                TextShow("是生鲜的产品有" + goodycount.Count + "个");


                MLbinaryApi mLbinary = new MLbinaryApi();
                TextShow("开始训练数据");
                mLbinary.InitData(goods);
                TextShow("训练完成");
                _mltype = (int)MLType.二元分类;
            }
            catch (Exception ex)
            {
                TextShow(ex.Message);
            }
        }
    }
}
