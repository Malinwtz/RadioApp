using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioServiceLibrary.RadioApiModels
{
    public class RadioProgram
    {
        public int Id { get; set; } //hämtas
        public string Title { get; set; } 
        public ProgramDetails Details { get; set; }
    }
}
