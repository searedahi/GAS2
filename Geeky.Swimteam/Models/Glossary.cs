using System;

namespace Geeky.Swimteam.Models
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
