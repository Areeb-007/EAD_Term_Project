using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineJobPortal.Models
{
    public partial class TblCompany
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public int? Status { get; set; }
    }
}
