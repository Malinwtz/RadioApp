using RadioServiceLibrary.ProgramApiModels;

namespace RadioApp.Models
{
    public class ProgramViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgramImage { get; set; }
        public string Description { get; set; }
        public ChannelViewModel Channel { get; set; }
        public List<EpisodeViewModel> LatestEpisodes { get; set; }

    }
}
