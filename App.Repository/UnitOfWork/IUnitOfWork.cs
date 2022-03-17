using System;

namespace App.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IParamGenRepository ParamGenRepository { get; }

        int SaveChanges();
    }
}
