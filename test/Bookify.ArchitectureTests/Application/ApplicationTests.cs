using Bookify.Application.Abstractions.Messaging;
using Bookify.ArchitectureTests.Infrastructure;
using FluentAssertions;
using FluentValidation;
using NetArchTest.Rules;

namespace Bookify.ArchitectureTests.Application;

public class ApplicationTests : BaseTest
{
	[Fact]
	public void CommandHandler_ShouldHave_CommandHandlerPostfix()
	{
		TestResult result = Types.InAssembly(ApplicationAssembly)
			.That()
			.ImplementInterface(typeof(ICommandHandler<>))
			.Should()
			.HaveNameEndingWith("CommandHandler")
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void CommandHandler_Should_NotBePublic()
	{
		TestResult result = Types.InAssembly(ApplicationAssembly)
			.That()
			.ImplementInterface(typeof(ICommandHandler<>))
			.Should()
			.NotBePublic()
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void QueryHandler_ShouldHave_QueryHandlerPostfix()
	{
		TestResult result = Types.InAssembly(ApplicationAssembly)
			.That()
			.ImplementInterface(typeof(IQueryHandler<,>))
			.Should()
			.HaveNameEndingWith("QueryHandler")
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void QueryHandler_Should_NotBePublic() 
	{
		TestResult result = Types.InAssembly(ApplicationAssembly)
			.That()
			.ImplementInterface(typeof(IQueryHandler<,>))
			.Should()
			.NotBePublic()
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void Validators_ShouldHave_ValidatorPostfix()
	{
		TestResult result = Types.InAssembly(ApplicationAssembly)
			.That()
			.ImplementInterface(typeof(IValidator<>))
			.Should()
			.HaveNameEndingWith("Validator")
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void Validators_Should_NotBePublic()
	{
		TestResult result = Types.InAssembly(ApplicationAssembly)
			.That()
			.ImplementInterface(typeof(IValidator<>))
			.Should()
			.NotBePublic()
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}
}
