using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Models
{
    [Table("Item")]

    public class Item
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }    
        public int Price { get; set; }

        public string Description { get; set; }


    }
}
