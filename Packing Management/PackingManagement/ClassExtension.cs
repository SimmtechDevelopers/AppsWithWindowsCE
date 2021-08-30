using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using PackingManagement.MembershipService;
using System.Windows.Forms;

namespace PackingManagement
{
    public static class ClassExtension
    {
        public static ListViewItem FindWithText(this ListView view, string text)
        {
            foreach(ListViewItem item in view.Items) 
            {
                if (item.Text == text) return item;
            }

            return null;
        }

        public static void RemoveWithText(this ListView view, string text)
        {
            view.Items.Remove(view.FindWithText(text));
        }


        public static PackingManagement.MobileControllerService.Oraganization CopyTo(this Oraganization organizaion)
        {
            PackingManagement.MobileControllerService.Oraganization org = new PackingManagement.MobileControllerService.Oraganization();
            
            org.Code = organizaion.Code;
            org.Description = organizaion.Description;
            org.Id = organizaion.Id;
            org.OperatingUnitId = organizaion.OperatingUnitId;
            org.IdSpecified = true;
            org.OperatingUnitIdSpecified = true;

            return org;
        }

        public static PackingManagement.MobileControllerService.UserProfile CopyTo(this UserProfile user) 
        {
            PackingManagement.MobileControllerService.UserProfile u = new PackingManagement.MobileControllerService.UserProfile();
            u.Code = user.Code;
            u.Email = user.Email;
            u.EndDate = user.EndDate;
            u.Id = user.Id;
            u.Name = user.Name;
            u.StartDate = user.StartDate;
            u.SelectedOrganization = user.SelectedOrganization.CopyTo();

            return u;
        }

        public static long ToLong(this string value)
        {
            try
            {
                return long.Parse(value);
            }
            catch (Exception ex)
            {
                if (value.Length > 1)
                {
                    return value.Substring(1).ToLong();
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
