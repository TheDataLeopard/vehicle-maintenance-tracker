using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Vehicle_Service_Tracker.Models;

namespace Vehicle_Service_Tracker.Reports
{
    public class ServiceHistoryPdf : IDocument
    {
        private readonly Vehicle _vehicle;

        public ServiceHistoryPdf(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);

                page.Header().Text($"Service History – {_vehicle.Name}")
                    .FontSize(20)
                    .Bold();

                page.Content().Column(col =>
                {
                    col.Spacing(10);

                    col.Item().Text($"{_vehicle.Year} {_vehicle.Make} {_vehicle.Model}");
                    col.Item().Text($"Mileage: {_vehicle.CurrentMileage} km");

                    col.Item().LineHorizontal(1);

                    foreach (var s in _vehicle.ServiceHistories
                        .OrderByDescending(x => x.ServiceDate))
                    {
                        col.Item().Border(1).Padding(10).Column(service =>
                        {
                            service.Item().Text(s.ServiceType).Bold();
                            service.Item().Text($"Date: {s.ServiceDate:d}");
                            service.Item().Text($"Mileage: {s.MileageAtService} km");
                            service.Item().Text($"Cost: {s.Cost:C}");

                            if (!string.IsNullOrEmpty(s.ServiceProvider))
                                service.Item().Text($"Provider: {s.ServiceProvider}");

                            if (!string.IsNullOrEmpty(s.Description))
                                service.Item().Text($"Notes: {s.Description}");
                        });
                    }
                });

                page.Footer()
                    .AlignCenter()
                    .Text(text =>
                    {
                        text.Span("Generated on ");
                        text.Span(DateTime.Now.ToString("yyyy-MM-dd"));
                    });
            });
        }
    }
}
