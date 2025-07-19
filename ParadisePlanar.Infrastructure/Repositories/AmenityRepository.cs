using ParadisePlanner.Application.Common.Interfaces;
using ParadisePlanner.Domain.Entities;
using ParadisePlanner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadisePlanner.Infrastructure.Repositories
{
    public class AmenityRepository: Repository<Amenity> , IAmenityRepository
    {
        private readonly ApplicationDbContext _db;

        public AmenityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Amenity entity)
        {
            _db.Amenities.Update(entity);
        }
    }
}
