using System;
using System.Collections.Generic;

#nullable disable

namespace Drop.Web.models
{
    public partial class AdminUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }
}
