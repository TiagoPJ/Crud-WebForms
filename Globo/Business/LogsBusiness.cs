using Globo.DAL;
using Globo.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globo.Business
{
    public class LogsBusiness
    {
        private LogsData _logsData;
        private LogsData LogsData
        {
            get
            {
                if (_logsData == null)
                    _logsData = new LogsData();

                return _logsData;
            }
            set
            {
                value = _logsData;
            }
        }

        public List<Logs> ListLogs()
        {
            List<Logs> list = new List<Logs>();

            list.AddRange(LogsData.GetAllLogs());

            return list;
        }
    }
}