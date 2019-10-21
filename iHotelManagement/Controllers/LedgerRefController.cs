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
    public class LedgerRefController : ControllerBase
    {
        private readonly ILedgerRefService _service;

        public LedgerRefController(ILedgerRefService service)
        {
            this._service = service;
        }


        //// GET: api/LedgerRef/All
        //[EnableQuery]
        //[HttpGet]
        //[Authorize(Roles = "SuperAdminDeveloper, Developer")]
        //[Route("All")]
        //public async Task<ActionResult<IEnumerable<LedgerRef>>> GetAllWithInactive()
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

        //// GET: api/LedgerRef/GetAll
        //[EnableQuery]
        //[HttpGet]
        //[Authorize(Roles = "SuperAdminDeveloper, Developer")]
        //[HttpGet]
        //[Route("GetAll")]
        //public async Task<ActionResult<IEnumerable<LedgerRef>>> GetAll()
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

        //// GET: api/LedgerRef/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<LedgerRef>> Get(int id)
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
        public async Task<ActionResult<IEnumerable<LedgerRef_R>>> SuperAdminDeveloperGetAll()
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
        public async Task<ActionResult<IEnumerable<LedgerRef_R>>> SuperAdminDeveloperGetAllActive()
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
        [Authorize(Roles = "OrgSuperAdmin, Developer")]
        [HttpGet]
        [Route("OSAGetAll")]
        public async Task<ActionResult<IEnumerable<LedgerRef_R>>> OrganizationSuperAdminDeveloperGetAll()
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
        [Authorize(Roles = "OrgSuperAdmin, Developer")]
        [HttpGet]
        [Route("OSAGetAllActive")]
        public async Task<ActionResult<IEnumerable<LedgerRef_R>>> OrganizationSuperAdminDeveloperGetAllActive()
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
        public async Task<ActionResult<LedgerRef_R>> Get(int id)
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


        // PUT: api/LedgerRef/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LedgerRef>> Put(int id, LedgerRef LedgerRef)
        {
            if (id == LedgerRef.Id)
            {
                try
                {
                    return await _service.UpdateAsync(LedgerRef);
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

        // POST: api/LedgerRef
        [HttpPost]
        public async Task<ActionResult<LedgerRef>> Post(LedgerRef LedgerRef)
        {
            try
            {
                LedgerRef = await _service.CreateAsync(LedgerRef);
                return CreatedAtAction("Get", new { id = LedgerRef.Id }, LedgerRef);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // DELETE: api/LedgerRef/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LedgerRef>> DeleteOrganization(int id)
        {
            try
            {
                if (await _service.DeleteAsync(id) != null)
                {
                    return Ok($"LedgerRef Detail with id {id} is deleted successfully");
                }
                else
                {
                    return BadRequest($"Problem while deleting LedgerRef. It seems we cannot find LedgerRef with id {id}");
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
