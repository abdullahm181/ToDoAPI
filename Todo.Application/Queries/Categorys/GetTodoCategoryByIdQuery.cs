using MediatR;
using Todo.Domain.Context;

namespace Todo.Application.Queries.Categorys
{
    public class GetTodoCategoryByIdQuery : IRequest<ApiResponse>
    {
        public int CategoryId { get; set; }
    }
}
