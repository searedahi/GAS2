using System;
using System.Collections.Generic;
using System.Linq;
using Geeky.Swimteam.Contexts;
using Geeky.Swimteam.Models;
using Geeky.Swimteam.ViewModels.Practice;
using Microsoft.Data.Entity;
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
            PracticeViewModel practiceVm = geekyObject as PracticeViewModel;
            if (practiceVm == null) return false;

            var practiceDb = CastToDbModel(practiceVm) as Practice;

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
            PracticeViewModel practice = (PracticeViewModel)geekyObject;

            if (practice == null) throw new Exception("No practice found to update???");

            var castedPractice = CastToDbModel(practice) as Practice;
            if (castedPractice == null){return false;}
            var dbPrac = _swimteamDb.Practices.FirstOrDefault(p=>p.Id == practice.Id);

            if (dbPrac == null) throw new Exception("No practice found to update???");

            dbPrac.Begins = castedPractice.Begins;
            dbPrac.Ends = castedPractice.Ends;
            dbPrac.MaxParticipants = castedPractice.MaxParticipants;
            dbPrac.Description = castedPractice.Description;

            _swimteamDb.Practices.Update(dbPrac);
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



        public IPractice CastToDbModel(PracticeViewModel practiceVm)
        {
            var practiceDb = new Practice
            {
                Id = practiceVm.Id,
                ConcurrencyStamp = practiceVm.ConcurrencyStamp,
                Description = practiceVm.Description,
                MaxParticipants = practiceVm.MaxParticipants
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
            
            return practiceDb;
        }

        public PracticeViewModel CastToViewModel(IPractice practiceD)
        {
            Practice domainPractice = practiceD as Practice;
            if (domainPractice == null) return new PracticeViewModel();

            var practiceVm = new PracticeViewModel
            {
                Id = domainPractice.Id,
                ConcurrencyStamp = domainPractice.ConcurrencyStamp,
                Description = domainPractice.Description,
                MaxParticipants = domainPractice.MaxParticipants
            };

            practiceVm.PracticeDate = domainPractice.Begins.ToString("d");
            practiceVm.Begins = domainPractice.Begins.ToString("t");
            practiceVm.Ends = domainPractice.Ends.ToString("t");

            return practiceVm;
        }
    }


    public interface IPracticeService : IGeekyService
    {
        IEnumerable<ICoach> Coaches { get; set; }
        IEnumerable<IPractice> Practices { get; set; }
        IPractice CastToDbModel(PracticeViewModel practiceVm);
        PracticeViewModel CastToViewModel(IPractice domainPractice);
    }
}