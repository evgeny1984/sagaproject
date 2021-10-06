using System;

namespace Sp.Dto.Dto
{
    public class ProductTransactionDto 
    {
        #region FKs

        public int ProductId { get; set; }

        #endregion

        public int Quantity { get; set; }

        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public PurchaseType PurchaseType { get; set; }

    }
}
