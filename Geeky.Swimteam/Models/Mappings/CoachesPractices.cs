using System;

namespace Geeky.Swimteam.Models.Mappings
{
    public class CoachesPractices : IGeekyObj
    {
        public Guid CoachId { get; set; }
        public Guid PracticeId { get; set; }
        public Coach Coach { get; set; }
        public Practice Practice { get; set; }
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}