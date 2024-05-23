namespace MCDotNetCore.PizzaApi.Features.Pizza
{
    public class PizzaQuery
    {
        public static string PizzaOrderQuery { get; } = 
            @"SELECT po.*, p.Pizza, p.Price FROM [dbo].[Tbl_PizzaOrder] po
             inner join [dbo].[Tbl_Pizza] p on p.PizzaId = po.PizzaId
             where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo";

        public static string PizzaOrderDetailQuery { get; } = 
            @"SELECT pod.*, pe.PizzaExtraName, pe.Price FROM [dbo].[Tbl_PizzaOrderDetail] pod
             inner join [dbo].[Tbl_PizzaExtra] pe on pe.PizzaExtraId = pod.PizzaExtraId 
             where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo";
    }
}
