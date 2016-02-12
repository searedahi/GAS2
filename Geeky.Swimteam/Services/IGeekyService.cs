using Geeky.Swimteam.Models;

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
