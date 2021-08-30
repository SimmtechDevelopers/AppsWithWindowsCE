namespace PackingManagement
{
    partial class OnhandInventoryForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnhandInventoryForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btn_Search = new System.Windows.Forms.Button();
            this.comboBoxLocator = new System.Windows.Forms.ComboBox();
            this.comboBoxInventory = new System.Windows.Forms.ComboBox();
            this.txt_BoxReason = new System.Windows.Forms.TextBox();
            this.lv_Packing = new System.Windows.Forms.ListView();
            this.columnHeaderBoxNo = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(4, 33);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(231, 30);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "Search";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // comboBoxLocator
            // 
            this.comboBoxLocator.Location = new System.Drawing.Point(92, 7);
            this.comboBoxLocator.Name = "comboBoxLocator";
            this.comboBoxLocator.Size = new System.Drawing.Size(143, 22);
            this.comboBoxLocator.TabIndex = 11;
            // 
            // comboBoxInventory
            // 
            this.comboBoxInventory.Location = new System.Drawing.Point(3, 7);
            this.comboBoxInventory.Name = "comboBoxInventory";
            this.comboBoxInventory.Size = new System.Drawing.Size(83, 22);
            this.comboBoxInventory.TabIndex = 10;
            this.comboBoxInventory.SelectedIndexChanged += new System.EventHandler(this.comboBoxInventory_SelectedIndexChanged);
            // 
            // txt_BoxReason
            // 
            this.txt_BoxReason.Location = new System.Drawing.Point(4, 69);
            this.txt_BoxReason.Name = "txt_BoxReason";
            this.txt_BoxReason.Size = new System.Drawing.Size(232, 21);
            this.txt_BoxReason.TabIndex = 12;
            this.txt_BoxReason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarcodeScaned);
            // 
            // lv_Packing
            // 
            this.lv_Packing.Columns.Add(this.columnHeaderBoxNo);
            this.lv_Packing.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lv_Packing.FullRowSelect = true;
            this.lv_Packing.Location = new System.Drawing.Point(5, 96);
            this.lv_Packing.Name = "lv_Packing";
            this.lv_Packing.Size = new System.Drawing.Size(232, 195);
            this.lv_Packing.TabIndex = 13;
            this.lv_Packing.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderBoxNo
            // 
            this.columnHeaderBoxNo.Text = "Box No";
            this.columnHeaderBoxNo.Width = 240;
            // 
            // OnhandInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.lv_Packing);
            this.Controls.Add(this.txt_BoxReason);
            this.Controls.Add(this.comboBoxLocator);
            this.Controls.Add(this.comboBoxInventory);
            this.Controls.Add(this.btn_Search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "OnhandInventoryForm";
            this.Text = "Onhand Inventory";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnhandInventoryForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ComboBox comboBoxLocator;
        private System.Windows.Forms.ComboBox comboBoxInventory;
        private System.Windows.Forms.TextBox txt_BoxReason;
        private System.Windows.Forms.ListView lv_Packing;
        private System.Windows.Forms.ColumnHeader columnHeaderBoxNo;
        //private System.Windows.Forms.ColumnHeader columnHeaderInventory;
        //private System.Windows.Forms.ColumnHeader columnHeaderQuantity;
    }
}