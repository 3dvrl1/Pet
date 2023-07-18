using ArmoryPet.Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;

namespace ArmoryPet.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
        


    public DbSet<CharacterDto> Characters { get; set; }
}