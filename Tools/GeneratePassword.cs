using System.Security.Cryptography;
using System.Text;

namespace TraduccionPhp.Tools;

internal static class PasswordGenerator
{
	public static string Generate()
	{
		const string characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
		var bytes = new byte[10];
		RandomNumberGenerator.Fill(bytes);

		var builder = new StringBuilder("1aA!");
		foreach (var value in bytes)
		{
			builder.Append(characters[value % characters.Length]);
		}

		return builder.ToString();
	}
}