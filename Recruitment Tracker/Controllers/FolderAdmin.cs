using Microsoft.AspNetCore.Mvc;
using Recruitment_Tracker.data;
using Recruitment_Tracker.Models;
using Microsoft.AspNetCore.Session;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Recruitment_Tracker.Controllers
{
    public class FolderAdmin : Controller
    {
        private readonly ILogger<FolderAdmin> _logger;
        private DbrecruitmentContext dbrecruitmentContext1;

        public FolderAdmin(ILogger<FolderAdmin> logger, DbrecruitmentContext dbrecruitmentContext)
        {
            _logger = logger;
            dbrecruitmentContext1 = dbrecruitmentContext;
        }

		public IActionResult AdminIndex()
        {
            return View();
        }
        public IActionResult adminDetail() 
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
        public IActionResult AnnouncmentAdmin()
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

        [HttpPost]
        public ActionResult AcceptReject(int id, string acceptButton, string rejectButton)
        {
              var data = dbrecruitmentContext1.DataPelamars.Find(id);

            if (acceptButton == "accept" /*&& data.IdCalonKaryawan < 2*/)
            {
                data.Jurusan = "Selamat Anda Lolos";
                //data.IdCalonKaryawan++;
            }
            else if (rejectButton == "reject" /*&& data.IdPengumuman < 2*/)
            {
                data.Jurusan = "Maaf Anda Tidak Lolos";
                //data.IdPengumuman++;
            }
            else
            {
                
            }
            dbrecruitmentContext1.SaveChanges();

            return RedirectToAction("AnnouncmentAdmin", new { id = data.Id });
        }
        


    }
}
