using System.Reflection.Emit;

namespace MyEshop.Models
{
    public class Product
    {
        //we are adding navigation prop so no need for List<Category>
        //public Product()
        //{
        //    Categories = new List<Category>();
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public List<Category> Categories { get; set; }
        public int ItemId { get; set; }


        //Navigation property
        public Item Item { get; set; }
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
