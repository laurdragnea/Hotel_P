using Hotel_P.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Hotel_P.Controllers
{
    public class BookingController : Controller
    {
        [HttpPost]
        public IActionResult Index(reservation cstm,int ID)
        {
            ViewBag.ID = ID;

            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=hotel_tr;port=3306;password=pass222"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                string sql = "UPDATE `hotel_tr`.`rooms` SET `free` = '0' WHERE (`roomID` = '" + ViewBag.ID + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                sql = "INSERT INTO `hotel_tr`.`reservations` (`customerID`, `First_Name`, `Last_Name`, `Email`, `Phone`, `Address`, `Start_date`, `End_date`) VALUES ('" + cstm.Id+"', '"+cstm.fname+"', '"+cstm.lname+"', '"+cstm.email+"', '"+cstm.phone+"', '"+cstm.address+ "', '"+cstm.start_date+ "', '"+cstm.end_date+"')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();


                con.Close();
            }
            return View();
        }
    }
}
