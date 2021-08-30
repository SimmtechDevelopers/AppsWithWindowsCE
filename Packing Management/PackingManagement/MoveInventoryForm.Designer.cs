namespace PackingManagement
{
    partial class MoveInventoryForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveInventoryForm));
            this.listViewPacking = new System.Windows.Forms.ListView();
            this.columnHeaderBoxNo = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderInventory = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderQuantity = new System.Windows.Forms.ColumnHeader();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.listViewJobs = new System.Windows.Forms.ListView();
            this.columnHeaderJob = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGradee = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderQty = new System.Windows.Forms.ColumnHeader();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxReason = new System.Windows.Forms.TextBox();
            this.comboBoxInventory = new System.Windows.Forms.ComboBox();
            this.comboBoxLocator = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listViewPacking
            // 
            this.listViewPacking.CheckBoxes = true;
            this.listViewPacking.Columns.Add(this.columnHeaderBoxNo);
            this.listViewPacking.Columns.Add(this.columnHeaderInventory);
            this.listViewPacking.Columns.Add(this.columnHeaderQuantity);
            this.listViewPacking.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listViewPacking.FullRowSelect = true;
            this.listViewPacking.Location = new System.Drawing.Point(3, 73);
            this.listViewPacking.Name = "listViewPacking";
            this.listViewPacking.Size = new System.Drawing.Size(232, 111);
            this.listViewPacking.TabIndex = 3;
            this.listViewPacking.View = System.Windows.Forms.View.Details;
            this.listViewPacking.SelectedIndexChanged += new System.EventHandler(this.listViewPacking_SelectedIndexChanged);
            this.listViewPacking.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarcodeScaned);
            // 
            // columnHeaderBoxNo
            // 
            this.columnHeaderBoxNo.Text = "Box No";
            this.columnHeaderBoxNo.Width = 70;
            // 
            // columnHeaderInventory
            // 
            this.columnHeaderInventory.Text = "Inventory";
            this.columnHeaderInventory.Width = 110;
            // 
            // columnHeaderQuantity
            // 
            this.columnHeaderQuantity.Text = "Qty";
            this.columnHeaderQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderQuantity.Width = 60;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(196, 190);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(39, 42);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Conf.";
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // listViewJobs
            // 
            this.listViewJobs.Columns.Add(this.columnHeaderJob);
            this.listViewJobs.Columns.Add(this.columnHeaderGradee);
            this.listViewJobs.Columns.Add(this.columnHeaderQty);
            this.listViewJobs.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listViewJobs.FullRowSelect = true;
            this.listViewJobs.Location = new System.Drawing.Point(3, 190);
            this.listViewJobs.Name = "listViewJobs";
            this.listViewJobs.Size = new System.Drawing.Size(187, 79);
            this.listViewJobs.TabIndex = 5;
            this.listViewJobs.View = System.Windows.Forms.View.Details;
            this.listViewJobs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarcodeScaned);
            // 
            // columnHeaderJob
            // 
            this.columnHeaderJob.Text = "Job";
            this.columnHeaderJob.Width = 80;
            // 
            // columnHeaderGradee
            // 
            this.columnHeaderGradee.Text = "Xout";
            this.columnHeaderGradee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderGradee.Width = 30;
            // 
            // columnHeaderQty
            // 
            this.columnHeaderQty.Text = "Qty";
            this.columnHeaderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderQty.Width = 60;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(197, 238);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(38, 31);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxReason
            // 
            this.textBoxReason.Location = new System.Drawing.Point(3, 44);
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(232, 23);
            this.textBoxReason.TabIndex = 7;
            // 
            // comboBoxInventory
            // 
            this.comboBoxInventory.Location = new System.Drawing.Point(3, 15);
            this.comboBoxInventory.Name = "comboBoxInventory";
            this.comboBoxInventory.Size = new System.Drawing.Size(83, 23);
            this.comboBoxInventory.TabIndex = 8;
            this.comboBoxInventory.SelectedIndexChanged += new System.EventHandler(this.comboBoxInventory_SelectedIndexChanged);
            // 
            // comboBoxLocator
            // 
            this.comboBoxLocator.Location = new System.Drawing.Point(92, 15);
            this.comboBoxLocator.Name = "comboBoxLocator";
            this.comboBoxLocator.Size = new System.Drawing.Size(143, 23);
            this.comboBoxLocator.TabIndex = 9;
            // 
            // MoveInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.comboBoxLocator);
            this.Controls.Add(this.comboBoxInventory);
            this.Controls.Add(this.textBoxReason);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.listViewJobs);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.listViewPacking);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoveInventoryForm";
            this.Text = "Move Inventory";
            this.GotFocus += new System.EventHandler(this.FocusChange);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewPacking;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.ColumnHeader columnHeaderBoxNo;
        private System.Windows.Forms.ColumnHeader columnHeaderQuantity;
        private System.Windows.Forms.ListView listViewJobs;
        private System.Windows.Forms.ColumnHeader columnHeaderJob;
        private System.Windows.Forms.ColumnHeader columnHeaderGradee;
        private System.Windows.Forms.ColumnHeader columnHeaderQty;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxReason;
        private System.Windows.Forms.ComboBox comboBoxInventory;
        private System.Windows.Forms.ComboBox comboBoxLocator;
        private System.Windows.Forms.ColumnHeader columnHeaderInventory;
    }
}