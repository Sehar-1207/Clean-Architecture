using ParadisePlanner.Application.Common.Interfaces;
using ParadisePlanner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadisePlanner.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IResortRepository Resort {  get; private set; }
        public IResortNoRepository ResortNo {  get; private set; }
        public IAmenityRepository Amenity { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Resort = new ResortRepository(_db);
            ResortNo = new ResortNoRepository(_db);
            Amenity= new AmenityRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
