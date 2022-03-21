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
    public partial class MoveInventoryForm : Form
    {
        private BasicHttpBinding_IMobilePackingController MobilePacking = new BasicHttpBinding_IMobilePackingController();
        private Timer LoadPackingListTimer = new Timer();
        private string ScanCode;

        private UserProfile User;
        private string[] Roles;
        private Inventory[] Inventory;

        public MoveInventoryForm()
        {
            InitializeComponent();

            this.LoadPackingListTimer.Tick += new EventHandler(LoadPackingListTimer_Tick);
#if DEBUG
            this.LoadPackingListTimer.Interval = 3000;
#else
            this.LoadPackingListTimer.Interval = 300;
#endif

            //this.MobilePacking.Url = "http://10.101.103.21:8618/Simmtech/BusinessService/MobileController/MobilePackingController";
            this.MobilePacking.Url = "http://stgate.simmtech.com:8618/Simmtech/BusinessService/MobileController/MobilePackingController";
        }

        public MoveInventoryForm(UserProfile user, string[] roles)
            : this()
        {
            try
            {
                this.User = user;
                this.Roles = roles;

                //if (!(this.Roles.Contains("STC INV/PACKING MANAGER") || this.Roles.Contains("STX INV/PACKING MANAGER") || this.Roles.Contains("STC INV/PACKING SUPER USER") || this.Roles.Contains("OSC Product Member"))) throw new Exception("User has no responsibility.");
                if (!(this.Roles.Contains(this.User.SelectedOrganization.ToString() + " INV/PACKING MANAGER")  || this.Roles.Contains("STC INV/PACKING SUPER USER") || this.Roles.Contains("OSC Product Member"))) throw new Exception("User has no responsibility.");

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

        void LoadPackingListTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.LoadPackingListTimer.Enabled = false;

                listViewJobs.Items.Clear();

                Packing scanned = new Packing() { Id = this.ScanCode.Substring(1).ToLong(), IdType = this.ScanCode.Substring(0, 1).ToUpper(), OrganizationId = this.User.SelectedOrganization.Id, OrganizationIdSpecified = true, IdSpecified = true };
                //Packing scanned = new Packing() { Id = 4139035, IdType = "M", OrganizationId = this.User.SelectedOrganization.Id, OrganizationIdSpecified = true, IdSpecified = true };

                if (this.CheckDuplicated((PackingBase)scanned) != DialogResult.OK) throw new Exception("Box duplicated.");

                Packing[] packings = MobilePacking.GetPackedListDetail((PackingBase)scanned, PackingStatus.All, true);
                if (packings == null) throw new Exception("Data Not Found!");

                scanned.IdType = packings.First().ParentIdType;
                scanned.Id = packings.First().ParentId;

                scanned.InventoryName = packings.First().InventoryName;
                scanned.LocationId = packings.First().LocationId;
                scanned.LocationName = packings.First().LocationName;

                scanned.Items = MobilePacking.GetPackedJobDetail((PackingBase)scanned, PackingStatus.All, true);

                ListViewItem item = new ListViewItem();
                item.Tag = scanned;
                item.Text = scanned.IdType + scanned.Id;
                
                item.SubItems.Add(string.Format("{0}[{1}]", scanned.InventoryName, scanned.LocationName));
                item.SubItems.Add(packings.Sum(s => s.Quantity).ToString("#,0"));

                item.Checked = true;
                this.listViewPacking.Items.Add(item);

                if (scanned.Items != null && ((PackedJob[])scanned.Items).Length > 0) this.ShowJob((PackedJob[])scanned.Items);
            }
            catch (Exception ex)
            {
                this.Throw(new Exception("[" + this.ScanCode + "] " + ex.Message));
            }
            finally
            {
                this.ScanCode = "";
            }
        }

        private void FocusChange(object sender, EventArgs e)
        {
            this.listViewPacking.Focus();
        }

        private void BarcodeScaned(object sender, KeyPressEventArgs e)
        {
            this.LoadPackingListTimer.Enabled = false;
            this.ScanCode += e.KeyChar;
            this.LoadPackingListTimer.Enabled = true;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            int result;
            bool specified;

            try
            {

                InventoryBase inventory = new InventoryBase()
                {
                    Organization = this.User.SelectedOrganization.Id,
                    Subinventory = (string)this.comboBoxInventory.SelectedValue,
                    LocationId = (decimal?)this.comboBoxLocator.SelectedValue,
                    LocationIdSpecified = true,
                    OrganizationSpecified = true
                };

                PackingBase[] packings = (from item in this.listViewPacking.Items.Cast<ListViewItem>()
                                          where item.Checked && ((((Packing)item.Tag).InventoryName != inventory.Subinventory) || (((Packing)item.Tag).LocationId != inventory.LocationId))
                                          select new PackingBase
                                          {
                                              Id = ((Packing)item.Tag).Id,
                                              IdType = ((Packing)item.Tag).IdType,
                                              OrganizationId = ((Packing)item.Tag).OrganizationId,
                                              IdSpecified = true,
                                              OrganizationIdSpecified = true
                                          }).ToArray();

                this.MobilePacking.MoveInventory(packings, inventory, this.textBoxReason.Text, false, true, this.User, out result, out specified);

                if (result != 1) throw new Exception("Cannot move inventory!");

                this.buttonClear_Click(null, null);

                this.FocusChange(null, null);
            }
            catch (Exception ex)
            {
                this.Throw(ex);
            }
        }

        private void listViewPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewJobs.Items.Clear();

            ListViewItem item = ((ListView)sender).FocusedItem;

            if (item == null) return;
            this.ShowJob((PackedJob[])((Packing)item.Tag).Items);
        }

        private void ShowJob(PackedJob[] jobs)
        {
            var jobDetail = from job in jobs
                            group job by new { JobNo = job.JobNo, Grade = job.Grade } into jobSum
                            select new JobDetail { JobNo = jobSum.Key.JobNo, Grade = jobSum.Key.Grade, Quantity = (int)jobSum.Sum(j => j.Quantity) };

            foreach (JobDetail j in jobDetail)
            {
                ListViewItem item = new ListViewItem();
                item.Text = j.JobNo;
                item.SubItems.Add(j.Grade.ToString());
                item.SubItems.Add(string.Format("{0:0,0}", j.Quantity));

                listViewJobs.Items.Add(item);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.listViewPacking.Items.Clear();
            this.listViewJobs.Items.Clear();
        }

        private void Throw(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void comboBoxInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.comboBoxLocator.DataSource = null;

            string subinventory = (string)((ComboBox)sender).SelectedItem;
            if(string.IsNullOrEmpty(subinventory)) return;

            var result = (from inv in this.Inventory
                          where inv.Subinventory == subinventory
                          select new { Key = inv.LocationId, Name = inv.Location }).ToArray();

            this.comboBoxLocator.DataSource = result;
            this.comboBoxLocator.DisplayMember = "Name";
            this.comboBoxLocator.ValueMember = "Key";
        }

        private DialogResult CheckDuplicated(PackingBase packing)
        {
            int count = (from item in this.listViewPacking.Items.Cast<ListViewItem>()
                                      where ((PackingBase)item.Tag).IdType == packing.IdType && ((PackingBase)item.Tag).Id == packing.Id
                                      select item).Count();

            return count > 0 ? DialogResult.Cancel : DialogResult.OK;
        }
    }
}