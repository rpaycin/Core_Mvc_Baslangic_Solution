using App.Core.Dto;
using App.Core.Service;
using App.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTestController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;//normalde burda işi yok. herşey GetAll metodundaki gibi kendi servisinde yazılmalı
        private IMapper _mapper;
        private IParamGenService _paramGenService;

        public ApiTestController(IUnitOfWork unitOfWork, IMapper mapper, IParamGenService paramGenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paramGenService = paramGenService;
        }

        // GET api/apitest 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_paramGenService.GetAllParamGen());
        }

        //GET api/apitest/4
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paramGen = _unitOfWork.ParamGenRepository.FirstOrDefault(p => p.Id == id);

            var paramGenDto = _mapper.Map<ParamGenDto>(paramGen);

            return Ok(paramGenDto);
        }

        //POST da sadece ekleme olur
        [HttpPost()]
        public async Task<IActionResult> Add(ParamGenDto paramGenDto)
        {
            var paramGen = _mapper.Map<ParamGen>(paramGenDto);

            _unitOfWork.ParamGenRepository.Add(paramGen);

            _unitOfWork.SaveChanges();

            return Ok(true);
        }

        //PUT da sadece update olur
        [HttpPut]
        public async Task<IActionResult> Update(ParamGenDto paramGenDto)
        {
            var paramGen = _mapper.Map<ParamGen>(paramGenDto);

            _unitOfWork.SaveChanges();

            return Ok(true);
        }

        //HttpDelete de sadece silme olur
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParam(int id)
        {
            var paramGen = _unitOfWork.ParamGenRepository.FirstOrDefault(p => p.Id == id);

            _unitOfWork.ParamGenRepository.Remove(paramGen);

            _unitOfWork.SaveChanges();

            return Ok(true);
        }
    }
}