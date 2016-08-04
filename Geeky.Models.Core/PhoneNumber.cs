using System;
using Geeky.Models.Core.Enums;

namespace Geeky.Models.Core
{
    public partial class PhoneNumber
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public PhoneNumberTypeEnum NumberType  { get; set; }
    }
}
