using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Vote : BaseEntity
    {


        public Vote() { }
        public Vote(int voterId, int receiverId, int helpRequestId, Int16 rate, Int16 mode)
        {
           VoterId = voterId;
           ReceiverId = receiverId;
            HelpRequestId = helpRequestId;
            Rate = rate;
            Mode = mode;
        }

        public int VoterId { get;private set; }
        public int ReceiverId { get;private set; }
        public int HelpRequestId { get;private set; }
        public Int16 Rate { get;private set; }
        public Int16 Mode { get;private set; } //if 1 : AsExpert  if2: AsRequester


        #region Navigration Properties

        public Customer Receiver { get;private set; }

        #endregion
    }
}
