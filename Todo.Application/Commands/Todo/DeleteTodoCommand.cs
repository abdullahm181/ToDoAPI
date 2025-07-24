using MediatR;
using Todo.Domain.Context;

namespace Todo.Application.Commands.Todo
{
    public class DeleteTodoCommand : IRequest<ApiResponse>
    {
        public int TodoId { get; set; }
    }
}
