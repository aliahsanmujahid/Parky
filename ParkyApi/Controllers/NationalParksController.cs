using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyApi.Models;
using ParkyApi.Models.Dtos;
using ParkyApi.Repository;
using ParkyApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : ControllerBase
    {
        private INationalParkRepository _npRepo;
        private readonly IMapper _mapper;

        public NationalParksController(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNationalParks()
        {

            var objList = _npRepo.GetNationalParks();

            var objDto = new List<NatinalParkDto>();

            foreach(var obj in objList)
            {
                objDto.Add(_mapper.Map<NatinalParkDto>(obj));
            }

            return Ok(objDto);

        }

        [HttpGet("{nationalParkId:int}", Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int nationalParkId)
        {

            var obj = _npRepo.GetNatinalPark(nationalParkId);
            if (obj == null)
                return NotFound();

            var objDto = _mapper.Map<NatinalParkDto>(obj);

            return Ok(objDto);

        }
        [HttpPost]
        public IActionResult CreateNationalPark(NatinalParkDto nationalParkdto)
        {

            if(nationalParkdto == null)
            {
                return BadRequest(ModelState);
            }

            var nationalParkObj = _mapper.Map<NatinalPark>(nationalParkdto);

            if (!_npRepo.CreateNationalPark(nationalParkObj))
            {
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("GetNationalPark", new { nationalParkId = nationalParkObj.Id }, nationalParkObj);


        }





    }
}
