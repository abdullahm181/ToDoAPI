using MediatR;
using Todo.Domain.Context;

namespace Todo.Application.Commands.Todo
{
    public class SearchTodoByTitleCommand : IRequest<ApiResponse>
    {

        public string searchTerm { get; set; }
    }
}
