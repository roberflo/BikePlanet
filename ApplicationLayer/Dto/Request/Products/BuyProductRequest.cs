namespace GFShop.ApplicationLayer.Dto.Request.Products
{
    public class BuyProductRequest
    {
        public int Quantity { get; set; }

        public string MovementReference { get; set; }
    }
}