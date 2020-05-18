using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public List<DetailedOrder> DetailedOrders { get; set; }
    }

    public class OrderDetails
    {
        public DetailedOrder OrderDetail { get; set; }
        public StreetAddress BillingAddress { get; set; }
        public StreetAddress ShippingAddress { get; set; }
    }

    public class DetailedOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }

    public class StreetAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

}