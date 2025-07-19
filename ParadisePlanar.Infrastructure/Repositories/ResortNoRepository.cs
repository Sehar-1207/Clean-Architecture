using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParadisePlanner.Application.Common.Interfaces;
using ParadisePlanner.Domain.Entities;
using ParadisePlanner.Infrastructure.Data;

namespace ParadisePlanner.Infrastructure.Repositories
{
    public class ResortNoRepository : Repository<ResortNo> , IResortNoRepository
    {
        private readonly ApplicationDbContext _db;

        public ResortNoRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(ResortNo entity)
        {
            _db.ResortNos.Update(entity);
        }
    }
}
