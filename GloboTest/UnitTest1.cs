using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Globo.Business;
using MongoDB.Bson;
using Globo;
using Globo.Objetos;
using System.Collections.Generic;
using System.Linq;

namespace GloboTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAllBusiness()
        {
            // REALIZADO TESTE DAS CAMADAS DE NEGOCIO,A
            // ONDE AS MESMAS CONSOMEM AS DAL ATÉ A CONEXÃO COM A BASE, NÃO SENDO NECESSÁRIO TESTES NESTES LOCAIS.

            Users user = new Users();
            user.Email = string.Empty;
            user.Name = string.Empty;
            user.Password = string.Empty;

            UsersBusiness userBI = new UsersBusiness();
            string email = "tiago.jesus@globo.com";
            string pass = "12345";

            //Coleta usuário da base
            userBI.GetUser(email, pass);

            //Salva novo usuário -- TESTADO PORÉM COMENTADO PARA NÃO GERAR LIXO NA BASE
            //userBI.SaveUser(email, pass, "Tiago");

            //Verifica existência de email
            userBI.VerifyExistUserByEmail(email);

            Characters ch = new Characters();
            ch.Name = "Yoda";
            ch.Feature = "Sabio";
            ch.Type = "Filme";

            CharactersBusiness chBI = new CharactersBusiness();

            // Salva personagem na base
            chBI.SaveCharacter(ch.Name, ch.Type, ch.Feature);

            // Retorna todos os personagens da base
            List<Characters> list = chBI.ListCharacters();

            ch = list.LastOrDefault();

            string id = ch.Id.ToString();

            // Retorna um registro da base
            chBI.GetCharacter(id);

            // Atualiza Registro na Base
            chBI.UpdateCharacter(id, ch.Name, ch.Type, "Mestre");

            // Exclui o registroda base
            chBI.ExcludeCharacter(id.ToString());
        }
    }
}
