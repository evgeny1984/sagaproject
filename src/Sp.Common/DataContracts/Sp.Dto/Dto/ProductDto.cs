using System.Collections.Generic;

namespace Sp.Dto.Dto
{
    public class ProductDto : BaseEntityDto
    {
        #region FKs

        #endregion

        #region Columns
        public string StockCode { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        #endregion

        #region Relationships

        public  List<ProductTransactionDto> ProductTransactions { get; set; }

        #endregion
    }
}
