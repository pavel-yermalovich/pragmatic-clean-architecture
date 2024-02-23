using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.IntegrationTests.Infrastructure;
using Bookify.Domain.Bookings;
using FluentAssertions;

namespace Bookify.Application.IntegrationTests.Bookings;

public class GetBookingTests : BaseIntegrationTest
{
	private static readonly Guid BookingId = Guid.NewGuid();
	
	public GetBookingTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) 
		: base(integrationTestWebAppFactory)
	{
	}

	[Fact]
	public async Task GetBooking_ShouldFailure_WhenBookingIsNotFound()
	{
		// Arrange
		var command = new GetBookingQuery(BookingId);

		// Act
		var result = await Sender.Send(command);

		// Assert
		result.Error.Should().Be(BookingErrors.NotFound);
	}
}
