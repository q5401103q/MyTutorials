namespace WaterPrintGenerator
{
    partial class WaterPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioPNG = new System.Windows.Forms.RadioButton();
            this.radioJPG = new System.Windows.Forms.RadioButton();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.groupBoxMark = new System.Windows.Forms.GroupBox();
            this.gbText = new System.Windows.Forms.GroupBox();
            this.txtMarkText = new System.Windows.Forms.TextBox();
            this.gbStyle = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRBMarginBottom = new System.Windows.Forms.TextBox();
            this.txtRTMarginTop = new System.Windows.Forms.TextBox();
            this.txtLBMarginBottom = new System.Windows.Forms.TextBox();
            this.txtLTMarginTop = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRBMarginRight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRTMarginRight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLBMarginLeft = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLTMarginLeft = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioRB = new System.Windows.Forms.RadioButton();
            this.radioRT = new System.Windows.Forms.RadioButton();
            this.radioLB = new System.Windows.Forms.RadioButton();
            this.radioLT = new System.Windows.Forms.RadioButton();
            this.txtMarkHeight = new System.Windows.Forms.TextBox();
            this.txtMarkWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMartString = new System.Windows.Forms.CheckBox();
            this.chkMarkStyle = new System.Windows.Forms.CheckBox();
            this.btnWaterMark = new System.Windows.Forms.Button();
            this.txtWaterMark = new System.Windows.Forms.TextBox();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.btnOrginal = new System.Windows.Forms.Button();
            this.txtOrginal = new System.Windows.Forms.TextBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxMark.SuspendLayout();
            this.gbText.SuspendLayout();
            this.gbStyle.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.groupBoxOutput);
            this.panelLeft.Controls.Add(this.groupBoxMark);
            this.panelLeft.Controls.Add(this.groupBoxMain);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(398, 557);
            this.panelLeft.TabIndex = 0;
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.label1);
            this.groupBoxOutput.Controls.Add(this.radioPNG);
            this.groupBoxOutput.Controls.Add(this.radioJPG);
            this.groupBoxOutput.Controls.Add(this.btnOutput);
            this.groupBoxOutput.Controls.Add(this.txtOutput);
            this.groupBoxOutput.Location = new System.Drawing.Point(9, 460);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(380, 85);
            this.groupBoxOutput.TabIndex = 2;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "输出图片配置";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "图片格式：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioPNG
            // 
            this.radioPNG.AutoSize = true;
            this.radioPNG.Location = new System.Drawing.Point(153, 60);
            this.radioPNG.Name = "radioPNG";
            this.radioPNG.Size = new System.Drawing.Size(47, 16);
            this.radioPNG.TabIndex = 6;
            this.radioPNG.TabStop = true;
            this.radioPNG.Text = ".PNG";
            this.radioPNG.UseVisualStyleBackColor = true;
            // 
            // radioJPG
            // 
            this.radioJPG.AutoSize = true;
            this.radioJPG.Checked = true;
            this.radioJPG.Location = new System.Drawing.Point(87, 60);
            this.radioJPG.Name = "radioJPG";
            this.radioJPG.Size = new System.Drawing.Size(47, 16);
            this.radioJPG.TabIndex = 5;
            this.radioJPG.TabStop = true;
            this.radioJPG.Text = ".JPG";
            this.radioJPG.UseVisualStyleBackColor = true;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(304, 20);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(73, 21);
            this.btnOutput.TabIndex = 3;
            this.btnOutput.Text = "选择路径";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(9, 21);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(289, 21);
            this.txtOutput.TabIndex = 2;
            // 
            // groupBoxMark
            // 
            this.groupBoxMark.Controls.Add(this.gbText);
            this.groupBoxMark.Controls.Add(this.gbStyle);
            this.groupBoxMark.Controls.Add(this.chkMartString);
            this.groupBoxMark.Controls.Add(this.chkMarkStyle);
            this.groupBoxMark.Controls.Add(this.btnWaterMark);
            this.groupBoxMark.Controls.Add(this.txtWaterMark);
            this.groupBoxMark.Location = new System.Drawing.Point(9, 70);
            this.groupBoxMark.Name = "groupBoxMark";
            this.groupBoxMark.Size = new System.Drawing.Size(380, 384);
            this.groupBoxMark.TabIndex = 1;
            this.groupBoxMark.TabStop = false;
            this.groupBoxMark.Text = "水印图片配置";
            // 
            // gbText
            // 
            this.gbText.Controls.Add(this.txtMarkText);
            this.gbText.Enabled = false;
            this.gbText.Location = new System.Drawing.Point(9, 325);
            this.gbText.Name = "gbText";
            this.gbText.Size = new System.Drawing.Size(365, 53);
            this.gbText.TabIndex = 6;
            this.gbText.TabStop = false;
            this.gbText.Text = "自定义文字";
            // 
            // txtMarkText
            // 
            this.txtMarkText.Location = new System.Drawing.Point(20, 21);
            this.txtMarkText.Name = "txtMarkText";
            this.txtMarkText.Size = new System.Drawing.Size(331, 21);
            this.txtMarkText.TabIndex = 0;
            // 
            // gbStyle
            // 
            this.gbStyle.Controls.Add(this.label13);
            this.gbStyle.Controls.Add(this.txtAlpha);
            this.gbStyle.Controls.Add(this.label12);
            this.gbStyle.Controls.Add(this.txtRBMarginBottom);
            this.gbStyle.Controls.Add(this.txtRTMarginTop);
            this.gbStyle.Controls.Add(this.txtLBMarginBottom);
            this.gbStyle.Controls.Add(this.txtLTMarginTop);
            this.gbStyle.Controls.Add(this.label11);
            this.gbStyle.Controls.Add(this.txtRBMarginRight);
            this.gbStyle.Controls.Add(this.label9);
            this.gbStyle.Controls.Add(this.txtRTMarginRight);
            this.gbStyle.Controls.Add(this.label7);
            this.gbStyle.Controls.Add(this.label10);
            this.gbStyle.Controls.Add(this.txtLBMarginLeft);
            this.gbStyle.Controls.Add(this.label8);
            this.gbStyle.Controls.Add(this.label5);
            this.gbStyle.Controls.Add(this.label6);
            this.gbStyle.Controls.Add(this.txtLTMarginLeft);
            this.gbStyle.Controls.Add(this.label4);
            this.gbStyle.Controls.Add(this.radioRB);
            this.gbStyle.Controls.Add(this.radioRT);
            this.gbStyle.Controls.Add(this.radioLB);
            this.gbStyle.Controls.Add(this.radioLT);
            this.gbStyle.Controls.Add(this.txtMarkHeight);
            this.gbStyle.Controls.Add(this.txtMarkWidth);
            this.gbStyle.Controls.Add(this.label3);
            this.gbStyle.Controls.Add(this.label2);
            this.gbStyle.Enabled = false;
            this.gbStyle.Location = new System.Drawing.Point(9, 83);
            this.gbStyle.Name = "gbStyle";
            this.gbStyle.Size = new System.Drawing.Size(365, 204);
            this.gbStyle.TabIndex = 5;
            this.gbStyle.TabStop = false;
            this.gbStyle.Text = "自定义样式";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(234, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "（数据越大越不透明）";
            // 
            // txtAlpha
            // 
            this.txtAlpha.Location = new System.Drawing.Point(286, 24);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(65, 21);
            this.txtAlpha.TabIndex = 9;
            this.txtAlpha.Text = "1.0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(239, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "透明度：";
            // 
            // txtRBMarginBottom
            // 
            this.txtRBMarginBottom.Location = new System.Drawing.Point(286, 168);
            this.txtRBMarginBottom.Name = "txtRBMarginBottom";
            this.txtRBMarginBottom.Size = new System.Drawing.Size(65, 21);
            this.txtRBMarginBottom.TabIndex = 7;
            this.txtRBMarginBottom.Text = "0";
            // 
            // txtRTMarginTop
            // 
            this.txtRTMarginTop.Location = new System.Drawing.Point(286, 139);
            this.txtRTMarginTop.Name = "txtRTMarginTop";
            this.txtRTMarginTop.Size = new System.Drawing.Size(65, 21);
            this.txtRTMarginTop.TabIndex = 7;
            this.txtRTMarginTop.Text = "0";
            // 
            // txtLBMarginBottom
            // 
            this.txtLBMarginBottom.Location = new System.Drawing.Point(286, 110);
            this.txtLBMarginBottom.Name = "txtLBMarginBottom";
            this.txtLBMarginBottom.Size = new System.Drawing.Size(65, 21);
            this.txtLBMarginBottom.TabIndex = 7;
            this.txtLBMarginBottom.Text = "0";
            // 
            // txtLTMarginTop
            // 
            this.txtLTMarginTop.Location = new System.Drawing.Point(286, 81);
            this.txtLTMarginTop.Name = "txtLTMarginTop";
            this.txtLTMarginTop.Size = new System.Drawing.Size(65, 21);
            this.txtLTMarginTop.TabIndex = 7;
            this.txtLTMarginTop.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(239, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "距下：";
            // 
            // txtRBMarginRight
            // 
            this.txtRBMarginRight.Location = new System.Drawing.Point(153, 168);
            this.txtRBMarginRight.Name = "txtRBMarginRight";
            this.txtRBMarginRight.Size = new System.Drawing.Size(65, 21);
            this.txtRBMarginRight.TabIndex = 5;
            this.txtRBMarginRight.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(239, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "距上：";
            // 
            // txtRTMarginRight
            // 
            this.txtRTMarginRight.Location = new System.Drawing.Point(153, 139);
            this.txtRTMarginRight.Name = "txtRTMarginRight";
            this.txtRTMarginRight.Size = new System.Drawing.Size(65, 21);
            this.txtRTMarginRight.TabIndex = 5;
            this.txtRTMarginRight.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "距下：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(106, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "距右：";
            // 
            // txtLBMarginLeft
            // 
            this.txtLBMarginLeft.Location = new System.Drawing.Point(153, 110);
            this.txtLBMarginLeft.Name = "txtLBMarginLeft";
            this.txtLBMarginLeft.Size = new System.Drawing.Size(65, 21);
            this.txtLBMarginLeft.TabIndex = 5;
            this.txtLBMarginLeft.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "距右：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "距上：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "距左：";
            // 
            // txtLTMarginLeft
            // 
            this.txtLTMarginLeft.Location = new System.Drawing.Point(153, 81);
            this.txtLTMarginLeft.Name = "txtLTMarginLeft";
            this.txtLTMarginLeft.Size = new System.Drawing.Size(65, 21);
            this.txtLTMarginLeft.TabIndex = 5;
            this.txtLTMarginLeft.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "距左：";
            // 
            // radioRB
            // 
            this.radioRB.AutoSize = true;
            this.radioRB.Location = new System.Drawing.Point(20, 169);
            this.radioRB.Name = "radioRB";
            this.radioRB.Size = new System.Drawing.Size(71, 16);
            this.radioRB.TabIndex = 3;
            this.radioRB.Text = "右下水印";
            this.radioRB.UseVisualStyleBackColor = true;
            // 
            // radioRT
            // 
            this.radioRT.AutoSize = true;
            this.radioRT.Location = new System.Drawing.Point(20, 140);
            this.radioRT.Name = "radioRT";
            this.radioRT.Size = new System.Drawing.Size(71, 16);
            this.radioRT.TabIndex = 3;
            this.radioRT.Text = "右上水印";
            this.radioRT.UseVisualStyleBackColor = true;
            // 
            // radioLB
            // 
            this.radioLB.AutoSize = true;
            this.radioLB.Location = new System.Drawing.Point(20, 111);
            this.radioLB.Name = "radioLB";
            this.radioLB.Size = new System.Drawing.Size(71, 16);
            this.radioLB.TabIndex = 3;
            this.radioLB.Text = "左下水印";
            this.radioLB.UseVisualStyleBackColor = true;
            // 
            // radioLT
            // 
            this.radioLT.AutoSize = true;
            this.radioLT.Checked = true;
            this.radioLT.Location = new System.Drawing.Point(20, 82);
            this.radioLT.Name = "radioLT";
            this.radioLT.Size = new System.Drawing.Size(71, 16);
            this.radioLT.TabIndex = 3;
            this.radioLT.TabStop = true;
            this.radioLT.Text = "左上水印";
            this.radioLT.UseVisualStyleBackColor = true;
            // 
            // txtMarkHeight
            // 
            this.txtMarkHeight.Location = new System.Drawing.Point(89, 51);
            this.txtMarkHeight.Name = "txtMarkHeight";
            this.txtMarkHeight.Size = new System.Drawing.Size(129, 21);
            this.txtMarkHeight.TabIndex = 2;
            this.txtMarkHeight.Text = "50";
            // 
            // txtMarkWidth
            // 
            this.txtMarkWidth.Location = new System.Drawing.Point(89, 24);
            this.txtMarkWidth.Name = "txtMarkWidth";
            this.txtMarkWidth.Size = new System.Drawing.Size(129, 21);
            this.txtMarkWidth.TabIndex = 2;
            this.txtMarkWidth.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "水印高度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "水印宽度：";
            // 
            // chkMartString
            // 
            this.chkMartString.AutoSize = true;
            this.chkMartString.Location = new System.Drawing.Point(9, 301);
            this.chkMartString.Name = "chkMartString";
            this.chkMartString.Size = new System.Drawing.Size(108, 16);
            this.chkMartString.TabIndex = 4;
            this.chkMartString.Text = "启用自定义文字";
            this.chkMartString.UseVisualStyleBackColor = true;
            this.chkMartString.CheckedChanged += new System.EventHandler(this.chkMartString_CheckedChanged);
            // 
            // chkMarkStyle
            // 
            this.chkMarkStyle.AutoSize = true;
            this.chkMarkStyle.Location = new System.Drawing.Point(9, 60);
            this.chkMarkStyle.Name = "chkMarkStyle";
            this.chkMarkStyle.Size = new System.Drawing.Size(108, 16);
            this.chkMarkStyle.TabIndex = 4;
            this.chkMarkStyle.Text = "启用自定义样式";
            this.chkMarkStyle.UseVisualStyleBackColor = true;
            this.chkMarkStyle.CheckedChanged += new System.EventHandler(this.chkMarkStyle_CheckedChanged);
            // 
            // btnWaterMark
            // 
            this.btnWaterMark.Location = new System.Drawing.Point(304, 21);
            this.btnWaterMark.Name = "btnWaterMark";
            this.btnWaterMark.Size = new System.Drawing.Size(73, 21);
            this.btnWaterMark.TabIndex = 3;
            this.btnWaterMark.Text = "选择图片";
            this.btnWaterMark.UseVisualStyleBackColor = true;
            this.btnWaterMark.Click += new System.EventHandler(this.btnWaterMark_Click);
            // 
            // txtWaterMark
            // 
            this.txtWaterMark.Location = new System.Drawing.Point(9, 21);
            this.txtWaterMark.Name = "txtWaterMark";
            this.txtWaterMark.Size = new System.Drawing.Size(289, 21);
            this.txtWaterMark.TabIndex = 2;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.btnOrginal);
            this.groupBoxMain.Controls.Add(this.txtOrginal);
            this.groupBoxMain.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(380, 52);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "原始图片配置";
            // 
            // btnOrginal
            // 
            this.btnOrginal.Location = new System.Drawing.Point(301, 20);
            this.btnOrginal.Name = "btnOrginal";
            this.btnOrginal.Size = new System.Drawing.Size(73, 21);
            this.btnOrginal.TabIndex = 2;
            this.btnOrginal.Text = "选择图片";
            this.btnOrginal.UseVisualStyleBackColor = true;
            this.btnOrginal.Click += new System.EventHandler(this.btnOrginal_Click);
            // 
            // txtOrginal
            // 
            this.txtOrginal.Location = new System.Drawing.Point(6, 20);
            this.txtOrginal.Name = "txtOrginal";
            this.txtOrginal.Size = new System.Drawing.Size(289, 21);
            this.txtOrginal.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelImage);
            this.panelRight.Controls.Add(this.panelTop);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(398, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(415, 557);
            this.panelRight.TabIndex = 1;
            // 
            // panelImage
            // 
            this.panelImage.Controls.Add(this.pictureBox1);
            this.panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage.Location = new System.Drawing.Point(0, 91);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(415, 466);
            this.panelImage.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(391, 438);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.groupBox1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(415, 91);
            this.panelTop.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相关信息";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(105, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(155, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "邮箱：lzl89788028@163.com";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(14, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(246, 25);
            this.label16.TabIndex = 1;
            this.label16.Text = "说明：本工具用于添加图片水印，严禁未经许可的商业行为。";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "作者：Jackal";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "生成图片";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WaterPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 557);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WaterPrint";
            this.Text = "水印合成工具";
            this.panelLeft.ResumeLayout(false);
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.groupBoxMark.ResumeLayout(false);
            this.groupBoxMark.PerformLayout();
            this.gbText.ResumeLayout(false);
            this.gbText.PerformLayout();
            this.gbStyle.ResumeLayout(false);
            this.gbStyle.PerformLayout();
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.GroupBox groupBoxMark;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.TextBox txtOrginal;
        private System.Windows.Forms.Button btnOrginal;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioPNG;
        private System.Windows.Forms.RadioButton radioJPG;
        private System.Windows.Forms.Button btnWaterMark;
        private System.Windows.Forms.TextBox txtWaterMark;
        private System.Windows.Forms.GroupBox gbStyle;
        private System.Windows.Forms.CheckBox chkMarkStyle;
        private System.Windows.Forms.TextBox txtRBMarginBottom;
        private System.Windows.Forms.TextBox txtRTMarginTop;
        private System.Windows.Forms.TextBox txtLBMarginBottom;
        private System.Windows.Forms.TextBox txtLTMarginTop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRBMarginRight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRTMarginRight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLBMarginLeft;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLTMarginLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioRB;
        private System.Windows.Forms.RadioButton radioRT;
        private System.Windows.Forms.RadioButton radioLB;
        private System.Windows.Forms.RadioButton radioLT;
        private System.Windows.Forms.TextBox txtMarkHeight;
        private System.Windows.Forms.TextBox txtMarkWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbText;
        private System.Windows.Forms.CheckBox chkMartString;
        private System.Windows.Forms.TextBox txtMarkText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAlpha;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}