namespace InsuranceClaims.Data;
public abstract class Claim
{

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
            int result = DateTime.Compare(DateOfIncident, DateOfClaim);
            if (result < 0)
            {
                return false;
            }
            return (result > 30) ? false : true;
        }
    }
}


