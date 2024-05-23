using MCDotNetCore.PizzaApi.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCDotNetCore.PizzaApi.Features;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{

    private readonly AppDBContext appDBContext;
   public PizzaController()
    {
        appDBContext = new AppDBContext();
    }

    [HttpGet]
    public async Task<IActionResult> GetPizzaAsync()
    {
        var lst = await appDBContext.Pizzas.ToListAsync();
        return Ok(lst);
    }

    [HttpGet("extras")]
    public async Task<IActionResult> GetPizzaextraasync()
    {
       var lst = await appDBContext.PizzaExtras.ToListAsync();
       return Ok(lst);
    }

    [HttpPost("order")]
    public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
    {
        var pizzaOrder = appDBContext.Pizzas.FirstOrDefault(x => x.Id == orderRequest.PizzaId);
        var totalAmount = pizzaOrder.Price;

        var extraList = await appDBContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();
       
        totalAmount += extraList.Sum(x => x.Price);

        var invoiceNo = DateTime.Now.ToString("yyyyMMddmmss");

        PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
        {
            PizzaId = orderRequest.PizzaId,
            PizzaOrderInvoiceNo = invoiceNo,
            TotalAmount = totalAmount
        };

        List<PizzaOrderDetailModel> pizzaOrderDetailModel = orderRequest.Extras.Select(extraId => new PizzaOrderDetailModel
        {
            PizzaExtraId = extraId,
            PizzaOrderInvoiceNo = invoiceNo

        }).ToList();

        await appDBContext.PizzaOrder.AddAsync(pizzaOrderModel);
        await appDBContext.PizzaOrderDetail.AddRangeAsync(pizzaOrderDetailModel);
        await appDBContext.SaveChangesAsync();

        OrderResponse response = new OrderResponse
        {
            InvoiceNo = invoiceNo,
            Message = "Thank you for your order! Enjoy your Pizza!",
            TotalAmount = totalAmount
        };
        return Ok(response);
    }

    [HttpGet("order/{invoiceNo}")]
    public async Task<IActionResult> GetOrder(string invoiceNo)
    {
        var item =  appDBContext.PizzaOrder.FirstOrDefault(x => x.PizzaOrderInvoiceNo == invoiceNo);
        var lst = await appDBContext.PizzaOrderDetail.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();
        return Ok(
           new {
               Order = item,
               OrderDetail = lst

        });
    }

}
