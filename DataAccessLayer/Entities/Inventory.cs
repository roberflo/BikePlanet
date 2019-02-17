using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GFShop.DataAccessLayer.Entities
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryId { get; set; }
        public double UnitCost { get; set; }
        
        public int Quantity { get; set; }

        public DateTime? LastEntry { get; set; }
        public DateTime? LastExit { get; set; }

       

        [ForeignKey("Product")]
       public int ProductId { get; set; }
        public Product Product { get; set; }


        
    }
}