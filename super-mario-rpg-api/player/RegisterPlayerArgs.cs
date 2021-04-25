namespace SuperMarioRpg.Api
{
    public record RegisterPlayerArgs(
        string EmailAddress,
        string Password,
        string UserName
    );
}
