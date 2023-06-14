using Microsoft.AspNetCore.Mvc;
using Recruitment_Tracker.data;
using Recruitment_Tracker.Models;

namespace Recruitment_Tracker.Controllers
{
    public class FolderUser : Controller
    {
        private readonly ILogger<FolderUser> _logger;
        private DbrecruitmentContext dbrecruitmentContext1;

        public FolderUser(ILogger<FolderUser> logger, DbrecruitmentContext dbrecruitmentContext)
        {
            _logger = logger;
            dbrecruitmentContext1 = dbrecruitmentContext;
        }
		//public IActionResult Index()
		//{
		//    return View();
		//}
		public IActionResult AppclientIndex()
        {
            return View();
        }
       
        //////////////////////////////////////////////// Controller Registration /////////////////////////////////////////
        [HttpGet]
        public IActionResult RegistrationAppclient()
        {
            Registration registration = new Registration();

            return View(registration);
        }
        [HttpPost]
        public IActionResult RegistrationAppclient (Registration registration)
        {
            var data = new DataPelamar()
            {
                Id = registration.Id,
                Nama = registration.Nama,
                Nik = registration.Nik,
                Gender = registration.Gender,
                Email = registration.Email,
                Phone = registration.Phone,
                Alamat = registration.Alamat,
                TempatLahir = registration.TempatLahir,
                TanggalLahir = registration.TanggalLahir,
                Agama = registration.Agama,
                Pendidikan = registration.Pendidikan,
                NamaPerguruan = registration.NamaPerguruan,
                Jurusan = registration.Jurusan,
                TahunLulus = registration.Jurusan,
                IdCalonKaryawan = registration.IdCalonKaryawan,
                IdPengumuman = registration.IdPengumuman,
                IdUser = registration.IdUser,
            };
            dbrecruitmentContext1.DataPelamars.Add(data);
            dbrecruitmentContext1.SaveChanges();

            return RedirectToAction("AnnouncmentAppclient", "FolderUser");
        }
        //////////////////////////////////////////////// Controlller Announcment /////////////////////////////////////////
        public IActionResult AnnouncmentAppclient()
        {
            RegistrationModel registrationModel = new RegistrationModel();
            registrationModel.ListRegistration = new List<Registration>();
            var data = dbrecruitmentContext1.DataPelamars.ToList();
            foreach (var Registration in data)
            {
                registrationModel.ListRegistration.Add(new Registration
                {
                    Id = Registration.Id,
                    Nama = Registration.Nama,
                    Nik = Registration.Nik,
                    Gender = Registration.Gender,
                    Email = Registration.Email,
                    Phone = Registration.Phone,
                    Alamat = Registration.Alamat,
                    TempatLahir = Registration.TempatLahir,
                    TanggalLahir = Registration.TanggalLahir,
                    Agama = Registration.Agama,
                    Pendidikan = Registration.Pendidikan,
                    NamaPerguruan = Registration.NamaPerguruan,
                    Jurusan = Registration.Jurusan,
                    TahunLulusan = Registration.TahunLulus,
                    IdCalonKaryawan = Registration.IdCalonKaryawan,
                    IdPengumuman = Registration.IdPengumuman,
                    IdUser = Registration.IdUser,
                });
            }

            return View(registrationModel);
        }
        public IActionResult appclientDetail()
        {
            RegistrationModel registrationModel = new RegistrationModel();
            registrationModel.ListRegistration = new List<Registration>();
            var data = dbrecruitmentContext1.DataPelamars.ToList();
            foreach (var Registration in data)
            {
                registrationModel.ListRegistration.Add(new Registration
                {
                    Id = Registration.Id,
                    Nama = Registration.Nama,
                    Nik = Registration.Nik,
                    Gender = Registration.Gender,
                    Email = Registration.Email,
                    Phone = Registration.Phone,
                    Alamat = Registration.Alamat,
                    TempatLahir = Registration.TempatLahir,
                    TanggalLahir = Registration.TanggalLahir,
                    Agama = Registration.Agama,
                    Pendidikan = Registration.Pendidikan,
                    NamaPerguruan = Registration.NamaPerguruan,
                    Jurusan = Registration.Jurusan,
                    TahunLulusan = Registration.TahunLulus,
                    IdCalonKaryawan = Registration.IdCalonKaryawan,
                    IdPengumuman = Registration.IdPengumuman,
                    IdUser = Registration.IdUser,
                });
            }

            return View(registrationModel);
        }

    }
}
