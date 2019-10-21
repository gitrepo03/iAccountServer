using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iHotel.Entity.Accounting;
using iHotel.Repository.Helper;
using iHotel.Service.ServiceInterface;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iHotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRefController : ControllerBase
    {
        private readonly IAccountRefService _service;

        public AccountRefController(IAccountRefService service)
        {
            this._service = service;
        }


        //// GET: api/AccountRef/All
        //[EnableQuery]
        //[HttpGet]
        //[Authorize(Roles = "SuperAdminDeveloper, Developer")]
        //[Route("All")]
        //public async Task<ActionResult<IEnumerable<AccountRef>>> GetAllWithInactive()
        //{
        //    try
        //    {
        //        return await _service.GetAll().ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
        //    }
        //}

        //// GET: api/AccountRef/GetAll
        //[EnableQuery]
        //[HttpGet]
        //[Authorize(Roles = "SuperAdminDeveloper, Developer")]
        //[HttpGet]
        //[Route("GetAll")]
        //public async Task<ActionResult<IEnumerable<AccountRef>>> GetAll()
        //{
        //    try
        //    {
        //        var orgDetails = await _service.Get().ToListAsync();
        //        return orgDetails;
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
        //    }
        //}

        //// GET: api/AccountRef/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AccountRef>> Get(int id)
        //{
        //    try
        //    {
        //        return await _service.GetAsync(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
        //    }
        //}

        // GET: api/Fiscal/SADGetAll
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "SuperAdminDeveloper, Developer")]
        [Route("SADGetAll")]
        public async Task<ActionResult<IEnumerable<AccountRef_R>>> SuperAdminDeveloperGetAll()
        {
            try
            {
                return await _service.GetAll().ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }


        // GET: api/Fiscal/SADGetAllActive
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "SuperAdminDeveloper, Developer")]
        [Route("SADGetAllActive")]
        public async Task<ActionResult<IEnumerable<AccountRef_R>>> SuperAdminDeveloperGetAllActive()
        {
            try
            {
                return await _service.GetAll().Where(fy => fy.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // GET: api/Fiscal/GetAll
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "OrgSuperAdmin, Developer")]
        [Route("OSAGetAll")]
        public async Task<ActionResult<IEnumerable<AccountRef_R>>> OrganizationSuperAdminDeveloperGetAll()
        {
            try
            {
                return await _service.GetAllOfOrg().ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // GET: api/Fiscal/OSAGetAll
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "OrgSuperAdmin, Developer")]
        [Route("OSAGetAllActive")]
        public async Task<ActionResult<IEnumerable<AccountRef_R>>> OrganizationSuperAdminDeveloperGetAllActive()
        {
            try
            {
                return await _service.GetAllOfOrg().Where(fy => fy.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // GET: api/Fiscal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountRef_R>> Get(int id)
        {
            try
            {
                return await _service.GetById(id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }


        // PUT: api/AccountRef/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AccountRef>> Put(int id, AccountRef AccountRef)
        {
            if (id == AccountRef.Id)
            {
                try
                {
                    return await _service.UpdateAsync(AccountRef);
                }
                catch (Exception ex)
                {
                    return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
                }
            }
            else
            {
                return BadRequest("Id and FiscalId doesnot match.");
            }
        }

        // POST: api/AccountRef
        [HttpPost]
        public async Task<ActionResult<AccountRef>> Post(AccountRef AccountRef)
        {
            try
            {
                AccountRef = await _service.CreateAsync(AccountRef);
                return CreatedAtAction("Get", new { id = AccountRef.Id }, AccountRef);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // DELETE: api/AccountRef/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountRef>> DeleteOrganization(int id)
        {
            try
            {
                if (await _service.DeleteAsync(id) != null)
                {
                    return Ok($"AccountRef Detail with id {id} is deleted successfully");
                }
                else
                {
                    return BadRequest($"Problem while deleting AccountRef. It seems we cannot find AccountRef with id {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        private async Task<bool> isExists(int id)
        {
            return await _service.GetById(id).SingleOrDefaultAsync() != null;
        }
    }
}
