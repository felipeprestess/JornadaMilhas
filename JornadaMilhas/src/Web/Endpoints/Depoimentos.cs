
using JornadaMilhas.Application.Depoimentos.Commands.CreateDepoimento;
using JornadaMilhas.Application.TodoItems.Commands.CreateTodoItem;
using JornadaMilhas.Application.TodoItems.Commands.DeleteTodoItem;
using JornadaMilhas.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace JornadaMilhas.Web.Endpoints;

public class Depoimentos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetDepoimentos, "/depoimentos-home");
    }

    public async Task<IEnumerable<WeatherForecast>> GetDepoimentos(ISender sender)
    {
        return await sender.Send(new GetWeatherForecastsQuery());
    }

    public Task<int> CreateDepoimento(ISender sender, CreateDepoimentoCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> DeleteDepoimento(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoItemCommand(id));
        return Results.NoContent();
    }
}
