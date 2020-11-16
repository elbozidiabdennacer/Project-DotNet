using Project.Models;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projet.Controllers
{
    public class GestionController : Controller
    {

        public List<Categorie> listCat = new List<Categorie>();

        List<Livre> listLivres = new List<Livre>();
        // GET: Gestion
        public ActionResult Accueil()
        {

            listLivres = ConnexionBD.getLivre();
            listCat = ConnexionBD.getCategorie();

            ViewBag.categ = listCat;
            ViewBag.Title ="Accueil";
            return View(listLivres);
        }

        // GET: Gestion/Details/5
        public ActionResult Details(int id)
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("login");
            }
            
            Livre livre = ConnexionBD.getLivreById(id);

            ViewBag.categ = listCat;
            ViewBag.Title = "Details";
            return View(livre);
        }

        
        public ActionResult Categorie(string ncat)
        {

            listCat = ConnexionBD.getCategorie();
            listLivres = ConnexionBD.getLivreByIdB(ncat);
            ViewBag.Title = ncat;
            ViewBag.categ = listCat;
            return View(listLivres);
        }

      
        public ActionResult signin()
        {
            return View();
        }

        public ActionResult signin(string y)
        {
            string nom = Request["nom"];
            string prenom = Request["Prenom"];
            string email = Request["Email"];
            string addresse = Request["Adresse"];
            string tele = Request["Tele"];
            string pass = Request["pass"];

            if (nom.Equals("") || prenom.Equals("") || email.Equals("") || addresse.Equals("") || tele.Equals("") || pass.Equals(""))
            {
                return View();
            }
            else
            {
                Client client = new Client(nom, prenom, email, addresse, tele, pass);
                ConnexionBD.setClient(client);
                Client user = ConnexionBD.login(email, pass);

                Session["user"] = user;
                return RedirectToAction("Accueil");
            }
            
        }


        public ActionResult login()
        {
              return View();
        }


        public ActionResult EstUser()
        {

            string email = Request["Email_l"];
            string pass = Request["passl"];

            Client user = ConnexionBD.login(email,pass);
            if (user != null)
            {
                Session["user"] = user;
                if (ConnexionBD.estAdmin(user.Email, user.password)) 
                {

                    return RedirectToAction("Index", "Admin/");
                }

                else
                {
                    return RedirectToAction("Accueil");
                }


            }

            ViewBag.er = "Erreur ";
            return RedirectToAction("login");    
        }

        public ActionResult vuePanier()
        {
            listCat = ConnexionBD.getCategorie();
            ViewBag.categ = listCat;
            Panier panier = (Panier)Session["panier"];
            if (panier == null)
                panier = new Panier();

            return View(panier.getLivres);
        }

        public ActionResult addAuPanier(int idl,string sender)
        {
            
            Livre livre = ConnexionBD.getLivreById(idl);
            if (Session["panier"] == null)
            {
                Session["panier"] = new Panier();
            }

            Panier panier =(Panier) Session["panier"];
            


            if (sender.Equals("pan"))
            {
                panier.sousLivre(livre);
                Session["panier"] = panier;
                return RedirectToAction("vuePanier");
            }

            else if (sender.Equals("det"))
            {
                panier.addLivre(livre);
                Session["panier"] = panier;
                return RedirectToAction("Accueil");
            }

            return null;
        }


        public ActionResult AddCommend()
        {
            Client user = (Client)Session["user"];
            Panier panier = (Panier)Session["panier"];

            if(user!=null && panier != null)
            {
            
                Commande c = new Commande();
                c.IdC = user.IdC;
                c.quantite = 1;
                c.Date= DateTime.Now.ToString("dd MMMM yyyy hh: mm:ss tt");

                foreach (var item in panier.getLivres)
                {
                    c.IdBk = item.IdBk;
                    ConnexionBD.setCommande(c);
                }

            }
            return RedirectToAction("Accueil");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Accueil");
        }

    }
}
