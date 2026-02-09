using Traduccion_php.Dto;
using Traduccion_php.Services;

namespace TraduccionPhp;

internal sealed class Program
{
    private const string OrgIdName = "loanstore";
    private const string UserName = "jdafoe@tlstpo.com";

    private static async Task Main()
    {
        var orgid = ThoughtspotClient.GetTargetOrgIdsByCognitoGroup([OrgIdName]);
        var tokenData = new TokenDataDto
        {
            username = "BrandNewAPISuperUser",
            secret_key = "3acb9fcc-15bc-44c3-8147-37e48c15ba1a",
            org_id = orgid[OrgIdName].FirstOrDefault() ?? string.Empty
        };
        var ret = await ThoughtspotClient.GetThoughtspotToken(tokenData);
        Console.WriteLine($"Login Status: {ret.DataResult}");

        var newUserData = new CreateUserDataDto
        {
            accont_type = "OIDC_USER",
            display_name = UserName,
            name = UserName,
            email = UserName,
            notify_on_share = false,
            org_identifiers = orgid[OrgIdName],
            password = "GallusSecretPass123!",
            trigger_welcome_email = false
        };

        var res = await ThoughtspotClient.CreateNewUser(newUserData, ret.DataResult);


    }
}





























