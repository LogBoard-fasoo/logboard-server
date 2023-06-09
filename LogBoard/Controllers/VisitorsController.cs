﻿#pragma warning disable CS1591
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LogBoard.Models;
using LogBoard.Repository;
using System.Linq;

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



        /// <summary>
        /// 주어진 기간 내의 특정 기업의 주간 방문 트랜드를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>12</strong> <br></br> 이 API는 주어진 기간 내의 특정 기업의 주간 방문 트랜드를 가져옵니다.
        /// </remarks>
        /// <param name="companyIds">기업 ID 문자열 EX) 1,2,3,4,5,100,200,300,...</param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        /// <returns>주어진 기간 내의 기술별 방문자 수 목록</returns>
        [HttpGet("weekly-trends/company")]
        public List<GraphChartModel> WeeklyTrendsByCompany([FromQuery] string companyIds, string startDate, string endDate)
        {
            List<GraphChartModel> graphCharts = new List<GraphChartModel>();

            var companyArr = companyIds.Split(",").Select(int.Parse).ToArray();


            Console.WriteLine(companyArr);
            try
            {
                graphCharts = _visitRepository.WeeklyTrendsByCompany(companyArr, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return graphCharts;
        }

        /// <summary>
        /// 주어진 기간 내의 특정 제품의 주간 방문 트랜드를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>16</strong> <br></br> 이 API는 주어진 기간 내의 특정 제품의 주간 방문 트랜드를 가져옵니다.
        /// </remarks>
        /// <param name="url">제품명 ex) products/analyticdid-use-case </param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        /// <returns>주어진 기간 내의 기술별 방문자 수 목록</returns>
        [HttpGet("weekly-trends/URL")]
        public GraphChartModel WeeklyTrendsByURL([FromQuery] string url, string startDate, string endDate)
        {
            GraphChartModel graphChart = new GraphChartModel();

            try
            {
                graphChart = _visitRepository.WeeklyTrendsByURL(url, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return graphChart;
        }

    }
}
