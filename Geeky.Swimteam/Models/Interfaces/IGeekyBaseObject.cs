﻿using System;

namespace Geeky.Swimteam.Models.Interfaces
{
    public interface IGeekyBaseObject
    {
        Guid? Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ShortDescription { get; set; }
    }
}
