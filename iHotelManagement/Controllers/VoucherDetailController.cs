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
    public class VoucherDetailController : ControllerBase
    {
        private readonly IVoucherDetailService _service;

        public VoucherDetailController(IVoucherDetailService service)
        {
            this._service = service;
        }


        // GET: api/VoucherDetail/All
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "SuperAdminDeveloper, Developer")]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<VoucherDetail>>> GetAllWithInactive()
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

        // GET: api/VoucherDetail/GetAll
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "SuperAdminDeveloper, Developer")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<VoucherDetail>>> GetAll()
        {
            try
            {
                return await _service.Get().ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // GET: api/VoucherDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherDetail>> Get(int id)
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

        // PUT: api/VoucherDetail/5
        [HttpPut("{id}")]
        public async Task<ActionResult<VoucherDetail>> Put(int id, VoucherDetail VoucherDetail)
        {
            if (id == VoucherDetail.Id)
            {
                try
                {
                    return await _service.UpdateAsync(VoucherDetail);
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

        // POST: api/VoucherDetail
        [HttpPost]
        public async Task<ActionResult<VoucherDetail>> Post(VoucherDetail VoucherDetail)
        {
            try
            {
                VoucherDetail = await _service.CreateAsync(VoucherDetail);
                return CreatedAtAction("Get", new { id = VoucherDetail.Id }, VoucherDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // DELETE: api/VoucherDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VoucherDetail>> Delete(int id)
        {
            try
            {
                if (await _service.DeleteAsync(id) != null)
                {
                    return Ok($"VoucherDetail Detail with id {id} is deleted successfully");
                }
                else
                {
                    return BadRequest($"Problem while deleting VoucherDetail. It seems we cannot find VoucherDetail with id {id}");
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
