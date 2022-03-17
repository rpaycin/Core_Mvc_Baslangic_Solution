using Microsoft.EntityFrameworkCore;

namespace App.Repository
{
    public class ParamGenRepository : Repository<ParamGen>, IParamGenRepository
    {
        public ParamGenRepository(DbContext context) : base(context)
        {
        }
    }
}
