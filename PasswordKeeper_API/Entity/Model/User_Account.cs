using PasswordKeeper_API.Entity.Model.Common;

namespace PasswordKeeper_API.Entity.Model
{
    public class User_Account : BaseModel
    {
        public int User_AccountId { get; set; }
        //public int UserId { get; set; }
        //public virtual User User {get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string GSM { get; set; }
        public string Password { get; set; }
    }
}
