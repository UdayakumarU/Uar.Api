
using Microsoft.EntityFrameworkCore;
using Uar.Api.Abstractions.Models;

namespace Uar.Api.Data;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<Campaign> Campaigns { get; set; }
}
