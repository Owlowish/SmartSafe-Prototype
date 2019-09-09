using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartsafe.Models;
using Microsoft.AspNetCore.Authorization;

namespace Smartsafe.Controllers
{
    public class LockController : Controller
    {
        
        // INITIALISATION DES CONTEXT DB
        private readonly UserContext _context;
        private readonly VariableContext _context2;
        private readonly EventContext _context3;
        
        public LockController(UserContext context1, VariableContext context2, EventContext context3)
        {
            _context = context1;
            _context2 = context2;
            _context3 = context3;
        }        
        
        public IActionResult Index()
        {
            return View();
        }


        // DEVEROUILLAGE : VERRIFICATION MDP ET IDENTIFIANT

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(User user)
        {
  
           // recherche dans la base de donnée l'élément correspondant aux critères
            try
            {
           // initialisation de userdb, issus de User.db, correspondant à l'identifiant entré par l'utilisateur
                var userdb = (from m in _context.User
                            where (m.UserNumber == user.UserNumber )
                            select m).Single();

            // debug Output *******************************************************************************
            Console.WriteLine("\n"+"\n"+"************  DEBUG ****************"+"\n"+"\n");
            Console.WriteLine ("Username INPUT : " + user.UserNumber);
            Console.WriteLine ("Password INPUT : " + user.Password);
            Console.WriteLine ("DataBase -- UserID : " + userdb.UserNumber + "  Password : " +  userdb.Password + "  Name : " + userdb.FirstName );
            Console.WriteLine ("time : " + DateTime.Now);
            Console.WriteLine("\n"+"\n"+"************************************"+"\n"+"\n");
            // *********************************************************************************************

            // vérification du mot de passe correspondant
            if (userdb.Password == user.Password)
           {                 
                // on donne l'accès en validant le token de connexion
                 var signedin = (from m in _context2.Variable
                            select m).Single();
                signedin.SignedIn= 1;
                _context2.SaveChanges();

                // on enregistre l'évenement
                
                _context3.Event.AddRange(

                    new Event{
                        Date = DateTime.Now,
                        Source = "User",
                        Criticite = 1,
                        Description = "Ouverture Coffre",           
                    }
                );
                _context3.SaveChanges();
                 return RedirectToAction("Unlock","Lock");
            }

              if (userdb.Password != user.Password)               
                return RedirectToAction("Erreur","Lock");
            }

            catch (System.Exception)
            {      
                 return RedirectToAction("Erreur","Lock");
            }

            return View(user);
        }



          public IActionResult Unlock()
        {
            return View();
        }



         public IActionResult Erreur()
        {
            return View();
        }


         public IActionResult SignOff()
        {
            // On refute le token de connexion
            var signedin = (from m in _context2.Variable
                        select m).Single();
            signedin.SignedIn= 0;
            _context2.SaveChanges();

            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
