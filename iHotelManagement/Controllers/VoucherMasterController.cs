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
    public class VoucherMasterController : ControllerBase
    {
        private readonly IVoucherMasterService _service;

        public VoucherMasterController(IVoucherMasterService service)
        {
            this._service = service;
        }


        //// GET: api/VoucherMaster/All
        //[EnableQuery]
        //[HttpGet]
        //[Authorize(Roles = "SuperAdminDeveloper, Developer")]
        //[Route("All")]
        //public async Task<ActionResult<IEnumerable<VoucherMaster>>> GetAllWithInactive()
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

        //// GET: api/VoucherMaster/GetAll
        //[EnableQuery]
        //[HttpGet]
        //[Authorize(Roles = "SuperAdminDeveloper, Developer")]
        //[HttpGet]
        //[Route("GetAll")]
        //public async Task<ActionResult<IEnumerable<VoucherMaster>>> GetAll()
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

        //// GET: api/VoucherMaster/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<VoucherMaster>> Get(int id)
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
        public async Task<ActionResult<IEnumerable<VoucherMaster_R>>> SuperAdminDeveloperGetAll()
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
        public async Task<ActionResult<IEnumerable<VoucherMaster_R>>> SuperAdminDeveloperGetAllActive()
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
        public async Task<ActionResult<IEnumerable<VoucherMaster_R>>> OrganizationSuperAdminDeveloperGetAll()
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
        public async Task<ActionResult<IEnumerable<VoucherMaster_R>>> OrganizationSuperAdminDeveloperGetAllActive()
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


        // PUT: api/VoucherMaster/5
        [HttpPut("{id}")]
        public async Task<ActionResult<VoucherMaster>> Put(int id, VoucherMaster VoucherMaster)
        {
            if (id == VoucherMaster.Id)
            {
                try
                {
                    return await _service.UpdateAsync(VoucherMaster);
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

        // POST: api/VoucherMaster
        [HttpPost]
        public async Task<ActionResult<VoucherMaster>> Post(VoucherMaster VoucherMaster)
        {
            try
            {
                VoucherMaster = await _service.CreateAsync(VoucherMaster);
                return CreatedAtAction("Get", new { id = VoucherMaster.Id }, VoucherMaster);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // DELETE: api/VoucherMaster/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VoucherMaster>> Delete(int id)
        {
            try
            {
                if (await _service.DeleteAsync(id) != null)
                {
                    return Ok($"VoucherMaster Detail with id {id} is deleted successfully");
                }
                else
                {
                    return BadRequest($"Problem while deleting VoucherMaster. It seems we cannot find VoucherMaster with id {id}");
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
