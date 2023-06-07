using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LogBoard.Models;
using LogBoard.Repository;

namespace LogBoard.Controllers
{

    [ApiController]
    [Route("visitors")]

    public class VisitorsController : ControllerBase
    {
        private readonly VisitorsRepository _visitRepository;

        public VisitorsController(VisitorsRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }



        /// <summary>
        /// 주어진 기간 내의 카테고리별 방문자 수를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>1</strong> <br></br>  이 API는 주어진 기간 내의 각 카테고리별 방문자 수를 조회합니다.
        /// </remarks>
        /// <param name="count">반환할 상위 N개의 카테고리 수</param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        /// <returns>주어진 기간 내의 카테고리별 방문자 수 목록</returns>
        [HttpGet("category")]
        public List<PieChartModel> VistorsByCategory([FromQuery] int count, string startDate, string endDate)
        {
            List<PieChartModel> visitors = new List<PieChartModel>();

            try
            {
                visitors = _visitRepository.VisitorsByCategory(count, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return visitors;
        }


        /// <summary>
        /// 주어진 기간 내의 산업군별 방문자 수를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>2</strong> <br></br> 이 API는 주어진 기간 내의 각 산업군별 방문자 수를 조회합니다.
        /// </remarks>
        /// <param name="count">반환할 상위 N개의 산업군 수</param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        /// <returns>주어진 기간 내의 산업군별 방문자 수 목록</returns>
        [HttpGet("industry")]
        public List<PieChartModel> VistorsByIndustry([FromQuery] int count, string startDate, string endDate)
        {
            List<PieChartModel> visitors = new List<PieChartModel>();

            try
            {
                visitors = _visitRepository.VisitorsByIndustry(count, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return visitors;
        }

        /// <summary>
        /// 주어진 기간 내의 기술별 방문자 수를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>3</strong> <br></br> 이 API는 주어진 기간 내의 각 기술별 방문자 수를 조회합니다.
        /// </remarks>
        /// <param name="count">반환할 상위 N개의 기술 수</param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        /// <returns>주어진 기간 내의 기술별 방문자 수 목록</returns>
        [HttpGet("technology")]
        public List<PieChartModel> VistorsByTechnology([FromQuery] int count, string startDate, string endDate)
        {
            List<PieChartModel> visitors = new List<PieChartModel>();

            try
            {
                visitors = _visitRepository.VisitorsByTechnology(count, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return visitors;
        }


    }
}
