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
    public partial class ShipmentValidateForm : Form
    {
        private BasicHttpBinding_IMobileShipmentController MobileShipment = new BasicHttpBinding_IMobileShipmentController();

        private Packing[] Packings;

        private UserProfile User;
        private string[] Roles;

        private Timer scannerTimer = new Timer();
        private TextBox ScannedTextBox;

        public ShipmentValidateForm()
        {
            InitializeComponent();
            
            //this.MobileShipment.Url = "http://10.101.103.21:8618/Simmtech/BusinessService/MobileController/MobileShipmentController";
            this.MobileShipment.Url = "http://stkgate.simmtech.co.kr:8618/Simmtech/BusinessService/MobileController/MobileShipmentController";

            this.scannerTimer.Tick += new EventHandler(BarcodeScanned);
            this.scannerTimer.Interval = 300;

            //this.textBoxShipment.Tag = new EventHandler(buttonSearch_Click);
            //this.textBoxPacking.Tag = new EventHandler(buttonCheck_Click);

            this.Clear();
        }

        public ShipmentValidateForm(UserProfile user, string[] roles) : this()
        {
            try
            {
                this.User = user;
                this.Roles = roles;

                if (!(this.Roles.Contains("STC INV/PACKING MANAGER") || this.Roles.Contains("STX INV/PACKING MANAGER") || this.Roles.Contains("STC INV/PACKING SUPER USER") || this.Roles.Contains("OSC Product Member"))) throw new Exception("User has no responsibility.");

            }
            catch (Exception ex)
            {
                this.Throw(ex);
                this.Close();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //id : 145317

            long shipmentId;
            bool shipmentIdSpec;

            Cursor.Current = Cursors.WaitCursor;
    
            this.MobileShipment.GetShipmentIdForName(this.textBoxShipment.Text.Trim().ToUpper(), out shipmentId, out shipmentIdSpec);

            this.Search(shipmentId);

            Cursor.Current = Cursors.Default;
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void Throw(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void Clear()
        {
            this.Packings = null;
            this.listViewPacking.Items.Clear();
            this.textBoxShipment.Text = "";

            this.textBoxShipment.Focus();
        }

        private void Search(long shipmentId)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.listViewPacking.Items.Clear();

            this.Packings = this.MobileShipment.GetShipmentPacking(new ShipmentBase() { OperatingUnitId = this.User.SelectedOrganization.OperatingUnitId, Id = shipmentId, OperatingUnitIdSpecified = true, IdSpecified = true });

            foreach (Packing pack in this.Packings)
            {
                ListViewItem item = new ListViewItem();
                item.Text = pack.IdType + pack.Id;
                item.SubItems.Add(string.Format("{0:0,0}", pack.Quantity));

                this.listViewPacking.Items.Add(item);
            }

            this.textBoxPacking.Focus();

            Cursor.Current = Cursors.Default;
        }

        private ListViewItem FindPacking(string packingId)
        {
            return this.listViewPacking.FindWithText(packingId);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (this.textBoxPacking.Text.Trim() == null) return;

            this.Check(this.textBoxPacking.Text);

            this.textBoxPacking.Text = "";
            this.textBoxPacking.Focus();
        }

        private void Check(string packingId)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (this.Packings.Where(w => (w.IdType + w.Id) == packingId).Count() <= 0) throw new Exception("Cannot find packing[" + packingId + "].");

                ListViewItem item = this.listViewPacking.FindWithText(packingId);

                if (item == null) throw new Exception("Packing checked. [" + packingId + "].");

                this.listViewPacking.Items.Remove(item);
            }
            catch (Exception ex)
            {
                this.Throw(ex);
            }

            Cursor.Current = Cursors.Default;
        }

        private void ClearTextBox(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "";
        }

        private void StartTimer(object sender, KeyPressEventArgs e)
        {
            if(!this.scannerTimer.Enabled) this.scannerTimer.Enabled = true;
            this.ScannedTextBox = (TextBox)sender;
        }

        private void BarcodeScanned(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Enabled = false;

            if (this.ScannedTextBox == this.textBoxShipment)
            {
                this.buttonSearch_Click(null, null);
            }
            else if (this.ScannedTextBox == this.textBoxPacking)
            {
                this.buttonCheck_Click(null, null);
            }

            this.ScannedTextBox = null;
        }

    }
}