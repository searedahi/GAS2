using System.Collections.Generic;
using Geeky.Swimteam.Models;

namespace Geeky.Swimteam.ViewModels.Account
{
    public class ManageUserRolesViewModel
    {
        public IList<SwimteamRole> CurrentRoles { get; set; }

        public IList<SwimteamRole> AvailableRoles { get; set; }
    }
}
