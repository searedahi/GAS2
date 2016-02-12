using System;

namespace Geeky.Swimteam.Models.Mappings
{
    public class SwimmersPractices : IGeekyObj
    {
        public Guid SwimmerId { get; set; }
        public Guid PracticeId { get; set; }
        public Practice Practice { get; set; }
        public Swimmer Swimmer { get; set; }
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}