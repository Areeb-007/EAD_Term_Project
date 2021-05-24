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
    public class CompaniesController : ControllerBase
    {
        OnlineJobPortalContext CompanyDBContext;
        public CompaniesController()
        {
            CompanyDBContext = new OnlineJobPortalContext();
        }


        [HttpGet]
        [Route("companyLogin")]
        public bool CompanyLogin(TblCompany cmp1)
        {
            TblCompany found = new TblCompany();
            try
            {
                found = CompanyDBContext.TblCompanies.First(cmp => (cmp.Email.Equals(cmp1.Email) && cmp.Password.Equals(cmp1.Password)));
            }
            catch (Exception ex)
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
        [Route("getCompanies")]
        public List<TblCompany> Get()
        {
            return CompanyDBContext.TblCompanies.ToList();
        }

        [HttpGet]
        [Route("getCompany/{id}")]
        public TblCompany GetCompanyById(int id)
        {
            TblCompany company = new TblCompany();
            try 
            {
                company = CompanyDBContext.TblCompanies.First(cmp => cmp.Id == id);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Message is {ex.Message}");
            }
            return company;
        }


        [HttpPost]
        [Route("addCompany")]
        public async Task AddCompany(TblCompany company)
        {
            CompanyDBContext.TblCompanies.Add(company);
            await CompanyDBContext.SaveChangesAsync();
        }
        [HttpDelete]
        [Route("deleteCompany/{id}")]
        public void DeleteCompany(int id)
        {
            CompanyDBContext.TblCompanies
                .Remove(CompanyDBContext.TblCompanies.First(cmp => cmp.Id == id));
            CompanyDBContext.SaveChangesAsync();
        }

        [HttpPut]
        [Route("updateCompany/{id}")]
        public void UpdateCompany( TblCompany cmp, int id)
        {
            TblCompany cmp2 = CompanyDBContext.TblCompanies.First(cm => cm.Id == id);
            cmp2.Name = cmp.Name;
            cmp2.Password = cmp.Password;
            cmp2.Status = cmp.Status;
            cmp2.Email = cmp.Email;
            cmp2.ContactNumber = cmp.ContactNumber;
            cmp2.Website = cmp.Website;
            CompanyDBContext.SaveChangesAsync();
        }
    }
}
