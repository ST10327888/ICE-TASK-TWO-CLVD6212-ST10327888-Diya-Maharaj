using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly TableService _tableService;

    public HomeController(TableService tableService)
    {
        _tableService = tableService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddSample()
    {
        var p = new Product
        {
            RowKey = Guid.NewGuid().ToString(),
            PartitionKey = "gear-surf-surfboards",
            Name = "Surfboard",
            Quantity = 10,
            Price = 300.00m,
            Clearance = true
        };
        await _tableService.UpsertProductAsync(p);
        TempData["Message"] = "Inserted sample product (check your table).";
        return RedirectToAction("Index");
    }
}
