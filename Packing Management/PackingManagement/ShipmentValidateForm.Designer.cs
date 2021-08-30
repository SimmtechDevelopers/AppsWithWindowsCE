namespace PackingManagement
{
    partial class ShipmentValidateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentValidateForm));
            this.textBoxShipment = new System.Windows.Forms.TextBox();
            this.listViewPacking = new System.Windows.Forms.ListView();
            this.columnHeaderBoxNo = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderQty = new System.Windows.Forms.ColumnHeader();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxPacking = new System.Windows.Forms.TextBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxShipment
            // 
            this.textBoxShipment.Location = new System.Drawing.Point(3, 38);
            this.textBoxShipment.Name = "textBoxShipment";
            this.textBoxShipment.Size = new System.Drawing.Size(232, 23);
            this.textBoxShipment.TabIndex = 8;
            this.textBoxShipment.GotFocus += new System.EventHandler(this.ClearTextBox);
            this.textBoxShipment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartTimer);
            // 
            // listViewPacking
            // 
            this.listViewPacking.Columns.Add(this.columnHeaderBoxNo);
            this.listViewPacking.Columns.Add(this.columnHeaderQty);
            this.listViewPacking.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listViewPacking.FullRowSelect = true;
            this.listViewPacking.Location = new System.Drawing.Point(3, 103);
            this.listViewPacking.Name = "listViewPacking";
            this.listViewPacking.Size = new System.Drawing.Size(232, 166);
            this.listViewPacking.TabIndex = 9;
            this.listViewPacking.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderBoxNo
            // 
            this.columnHeaderBoxNo.Text = "Box No";
            this.columnHeaderBoxNo.Width = 100;
            // 
            // columnHeaderQty
            // 
            this.columnHeaderQty.Text = "Quantity";
            this.columnHeaderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderQty.Width = 60;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(3, 67);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(232, 30);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(3, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(232, 28);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxPacking
            // 
            this.textBoxPacking.Location = new System.Drawing.Point(93, 190);
            this.textBoxPacking.Name = "textBoxPacking";
            this.textBoxPacking.Size = new System.Drawing.Size(116, 23);
            this.textBoxPacking.TabIndex = 12;
            this.textBoxPacking.Visible = false;
            this.textBoxPacking.GotFocus += new System.EventHandler(this.ClearTextBox);
            this.textBoxPacking.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartTimer);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(120, 226);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(48, 23);
            this.buttonCheck.TabIndex = 13;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.Visible = false;
            // 
            // ShipmentValidateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.textBoxPacking);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listViewPacking);
            this.Controls.Add(this.textBoxShipment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShipmentValidateForm";
            this.Text = "Shipment Validate Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxShipment;
        private System.Windows.Forms.ListView listViewPacking;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ColumnHeader columnHeaderBoxNo;
        private System.Windows.Forms.ColumnHeader columnHeaderQty;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxPacking;
        private System.Windows.Forms.Button buttonCheck;
    }
}