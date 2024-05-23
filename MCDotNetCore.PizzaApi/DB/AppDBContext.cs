using MCDotNetCore.PizzaApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MCDotNetCore.PizzaApi.DB;

internal class AppDBContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<PizzaModel> Pizzas { get; set; }

    public DbSet<PizzaExtraModel> PizzaExtras { get; set; }

    public DbSet<PizzaOrderModel> PizzaOrder { get; set; }
    public DbSet<PizzaOrderDetailModel> PizzaOrderDetail { get; set; }


}
[Table("Tbl_Pizza")]
public class PizzaModel{

    [Key]
    [Column("PizzaId")]
    public int Id { get; set; }

    [Column("Pizza")]
    public string Name { get; set; }

    public decimal Price { get; set; }
}

[Table("Tbl_PizzaExtra")]
public class PizzaExtraModel
{
    [Key]
    [Column("PizzaExtraId")]
    public int Id { get; set; }

    [Column("PizzaExtraName")]
    public string Name { get; set; }

    [Column("Price")]
    public decimal Price { get; set; }

    [NotMapped]
    public string PriceStr { get { return "$" + Price; } }

}

public class OrderRequest
{
    public int PizzaId { get; set; }

    public int[] Extras { get; set; }
}

public class OrderResponse
{
    public string Message { get; set; }
    public string InvoiceNo { get; set; }
    public decimal TotalAmount { get; set; }
}
[Table("Tbl_PizzaOrder")]
public class PizzaOrderModel
{
    [Key]
    [Column("PizzaOrderId")]
    public int PizzaOrderId { get; set; }
    [Column("PizzaOrderInvoiceNo")]
    public string PizzaOrderInvoiceNo { get; set; }
    [Column("PizzaId")]
    public int PizzaId { get; set; }
    [Column("TotalAmount")]
    public decimal TotalAmount { get; set; }
}

[Table("Tbl_PizzaOrderDetail")]
public class PizzaOrderDetailModel
{
    [Key]
    [Column("PizzaOrderDetailId")]
    public int PizzaOrderId { get; set; }
    [Column("PizzaOrderInvoiceNo")]
    public string PizzaOrderInvoiceNo { get; set; }
    [Column("PizzaExtraId")]
    public int PizzaExtraId { get; set; }
}
