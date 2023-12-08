using InsuranceClaims.Data;
using InsuranceClaims.Repository;

namespace InsuranceClaims.Tests;

public class RepositoryTests
{
    [Fact]
    public void GetAllClaims()
    {
        ClaimRespository _repository = new ClaimRespository();
        CarClaim claim1 = new CarClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        HomeClaim claim2 = new HomeClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        TheftClaim claim3 = new TheftClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        CarClaim claim4 = new CarClaim("Description", 10.0, DateTime.Now, DateTime.Now);

        _repository.AddClaim(claim1);
        _repository.AddClaim(claim2);
        _repository.AddClaim(claim3);
        _repository.AddClaim(claim4);
        Queue<Claim> claims = _repository.GetAllClaims();
        int expected = 4;

        int actual = claims.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetCurrentClaim()
    {
        ClaimRespository _repository = new ClaimRespository();
        CarClaim expected = new CarClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        HomeClaim claim2 = new HomeClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        TheftClaim claim3 = new TheftClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        CarClaim claim4 = new CarClaim("Description", 10.0, DateTime.Now, DateTime.Now);

        _repository.AddClaim(expected);
        _repository.AddClaim(claim2);
        _repository.AddClaim(claim3);
        _repository.AddClaim(claim4);
        Claim actual = _repository.GetClaim();
        

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AddClaim()
    {
        ClaimRespository _repository = new ClaimRespository();
        CarClaim claim = new CarClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        bool expected = true;
        
        bool actual = _repository.AddClaim(claim);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RemoveClaim()
    {
        ClaimRespository _repository = new ClaimRespository();
        CarClaim claim1 = new CarClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        HomeClaim claim2 = new HomeClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        TheftClaim claim3 = new TheftClaim("Description", 10.0, DateTime.Now, DateTime.Now);
        CarClaim claim4 = new CarClaim("Description", 10.0, DateTime.Now, DateTime.Now);

        _repository.AddClaim(claim1);
        _repository.AddClaim(claim2);
        _repository.AddClaim(claim3);
        _repository.AddClaim(claim4);
        _repository.RemoveFirstClaim();
        Queue<Claim> claims = _repository.GetAllClaims();
        int expected = 3;

        int actual = claims.Count;
        Assert.Equal(expected, actual);
    }

}