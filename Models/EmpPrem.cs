﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ArtGallery.Models
{
    public partial class EmpPrem
    {
        public int Eid { get; set; }
        public string Ename { get; set; }
        public int? Salary { get; set; }
        public DateTime? Doj { get; set; }
        public string City { get; set; }
    }
}
