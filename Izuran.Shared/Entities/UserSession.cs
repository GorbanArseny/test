using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izuran.Shared.Entities
{
    public class UserSession
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token {  get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; }
    }
}
