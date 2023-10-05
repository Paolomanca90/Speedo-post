﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace U4_W5_D1_5.Models
{
    public static class DB
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);

        public static Utente GetUtente(Utente u)
        {
            SqlCommand sqlCommand = new SqlCommand("Select * FROM Utente WHERE Username=@Username And Password=@Password", conn);
            sqlCommand.Parameters.AddWithValue("Username", u.Username);
            sqlCommand.Parameters.AddWithValue("Password", u.Password);
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
            }
            conn.Close();
            return u;
        }

        public static void AddCliente(Privato p)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Privato Values(@NomeCliente, @CognomeCliente, @CF, @IndirizzoCliente, @CittaCliente)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("NomeCliente", p.Nome);
            cmd.Parameters.AddWithValue("CognomeCliente", p.Cognome);
            cmd.Parameters.AddWithValue("CF", p.CF);
            cmd.Parameters.AddWithValue("IndirizzoCliente", p.Indirizzo);
            cmd.Parameters.AddWithValue("CittaCliente", p.Citta);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void AddAzienda(Azienda a)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Azienda Values(@RagioneSociale, @PartitaIva, @Sede, @CittaAzienda)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("RagioneSociale", a.RagioneSociale);
            cmd.Parameters.AddWithValue("PartitaIva", a.PartitaIva);
            cmd.Parameters.AddWithValue("Sede", a.Sede);
            cmd.Parameters.AddWithValue("CittaAzienda", a.Citta);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void AddSpedizionePrivato(SpedizionePrivato s)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO SpedizionePrivato Values(@Mittente,@NomeDestinatario, @CognomeDestinatario, @IndirizzoDestinatario, @CittaDestinatario, @Peso, @Costo, @DataSpedizione, @DataConsegna, @NumeroParcel)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("Mittente",s.Mittente);
            cmd.Parameters.AddWithValue("NomeDestinatario",s.NomeDestinatario);
            cmd.Parameters.AddWithValue("CognomeDestinatario",s.CognomeDestinatario);
            cmd.Parameters.AddWithValue("IndirizzoDestinatario",s.IndirizzoDestinatario);
            cmd.Parameters.AddWithValue("CittaDestinatario",s.CittaDestinatario);
            cmd.Parameters.AddWithValue("Peso",s.Peso);
            if (s.Peso < 5)
            {
                cmd.Parameters.AddWithValue("Costo", 4.90);
            }
            else if (s.Peso >= 6 && s.Peso < 10)
            {
                cmd.Parameters.AddWithValue("Costo", 9.90);
            }
            else
            {
                cmd.Parameters.AddWithValue("Costo", 19.90);
            }
            cmd.Parameters.AddWithValue("DataSpedizione",Convert.ToDateTime(s.DataSpedizione));
            cmd.Parameters.AddWithValue("DataConsegna",Convert.ToDateTime(s.dataConsegna));
            s.NumeroParcel = "SPL-"+DateTime.Now.ToString("yyMMddHHmmss");
            cmd.Parameters.AddWithValue("NumeroParcel", s.NumeroParcel);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("Insert INTO Dettaglio Values(@DataModifica, @LuogoModifica, @StatoModifica, @NumeroParcel)", conn);
            cmd.Parameters.AddWithValue("DataModifica", DateTime.Now);
            cmd.Parameters.AddWithValue("LuogoModifica", "Milano");
            cmd.Parameters.AddWithValue("StatoModifica", "Presa in carico");
            cmd.Parameters.AddWithValue("NumeroParcel", s.NumeroParcel);
            cmd.ExecuteNonQuery();
            conn.Close();
        } 

        public static void AddSpedizioneAzienda(SpedizioneAzienda s)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO SpedizioneAzienda Values(@Azienda, @NomeDestinatario, @CognomeDestinatario, @IndirizzoDestinatario, @CittaDestinatario, @Peso, @Costo, @DataSpedizione, @DataConsegna, @NumeroParcel)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("Azienda", s.Azienda);
            cmd.Parameters.AddWithValue("NomeDestinatario", s.NomeDestinatario);
            cmd.Parameters.AddWithValue("CognomeDestinatario", s.CognomeDestinatario);
            cmd.Parameters.AddWithValue("IndirizzoDestinatario", s.IndirizzoDestinatario);
            cmd.Parameters.AddWithValue("CittaDestinatario", s.CittaDestinatario);
            cmd.Parameters.AddWithValue("Peso", s.Peso);
            if(s.Peso < 5)
            {
                cmd.Parameters.AddWithValue("Costo", 4.90);
            }
            else if (s.Peso >=6 && s.Peso < 10)
            {
                cmd.Parameters.AddWithValue("Costo", 9.90);
            }
            else
            {
                cmd.Parameters.AddWithValue("Costo", 19.90);
            }
            cmd.Parameters.AddWithValue("DataSpedizione", Convert.ToDateTime(s.DataSpedizione));
            cmd.Parameters.AddWithValue("DataConsegna", Convert.ToDateTime(s.dataConsegna));
            s.NumeroParcel = "SPL-" + DateTime.Now.ToString("yyMMddHHmmss");
            cmd.Parameters.AddWithValue("NumeroParcel", s.NumeroParcel);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("Insert INTO Dettaglio Values(@DataModifica, @LuogoModifica, @StatoModifica, @NumeroParcel)", conn);
            cmd.Parameters.AddWithValue("DataModifica", DateTime.Now);
            cmd.Parameters.AddWithValue("LuogoModifica", "Milano");
            cmd.Parameters.AddWithValue("StatoModifica", "Presa in carico");
            cmd.Parameters.AddWithValue("NumeroParcel", s.NumeroParcel);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Privato> getPrivati()
        {
            List<Privato> lista = new List<Privato>();
            SqlCommand cmd = new SqlCommand("select * from Privato", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Privato utente = new Privato();
                utente.Nome = sqlDataReader["NomeCliente"].ToString();
                utente.Cognome = sqlDataReader["CognomeCliente"].ToString();
                utente.Citta = sqlDataReader["CittaCliente"].ToString();
                utente.Indirizzo = sqlDataReader["IndirizzoCliente"].ToString();
                utente.CF = sqlDataReader["CF"].ToString();
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }

        public static List<Azienda> getAziende()
        {
            List<Azienda> lista = new List<Azienda>();
            SqlCommand cmd = new SqlCommand("select * from Azienda", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Azienda utente = new Azienda();
                utente.RagioneSociale = sqlDataReader["RagioneSociale"].ToString();
                utente.PartitaIva = Convert.ToInt32(sqlDataReader["PartitaIva"]);
                utente.Citta = sqlDataReader["CittaAzienda"].ToString();
                utente.Sede = sqlDataReader["Sede"].ToString();
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }

        public static List<SpedizioneAzienda> GetSpedizioniAzienda()
        {
            List<SpedizioneAzienda> lista = new List<SpedizioneAzienda>();
            SqlCommand cmd = new SqlCommand("select *, RagioneSociale from SpedizioneAzienda Inner Join Azienda on Azienda = PartitaIva", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                SpedizioneAzienda s = new SpedizioneAzienda();
                s.Azienda = sqlDataReader["RagioneSociale"].ToString();
                s.NomeDestinatario = sqlDataReader["NomeDestinatario"].ToString();
                s.CognomeDestinatario = sqlDataReader["CognomeDestinatario"].ToString();
                s.IndirizzoDestinatario = sqlDataReader["IndirizzoDestinatario"].ToString();
                s.CittaDestinatario = sqlDataReader["CittaDestinatario"].ToString();
                s.DataSpedizione = Convert.ToDateTime(sqlDataReader["DataSpedizione"]);
                s.dataConsegna = Convert.ToDateTime(sqlDataReader["DataConsegna"]);
                s.NumeroParcel = sqlDataReader["NumeroParcel"].ToString();
                lista.Add(s);
            }
            conn.Close();
            return lista;
        }

        public static List<SpedizionePrivato> GetSpedizioniPrivato()
        {
            List<SpedizionePrivato> lista = new List<SpedizionePrivato>();
            SqlCommand cmd = new SqlCommand("select *, CognomeCliente, NomeCliente  from SpedizionePrivato Inner Join Privato On Mittente = CF", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                SpedizionePrivato s = new SpedizionePrivato();
                s.Mittente = $"{sqlDataReader["CognomeCliente"].ToString()}, {sqlDataReader["NomeCliente"].ToString()}";
                s.NomeDestinatario = sqlDataReader["NomeDestinatario"].ToString();
                s.CognomeDestinatario = sqlDataReader["CognomeDestinatario"].ToString();
                s.IndirizzoDestinatario = sqlDataReader["IndirizzoDestinatario"].ToString();
                s.CittaDestinatario = sqlDataReader["CittaDestinatario"].ToString();
                s.DataSpedizione = Convert.ToDateTime(sqlDataReader["DataSpedizione"]);
                s.dataConsegna = Convert.ToDateTime(sqlDataReader["DataConsegna"]);
                s.NumeroParcel = sqlDataReader["NumeroParcel"].ToString();
                lista.Add(s);
            }
            conn.Close();
            return lista;
        }

        public static void deleteSpedPrivato(string parcel)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from SpedizionePrivato where NumeroParcel = @NumeroParcel", conn);
            cmd.Parameters.AddWithValue("NumeroParcel", parcel);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteSpedAzienda(string parcel)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from SpedizioneAzienda where NumeroParcel = @NumeroParcel", conn);
            cmd.Parameters.AddWithValue("NumeroParcel", parcel);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Dettaglio> GetDettagli(string parcel) 
        {
            List<Dettaglio> lista = new List<Dettaglio>();
            SqlCommand cmd = new SqlCommand("select * from Dettaglio where NumeroParcel = @NumeroParcel", conn);
            cmd.Parameters.AddWithValue("NumeroParcel", parcel);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Dettaglio s = new Dettaglio();
                s.DataModifica = Convert.ToDateTime(sqlDataReader["DataModifica"]);
                s.LuogoModifica = sqlDataReader["LuogoModifica"].ToString();
                s.StatoModifica = sqlDataReader["StatoModifica"].ToString();
                s.NumeroParcel = sqlDataReader["NumeroParcel"].ToString();
                lista.Add(s);
            }
            conn.Close();
            return lista;
        }

        public static void EditSped(Dettaglio d, ViewContext view)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Dettagli Values(@DataModifica, @LuogoModifica, @StatoModifica, @NumeroParcel)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("DataModifica", Convert.ToDateTime(d.DataModifica));
            cmd.Parameters.AddWithValue("LuogoModifica", d.LuogoModifica);
            cmd.Parameters.AddWithValue("StatoModifica", d.StatoModifica);
            cmd.Parameters.AddWithValue("NumeroParcel", view.RouteData.Values["Id"]);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}