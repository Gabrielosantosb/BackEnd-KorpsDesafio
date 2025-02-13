namespace BackEnd_KorpsDesafio.ORM.Model.Product
{
    public class CreateProductRequest
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }        
        public int CategoryId { get; set; }
    }
}
