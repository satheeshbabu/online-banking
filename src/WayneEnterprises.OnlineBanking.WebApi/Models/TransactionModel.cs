namespace WayneEnterprises.OnlineBanking.WebApi.Models
{
    public class TransactionModel
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }
    }
}
