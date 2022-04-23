using EntityFrameworkCore.CommonTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.DAL.Entities
{
    public interface IEntityBase<TKey> : IEntityBase
    {
        TKey Id { get; set; }
    }

    public interface IEntityBase : IModificationTrackable, ICreationTrackable
    {
    }
}
