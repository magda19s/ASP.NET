namespace Lab10v2.Models
{
    public class ShopCart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalPrice { get; set; }

        public Category Category { get; set; }

        public string Image { get; set; }
        public int Amount { get; set; }

        
    }
}
