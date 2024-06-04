

namespace Help.Domain.Core.AccountAgg.DTOs.Vote
{
    public class CreateVoteDTO
    {
        public int VoterId { get; set; }
        public int ReceiverId { get; set; }
        public int HelpRequestId { get; set; }
        public Int16 Rate { get; set; }
        public Int16 Mode { get; set; }
    }
}
