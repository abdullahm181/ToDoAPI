using MediatR;
using Todo.Domain.Context;

namespace Todo.Application.Queries.Categorys
{
    public class GetAllTodoCategoriesQuery : IRequest<ApiResponse>
    {
    }
}
