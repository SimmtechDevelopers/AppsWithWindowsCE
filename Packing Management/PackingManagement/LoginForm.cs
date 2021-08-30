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
    public partial class LoginForm : Form
    {
        BasicHttpBinding_IUserMembershipProvider membership = new BasicHttpBinding_IUserMembershipProvider();
        BasicHttpBinding_IUserRoleProvider role = new BasicHttpBinding_IUserRoleProvider();

        public UserProfile User { get; private set; }
        public string[] Roles { get; private set; }

        public LoginForm()
        {
            InitializeComponent();

            this.membership.Url = "http://stkgate.simmtech.co.kr:8519/Simmtech/User/Membership";
            this.role.Url = "http://stkgate.simmtech.co.kr:8519/Simmtech/User/Role";

            this.comboBoxOrganization.DataSource = membership.GetOrganizations();
            this.comboBoxOrganization.DisplayMember = "Description";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //this.textBoxId.Text = "developer";
            //this.textBoxPassword.Text = "icsmen123$";

            if (string.IsNullOrEmpty(this.textBoxId.Text) || string.IsNullOrEmpty(this.textBoxPassword.Text))
            {
                throw new NoNullAllowedException();
            }
            else
            {
                bool result;
                bool resultSpecified;

                this.membership.ValidateUser(this.textBoxId.Text, this.textBoxPassword.Text, out result, out resultSpecified);

                if (result)
                {
                    this.User = this.membership.GetUser(this.textBoxId.Text);
                    this.Roles = this.role.GetRolesForUser(this.User.Code);  //--------*******
                    this.User.SelectedOrganization = (Oraganization)this.comboBoxOrganization.SelectedItem;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}