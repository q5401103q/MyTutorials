using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterPrintGenerator
{
    public partial class WaterPrint : Form
    {
        public WaterPrint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开文件选择器，选择原始图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrginal_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择原始图片文件";
            fileDialog.Filter = "图片文件(*.jpg,*.png)|*.jpg;*.png";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOrginal.Text = fileDialog.FileName;
            }
        }

        /// <summary>
        /// 打开文件选择器，选择水印图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaterMark_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择水印图片文件";
            fileDialog.Filter = "图片文件(*.jpg,*.png)|*.jpg;*.png";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtWaterMark.Text = fileDialog.FileName;
            }
        }

        /// <summary>
        /// 选择输出的图片的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择输出文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = dialog.SelectedPath;
            }
        }

        /// <summary>
        /// 改变自定义水印效果的启用与禁用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMarkStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMarkStyle.Checked)
            {
                gbStyle.Enabled = true;
            }
            else
            {
                gbStyle.Enabled = false;
            }
        }

        /// <summary>
        /// 改变自定义文字的启用与禁用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMartString_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMartString.Checked)
            {
                gbText.Enabled = true;
            }
            else
            {
                gbText.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tuple<bool, string> checkResult = ValidateData();
            if (!checkResult.Item1)
            {
                MessageBox.Show(checkResult.Item2);
                return;
            }

            string outputType = radioJPG.Checked ? ".jpg" : ".png";
            int paddingleft = 0;
            int paddingright = 0;
            int paddingtop = 0;
            int paddingbottom = 0;
            Single alpha = Convert.ToSingle(txtAlpha.Text);

            WatermarkDirection wmd = WatermarkDirection.TopLeft;
            if (radioLT.Checked)
            {
                wmd = WatermarkDirection.TopLeft;
                paddingleft = Convert.ToInt32(txtLTMarginLeft.Text);
                paddingtop = Convert.ToInt32(txtLTMarginTop.Text);
            }
            if (radioLB.Checked)
            {
                wmd = WatermarkDirection.BottomLeft;
                paddingleft = Convert.ToInt32(txtLBMarginLeft.Text);
                paddingbottom = Convert.ToInt32(txtLBMarginBottom.Text);
            }
            if (radioRT.Checked)
            {
                wmd = WatermarkDirection.TopRight;
                paddingtop = Convert.ToInt32(txtRTMarginTop.Text);
                paddingright = Convert.ToInt32(txtRTMarginRight.Text);
            }
            if (radioRB.Checked)
            {
                wmd = WatermarkDirection.BottomRight;
                paddingright = Convert.ToInt32(txtRBMarginRight.Text);
                paddingbottom = Convert.ToInt32(txtRBMarginBottom.Text);
            }

            try
            {
                ImageGenerator generator = new ImageGenerator();
                string target = generator.BuildWatermark(txtOrginal.Text, txtWaterMark.Text, txtOutput.Text, outputType, chkMarkStyle.Checked, chkMartString.Checked, Convert.ToInt32(txtMarkWidth.Text), Convert.ToInt32(txtMarkHeight.Text), alpha, wmd, paddingleft, paddingtop, paddingright, paddingbottom, txtMarkText.Text);

                pictureBox1.Image = Image.FromFile(target);

                MessageBox.Show("水印添加成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加水印时发生错误："+ ex.Message);
            }
        }

        private Tuple<bool, string> ValidateData()
        {
            bool flag = true;
            string msg = string.Empty;

            if (string.IsNullOrEmpty(txtOrginal.Text))
            {
                flag = false;
                msg = "原始图片路径错误";
            }
            if (string.IsNullOrEmpty(txtWaterMark.Text))
            {
                flag = false;
                msg = "水印图片路径错误";
            }
            if (string.IsNullOrEmpty(txtOutput.Text))
            {
                flag = false;
                msg = "输出图片路径错误";
            }
            if (chkMartString.Checked && string.IsNullOrEmpty(txtMarkText.Text))
            {
                flag = false;
                msg = "自定义水印文字不能为空";
            }
            if (chkMarkStyle.Checked)
            {
                if (!Regex.IsMatch(txtMarkHeight.Text, "\\d+"))
                {
                    flag = false;
                    msg = "自定义水印高度不正确";
                }
                if (!Regex.IsMatch(txtMarkWidth.Text, "\\d+"))
                {
                    flag = false;
                    msg = "自定义水印宽度不正确";
                }
                if (!Regex.IsMatch(txtAlpha.Text, "0.\\d{1,2}$|1.0"))
                {
                    flag = false;
                    msg = "透明度设置不正确";
                }
            }

            return Tuple.Create<bool, string>(flag, msg);
        }
    }
}
