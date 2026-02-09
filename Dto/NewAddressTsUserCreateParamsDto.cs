using System.Collections.Generic;

namespace TraduccionPhp.Dto;

internal sealed class NewAddressTsUserCreateParamsDto
{
	public required string SecToken { get; init; }
	public required string CognitoUsername { get; init; }
	public required string Email { get; init; }
	public required IReadOnlyList<string> OrgIds { get; init; }
	public required string BearerToken { get; init; }
}