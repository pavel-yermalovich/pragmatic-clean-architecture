using Bookify.Domain.Users;

namespace Bookify.Domain.UnitTests.Users;

internal static class UserData
{
	public static readonly FirstName FirstName = new FirstName("John");
	public static readonly LastName LastName = new LastName("Doe");
	public static readonly Email Email = new Email("john.doe@test.com");
}
