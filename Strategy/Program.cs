using Strategy;

var order = new Order("SR", "Speaker", 100.00);
order.Export(new CSVExport());
order.Export(new PDFExport());
order.Export(new XMLExport());

Console.ReadKey();