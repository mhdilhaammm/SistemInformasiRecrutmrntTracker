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

namespace Recruitment_Tracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DbrecruitmentContext dbrecruitmentContext1;

        public HomeController(ILogger<HomeController> logger, DbrecruitmentContext dbrecruitmentContext)
        {
            _logger = logger;
            dbrecruitmentContext1 = dbrecruitmentContext;
        }
		public IActionResult Index()
		{
			return View();
		}

        ///////////////////////////////////////////////////////////////////// Controller Login //////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("rolle") == "Admin")
            {
                return RedirectToAction("AdminIndex", "FolderAdmin");
            }
            else if (HttpContext.Session.GetString("rolle") == "User")
            {
                return RedirectToAction("AppclientIndex", "FolderUser");
            }
            else
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAcc user)
        {
           var data = dbrecruitmentContext1.Users.Where(m => (m.Username== user.Username) && (m.Password== user.Password)).FirstOrDefault();

            if( data != null)
            {
                HttpContext.Session.SetInt32("id", data.IdUser);
                HttpContext.Session.SetString("username", value: data.Username);
                HttpContext.Session.SetString("password", data.Password);
                HttpContext.Session.SetString("email", data.Email);
                HttpContext.Session.SetString("rolle", data.Rolle);

                return RedirectToAction("Login", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }
        //////////////////////////////////////////////////////////////////// Controller Logout ///////////////////////////////////////////////////////////
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        ///////////////////////////////////////////////////////////////////// Controller Announcment /////////////////////////////////////////////////////
        public IActionResult Announcment()
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

        ///////////////////////////////////////////////////////////////// Controller Registration Account /////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult RegistrasiAccount()
        {   
            UserAcc userAcc = new UserAcc();

            return View(userAcc);
        }
        [HttpPost]
        public IActionResult RegistrasiAccount(UserAcc userAcc)
        {
           
            var data = new User()
            {
                IdUser = userAcc.IdUser,
                NamaUser = userAcc.NamaUser,
                Username = userAcc.Username,
                Password = userAcc.Password,
                Email = userAcc.Email,
                Rolle = userAcc.Rolle,
            };
            dbrecruitmentContext1.Users.Add(data);
            dbrecruitmentContext1.SaveChanges();

            return RedirectToAction("RegistrasiAccount", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



