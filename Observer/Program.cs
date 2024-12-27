using Observer;

TicketStockService ticketStockService = new();
TicketResaleService ticketResaleService = new();
OrderService orderService = new();


orderService.AddListener(ticketStockService);
orderService.AddListener(ticketResaleService);


orderService.SellTicket(1, 5);

Console.WriteLine();

orderService.RemoveListener(ticketStockService);

orderService.SellTicket(1, 3);

Console.ReadKey();