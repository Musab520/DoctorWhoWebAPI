namespace DoctorWho.Web.DtoModels
{
    public class DoctorForUpdateDto
    {
        public int DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FirstEpisodeDate { get; set; }
        public DateTime LastEpisodeDate { get; set; }
    }
}
