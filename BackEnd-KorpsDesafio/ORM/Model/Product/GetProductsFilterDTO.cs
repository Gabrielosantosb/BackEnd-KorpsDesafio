namespace BackEnd_KorpsDesafio.ORM.Model.Lead
{
    public class GetProductsFilterDTO
    {
        public string? ProductName { get; set; }        
        public DateTime? DateCreatedStart { get; set; }
        public DateTime? DateCreatedEnd { get; set; }
        public decimal? MinPrice { get; set; }           
        public decimal? MaxPrice { get; set; }
        public bool? IsActive { get; set; }
    }
}
