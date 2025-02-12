using FrameworkDigital_DesafioBackEnd.ORM.Enum;

namespace FrameworkDigital_DesafioBackEnd.ORM.Model.Lead
{
    public class GetProductsFilterDTO
    {
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public DateTime? DateCreatedStart { get; set; }
        public DateTime? DateCreatedEnd { get; set; }
        public decimal? MinPrice { get; set; }           
        public decimal? MaxPrice { get; set; }
    }
}
