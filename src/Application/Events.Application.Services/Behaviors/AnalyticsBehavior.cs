using Events.Application.Services.Features.Analytics.Repositories;
using Events.Application.Services.Interfaces;
using Events.Domain.Aggregates.AnalyticsAggregate;
using MediatR;

namespace Events.Application.Services.Behaviors;

/// <summary>
///     Behavior для аналитики.
/// </summary>
/// <typeparam name="TRequest">Тип запроса.</typeparam>
/// <typeparam name="TResponse">Тип ответа.</typeparam>
public class AnalyticsBehavior<TRequest, TResponse>(
    IPageViewRepository pageViewRepository,
    ICurrentUserProvider currentUserProvider
)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is not ITrackPageView trackable)
            return await next(cancellationToken);

        var response = await next(cancellationToken);

        try
        {
            var userId = currentUserProvider.UserId;
            var pageView = new PageView(trackable.EntityType, trackable.EntityId, userId);

            await pageViewRepository.AddAsync(pageView, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return response;
    }
}