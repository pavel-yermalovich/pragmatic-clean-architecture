using Bookify.Application.Apartments.SearchApartments;
using Bookify.Application.IntegrationTests.Infrastructure;
using FluentAssertions;

namespace Bookify.Application.IntegrationTests.Apartments;

public class SearchApartmentTests : BaseIntegrationTest
{
	public SearchApartmentTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) 
		: base(integrationTestWebAppFactory)
	{
	}

	[Fact]
	public async Task SearchApartments_ShouldReturnEmptyList_WhenDateRangeIsInvalid()
	{
		// Arrange
		var query = new SearchApartmentsQuery(new DateOnly(2024, 1, 25), new DateOnly(2024, 1, 1));

		// Act
		var result = await Sender.Send(query);

		// Assert
		result.IsSuccess.Should().BeTrue();
		result.Value.Should().BeEmpty();
	}

	[Fact]
	public async Task SearchApartments_ShouldReturnEmptyList_WhenDateRangeIsValid()
	{
		// Arrange
		var query = new SearchApartmentsQuery(new DateOnly(2024, 3, 1), new DateOnly(2024, 3, 2));

		// Act
		var result = await Sender.Send(query);

		// Assert
		result.IsSuccess.Should().BeTrue();
		result.Value.Should().BeEmpty();
	}
}
