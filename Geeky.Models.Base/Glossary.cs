using System;

namespace Geeky.Models.Base
{
    public class Glossary
    {
        public Guid Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
        public string Language { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Disabled { get; set; }
    }
}
