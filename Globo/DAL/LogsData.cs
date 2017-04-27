using Globo.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globo.DAL
{
    public class LogsData
    {
        private MongoDB _mongoDB;
        private MongoDB MongoDB
        {
            get
            {
                if (_mongoDB == null)
                    _mongoDB = new MongoDB();

                return _mongoDB;
            }
            set
            {
                value = _mongoDB;
            }
        }

        public IQueryable<Logs> GetAllLogs()
        {
            return MongoDB.GetAll<Logs>().AsQueryable();
        }
    }
}