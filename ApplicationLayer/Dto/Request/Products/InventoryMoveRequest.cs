namespace GFShop.ApplicationLayer.Dto.Request.Products
{
    public class InventoryMoveRequest
    {
        public double UnitCost { get; set; }
        
        public int Quantity { get; set; }

        public bool Entry { get; set; }
        public string MovementReference { get; set; }
    }
}