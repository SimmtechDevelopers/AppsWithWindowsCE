using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PackingManagement.MembershipService;

namespace PackingManagement
{
    public partial class MainForm : Form
    {
        private UserProfile User;
        private string[] Roles;

        public MainForm()
        {
            InitializeComponent();
            //this.Text = "Development : " + this.Text;
        }

        public MainForm(UserProfile user, string[] roles) : this()
        {
            this.User = user;
            this.Roles = roles;
        }

        private void menuItemMoveInventory_Click(object sender, EventArgs e)
        {
            Form frm = new MoveInventoryForm(this.User.CopyTo(), this.Roles);
            frm.ShowDialog();
        }

        private void menuItemShipmentValidate_Click(object sender, EventArgs e)
        {
            Form frm = new ShipmentValidateForm(this.User.CopyTo(), this.Roles);
            frm.ShowDialog();
        }


        private void menuItemOnHandInventory_Click(object sender, EventArgs e)
        {
            Form frm = new OnhandInventoryForm(this.User.CopyTo(), this.Roles);
            frm.ShowDialog();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}