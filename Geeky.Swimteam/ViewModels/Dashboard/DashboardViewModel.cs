using System.Collections.Generic;
using Geeky.Models.Base;
using Geeky.Models.Swim;

namespace Geeky.Swimteam.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public GeekyUser GeekyUser { get; set; }

        public List<Swimmer> Swimmers { get; set; }

    }
}
