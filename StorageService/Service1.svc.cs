﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StorageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private Model1 komponentdb = new Model1();

        #region Connection string
        //Data Source=natascha.database.windows.net;Initial Catalog=School;Integrated Security=False;User ID=nataschajakobsen;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        private static string connectingString =
               "Server=tcp:natascha.database.windows.net,1433;Initial Catalog=School;Persist Security Info=False;User ID=nataschajakobsen;Password=Roskilde4000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        #endregion


        #region GET
        public List<Komponenter> GetKomponenter()
        {
            List<Komponenter> liste = new List<Komponenter>(); //ny instans af komponent
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = "SELECT * FROM Components";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Komponenter komponent = new Komponenter
                    {
                        Id = reader.GetInt32(0),
                        Titel = reader.GetString(1),
                        Specification = reader.GetString(2),
                        Price = reader.GetInt32(3),
                        Bulk = reader.GetInt32(4),
                        Link = reader.GetString(5),
                        Note = reader.GetString(6),
                        EstDelivery = reader.GetInt32(7)
                    };
                    liste.Add(komponent);
                }

            }
            return liste;
        }
        #endregion

        #region DELETE
        public void DeleteKompoent(int id)
        {
            SqlConnection conn = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = @"DELETE FROM Components WHERE Components.id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion


    }
}
