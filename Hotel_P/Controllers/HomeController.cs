using Hotel_P.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Hotel_P.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
             List<Room> rooms = new List<Room>();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=hotel_tr;port=3306;password=pass222"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from rooms WHERE free = TRUE", con);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

                while (mySqlDataReader.Read())
                {

                    Room rm;
                    rm = new Room();
                    rm.Id = Convert.ToInt32(mySqlDataReader["roomID"]);
                    rm.free = Convert.ToBoolean(mySqlDataReader["free"]);
                    rm.room_type = Convert.ToString(mySqlDataReader["room_type"]);
                    rm.capacity = Convert.ToInt32(mySqlDataReader["capacity"]);
                    rm.floor = Convert.ToInt32(mySqlDataReader["floor"]);

                    rooms.Add(rm);


                }

                con.Close();
            }
            return View(rooms);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}