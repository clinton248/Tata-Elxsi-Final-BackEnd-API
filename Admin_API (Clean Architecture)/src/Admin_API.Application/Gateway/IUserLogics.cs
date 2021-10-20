using Admin_API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_API.Application.Gateway
{
    public interface IUserLogics
    {
        List<UserDto> GetAll();
        int EditInfo(EditDto model);
    }
}
