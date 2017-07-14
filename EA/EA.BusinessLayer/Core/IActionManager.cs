using EA.Common.Core;
using EA.DA.Core;
using System.Collections.Generic;

namespace EA.BusinessLayer.Core
{
    public interface IActionManager
    {
        IUnitOfWork UnitOfWork { get; }

        void Create(BaseEntity entity);

        void Update(BaseEntity entity);

        void Delete(BaseEntity entity);

        IEnumerable<BaseEntity> GetAll();

        void SaveChanges();
    }
}