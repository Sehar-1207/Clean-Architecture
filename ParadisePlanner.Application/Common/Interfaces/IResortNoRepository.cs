using ParadisePlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadisePlanner.Application.Common.Interfaces
{
    public interface IResortNoRepository : IRepository<ResortNo>
    {
        void Update(ResortNo entity);
    }
}
