using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        OnlineJobPortalContext AdminDBContext;
        public AdminController()
        {
            AdminDBContext = new OnlineJobPortalContext();
        }


        [HttpGet]
        [Route("getAdmins")]
        public List<TblAdmin> GetAdmins()
        {
            return AdminDBContext.TblAdmins.ToList();
        }

        [HttpGet]
        [Route("adminLogin")]
        public bool AdminLogin(TblAdmin admin)
        {
            TblAdmin found=new TblAdmin();
            try 
            {
                found = AdminDBContext.TblAdmins.First(ad => (ad.Username.Equals(admin.Username) && ad.Password.Equals(admin.Password) ));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"The error is {ex.Message.ToString()}");
            }
            if (found.Id != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [Route("getAdmin/{id}")]
        public List<TblAdmin> GetAdminByID(int id)
        {
            return AdminDBContext.TblAdmins.Where(admin => admin.Id == id).ToList();
        }

        [HttpPut]
        [Route("updateAdmin/{id}")]
        public void UpdateAdmin(TblAdmin adm,int id)
        {
            TblAdmin admin = AdminDBContext.TblAdmins.First(ad => ad.Id == id);
            admin.Username = adm.Username;
            admin.Password = adm.Password;
            AdminDBContext.SaveChangesAsync();
        }

        [HttpPut]
        [Route("approveCompany/{id}")]
        public void ApproveCompany(int id)
        {
            TblCompany cmp2 = new TblCompany();
            try
            {
                cmp2 = AdminDBContext.TblCompanies.First(cmp => cmp.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message is {ex.Message}");
            }

            if(cmp2.Id != null)
            {
                cmp2.Status = 1;
                AdminDBContext.SaveChangesAsync();
            }
        }

        [HttpPut]
        [Route("disapproveCompany/{id}")]
        public void DisApproveCompany(int id)
        {
            TblCompany cmp2 = new TblCompany();
            try
            {
                cmp2 = AdminDBContext.TblCompanies.First(cmp => cmp.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message is {ex.Message}");
            }

            if (cmp2.Id != null)
            {
                cmp2.Status = 0;
                AdminDBContext.SaveChangesAsync();
            }
        }
    }
}
