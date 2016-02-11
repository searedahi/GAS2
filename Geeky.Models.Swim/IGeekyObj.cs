using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geeky.Models.Swim
{
    public interface IGeekyObj
    {
        Guid Id { get; set; }
        string ConcurrencyStamp { get; set; }
    }
}
