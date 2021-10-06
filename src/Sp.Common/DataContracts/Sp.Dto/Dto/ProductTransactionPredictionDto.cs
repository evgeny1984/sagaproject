using System.Collections.Generic;

namespace Sp.Dto.Dto
{
    public class ProductTransactionPredictionDto
    {
        #region Regression Line

        public int X { get; set; }
        public int Y { get; set; }

        #endregion

        public List<ProductTransactionDto> ProductTransactions { get; set; }

    }
}
