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
using WebApi.Models.Diary;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("diary")]
    public class DiaryController : ControllerBase
    {

        private IDiaryService _diaryService;
        private IDiaryService2 _diaryService2;

        public DiaryController(IDiaryService diaryService, IDiaryService2 diaryService2)
        {
            _diaryService = diaryService;
            _diaryService2 = diaryService2;
        }



        // [HttpPost("getList")]
        // public IActionResult GetList([FromBody] GetDiaryListDTO model)
        // {
        //     DiaryPageItem dp = new DiaryPageItem();

        //     dp.setA = _diaryService.GetDiaryList(model.qDate, model.qClinicId, "A");
        //     dp.setB = _diaryService.GetDiaryList(model.qDate, model.qClinicId, "B");
        //     dp.setC = _diaryService.GetDiaryList(model.qDate, model.qClinicId, "C");
        //     return Ok(dp);

        // }

        [HttpPost("getDiaryPage")]
        public IActionResult GetDiaryPage([FromBody] GetDiaryListDTO2 model)
        {
            var dp = _diaryService2.GetDiaryPage(model.date, model.clinicId);
            return Ok(dp);

        }
    }
}

