using System;
using Geeky.Models.Base.Enums;

namespace Geeky.Models.Base
{
    public class PhoneNumber
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public PhoneNumberTypeEnum NumberType  { get; set; }
    }
}
