using MediatR;
using Todo.Domain.Context;

namespace Todo.Application.Queries.Todo
{
    public class GetAllTodosQuery : IRequest<ApiResponse>
    {
    }
}
