using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace IndigoSoftTestTask.Application.FunctionalTests;

[SetUpFixture]
public partial class Testing
{
    private static CustomWebApplicationFactory _factory = null!;
    private static IServiceScopeFactory _scopeFactory = null!;

    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        _factory = new CustomWebApplicationFactory();
        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
    }

    [OneTimeTearDown]
    public void DisposeFactory()
    {
        _factory?.Dispose();
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = _scopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        return await mediator.Send(request);
    }

}
