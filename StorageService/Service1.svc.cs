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
       
        //..
        #region Connection string
        
        private static string connectingString =
               "Server=tcp:natascha.database.windows.net,1433;Initial Catalog=School;Persist Security Info=False;User ID=nataschajakobsen;Password=Roskilde4000;" +
               "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        #endregion

        //Components

        #region GET all components method
        public List<Component> GetComponents()
        {
            List<Component> liste = new List<Component>(); //ny instans af komponent
            using (SqlConnection conn = new SqlConnection(connectingString)) //åben forbindelse til SQL server
            {
                conn.Open(); //åbner for forbindelsen
                String sql = "SELECT * FROM Components";
                SqlCommand command = new SqlCommand(sql, conn); //ny instans af SqlCommand, som kræver parametrer string og sqlconnection. 

                //retrieving data as soon as it is available, retrieve a read-only, forward-only stream of data from a database. 
                //Results are returned as the query executes, and are stored in the network buffer on the client until you request them using the Read method of the DataReader. Bruges i While loopet. 
                SqlDataReader reader = command.ExecuteReader(); 

                while (reader.Read())
                {
                    Component komponent = new Component
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Specification = reader.GetString(2),
                        Price = reader.GetInt32(3),
                        Link = reader.GetString(4),
                        Note = reader.GetString(5),
                        EstDelivery = reader.GetInt32(6),
                        Quantity = reader.GetInt32(7),
                        Available = reader.GetInt32(8)

                    };
                    liste.Add(komponent);
                }

            }
            return liste;
        }
        #endregion

        #region POST component method
        public void AddComponent(Component newKomponent)
        {
            SqlConnection conn = new SqlConnection(connectingString); //laver en ny instans af SqlConnection og kalder den conn.
            SqlCommand command = new SqlCommand(); //ny instans af SqlCommand og kalder den command

            command.Connection = conn;
            conn.Open(); //åbner forbindelsen 

            command.CommandText = @"INSERT INTO Components(Id, Title, Specification, Price, Link, Note, EstDelivery, Quantity, Available) 
                                VALUES (@id, @Title, @Specification, @Price, @Link, @Note, @EstDelivery, @Quantity, @Available)";

            command.Parameters.AddWithValue("@id", newKomponent.Id); //skal bruge et parameter name og en object værdi
            command.Parameters.AddWithValue("@Title", newKomponent.Title);
            command.Parameters.AddWithValue("@Specification ", newKomponent.Specification);
            command.Parameters.AddWithValue("@Price", newKomponent.Price);
            command.Parameters.AddWithValue("@Link", newKomponent.Link);
            command.Parameters.AddWithValue("@Note", newKomponent.Note);
            command.Parameters.AddWithValue("@EstDelivery", newKomponent.EstDelivery);
            command.Parameters.AddWithValue("@Quantity", newKomponent.Quantity);
            command.Parameters.AddWithValue("@Available", newKomponent.Available);

            command.ExecuteNonQuery(); //udfører SQL statement "command". Used for executing queries that does not return any data. It is used to execute the sql statements like update, insert, delete. ExecuteNonQuery executes the command and returns the number of rows affected
            conn.Close();
        }

        #endregion

        #region PUT component
        public void UpdateComponent(Component component)
        {
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = @"UPDATE Components SET Id = @id, Title = @Title, Specification = @Specification, Price = @Price, Link = @Link, Note = @Note, EstDelivery = @EstDelivery, Quantity = @Quantity, Available = @Available WHERE Components.Id = @id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", component.Id);
                command.Parameters.AddWithValue("@Title", component.Title);
                command.Parameters.AddWithValue("@Specification ", component.Specification);
                command.Parameters.AddWithValue("@Price", component.Price);
                command.Parameters.AddWithValue("@Link", component.Link);
                command.Parameters.AddWithValue("@Note", component.Note);
                command.Parameters.AddWithValue("@EstDelivery", component.EstDelivery);
                command.Parameters.AddWithValue("@Quantity", component.Quantity);
                command.Parameters.AddWithValue("@Available", component.Available);

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion

        #region DELETE component method
        public void DeleteComponent(int id)
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


        //Reservations

        #region GET all reservations method
        public List<Reservation> GetReservations()
        {
            List<Reservation> liste = new List<Reservation>(); //ny instans af en reservation
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = "SELECT * FROM Reservations WHERE IsInProduction = 0 AND IsDone = 0";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Reservation reservation = new Reservation
                    {
                        Id = reader.GetInt32(0),
                        Product = reader.GetString(1),
                        IsInProduction = reader.GetBoolean(2),
                        IsDone = reader.GetBoolean(3),
                        ScheduledDate = reader.GetString(4)
                    };
                    liste.Add(reservation);
                }
            }
            return liste;
        }

        #endregion


        #region POST new reservation method

        public void AddReservation(Reservation reservation)
        {
            SqlConnection conn = new SqlConnection(connectingString); //laver en ny instans af SqlConnection og kalder den conn.
            SqlCommand command = new SqlCommand(); //ny instans af SqlCommand og kalder den command

            command.Connection = conn;
            conn.Open(); //åbner forbindelsen 

            command.CommandText = @"INSERT INTO Reservations(Id, Product, IsInProduction, IsDone, ScheduledDate) 
                                VALUES (@Id, @Product, @IsInProduction, @IsDone, @ScheduledDate)";

            command.Parameters.AddWithValue("@Id", reservation.Id);
            command.Parameters.AddWithValue("@Product", reservation.Product);
            command.Parameters.AddWithValue("@IsInProduction", reservation.IsInProduction);
            command.Parameters.AddWithValue("@IsDone", reservation.IsDone);
            command.Parameters.AddWithValue("@ScheduledDate", reservation.ScheduledDate);

            command.ExecuteNonQuery(); //udfører SQL statement "command"
            conn.Close();
        }

        #endregion

        #region PUT reservation
        public void UpdateReservation(Reservation reservation)
        {
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = @"UPDATE Reservations SET Product = @Product, IsInProduction = @IsInProduction, IsDone = @IsDone, ScheduledDate = @ScheduledDate WHERE Reservations.Id = @Id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@Id", reservation.Id);
                command.Parameters.AddWithValue("@Product", reservation.Product);
                command.Parameters.AddWithValue("@IsInProduction", reservation.IsInProduction);
                command.Parameters.AddWithValue("@IsDone", reservation.IsDone);
                command.Parameters.AddWithValue("@ScheduledDate", reservation.ScheduledDate);

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion

        #region PUT reservation to production
        public void MoveToProduction(Reservation reservation)
        {
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = @"UPDATE Reservations SET IsInProduction = @IsInProduction WHERE Reservations.Id = @Id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@Id", reservation.Id);
                command.Parameters.AddWithValue("@IsInProduction", reservation.IsInProduction);

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion

        #region DELETE reservation method

        public void DeleteReservation(int Id)
        {
            SqlConnection conn = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = @"DELETE FROM Reservations WHERE Reservations.Id = @Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        #endregion


        //Production

        #region GET all in production method
        public List<Reservation> GetAllInProduction()
        {
            List<Reservation> liste = new List<Reservation>(); //ny instans af en reservation
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = "SELECT * FROM Reservations";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Reservation reservation = new Reservation
                    {
                        Id = reader.GetInt32(0),
                        Product = reader.GetString(1),
                        IsInProduction = reader.GetBoolean(2),
                        IsDone = reader.GetBoolean(3),
                        ScheduledDate = reader.GetString(4)
                    };

                    if (reservation.IsInProduction == true && reservation.IsDone == false)
                    {
                        liste.Add(reservation);
                    }
                }

            }
            return liste;
        }

        #endregion

        #region PUT production to done
        public void MoveToDone(Reservation reservation)
        {
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = @"UPDATE Reservations SET IsDone = @IsDone, IsInProduction = @IsInProduction WHERE Reservations.Id = @Id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@Id", reservation.Id);
                command.Parameters.AddWithValue("@IsInProduction", reservation.IsInProduction);
                command.Parameters.AddWithValue("@IsDone", reservation.IsDone);

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion


        //Done

        #region GET all done method
        public List<Reservation> GetAllDone()
        {
            List<Reservation> liste = new List<Reservation>(); //ny instans af en reservation
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = "SELECT * FROM Reservations";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Reservation reservation = new Reservation
                    {
                        Id = reader.GetInt32(0),
                        Product = reader.GetString(1),
                        IsInProduction = reader.GetBoolean(2),
                        IsDone = reader.GetBoolean(3),
                        ScheduledDate = reader.GetString(4)
                    };

                    if (reservation.IsDone == true)
                    {
                        liste.Add(reservation);
                    }
                }

            }
            return liste;
        }

        #endregion

    }
}
