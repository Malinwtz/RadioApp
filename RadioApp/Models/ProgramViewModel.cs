namespace RadioApp.Models
{
    public class ProgramViewModel
    {       
        public string Channel { get; set; } //p1, p2, p3
        //public string Category { get; set; } //vilken kategori programmet tillhör
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<EpisodeViewModel> Episodes { get; set; } //3 senaste avsnitten för varje program
    }
}
