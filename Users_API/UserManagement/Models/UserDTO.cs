namespace UserManagement.Controllers
{
    internal class UserDTO
    {
        public UserDTO(string email, string userName, string role, string status)
        {
            this.email = email;
            this.userName = userName;
            this.role = role;
            this.status = status;
        }
        public string email { get; set; }
        public string userName { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public string Token { get; set; }
    }
}