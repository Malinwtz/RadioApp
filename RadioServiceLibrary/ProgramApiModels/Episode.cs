﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioServiceLibrary.ProgramApiModels
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AudioUrl { get; set; }
    }
}
