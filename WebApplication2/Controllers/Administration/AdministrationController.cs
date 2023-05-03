using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Application.Administration.Implementations;
using TM.Application.Administration.Interfaces;
using TM.Application.EmployeeManagement.Implementations;
using TM.Application.EmployeeManagement.Interfaces;
using TM.Model.Business.EmployeeManagement;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IAdministrationApplication administrationApplication;
        public AdministrationController(IAdministrationApplication administrationApplication)
        {
            this.administrationApplication = administrationApplication;
        }


        //[Authorize]
        [Route("api/GetMenuItemDetails")]
        [HttpGet]
        public async Task<List<MenuDetails>> MenuItemDetails()
        {
            List<MenuDetails> menuDetails = await administrationApplication.MenuItemDetails();
            return menuDetails;
        }

        // GET api/<AdministrationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdministrationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdministrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdministrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
