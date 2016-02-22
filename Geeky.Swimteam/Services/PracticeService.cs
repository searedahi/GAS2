using System;
using System.Collections.Generic;
using System.Linq;
using Geeky.Swimteam.Contexts;
using Geeky.Swimteam.Models;
using Geeky.Swimteam.ViewModels.Practice;
using ICoach = Geeky.Swimteam.Models.ICoach;
using IGeekyObj = Geeky.Swimteam.Models.IGeekyObj;
using IPractice = Geeky.Swimteam.Models.IPractice;
using Practice = Geeky.Swimteam.Models.Practice;

namespace Geeky.Swimteam.Services
{
    public class PracticeService : IPracticeService
    {
        private SwimteamDbContext _swimteamDb;

        public IEnumerable<ICoach> Coaches { get; set; }
        public IEnumerable<IPractice> Practices { get; set; }

        public PracticeService(SwimteamDbContext swimteamDbContext)
        {
            _swimteamDb = swimteamDbContext;
            Practices = _swimteamDb.Practices.ToList();
            Coaches = _swimteamDb.Coaches.ToList();
        }

        public bool Create(IGeekyObj geekyObject)
        {
            PracticeViewModel practiceVm = (PracticeViewModel)geekyObject;
            if (practiceVm == null) return false;

            var practiceDb = new Practice
            {
                ConcurrencyStamp = practiceVm.ConcurrencyStamp,
                Description = practiceVm.Description
            };

            DateTime baseDate = new DateTime();
            if (!string.IsNullOrEmpty(practiceVm.PracticeDate))
            {
                bool res = DateTime.TryParse(practiceVm.PracticeDate, out baseDate);
                if (!res) { throw new Exception("Cannot parse practice date in practice service."); }
            }

            if (!string.IsNullOrEmpty(practiceVm.Begins))
            {
                try
                {
                    TimeSpan beginTime = Convert.ToDateTime(practiceVm.Begins).TimeOfDay;
                    var beginning = baseDate;
                    beginning += beginTime;
                    practiceDb.Begins = beginning;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Cannot parse begins time in practice service.     {ex.Message}");
                }
            }

            if (!string.IsNullOrEmpty(practiceVm.Ends))
            {
                try
                {
                    TimeSpan endTime = Convert.ToDateTime(practiceVm.Ends).TimeOfDay;
                    var ending = baseDate;
                    ending += endTime;
                    practiceDb.Ends = ending;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Cannot parse end time in practice service. {ex.Message}");
                }
            }

            _swimteamDb.Practices.Add(practiceDb);
            var recordCount = _swimteamDb.SaveChanges();
            return recordCount > 0;
        }

        public IGeekyObj Read(string geekyObjId)
        {
            var practice = _swimteamDb.Practices.Single(p => p.Id.ToString().Equals(geekyObjId));
            return practice ?? new Practice();
        }

        public bool Update(IGeekyObj geekyObject)
        {
            Practice practice = (Practice)geekyObject;

            if (practice == null) throw new Exception("No practice found to update???");

            _swimteamDb.Practices.Update(practice);
            var recordCount = _swimteamDb.SaveChanges();
            return recordCount > 0;
        }

        public bool Delete(IGeekyObj geekyObjId)
        {
            var practice = _swimteamDb.Practices.Single(p => p.Id.Equals(geekyObjId.Id));
            if (practice == null) throw new Exception("No practice found to delete???");
            _swimteamDb.Practices.Remove(practice);
            var recordCount = _swimteamDb.SaveChanges();
            return recordCount > 0;
        }
    }


    public interface IPracticeService : IGeekyService
    {
        IEnumerable<ICoach> Coaches { get; set; }
        IEnumerable<IPractice> Practices { get; set; }
    }
}