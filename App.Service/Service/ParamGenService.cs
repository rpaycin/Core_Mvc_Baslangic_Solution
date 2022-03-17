using App.Core.Dto;
using App.Core.Service;
using App.Repository;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Service
{
    public class ParamGenService : Service<ParamGenDto>, IParamGenService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ParamGenService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ParamGenDto GetById(int id)
        {
            var paramGen = _unitOfWork.ParamGenRepository.Get(id);

            var paramGenDto = _mapper.Map<ParamGenDto>(paramGen);

            SetDefaultValues(paramGenDto);

            return paramGenDto;
        }

        public async Task<List<ParamGenDto>> GetAllParamGen()
        {
            var paramGens = await _unitOfWork.ParamGenRepository.GetAllAsync();

            var paramGenDtos = _mapper.Map<List<ParamGenDto>>(paramGens);

            return paramGenDtos;
        }

        public bool Any(int id) => _unitOfWork.ParamGenRepository.Any(x => x.Id == id);
    }
}
