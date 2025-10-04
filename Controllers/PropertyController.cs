
using AIRBNB.Data;
using AIRBNB.Models.DTOs.Properties;
using AIRBNB.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AIRBNB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Host")]
    public class PropertyController : Controller
    {

        private readonly DataBaseContext _context;

        public PropertyController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromBody] CreatePropertyDto dto)
        {
            var hostId = int.Parse(User.FindFirst("id").Value);

            var property = new PropertyModel
            {
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                PricePerNight = dto.PricePerNight,
                PropertyType = dto.PropertyType,
                HostId = hostId
            };

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Property created successfully!", property.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] UpdatePropertyDto dto)
        {
            var hostId = int.Parse(User.FindFirst("id").Value);

            var property = await _context.Properties.FirstOrDefaultAsync(p => p.Id == id && p.HostId == hostId);
            if (property == null) return NotFound("Property not found!");

            if (!string.IsNullOrEmpty(dto.Title)) property.Title = dto.Title;
            if (!string.IsNullOrEmpty(dto.Description)) property.Description = dto.Description;
            if (!string.IsNullOrEmpty(dto.Location)) property.Location = dto.Location;
            if (dto.PricePerNight.HasValue) property.PricePerNight = dto.PricePerNight.Value;
            if(dto.PropertyType.HasValue) property.PropertyType = dto.PropertyType.Value;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Property updated successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var hostId = int.Parse(User.FindFirst("id").Value);

            var property = await _context.Properties.FirstOrDefaultAsync(p => p.Id == id && p.HostId == hostId);
            if (property == null) return NotFound("Property Not Found");

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Property deleted successfully!" });

        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyProperties()
        {
            var hostId = int.Parse(User.FindFirst("id").Value);

            var properties = await._context.Properties
                .Where(p => p.HostId == hostId)
                .Select(p => new PropertyResponseDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Location = p.Location,
                    PricePerNight = p.PricePerNight,
                    PropertyType = p.PropertyType,
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();

            return Ok(properties);
        }


        [HttpGet("reservations")]
        public async Task<IActionResult> GetReservationsForHost()
        {
            var hostId = int.Parse(User.FindFirst("id").Value);

            var reservations = await _context.Reservations
                .Include(r => r.Property)
                .Include(r => r.Guest)
                .Where(r => r.Property.HostId == hostId)
                .Select(r => new ReservationResponseDto
                {
                    Id = r.Id,
                    GuestName = r.Guest != null
                        ? (r.Guest.FirstName + " " + r.Guest.LastName)
                        : "Unknown Guest",
                    Checkin = r.Checkin,
                    Checkout = r.Checkout,
                    TotalPrice = r.TotalPrice,
                    PropertyTitle = r.Property.Title
                })
                .ToListAsync();

            return Ok(reservations);
        }
        



        
        public IActionResult Index()
        {
            return View();
        }
    }
}
