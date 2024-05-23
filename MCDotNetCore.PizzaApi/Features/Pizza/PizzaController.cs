using MCDotNetCore.PizzaApi.DB;
using MCDotNetCore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCDotNetCore.PizzaApi.Features.Pizza;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{

    private readonly AppDBContext _appDBContext;
    private readonly DapperService _dapperService;
    public PizzaController()
    {
        _appDBContext = new AppDBContext();
        _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
    }

    [HttpGet]
    public async Task<IActionResult> GetPizzaAsync()
    {
        var lst = await _appDBContext.Pizzas.ToListAsync();
        return Ok(lst);
    }

    [HttpGet("extras")]
    public async Task<IActionResult> GetPizzaextraasync()
    {
        var lst = await _appDBContext.PizzaExtras.ToListAsync();
        return Ok(lst);
    }

    [HttpPost("order")]
    public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
    {
        var pizzaOrder = _appDBContext.Pizzas.FirstOrDefault(x => x.Id == orderRequest.PizzaId);
        var totalAmount = pizzaOrder.Price;

        var extraList = await _appDBContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();

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

        await _appDBContext.PizzaOrder.AddAsync(pizzaOrderModel);
        await _appDBContext.PizzaOrderDetail.AddRangeAsync(pizzaOrderDetailModel);
        await _appDBContext.SaveChangesAsync();

        OrderResponse response = new OrderResponse
        {
            InvoiceNo = invoiceNo,
            Message = "Thank you for your order! Enjoy your Pizza!",
            TotalAmount = totalAmount
        };
        return Ok(response);
    }

    //[HttpGet("order/{invoiceNo}")]
    //public async Task<IActionResult> GetOrder(string invoiceNo)
    //{
    //    var item = _appDBContext.PizzaOrder.FirstOrDefault(x => x.PizzaOrderInvoiceNo == invoiceNo);
    //    var lst = await _appDBContext.PizzaOrderDetail.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();
    //    return Ok(
    //       new
    //       {
    //           Order = item,
    //           OrderDetail = lst

    //       });
    //}

    [HttpGet("order/{invoiceNo}")]
    public IActionResult GetOrder(string invoiceNo)
    {
        var item = _dapperService.FindById<PizzaOrderInvoiceHeadModel>
            (PizzaQuery.PizzaOrderQuery,
            new { PizzaOrderInvoiceNo = invoiceNo });

        var lst = _dapperService.Query<PizzaOrderInvoiceDetailModel>
            (
            PizzaQuery.PizzaOrderDetailQuery,
            new { PizzaOrderInvoiceNo = invoiceNo }
            );

        var model = new PizzaOrderResponse
        {
            Order = item,
            OrderDetail = lst
        };

        return Ok(model);
    }

}
