﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinhasFinancas.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int User_Id { get; set; }
    }
}