using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using PackingManagement.MembershipService;

namespace PackingManagement
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            DialogResult result;
            UserProfile user;
            string[] roles;

#if _DEBUG
            result = DialogResult.OK;
            user = new UserProfile() { Code = "19990142", Name = "신사웅" };
            user.SelectedOrganization = new Oraganization() { OperatingUnitId = 81, Id = 101, IdSpecified = false, OperatingUnitIdSpecified = false };
            roles = new string[] { "STC INV/PACKING MANAGER" };
#else
            using (LoginForm form = new LoginForm())
            {
                form.ShowDialog();
            
                result = form.DialogResult;
                user = form.User;
                roles = form.Roles;
            }
#endif
            if (result == DialogResult.OK && user != null && roles != null)
            {
                Application.Run(new MainForm(user, roles));
            }
        }
    }
}