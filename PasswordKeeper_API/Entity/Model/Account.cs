using PasswordKeeper_API.Entity.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
