﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Todo.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected IMediator mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
