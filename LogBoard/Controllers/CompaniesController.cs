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
        /// API CODE : <strong>7</strong> <br></br> 웹사이트에 많이 방문한 TOP30개의 기업정보를 가져옵니다.
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

        /// <summary>
        /// 특정 기업의 관심 제품 TOP5를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>13</strong> <br></br> 특정 기업의 관심 제품 TOP5를 가져옵니다.
        /// </remarks>
        /// <param name="companyId">기업 ID</param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        /// <returns>특정 기업의 관심 제품 TOP5를 가져옵니다.</returns>
        [HttpGet("/interested-products/top5")]
        public List<PieChartModel> InterestedProductsByCompany([FromQuery] int companyId, string startDate, string endDate)
        {
            List<PieChartModel> interestedProducts = new List<PieChartModel>();

            try
            {
                interestedProducts = _CompaniesRepository.InterestedProductsByCompany(companyId, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return interestedProducts;


        }



    }
}
