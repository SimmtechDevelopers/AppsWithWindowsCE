using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PackingManagement.MobileControllerService;

namespace PackingManagement
{
    public partial class OnhandInventoryForm : Form
    {
        private BasicHttpBinding_IMobilePackingController MobilePacking = new BasicHttpBinding_IMobilePackingController();
        private UserProfile User;
        private string[] Roles;
        private Inventory[] Inventory;
        private Packing[] packing;
        private Timer PackingListScanTimer = new Timer();
        private string ScanCode;


        public OnhandInventoryForm()
        {
            InitializeComponent();
            this.MobilePacking.Url = "http://stgate.simmtech.com:8618/Simmtech/BusinessService/MobileController/MobilePackingController";
            
            this.PackingListScanTimer.Tick += new EventHandler(PackingListScanTimer_Tick);
            this.PackingListScanTimer.Interval = 500;
            this.PackingListScanTimer.Enabled = false;


        }

        public OnhandInventoryForm(UserProfile user, string[] roles)
            : this()
        {
            try
            {
                this.User = user;
                this.Roles = roles;

                //if (!(this.Roles.Contains("STC INV/PACKING MANAGER") || this.Roles.Contains("STC INV/PACKING SUPER USER") || this.Roles.Contains("OSC Product Member"))) throw new Exception("User has no responsibility.");
                if (!(this.Roles.Contains(this.User.SelectedOrganization.ToString() + " INV/PACKING MANAGER") || this.Roles.Contains("STC INV/PACKING SUPER USER") || this.Roles.Contains("OSC Product Member"))) throw new Exception("User has no responsibility.");

                this.Inventory = MobilePacking.GetInventory(this.User.SelectedOrganization);
                //var result = (from inv in this.Inventory group inv by inv.Subinventory into g select g.Key).ToArray();
                this.comboBoxInventory.DataSource = (from inv in this.Inventory group inv by inv.Subinventory into g select g.Key).ToArray();


            }
            catch (Exception ex)
            {
                this.Throw(ex);
                this.Close();
            }
                    
        }

        private void Throw(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void comboBoxInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.comboBoxLocator.DataSource = null;

            string subinventory = (string)((ComboBox)sender).SelectedItem;
            if (string.IsNullOrEmpty(subinventory)) return;

            var result = (from inv in this.Inventory
                          where inv.Subinventory == subinventory
                          select new { Key = inv.LocationId, Name = inv.Location }).ToArray();

            this.comboBoxLocator.DataSource = result;
            this.comboBoxLocator.DisplayMember = "Name";
            this.comboBoxLocator.ValueMember = "Key";
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Serch();
        }

        private void Serch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lv_Packing.Items.Clear();
                CommonCode common = new CommonCode()
                {
                    Id = int.Parse(this.comboBoxLocator.SelectedValue.ToString()),         //Location_id
                    Code = this.comboBoxInventory.SelectedItem.ToString(),                 //inventory_code
                    GroupCode = this.User.SelectedOrganization.Id.ToString(),              //org_id               
                    IdSpecified = true

                    //GroupCode = "101",          //org_id                
                    //Code = "ST2001",             //inventory_code
                    //Id = 161,                    //Location_id                 
                    //IdSpecified = true,

                };

                packing = this.MobilePacking.GetInventoryPackingList(common, User);

                if (packing == null)
                    MessageBox.Show("No Data Found");
                else
                {
                    foreach (Packing pack in packing)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = pack.IdType + pack.Id;
                        lv_Packing.Items.Add(item);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Throw(ex);
            }
            finally
            {
                txt_BoxReason.Focus();
                Cursor.Current = Cursors.Default;
            }
        }

        private void BarcodeScaned(object sender, KeyPressEventArgs e)
        {
            this.PackingListScanTimer.Enabled = false;
            this.ScanCode += e.KeyChar;
            this.PackingListScanTimer.Enabled = true;
        }

        private void PackingListScanTimer_Tick(object sender, EventArgs e)
        {
            this.PackingListScanTimer.Enabled = false;
            txt_BoxReason.Text = this.ScanCode;
            ScanDataCheck();

            this.ScanCode = "";
            txt_BoxReason.Text = "";
            txt_BoxReason.Focus();
        }


        private void ScanDataCheck()
        {
            //listview == null and  packing array Not Found data   --> DB에 존재 하지 않는 item
            //listview == null and  packing array Found data       --> 중복 스캔으로 판단(스캔 타임 DB에 있음)
            int count = 0;
            ListViewItem item = lv_Packing.FindWithText(ScanCode);
            count = packing.Where(w => w.IdType + w.Id == ScanCode).Count();

            if (item == null && count > 0)
            {
                MessageBox.Show("Data already saved [" + ScanCode + "]");
                return;
            }

            if (item == null || count == 0)
            {
                MessageBox.Show("Not Found Data [" + ScanCode + "]");
                return;
            }

            ScanDataSave();
            RemovePackingID(item);
        }

        private void ScanDataSave()
        {
            //int result;
            //bool spec;
            //PackingBase packing = new PackingBase()
            //{
            //    Id = 30518,
            //    IdType = "E",
            //    OrganizationId = 101,
            //    IdSpecified = true,
            //    OrganizationIdSpecified = true,
            //};

            //this.MobilePacking.ValidateOnHandPacking(packing, this.User, out result, out spec);

            int result;
            bool specified;
            PackingBase scanned = new PackingBase()
            {
                Id = this.ScanCode.Substring(1).ToLong(),
                IdType = this.ScanCode.Substring(0, 1).ToUpper(),
                OrganizationId = this.User.SelectedOrganization.Id,
                IdSpecified = true,
                OrganizationIdSpecified = true
            };

            this.MobilePacking.ValidateOnHandPacking(scanned, this.User, out result, out specified);

        }

        private void RemovePackingID(ListViewItem item)
        {
            try
            {
                lv_Packing.Items.RemoveAt(item.Index);
            }
            catch (Exception ex)
            {
                this.Throw(new Exception("[" + this.ScanCode + "][" + item.Index + "] " + ex.Message));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.PackingListScanTimer.Enabled = true;
        }

        private void OnhandInventoryForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // 로커 위로
                // 위로
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // 로커 아래로
                // 아래로
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // 왼쪽
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // 오른쪽
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }


    }
}