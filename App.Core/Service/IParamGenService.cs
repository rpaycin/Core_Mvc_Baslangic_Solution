using App.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Service
{
    public interface IParamGenService: IService<ParamGenDto>
    {
        Task<List<ParamGenDto>> GetAllParamGen();
    }
}
