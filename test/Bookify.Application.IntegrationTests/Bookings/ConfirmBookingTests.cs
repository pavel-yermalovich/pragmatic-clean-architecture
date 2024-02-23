using Bookify.Application.Bookings.ConfirmBooking;
using Bookify.Application.IntegrationTests.Infrastructure;
using Bookify.Domain.Bookings;
using FluentAssertions;

namespace Bookify.Application.IntegrationTests.Bookings;

public class ConfirmBookingTests : BaseIntegrationTest
{
	public ConfirmBookingTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) 
		: base(integrationTestWebAppFactory)
	{
	}

	[Fact]
	public async Task ConfirmBooking_ShouldFailure_WhenBookingIsNotFound()
	{
		// Arrange
		var command = new ConfirmBookingCommand(Guid.NewGuid());

		// Act
		var result = await Sender.Send(command);

		// Assert
		result.Error.Should().Be(BookingErrors.NotFound);
	}
}