namespace BackEnd_KorpsDesafio.ORM.Model.Product
{
    public class CreateProductRequest
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
