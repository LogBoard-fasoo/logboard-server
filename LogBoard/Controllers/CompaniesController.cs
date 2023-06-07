using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogBoard.Models;
using System.Data;
using MySql.Data.MySqlClient;
using LogBoard.Repository;

namespace LogBoard.Controllers
{

    [ApiController]
    [Route("companies")]

    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesRepository _CompaniesRepository;

        public CompaniesController(CompaniesRepository companiesRepository)
        {
            _CompaniesRepository = companiesRepository;
        }

        /// <summary>
        /// 웹사이트에 많이 방문한 TOP30개의 기업정보를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 웹사이트에 많이 방문한 TOP30개의 기업정보를 가져옵니다.
        /// </remarks>
        [HttpGet("visited/top30")]
        public List<Company> CompaniesVisitedRank([FromQuery] string startDate, string endDate)
        {
            List<Company> companies = new List<Company>();

            try
            {
                companies = _CompaniesRepository.CompaniesVisitedRank(startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return companies;
        }



    }
}
