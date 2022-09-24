using System;
using System.Collections.Generic;
using copatroca.Interfaces;
using copatroca.Models;
using System.Data.SqlClient;

namespace copatroca.Repositories { 

    internal class ContactRepository {
        private readonly string stringConexao = "server=labsoft.pcs.usp.br,1433;database=db_4;User=usuario_4;pwd=39431322853";
        
        /// <summary>
        ///Adiciona uma informa��o de contato de um determinado usu�rio 
        /// </summary>
        /// <param name="newContact">String livre para o usu�rio inserir as informa��es de contato</param>
        /// <param name="newContactUser">Contato que ter� o contato adicionado</param>
        public void Create(Contact newContact)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Contacts ([Info], [User_Id]) VALUES (@Info, @User_Id);";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", newContact.Info);
                    cmd.Parameters.AddWithValue("@User_Id", newContact.User_Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        void Update(Contact updateContact);
        //void Delete(User user);
        Contact Read(string userEmail);

        
    }
} 
