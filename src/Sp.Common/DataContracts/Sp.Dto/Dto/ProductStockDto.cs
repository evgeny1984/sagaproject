namespace Sp.Dto.Dto
{
    public class ProductStockDto : BaseEntityDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
    }
}
