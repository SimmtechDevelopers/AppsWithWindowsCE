namespace PackingManagement
{
    partial class MainForm
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
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemMoveInventory = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemShipmentValidate = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemOnHandInventory = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuItem1);
            this.mainMenu.MenuItems.Add(this.menuItem2);
            this.mainMenu.MenuItems.Add(this.menuItem3);
            this.mainMenu.MenuItems.Add(this.menuItemExit);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItemMoveInventory);
            this.menuItem1.Text = "Packing";
            // 
            // menuItemMoveInventory
            // 
            this.menuItemMoveInventory.Text = "Move Inventory";
            this.menuItemMoveInventory.Click += new System.EventHandler(this.menuItemMoveInventory_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuItemShipmentValidate);
            this.menuItem2.Text = "Shipment";
            // 
            // menuItemShipmentValidate
            // 
            this.menuItemShipmentValidate.Text = "Shipment Validate";
            this.menuItemShipmentValidate.Click += new System.EventHandler(this.menuItemShipmentValidate_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.MenuItems.Add(this.menuItemOnHandInventory);
            this.menuItem3.Text = "OnHand";
            // 
            // menuItemOnHandInventory
            // 
            this.menuItemOnHandInventory.Text = "OnHand Inventory";
            this.menuItemOnHandInventory.Click += new System.EventHandler(this.menuItemOnHandInventory_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemMoveInventory;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemShipmentValidate;        
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItemOnHandInventory;
        private System.Windows.Forms.MenuItem menuItemExit;
        

    }
}