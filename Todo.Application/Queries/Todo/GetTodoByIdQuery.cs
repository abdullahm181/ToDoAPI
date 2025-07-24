using MediatR;
using Todo.Domain.Context;

namespace Todo.Application.Queries.Todo
{
    public class GetTodoByIdQuery : IRequest<ApiResponse>
    {
        public int TodoId { get; set; }

    }
}
