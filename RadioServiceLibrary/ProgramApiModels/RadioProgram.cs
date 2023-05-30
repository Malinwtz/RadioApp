using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RadioServiceLibrary.ProgramApiModels
{
    public class RadioProgram
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string ProgramImage { get; set; }
        public string Description { get; set; }
        public Channel Channel { get; set; }
        public List<Episode> LatestEpisodes { get; set; }

    }
}
