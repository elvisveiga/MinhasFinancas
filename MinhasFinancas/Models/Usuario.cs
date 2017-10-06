using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinhasFinancas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime Registration_Date { get; set; }
        public string Token { get; set; }
    }
}