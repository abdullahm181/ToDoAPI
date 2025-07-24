using MediatR;
using Todo.Domain.Context;

namespace Todo.Application.Commands.Categorys
{
    public class DeleteTodoCategoryCommand : IRequest<ApiResponse>
    {
        public int CategoryId { get; set; }
    }
}
