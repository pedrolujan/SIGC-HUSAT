using System.Collections.Generic;
using System.ComponentModel;

namespace selferviceSIGC.Model.Business
{
    public class Document
    {

        /// <summary>
        /// Fuelind Id Transaction
        /// </summary>
        [DisplayName("fuelingIdTransaction")]
        public string FuelingIdTransaction { get; set; }
        /// <summary>
        /// Operator Code
        /// </summary>
        [DisplayName("operatorCode")]
        public string OperatorCode { get; set; }
        /// <summary>
        /// Total Amount Document
        /// </summary>
        [DisplayName("totalAmountDocument")]
        public decimal TotalAmountDocument { get; set; }
        /// <summary>
        /// Delivered Amount
        /// </summary>
        [DisplayName("deliveredAmount")]
        public decimal DeliveredAmount { get; set; }
        /// <summary>
        /// Currency
        /// </summary>
        [DisplayName("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Qr
        /// </summary>
        [DisplayName("useQrIdentified")]
        public bool UseQrIdentified { get; set; }

        /// <summary>
        /// Document Lines
        /// </summary>
        [DisplayName("ocumentLines")]
        public List<DetailDocument> DocumentLines { get; set; }

        /// <summary>
        /// Payments lines
        /// </summary>
        [DisplayName("payments")]
        public List<PaymentDocument> Payments { get; set; }


    }

    public class DetailDocument
    {
        /// <summary>
        /// Line id
        /// </summary>
        [DisplayName("lineNumberInTicket")]
        public int LineNumberInTicket { get; set; }
        /// <summary>
        /// Product Id
        /// </summary>
        [DisplayName("productReference")]
        public string ProductReference { get; set; }
        /// <summary>
        /// Product Description
        /// </summary>
        [DisplayName("productDescription")]
        public string ProductDescription { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DisplayName("productQuantity")]
        public decimal ProductQuantity { get; set; }
        /// <summary>
        /// Unit Price
        /// </summary>
        [DisplayName("amountPerUnit")]
        public decimal AmountPerUnit { get; set; }
        /// <summary>
        /// Discount
        /// </summary>
        [DisplayName("discountPercentage")]
        public decimal DiscountPercentage { get; set; }
        /// <summary>
        /// Total amount products
        /// </summary>
        [DisplayName("totalLineAmount")]
        public decimal TotalLineAmount { get; set; }
        /// <summary>
        /// Discount amount
        /// </summary>
        [DisplayName("discountedAmount")]
        public decimal DiscountedAmount { get; set; }
        /// <summary>
        /// Ammount 
        /// </summary>
        [DisplayName("amountFreight")]
        public decimal AmountFreight { get; set; }
        /// <summary>
        /// Surcharge
        /// </summary>
        [DisplayName("amountSurcharge")]
        public decimal AmountSurcharge { get; set; }
        /// <summary>
        /// Cluster Id
        /// </summary>
        [DisplayName("idCluster")]
        public string IdCluster { get; set; }
        /// <summary>
        /// Coeficiente
        /// </summary>
        [DisplayName("coeficiente")]
        public decimal Coeficiente { get; set; }
    }

    public class PaymentDocument
    {
        /// <summary>
        /// Payment Name
        /// </summary>
        [DisplayName("paymentName")]
        public string PaymentName { get; set; }
        /// <summary>
        /// Currency Id ISO
        /// </summary>
        [DisplayName("currencyId")]
        public string CurrencyId { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        [DisplayName("amount")]
        public decimal Amount { get; set; }
        /// <summary>
        /// Has paid by base currency
        /// </summary>
        [DisplayName("hasBeenPaidByBaseCurrency")]
        public bool HasBeenPaidByBaseCurrency { get; set; }
        /// <summary>
        /// Exchange Factor
        /// </summary>
        [DisplayName("exchangeFactor")]
        public decimal ExchangeFactor { get; set; }
        /// <summary>
        /// Give Amount
        /// </summary>
        [DisplayName("givenAmount")]
        public decimal GivenAmount { get; set; }
    }
}
