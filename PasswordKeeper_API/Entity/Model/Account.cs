using PasswordKeeper_API.Entity.Model.Common;

namespace PasswordKeeper_API.Entity.Model
{
    public class Account: BaseModel
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }
}
