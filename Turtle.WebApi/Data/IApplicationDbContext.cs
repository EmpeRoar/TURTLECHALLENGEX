using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turtle.WebApi.Models;

namespace Turtle.WebApi.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Command> Commands { get; set; }
       
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
