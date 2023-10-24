namespace ProductApp.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int Id, String ProductName)
        {
            this.Id = Id;
            this.ProductName = ProductName;
        }

        public int Id { get; set; }

        public String? ProductName { get; set; }
    }
}
