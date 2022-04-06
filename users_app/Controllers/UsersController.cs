using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users_app.Application;
using users_app.Application.Commands;
using users_app.Application.DTO;
using users_app.Application.Queries;
using users_app.Application.Searches;


namespace users_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAppActor _actor;
        private readonly ExecutionAgent _exec;

        public UsersController(IAppActor actor, ExecutionAgent exec)
        {
            _actor = actor;
            _exec = exec;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearchDto search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_exec.ExecuteQuery(query, search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserQuery query)
        {
            return Ok(_exec.ExecuteQuery(query, id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] CreateUserDto dto, [FromServices] ICreateUserCommand comm)
        {
            _exec.ExecuteCommand(comm, dto);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EditUserDto dto, [FromServices] IEditUserCommand comm)
        {
            dto.Id = id;
            _exec.ExecuteCommand(comm, dto);
        }

    }
}
