namespace MappingGenerator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnGenEntity = new System.Windows.Forms.Button();
            this.btnGenMapping = new System.Windows.Forms.Button();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cobTable = new System.Windows.Forms.ComboBox();
            this.txtInitialCategory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(13, 186);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 50);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "连接数据库";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnGenEntity
            // 
            this.btnGenEntity.Location = new System.Drawing.Point(150, 186);
            this.btnGenEntity.Name = "btnGenEntity";
            this.btnGenEntity.Size = new System.Drawing.Size(100, 50);
            this.btnGenEntity.TabIndex = 0;
            this.btnGenEntity.Text = "生成实体文件";
            this.btnGenEntity.UseVisualStyleBackColor = true;
            this.btnGenEntity.Click += new System.EventHandler(this.btnGenEntity_Click);
            // 
            // btnGenMapping
            // 
            this.btnGenMapping.Location = new System.Drawing.Point(284, 186);
            this.btnGenMapping.Name = "btnGenMapping";
            this.btnGenMapping.Size = new System.Drawing.Size(100, 50);
            this.btnGenMapping.TabIndex = 0;
            this.btnGenMapping.Text = "生成映射文件";
            this.btnGenMapping.UseVisualStyleBackColor = true;
            this.btnGenMapping.Click += new System.EventHandler(this.btnGenMapping_Click);
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(122, 12);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(262, 21);
            this.txtDataSource.TabIndex = 1;
            this.txtDataSource.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Source";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "请选择要生成的表名";
            // 
            // cobTable
            // 
            this.cobTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobTable.FormattingEnabled = true;
            this.cobTable.Location = new System.Drawing.Point(13, 151);
            this.cobTable.Name = "cobTable";
            this.cobTable.Size = new System.Drawing.Size(371, 20);
            this.cobTable.TabIndex = 3;
            // 
            // txtInitialCategory
            // 
            this.txtInitialCategory.Location = new System.Drawing.Point(122, 39);
            this.txtInitialCategory.Name = "txtInitialCategory";
            this.txtInitialCategory.Size = new System.Drawing.Size(263, 21);
            this.txtInitialCategory.TabIndex = 4;
            this.txtInitialCategory.Text = "DCT";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Initial Catalog";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(122, 96);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(263, 21);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Text = "Monday@1";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "User Id";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(122, 69);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(262, 21);
            this.txtUserId.TabIndex = 5;
            this.txtUserId.Text = "sa";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 251);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtInitialCategory);
            this.Controls.Add(this.cobTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.btnGenMapping);
            this.Controls.Add(this.btnGenEntity);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "EF工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnGenEntity;
        private System.Windows.Forms.Button btnGenMapping;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cobTable;
        private System.Windows.Forms.TextBox txtInitialCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserId;
    }
}

