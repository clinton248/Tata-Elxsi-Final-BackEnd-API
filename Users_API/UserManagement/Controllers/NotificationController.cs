using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Authentication;
using UserManagement.Models;

namespace UserManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class NotificationController : ControllerBase
    {
        SqlConnection con = new SqlConnection(@"server=104.251.211.189;user id= SA;password=Clintontom1@;database=UserManagementDB");
        private readonly ApplicationDbContext _context;

        public NotificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Notification

        [HttpGet("{UserName}")]
        [Authorize]
        public string GetNotification(string UserName)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Notifications where UserName='" + UserName + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No Data found";
            }
        }

        // POST api/<NotisController>
        [HttpPost]
        public async Task<IActionResult> PostNotification([FromBody] NotificationModel model)
        {
            SqlCommand cmd = new SqlCommand("Insert into Notifications(Count,Notification_Message,Date,UserName) values('" + model.count + "','" + model.Notification_Message + "','" + model.Date + "','" + model.UserName + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return Ok(new Response { Status = "Success", Message = "Data inserted successfully!!!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "error", Message = "Insertion Failed" });
            }
        }

        // PUT api/<NotisController>/5
        [HttpPut]
        public async Task<IActionResult> PutNotification([FromBody] NotificationModel model)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Notifications SET Status='" + model.Status + "' WHERE UserName='" + model.UserName+ "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return Ok(new Response { Status = "Success", Message = "Marked all as read" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "error", Message = "No Notification found" });
            }
        }

        // DELETE api/<NotisController>/5
        [HttpDelete("{UserName}")]
        [Authorize]
        public async Task<IActionResult> DeleteNotification(string Username)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Notifications WHERE UserName='" + Username + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //int count = 0;
            if (Username != null)
            {
                SqlCommand del = new SqlCommand("Delete from Notifications Where UserName ='" + Username + "' ", con);
                con.Open();
                int a = del.ExecuteNonQuery();
                con.Close();
                return Ok(new Response { Status = "Success", Message = "Deleted Successfully!!!" });
            }
            else
            {
                SqlCommand del = new SqlCommand("Delete from Notifications", con);
                con.Open();
                int a = del.ExecuteNonQuery();
                con.Close();
                return Ok(new Response { Status = "Success", Message = "Cleared all Notification" });
            }
        }

    }
}
