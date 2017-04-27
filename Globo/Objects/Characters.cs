using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globo.Objetos
{
    public class Characters
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Feature { get; set; }
        public ObjectId Id { get; set; }
    }
}