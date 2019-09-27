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
    public class VoucherTypeController : ControllerBase
    {
        private readonly IVoucherTypeService _service;

        public VoucherTypeController(IVoucherTypeService service)
        {
            this._service = service;
        }


        // GET: api/VoucherType/All
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "SuperAdminDeveloper, Developer")]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<VoucherType>>> GetAllWithInactive()
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

        // GET: api/VoucherType/GetAll
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "SuperAdminDeveloper, Developer")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<VoucherType>>> GetAll()
        {
            try
            {
                var orgDetails = await _service.Get().ToListAsync();
                return orgDetails;
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // GET: api/VoucherType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherType>> Get(int id)
        {
            try
            {
                return await _service.GetAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // PUT: api/VoucherType/5
        [HttpPut("{id}")]
        public async Task<ActionResult<VoucherType>> Put(int id, VoucherType VoucherType)
        {
            if (id == VoucherType.Id)
            {
                try
                {
                    return await _service.UpdateAsync(VoucherType);
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

        // POST: api/VoucherType
        [HttpPost]
        public async Task<ActionResult<VoucherType>> Post(VoucherType VoucherType)
        {
            try
            {
                VoucherType = await _service.CreateAsync(VoucherType);
                return CreatedAtAction("Get", new { id = VoucherType.Id }, VoucherType);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // DELETE: api/VoucherType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VoucherType>> DeleteOrganization(int id)
        {
            try
            {
                if (await _service.DeleteAsync(id) != null)
                {
                    return Ok($"VoucherType Detail with id {id} is deleted successfully");
                }
                else
                {
                    return BadRequest($"Problem while deleting VoucherType. It seems we cannot find VoucherType with id {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        private async Task<bool> isExists(int id)
        {
            return await _service.GetAsync(id) != null;
        }
    }
}
