using QuestPDF.Fluent;
using Vehicle_Service_Tracker.Reports;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle_Service_Tracker.Data;
using Vehicle_Service_Tracker.Models;

namespace Vehicle_Service_Tracker.Controllers
{
    public class ServiceHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceHistory/Index?vehicleId=5
        public async Task<IActionResult> Index(int vehicleId)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.ServiceHistories)
                .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: ServiceHistory/Create?vehicle=5
        public IActionResult Create(int vehicleId)
        {
            var service = new ServiceHistory
            {
                VehicleId = vehicleId,
                ServiceDate = DateTime.Today
            };

            return View(service);
        }

        // POST: ServiceHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceHistory serviceHistory)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceHistory);
            }

            _context.ServiceHistories.Add(serviceHistory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { vehicleId = serviceHistory.VehicleId });
        }

        // GET: ServiceHistory/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var service = await _context.ServiceHistories.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: ServiceHistory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceHistory serviceHistory)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceHistory);
            }

            _context.ServiceHistories.Update(serviceHistory);
            await _context.SaveChangesAsync();

            return RedirectToAction(
                "Index",
                new { vehicleId = serviceHistory.VehicleId });
        }

        // GET: ServiceHistory/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _context.ServiceHistories
                .Include(s => s.Vehicle)
                .FirstOrDefaultAsync(s => s.ServiceHistoryId == id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: ServiceHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.ServiceHistories.FindAsync(id);
            if (service != null)
            {
                _context.ServiceHistories.Remove(service);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(
                "Index",
                new { vehicleId = service.VehicleId });
        }

        // GET: ServiceHistory/DownloadCSV/5
        public async Task<IActionResult> Download(int vehicleId)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.ServiceHistories)
                .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);

            if (vehicle == null)
            {
                return NotFound();
            }

            var sb = new StringBuilder();

            // CSV header
            sb.AppendLine("Service Date,Service Type,Mileage,Cost,Service Provider,Description");

            foreach (var service in vehicle.ServiceHistories
                .OrderByDescending(s => s.ServiceDate))
            {
                sb.AppendLine(
                    $"{service.ServiceDate:yyyy-MM-dd}," +
                    $"\"{service.ServiceType}\"," +
                    $"{service.MileageAtService}," +
                    $"{service.Cost}," +
                    $"\"{service.ServiceProvider}\"," +
                    $"\"{service.Description}\""
                );
            }

            var fileName =
                $"ServiceHistory_{vehicle.Make}_{vehicle.Model}.csv"
                .Replace(" ", "_");

            return File(
                Encoding.UTF8.GetBytes(sb.ToString()),
                "text/csv",
                fileName);
        }

        // GET: ServiceHistory/DownloadPdf/5
        public async Task<IActionResult> DownloadPdf(int vehicleId)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.ServiceHistories)
                .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);

            if (vehicle == null)
                return NotFound();

            var document = new ServiceHistoryPdf(vehicle);
            var pdfBytes = document.GeneratePdf();

            var fileName =
                $"ServiceHistory_{vehicle.Make}_{vehicle.Model}.pdf"
                .Replace(" ", "_");

            return File(pdfBytes, "application/pdf", fileName);
        }

    }
}
