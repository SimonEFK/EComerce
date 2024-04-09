namespace HardwareStore.App.Models.Orders
{
    using Microsoft.AspNetCore.Mvc;

    public class OrderInputModel
    {               
        public List<OrderItemInputModel> Items { get; set; }
    }
}
