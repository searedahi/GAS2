using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geeky.Models.Swim;

namespace Geeky.Swimteam.Services
{
    public interface IGeekyService
    {
        bool Create(IGeekyObj geekyObject);
        IGeekyObj Read(string geekyObjId);
        bool Update(IGeekyObj geekyObject);
        bool Delete(IGeekyObj geekyObjId);
    }
}
