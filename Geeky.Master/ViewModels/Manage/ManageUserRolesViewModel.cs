using System.Collections.Generic;
using Geeky.Master.Models;

namespace Geeky.Master.ViewModels.Manage
{
    public class ManageUserRolesViewModel
    {
        public IList<GeekyRole> CurrentRoles { get; set; }

        public IList<GeekyRole> AvailableRoles { get; set; }
    }
}
