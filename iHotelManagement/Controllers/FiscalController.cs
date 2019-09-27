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
    public class FiscalController : ControllerBase
    {
        private readonly IFiscalService _service;

        public FiscalController(IFiscalService service)
        {
            this._service = service;
        }


        // GET: api/Fiscal/All
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "SuperAdminDeveloper, Developer")]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<FiscalYear>>> GetAllWithInactive()
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

        // GET: api/Fiscal/GetAll
        [EnableQuery]
        [HttpGet]
        [Authorize(Roles = "SuperAdminDeveloper, Developer")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<FiscalYear>>> GetAll()
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

        // GET: api/Fiscal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FiscalYear>> Get(int id)
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

        // PUT: api/Fiscal/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FiscalYear>> Put(int id, FiscalYear fiscal)
        {
            if (id == fiscal.Id)
            {
                try
                {
                    return await _service.UpdateAsync(fiscal);
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

        // POST: api/Fiscal
        [HttpPost]
        public async Task<ActionResult<FiscalYear>> Post(FiscalYear fiscal)
        {
            try
            {
                fiscal = await _service.CreateAsync(fiscal);
                return CreatedAtAction("Get", new { id = fiscal.Id }, fiscal);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // DELETE: api/Fiscal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FiscalYear>> DeleteOrganization(int id)
        {
            try
            {
                if (await _service.DeleteAsync(id) != null)
                {
                    return Ok($"Fiscal Detail with id {id} is deleted successfully");
                }
                else
                {
                    return BadRequest($"Problem while deleting Fiscal Detail. It seems we cannot find Fiscal Detail with id {id}");
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
