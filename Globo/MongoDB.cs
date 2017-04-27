using Globo.Objects;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globo
{
    public class MongoDB
    {
        private const string StringDeConexao = "mongodb://globo:globo@cluster0-shard-00-00-isavw.mongodb.net:27017,cluster0-shard-00-01-isavw.mongodb.net:27017,cluster0-shard-00-02-isavw.mongodb.net:27017/admin?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin";
        private MongoClient client = new MongoClient(StringDeConexao);
        private IMongoDatabase _MongoData;

        private IMongoDatabase MongoData
        {
            get
            {
                if (_MongoData == null)
                    _MongoData = client.GetDatabase("project_globo");

                return _MongoData;
            }
            set
            {
                value = _MongoData;
            }
        }

        public T Get<T>(Func<T, bool> expressao) where T : class
        {
            return MongoData.GetCollection<T>(typeof(T).Name).AsQueryable().Where(expressao).FirstOrDefault();
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return MongoData.GetCollection<T>(typeof(T).Name).AsQueryable();
        }

        public void Delete<T>(ObjectId Id) where T : class
        {
            MongoData.GetCollection<T>(typeof(T).Name).DeleteOneAsync(new BsonDocument("_id", Id));
        }

        public void Save<T>(T Objeto) where T : class
        {
            MongoData.GetCollection<T>(typeof(T).Name).InsertOne(Objeto);
        }

        public void Update<T>(UpdateDefinition<T> Objeto, ObjectId Id) where T : class
        {
            MongoData.GetCollection<T>(typeof(T).Name).UpdateOneAsync(new BsonDocument("_id", Id), Objeto);
        }

        public void SaveLog(string Action, string NameCharacter, string Type, string email = "")
        {
            Logs log = new Logs();
            log.Name = HttpContext.Current == null ? email : (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) ? email : HttpContext.Current.User.Identity.Name);
            log.NameObject = NameCharacter;
            log.Data = DateTime.Now.ToString();
            log.Type = Type;
            log.Action = Action;

            Save<Logs>(log);
        }
    }
}