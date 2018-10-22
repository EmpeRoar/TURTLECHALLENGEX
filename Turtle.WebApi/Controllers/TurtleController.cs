using CommandInputs.interfaces;
using CommandInputs.extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Turtle.WebApi.Data;
using Turtle.World;
using Turtle.World.interfaces;
using Turtle.World.models;
using CommandInputs;
using System.Linq;

namespace Turtle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurtleController : ControllerBase
    {
        IServiceProvider _serviceProvider;
        ITurtle _turtle;
        ICommandInput _dbInput;
        public TurtleController(IServiceProvider serviceProvider, 
                                ITurtle turtle,
                                ICommandInput dbInput)
        {
            _serviceProvider = serviceProvider;
            _turtle = turtle;
            _dbInput = dbInput;
        }

      

        [HttpGet]
        [Route("place/{x}/{y}/{f}")]
        public async Task<ActionResult<string>> Place([FromRoute] string x, [FromRoute] string y, [FromRoute] string f)
        {
            using (var context = new ApplicationDbContext(
                _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Commands.Add(new Models.Command()
                {
                    Task = $"Place {x},{y},{f}"
                });

                context.SaveChanges();
                return Ok("Place");
            }
        }

       

        [HttpGet]
        [Route("move")]
        public async Task<ActionResult<string>> Move()
        {
            using (var context = new ApplicationDbContext(
                _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Commands.Add(new Models.Command()
                {
                     Task = "Move"
                });

                context.SaveChanges();
                return Ok("Move");
            }
        }

        [HttpGet]
        [Route("left")]
        public async Task<ActionResult<string>> Left()
        {
            using (var context = new ApplicationDbContext(
                _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Commands.Add(new Models.Command()
                {
                    Task = "left"
                });

                context.SaveChanges();
                return Ok("left");
            }
        }

        [HttpGet]
        [Route("right")]
        public async Task<ActionResult<string>> Right()
        {
            using (var context = new ApplicationDbContext(
                _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Commands.Add(new Models.Command()
                {
                    Task = "right"
                });

                context.SaveChanges();
                return Ok("right");
            }
           
        }

        [HttpGet]
        [Route("report")]
        public async Task<ActionResult<string>> Report()
        {
            using (var context = new ApplicationDbContext(
                _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Commands.Add(new Models.Command()
                {
                    Task = "report"
                });

                context.SaveChanges();

                var table = new Table();
                var turtleState = new TurtleState();
                string emittedReport = String.Empty;
                var turtle = new TurtleObject(turtleState, table);
                turtle.Read(await context.Commands.Select(x => x.Task).ToListAsync());
               var dbInput = new WebApiInput(turtle);
                dbInput.Execute();
                var msg = dbInput.GetReportMessage();
                return Ok(msg);
            }
            
        }

        [HttpGet]
        [Route("clear")]
        public async Task<ActionResult<string>> Clear()
        {
            using (var context = new ApplicationDbContext(
                _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var commands = context.Commands;
                foreach (var command in commands)
                {
                    context.Commands.Remove(command);
                }
                context.SaveChanges();
                return Ok("cleared");
            }
        }
    }
}