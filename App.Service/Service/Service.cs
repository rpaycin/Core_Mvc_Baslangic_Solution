using App.Core.Dto;
using System;

namespace App.Service.Service
{
    public abstract class Service<T> where T:BaseDto
    {
        public virtual void SetDefaultValues(T entity)
        {
            if (entity.Id > 0)
            {
                entity.UpdateDate = DateTime.Now;
            }
            else
            {
                entity.CreateDate = DateTime.Now;
            }
        }
    }
}
