namespace Recruitment_Tracker.Models
{

    public class AnnouncmentModel
    {
        public List<Announcment> AnnouncmentList { get; set; }
    }

    public class Announcment
    {
        public int id_pengumuman { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }

    }
}
