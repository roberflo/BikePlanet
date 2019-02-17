using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GFShop.DataAccessLayer.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Likes { get; set; }
        
        public string Category { get; set; }

        public int Stock 
        {
            get {  return Inventory.Sum(od => od.Quantity); }
        }

        public ICollection<Inventory> Inventory { get; set; }
    }
}