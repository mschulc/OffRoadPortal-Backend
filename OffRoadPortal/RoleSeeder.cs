/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: RoleSeeder.cs                                     //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Entities;
using OffRoadPortal.Services;

namespace OffRoadPortal;

public class RoleSeeder
{
    private readonly OffRoadPortalDbContext _dbContext;

    public RoleSeeder(OffRoadPortalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if(_dbContext.Database.CanConnect())
        {
            if(!_dbContext.Roles.Any())
            {
                var roles = new List<Role>()
                {
                    new Role{Id = 1, Name = "Standard" },
                    new Role{Id = 2, Name = "Premium"},
                    new Role{Id = 3, Name = "Redactor" },
                    new Role{Id = 4, Name = "Admin"}
                };

                _dbContext.Roles.AddRange(roles);
                _dbContext.SaveChanges();
            }
        }
    }
}
