using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("patients")]
    public class PatientsController : ControllerBase
    {
        private IPatientService _patientService;
   //  private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public PatientsController(
            IPatientService patientService,
          //  IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _patientService = patientService;
          //  _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var patientsList = _patientService.GetAll();
            // var model = _mapper.Map<IList<UserModel>>(users);
            return Ok(patientsList);
        }

    }
}