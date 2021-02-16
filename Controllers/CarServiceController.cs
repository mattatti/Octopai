using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Octopai.Models;
using Microsoft.Extensions.Logging;
using System.IO;
using OfficeOpenXml;

namespace Octopai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarServiceController : ControllerBase
    {
        private readonly CarServiceDBContext _context;
        private readonly ILogger<CarServiceController> _logger;
        public CarServiceController(ILogger<CarServiceController> logger, CarServiceDBContext context)
        {
            _context = context;
            _logger = logger;

        }
        public async void ImportFromExcel(IFormFile file)
        {
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (var row = 2; row <= rowCount; row++)
                    {
                        var existingCarServiceCount = _context.CarServices.Count(a => a.ServiceId == int.Parse(worksheet.Cells[row, 5].Value.ToString().Trim()));
                        if (existingCarServiceCount == 0)
                        {
                            // Do your insert

                            _context.CarServices.Add(new CarService
                            {
                                CustomerId = int.Parse(worksheet.Cells[row, 1].Value.ToString().Trim()),
                                CarModelId = int.Parse(worksheet.Cells[row, 2].Value.ToString().Trim()),
                                ServiceStartDate = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                ServiceEndDate = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                ServiceId = int.Parse(worksheet.Cells[row, 5].Value.ToString().Trim()),
                                ServiceName = worksheet.Cells[row, 6].Value.ToString().Trim(),
                                Cost = float.Parse(worksheet.Cells[row, 7].Value.ToString().Trim()),
                                NetHours = float.Parse(worksheet.Cells[row, 8].Value.ToString().Trim()),
                            }); ;
                        }

                    }
                    _context.SaveChanges();
                }
            }

        }

        // GET: api/CarService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarService>>> GetCarServices()
        {
            return await _context.CarServices.ToListAsync();
        }

        // GET: api/CarService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarService>> GetCarService(int id)
        {
            var carService = await _context.CarServices.FindAsync(id);

            if (carService == null)
            {
                return NotFound();
            }

            return carService;
        }

        // PUT: api/CarService/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarService(int id, CarService carService)
        {
            if (id != carService.ServiceId)
            {
                return BadRequest();
            }

            _context.Entry(carService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarService
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CarService>> PostCarService(CarService carService)
        {
            _context.CarServices.Add(carService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarService", new { id = carService.ServiceId }, carService);
        }

        // DELETE: api/CarService/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarService>> DeleteCarService(int id)
        {
            var carService = await _context.CarServices.FindAsync(id);
            if (carService == null)
            {
                return NotFound();
            }

            _context.CarServices.Remove(carService);
            await _context.SaveChangesAsync();

            return carService;
        }

        private bool CarServiceExists(int id)
        {
            return _context.CarServices.Any(e => e.ServiceId == id);
        }
    }
}
