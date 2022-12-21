namespace Lab10v2.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Article Article { get; set; }
        public double TotalPrice { get; set; }
        public int Amount { get; set; }

        public Category Category { get; set; }

        
    }
}
