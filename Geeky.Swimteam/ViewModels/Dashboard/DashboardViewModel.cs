using System.Collections.Generic;
using Geeky.Swimteam.Models;

namespace Geeky.Swimteam.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public SwimteamUser SwimteamUser { get; set; }

        public List<Swimmer> Swimmers { get; set; }

    }
}
