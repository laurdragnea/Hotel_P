using Hotel_P.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace Hotel_P.Controllers
{
    public class ReservationController : Controller
    {
        
        public IActionResult Index(int ID)
        {

            ViewBag.ID = ID;
            return View();
        }
        
       
    }
}
