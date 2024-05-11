﻿namespace Ontap_NET104.Models
{
    public class Cart
    {
        public string Username { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public virtual List<CartDetails> CartDetails { get; set; }
        public virtual Account Account { get; set; }
    }
}
