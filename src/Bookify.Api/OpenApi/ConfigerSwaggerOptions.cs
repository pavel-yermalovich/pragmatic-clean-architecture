﻿using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bookify.Api.OpenApi;

public class ConfigerSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
	private readonly IApiVersionDescriptionProvider _provider;

	public ConfigerSwaggerOptions(IApiVersionDescriptionProvider provider)
	{
		_provider = provider;
	}
	
	public void Configure(string? name, SwaggerGenOptions options)
	{
		Configure(options);
	}

	public void Configure(SwaggerGenOptions options)
	{
		foreach (var description in _provider.ApiVersionDescriptions)
		{
			options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
		}
	}

	private OpenApiInfo CreateVersionInfo(ApiVersionDescription apiVersionDescription)
	{
		var openApiInfo = new OpenApiInfo
		{
			Title = $"Bookify.Api v{apiVersionDescription}",
			Version = apiVersionDescription.ApiVersion.ToString()
		};

		if (apiVersionDescription.IsDeprecated)
		{
			openApiInfo.Description += " This API version has been deprecated.";
		}

		return openApiInfo;
	}
}
