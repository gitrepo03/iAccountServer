using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iHotel.Entity.Admin;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Service.ServiceInterface;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using iHotel.Repository.Helper;

namespace iHotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService orgService;

        public OrganizationController(IOrganizationService orgService)
        {
            this.orgService = orgService;
        }

        // GET: api/Organization
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "SuperAdminDeveloper, Developer")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Organization>>> GetAllOrganizations()
        {
            try
            {
                var orgDetails = await orgService.GetAll().ToListAsync();
                return orgDetails;
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // GET: api/Organization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(int id)
        {
            try
            {
                return await orgService.GetById(id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // PUT: api/Organization/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Organization>> PutOrganization(int id, Organization organization)
        {
            if (id == organization.Id)
            {
                try
                {
                    return await orgService.UpdateAsync(organization);
                }
                catch (Exception ex)
                {
                    return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
                }
            }
            else
            {
                return BadRequest("Id and OrganizationId doesnot match.");
            }
        }

        // POST: api/Organization
        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganization(Organization organization)
        {
            try
            {
                organization = await orgService.CreateAsync(organization);
                return CreatedAtAction("Get", new { id = organization.Id }, organization);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // DELETE: api/Organization/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organization>> DeleteOrganization(int id)
        {
            try
            {
                if (await orgService.DeleteAsync(id) != null)
                {
                    return Ok($"Organization Detail with id {id} is deleted successfully");
                }
                else
                {
                    return BadRequest($"Problem while deleting Organization Detail. It seems we cannot find Organization Detail with id {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        private async Task<bool> OrganizationExists(int id)
        {
            return await orgService.GetById(id).SingleOrDefaultAsync() != null;
        }
    }
}
