using Globo.DAL;
using Globo.Objetos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globo.Business
{
    public class CharactersBusiness
    {
        private CharactersData _charactersData;
        private CharactersData CharactersData
        {
            get
            {
                if (_charactersData == null)
                    _charactersData = new CharactersData();

                return _charactersData;
            }
            set
            {
                value = _charactersData;
            }
        }

        public Characters GetCharacter(string Id)
        {
            return CharactersData.GetCharacter(ObjectId.Parse(Id));
        }

        public List<Characters> ListCharacters()
        {
            List<Characters> list = new List<Characters>();

            list.AddRange(CharactersData.GetAllCharacters());

            return list;
        }

        public void UpdateCharacter(string Id, string Name, string Type, string Feature)
        {
            Characters characters = new Characters();

            characters.Name = Name;
            characters.Type = Type;
            characters.Feature = Feature;

            CharactersData.UpdateCharacter(characters, ObjectId.Parse(Id));
        }

        public void SaveCharacter(string Name, string Type, string Feature)
        {
            Characters characters = new Characters();
            characters.Name = Name;
            characters.Type = Type;
            characters.Feature = Feature;
            
            CharactersData.SaveCharacter(characters);
        }

        public void ExcludeCharacter(string Id)
        {
            CharactersData.ExcludeCharacter(ObjectId.Parse(Id));
        }
    }
}