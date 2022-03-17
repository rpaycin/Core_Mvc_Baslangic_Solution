namespace App.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AksaContext _context;

        public IParamGenRepository ParamGenRepository { get; private set; }

        public UnitOfWork(AksaContext aksaContext)
        {
            _context = aksaContext;

            ParamGenRepository = new ParamGenRepository(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
