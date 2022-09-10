using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class UserOperationClaim : Entity
{
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
    }

    public UserOperationClaim(Guid id, Guid userId, int operationClaimId) : base(id)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}