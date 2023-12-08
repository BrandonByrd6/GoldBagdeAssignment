namespace InsuranceClaims.Data;

public class TheftClaim : Claim
{
    public TheftClaim()
    {
        
    }

    public TheftClaim(string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim): 
        base(description, claimAmount, dateOfIncident, dateOfClaim)
    {
        
    }
}
