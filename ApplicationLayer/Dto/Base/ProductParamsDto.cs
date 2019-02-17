namespace GFShop.ApplicationLayer.Dto.Base
{
    public class ProductParamsDto
    {

        public string Sort_by { get; set; }="Name";
        public string Order_by { get; set; }="ASC";
        public string Category { get; set; }=""; 
        public int Skip { get; set; }=0;
        public int Take { get; set; }=5;
        public bool OnlyAvailable { get; set; }=false;

        public string Search { get; set; }="";
    }
}