using System.Collections.Generic;

namespace WayneEnterprises.OnlineBanking.WebApi.Models
{
    public class AccountModel
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public IList<TransactionModel> Transactions { get; set; }
    }
}
