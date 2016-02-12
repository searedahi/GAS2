using System;

namespace Geeky.Swimteam.Models
{
    public interface IGeekyObj
    {
        Guid Id { get; set; }
        string ConcurrencyStamp { get; set; }
    }
}