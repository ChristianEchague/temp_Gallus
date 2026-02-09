namespace TraduccionPhp.Dto;

internal sealed class NewAddressTsLoginAsAdminOrgParamsDto
{
	public required string SecToken { get; init; }
	public required string OrgId { get; init; }
}