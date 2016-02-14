using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using Geeky.Swimteam.Contexts;
using Geeky.Swimteam.Models;

namespace Geeky.Swimteam.Services
{
    public class ImageService : IImageService
    {
        private SwimteamDbContext _swimteamDb;

        public IEnumerable<GImage> Images { get; set; }

        public ImageService(SwimteamDbContext swimteamDbContext)
        {
            _swimteamDb = swimteamDbContext;
        }

        public bool Create(IGeekyObj geekyObject)
        {
            GImage practice = (GImage)geekyObject;

            if (practice == null) return false;

            _swimteamDb.Images.Add(practice);
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


    public interface IImageService : IGeekyService
    {
        IEnumerable<GImage> Images { get; set; }
    }
}