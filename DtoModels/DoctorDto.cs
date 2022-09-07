namespace DoctorWho.Web.DtoModels
{
    public class DoctorDto
    {
        public class Doctor
        {
            public int DoctorId { get; set; }
            public int DoctorNumber { get; set; }
            public string DoctorName { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime FirstEpisodeDate { get; set; }
            public DateTime LastEpisodeDate { get; set; }
           // public List<EpisodeDto> EpisodeList { get; set; }
        }
    }
}
