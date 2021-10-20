using Admin_API.Application.DTOs;
using Admin_API.Application.Gateway;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Admin_API.Application.AdminAppLayer.Usecases.UserList
{
    public class UserLogics : IUserLogics
    {
        SqlConnection con = new SqlConnection(@"server=104.251.211.189;user id= SA;password=Clintontom1@;database=UserManagementDB");
        private readonly IProfileDbContext _ProfileDbContext;
        public UserLogics(IProfileDbContext ProfileDbContext)
        {
            _ProfileDbContext = ProfileDbContext;
        }

        public List<UserDto> GetAll()
        {


            return _ProfileDbContext.Users
                .Select(_ => new UserDto
                {
                    // Id = _.Id,
                    UserName = _.UserName,
                    Email = _.Email,
                    Continent = _.Continent,
                    Country = _.Country,
                    Language = _.Language,
                    Address = _.Address,
                    PhoneNumber = _.PhoneNumber,
                    Status = _.Status
                }).ToList();
        }
        public int EditInfo(EditDto model)
        {
            //  var user = await userManager.FindByNameAsync(model.UserName);
            string Status = model.Status.ToString();
            string UserName = model.UserName.ToString();

            SqlCommand cmd = new SqlCommand("UPDATE AspNetUsers SET Status='" + Status + "'WHERE Username='" + UserName + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }


    }
}
