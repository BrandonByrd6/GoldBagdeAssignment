namespace InsuranceClaims.Data;

public class HomeClaim : Claim
{

    public HomeClaim()
    {
        
    }

    public HomeClaim(string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim): 
        base(description, claimAmount, dateOfIncident, dateOfClaim)
    {
        
    }
}
