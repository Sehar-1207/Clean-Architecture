using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadisePlanner.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IResortRepository Resort { get; }
        IResortNoRepository ResortNo { get; }
        IAmenityRepository Amenity { get; }
        void Save();
    }
}
