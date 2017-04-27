using Globo.Objetos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globo.DAL
{
    public class CharactersData
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
        public void SaveCharacter(Characters character)
        {
            MongoDB.Save(character);
            MongoDB.SaveLog("Update", character.Name, "Character");
        }

        public Characters GetCharacter(ObjectId Id)
        {
            return MongoDB.Get<Characters>(x => x.Id == Id);
        }

        public IQueryable<Characters> GetAllCharacters()
        {
            return MongoDB.GetAll<Characters>().AsQueryable();
        }

        public void UpdateCharacter(Characters character, ObjectId Id)
        {
            var objeto = Builders<Characters>.Update.Set("Name", character.Name).Set("Type", character.Type).Set("Feature", character.Feature);
            MongoDB.Update(objeto, Id);
            MongoDB.SaveLog("Update", character.Name, "Character");
        }

        public void ExcludeCharacter(ObjectId Id)
        {
            string nameCharacter = GetCharacter(Id).Name;
            MongoDB.Delete<Characters>(Id);
            MongoDB.SaveLog("Delete", nameCharacter, "Character");
        }

    }
}