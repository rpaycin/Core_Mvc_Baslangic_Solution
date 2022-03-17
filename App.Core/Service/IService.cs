using App.Core.Dto;
using System;
using System.Linq.Expressions;

namespace App.Core.Service
{
    public interface IService<T> where T : BaseDto
    {
        bool Any(int id);
    }
}
