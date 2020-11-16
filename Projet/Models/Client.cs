using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Client
    {
        private int _IdC;
        private string _Nom;
        private string _Prenom;
        private string _Email;
        private string _Addresse;
        private string _Tele;
        private string _password;

        public Client() { }

        public Client(string Nom, string Prenom, string Email,string Addresse, string Tele,string password)
        {
            _Nom = Nom;
            _Prenom = Prenom;
            _Email = Email;
            _Addresse = Addresse;
            _Tele = Tele;
            _password = password;
        }

        public Client(string Nom, string Prenom,string Email, string Addresse, string Tele) 
        {
            _Nom = Nom;
            _Prenom = Prenom;
            _Email = Email;
            _Addresse = Addresse;
            _Tele = Tele;
        }

        public int IdC
        {
            get { return _IdC; }
            set { _IdC = value; }
        }

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        public string Prenom
        {
            get { return _Prenom; }
            set { _Prenom = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Addresse
        {
            get { return _Addresse; }
            set { _Addresse = value; }
        }

        public string Tele
        {
            get { return _Tele; }
            set { _Tele = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

    }
}