﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Ilk_Mvc_Projesi.Models
{
    public partial class DumonVw
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CompanyName { get; set; }
    }
}
