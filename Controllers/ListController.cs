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
    // [Authorize]
    [ApiController]
    [Route("lists")]
    public class ListController : ControllerBase
    {

        private IListService _listService;
        public ListController(
            IListService listService)
        {
            _listService = listService;
        }

        [HttpGet("getClinics")]
        public IActionResult GetClinics()
        {
            var clinicList = _listService.GetClinics();
            return Ok(clinicList);
        }

        [HttpGet("getLocalities")]
        public IActionResult GetLocalities()
        {
            var LocList = _listService.GetLocalities();
            return Ok(LocList);
        }
    }
}
