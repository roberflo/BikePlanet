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

         public string MovementReference { get; set; }
        public DateTime? Entry { get; set; }
        public DateTime? Exit { get; set; }

       

        
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }


        
    }
}