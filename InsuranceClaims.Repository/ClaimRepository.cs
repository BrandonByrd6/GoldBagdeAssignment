using System.Collections.Generic;
using InsuranceClaims.Data;
namespace InsuranceClaims.Repository;
public class ClaimRespository
{
    private readonly Queue<Claim> _dbcontext;

    public ClaimRespository()
    {
        _dbcontext = new Queue<Claim>();
    }

    public Queue<Claim> GetAllClaims()
    {
        return _dbcontext;
    }

    public Claim GetClaim()
    {
        return _dbcontext.Peek();
    }

    public bool AddClaim(Claim claim) {
        if(claim == null) {
            return false;
        }

        _dbcontext.Enqueue(claim);
        return true;
    }

    public void RemoveFirstClaim() {
        _dbcontext.Dequeue();
    }
}
