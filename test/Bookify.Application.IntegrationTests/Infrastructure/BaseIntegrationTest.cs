using Bookify.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Application.IntegrationTests.Infrastructure;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
	private readonly IServiceScope _scope;

	protected readonly ISender Sender;
	protected readonly ApplicationDbContext DbContext;
	
	protected BaseIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
	{
		_scope = integrationTestWebAppFactory.Services.CreateScope();

		Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
		DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
	}
}
