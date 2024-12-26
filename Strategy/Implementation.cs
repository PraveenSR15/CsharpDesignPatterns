namespace Strategy
{
    public interface IExportService
    {
        public void Export(Order order);
    }

    public class CSVExport : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exported {order.Name} to CSV");
        }
    }
    public class PDFExport : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exported {order.Name} to PDF");
        }
    }

    public class XMLExport : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exported {order.Name} to XML");
        }
    }

    public class Order
    {
        public string Customer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

        public Order(string customer,string name,double amount)
        {
            Customer = customer;
            Name = name;
            Amount = amount;
        }

        public void Export(IExportService? exportService)
        {
            exportService?.Export(this);
        }
    }
}
