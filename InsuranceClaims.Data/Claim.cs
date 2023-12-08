namespace InsuranceClaims.Data;
public abstract class Claim
{

    public Claim()
    {
        Description = "";
    }

    public Claim(string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
    {
        Description = description;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
    }

    public string Description { get; set; }
    public double ClaimAmount { get; set; }
    public DateTime DateOfIncident { get; set; }
    public DateTime DateOfClaim { get; set; }

    public bool IsValid
    {
        get
        {
           return (DateOfClaim - DateOfIncident).TotalDays < 30;
        }
    }
}


