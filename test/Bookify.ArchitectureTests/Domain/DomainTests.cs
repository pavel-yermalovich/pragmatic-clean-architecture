using Bookify.ArchitectureTests.Infrastructure;
using Bookify.Domain.Abstractions;
using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;

namespace Bookify.ArchitectureTests.Domain;

public class DomainTests : BaseTest
{
	[Fact]
	public void DomainEvents_ShouldBe_Sealed() 
	{ 
		TestResult result = Types.InAssembly(DomainAssembly)
			.That()
			.ImplementInterface(typeof(IDomainEvent))
			.Should()
			.BeSealed()
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void DomainEvent_ShouldHave_DomainEventPostfix() 
	{
		TestResult result = Types.InAssembly(DomainAssembly)
			.That()
			.ImplementInterface(typeof(IDomainEvent))
			.Should()
			.HaveNameEndingWith("DomainEvent")
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void Entities_ShouldHave_ParameterlessConstructor() 
	{ 
		var entityTypes = Types.InAssembly(DomainAssembly)
			.That()
			.Inherit(typeof(Entity))
			.GetTypes();

		var failingTypes = new List<Type>();
		foreach (var entityType in entityTypes)
		{
			ConstructorInfo[] constructors = entityType.GetConstructors(BindingFlags.NonPublic |
				BindingFlags.Instance);
			if (!constructors.Any(c => c.GetParameters().Length == 0))
			{
				failingTypes.Add(entityType);
			}
		}

		failingTypes.Should().BeEmpty();
	}
}
