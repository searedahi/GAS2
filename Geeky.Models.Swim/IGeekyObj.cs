using System;

namespace Geeky.Models.Swim
{
    public interface IGeekyObj
    {
        Guid Id { get; set; }
        string ConcurrencyStamp { get; set; }
    }
}
