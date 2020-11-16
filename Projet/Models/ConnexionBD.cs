using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Web;
using MySql.Data.MySqlClient;
using Projet.Models;

namespace Project.Models
{
    public class ConnexionBD
    {

        public static MySqlConnection getConnexion()
          {
              try
              {
                  string strCon = "Server=localhost;Database=vendre_books;port=3307;User Id=root;password=";
                  MySqlConnection cn = new MySqlConnection(strCon);
                  Console.WriteLine("État de la connexion : " + cn.State);
                  return cn;
              }
              catch (Exception e)
              {
                  Console.WriteLine("Erreur : " + e.Message);
                  return null;
              } 
          }

        
        public static void setResultat(string sql)
        {

            try
            {
                MySqlConnection cnx = ConnexionBD.getConnexion();
                MySqlCommand cmd = new MySqlCommand(sql, cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur " + e.Message);
            }
        }

        public static void setClient(Client c)
        {

            string sql = "INSERT INTO client(NomC,PrenomC , EmailC, AddresseC, TeleC, Password) " +
                "VALUES ('"+c.Nom+"','"+c.Prenom+"','"+c.Email+"','"+c.Addresse+"','"+c.Tele+"','"+c.password+"');";
            ConnexionBD.setResultat(sql);
        }

       


        public static void setLivre(Livre l)
        {
            string sql = "INSERT INTO books(NomBk, AuteurBk, Date_edition, PrixBk, pthimage, IdB)" +
                "VALUES ('"+l.Nom+"','"+l.Auteur+"','"+l.date_edition+"','"+ l.Prix+"','"+l.pthimg+"','"+l.IdB+"')";
            ConnexionBD.setResultat(sql);
        }


        public static void setCategorie(Categorie c)
        {
            string sql= "INSERT INTO biblio(IdB, NomB) VALUES ("+c.IdB+",'"+c.NomB+"')";
            ConnexionBD.setResultat(sql);
        }


        public static void setCommande(Commande c)
        {
            string sql = "INSERT INTO commande(IdC, IdBk, quantite, Date) " +
                "VALUES ('"+c.IdC+"','"+c.IdBk+"','"+c.quantite+"','"+c.Date+"')";
            ConnexionBD.setResultat(sql);
        }


        public static MySqlDataReader getResultat(string sql)
        {

            try
            {
                MySqlConnection cnx = ConnexionBD.getConnexion();
                MySqlCommand cmd = new MySqlCommand(sql, cnx);
                cnx.Open();
                MySqlDataReader resultat = cmd.ExecuteReader();
                
                return resultat;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur " + e.Message);
                return null;
            }

        }


        public static List<Categorie> getCategorie()
        {
            List<Categorie> listCat = new List<Categorie>();
            string sql = "SELECT * FROM biblio;";
            MySqlDataReader dataCat = ConnexionBD.getResultat(sql);

            while (dataCat.Read())
            {
                Categorie cat = new Categorie();
                cat.IdB = dataCat.GetInt16(0);
                cat.NomB = dataCat.GetString(1);
                listCat.Add(cat);
            }
            return listCat;
        }


        public static List<Livre> getLivre()
        {
            List<Livre> listLivres = new List<Livre>();
            string sql = "SELECT * FROM books;";
            MySqlDataReader dataLivres = ConnexionBD.getResultat(sql);
            while (dataLivres.Read())
            {
                Livre livre = new Livre();
                livre.IdBk = dataLivres.GetInt16(0);
                livre.Nom = dataLivres.GetString(1);
                livre.pthimg = dataLivres.GetString(6);

                listLivres.Add(livre);
            }
            return listLivres;

        }


        public static Livre getLivreById(int id)
        {
            Livre livre = new Livre();
            string sql = "SELECT * FROM books WHERE IdBk="+id+";";
            MySqlDataReader l= ConnexionBD.getResultat(sql);
            if (l.Read())
            {
                livre.IdBk = l.GetInt16(0);
                livre.Nom = l.GetString(1);
                livre.Auteur = l.GetString(2);
                livre.date_edition = l.GetString(3);
                livre.Prix = l.GetDouble(4);
                livre.pthimg = l.GetString(6);
                livre.IdB = l.GetInt16(7);
            }
            return livre;
        }


        public static List<Livre> getLivreByIdB(string cat)
        {
            List<Livre> listLivres = new List<Livre>();
            string sql = "SELECT * FROM books b, biblio o WHERE b.IdB=o.Idb and o.NomB='"+cat+"'";
            MySqlDataReader dataLivres =  ConnexionBD.getResultat(sql);
            Livre livre = new Livre();
            while (dataLivres.Read())
            {
                
                livre.IdBk = dataLivres.GetInt16(0);
                livre.Nom = dataLivres.GetString(1);
                livre.pthimg = dataLivres.GetString(6);

                listLivres.Add(livre);
            }
            return listLivres;

        }

        public static List<Client> getClients()
        {
            
            List<Client> clients = new List<Client>();
            string sql = "SELECT * FROM client";
            MySqlDataReader dataClients = ConnexionBD.getResultat(sql);

            while (dataClients.Read())
            {
                Client cl = new Client();
                cl.IdC = dataClients.GetInt16(0);
                cl.Nom = dataClients.GetString(1);
                cl.Prenom = dataClients.GetString(2);
                cl.Email = dataClients.GetString(3);
                cl.Addresse = dataClients.GetString(4);
                cl.Tele = dataClients.GetString(5);

                clients.Add(cl);
            }
            return clients;
        }

        public static List<getCommande> getCommandes()
        {
            
            List<getCommande> commandes = new List<getCommande>();

            String query = "SELECT cl.NomC, cl.PrenomC, cl.EmailC, cl.AddresseC, cl.TeleC, b.NomBk, b.IdBk, cm.Date  FROM client cl, commande cm, books b "
                        + "WHERE cm.IdC=cl.IdC and cm.IdBk=b.IdBk";

            MySqlDataReader dc = ConnexionBD.getResultat(query);

            while (dc.Read())
            {
                getCommande c = new getCommande();
                c.Nom = dc.GetString("NomC");
                c.Prenom = dc.GetString("PrenomC");
                c.Email = dc.GetString("EmailC");
                c.Addresse = dc.GetString("AddresseC");
                c.Tele = dc.GetString("TeleC");
                c.NomBk = dc.GetString("NomBk");
                c.IdBk = dc.GetInt16("IdBk");
                c.date = dc.GetString("Date");

                commandes.Add(c);
            }

            return commandes;
        }


        public static Client login(string email, string pass)
        {

            string sql = "SELECT * FROM client WHERE EmailC ='" + email + "' AND Password='" + pass + "'";
            Client user = new Client();
            MySqlDataReader dataUser = ConnexionBD.getResultat(sql);
            if (dataUser.Read())
            {
                user.IdC = dataUser.GetInt32(0);
                user.Nom = dataUser.GetString(1);
                user.Prenom = dataUser.GetString(2);
                user.Email = dataUser.GetString(3);
                user.Addresse = dataUser.GetString(4);
                user.Tele = dataUser.GetString(5);
                user.password = dataUser.GetString(6);

                return user;
            }
            else
            {
                return null;
            }
        }


        public static Boolean estAdmin(string email, string pass)
        {
            string sql = "SELECT * FROM client where IdC=1";
            MySqlDataReader admin = ConnexionBD.getResultat(sql);
           if(admin.Read())
           {
                string ad_email = admin.GetString(3);
                string ad_pass = admin.GetString(6);

                if (email.Equals(ad_email) && pass.Equals(ad_pass) ) { 
                    return true;
                }
                else
                {
                    return false;
                }
           }
            else
            {
                return false;
            }
        }

    }
}









