namespace InsuranceClaims.Data;

public class CarClaim : Claim
{
    public CarClaim(string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim): 
        base(description, claimAmount, dateOfIncident, dateOfClaim)
    {
        
    }
}
