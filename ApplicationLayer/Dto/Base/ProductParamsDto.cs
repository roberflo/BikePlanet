namespace GFShop.ApplicationLayer.Dto.Base
{
    public class ProductParamsDto
    {

        public string Sort_by { get; set; }="Name";
        public string Order_by { get; set; }="ASC";
        public string Filter { get; set; }=""; 
        public int Skip { get; set; }=0;
        public int Take { get; set; }=5;
        

       
     
    }
}