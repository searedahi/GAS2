using System;
using System.Collections.Generic;
using Geeky.Models.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Geeky.Models.Core
{
    public partial class GeekyUser
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? ApplicationUserId { get; set; }
        public RiseStatusEnumType Status { get; set; }

        //Lazy Loading references

        //public Guid? UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual AuthorizationSignature AuthorizationSignature { get; set; }
        public string GoogleLookup { get; set; }

        public Guid? ActiveCreditCardId { get; set; }
        public CreditCard ActiveCreditCard { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }

    }
}
