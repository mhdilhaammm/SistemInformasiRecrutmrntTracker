using System.ComponentModel.DataAnnotations;

namespace Recruitment_Tracker.Models
{
    public class RegistrationModel
    {
        public List<Registration> ListRegistration { get; set; }
    }
    public class Registration
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Nik { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone  { get; set; }
        public string Alamat { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string Agama { get; set; }
        public string Pendidikan { get; set; }
        public string NamaPerguruan { get; set; }
        public string Jurusan { get; set; }
        public string TahunLulusan { get; set; }
        public int? IdCalonKaryawan { get; set; }
        public int? IdPengumuman { get; set; }
        public int? IdUser { get; set; }

    }
}
