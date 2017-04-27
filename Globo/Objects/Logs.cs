using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globo.Objects
{
    public class Logs
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public string NameObject { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public ObjectId Id { get; set; }
    }
}