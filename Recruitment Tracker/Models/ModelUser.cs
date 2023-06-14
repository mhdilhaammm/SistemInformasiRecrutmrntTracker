namespace Recruitment_Tracker.Models
{
    public class UserModel
    {
        public List<UserAcc> UserList { get; set; }
    }
    public class CreateViewModel
    {
        public List<UserAcc> Categories { get; set; }
    }

    public class UserAcc
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Rolle { get; set; }
        public string NamaUser { get; set; }
    }

}
