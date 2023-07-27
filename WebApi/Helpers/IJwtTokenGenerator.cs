namespace WebApi.Helpers
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId,string userName);

    }
}
