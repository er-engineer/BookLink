using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
