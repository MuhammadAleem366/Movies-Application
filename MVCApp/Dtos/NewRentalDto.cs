﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.Dtos
{
    public class NewRentalDto
    {
        public int CutomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}