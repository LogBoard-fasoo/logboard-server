﻿#pragma warning disable CS1591
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LogBoard.Models;
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

        /// <summary>
        /// 특정 기업의 관심 카테고리를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>14</strong> <br></br> 특정 기업의 관심카테고리를 가져옵니다.
        /// </remarks>
        /// <param name="companyId">기업 ID</param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        /// <returns>특정 기업의 관심 카테고리를 가져옵니다.</returns>
        [HttpGet("/interested-category")]
        public List<PieChartModel> InterestedCategoryByCompany([FromQuery] int companyId, string startDate, string endDate)
        {
            List<PieChartModel> interestedCategory = new List<PieChartModel>();

            try
            {
                interestedCategory = _CompaniesRepository.InterestedCategoryByCompany(companyId, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return interestedCategory;


        }

        /// <summary>
        /// 특정 기업정보를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>15</strong> <br></br> 특정 기업정보를 가져옵니다.
        /// </remarks>
        /// <param name="companyId">기업 ID</param>
        /// <returns>특정 기업정보를 가져옵니다.</returns>
        [HttpGet("")]
        public CompanyDeatil CompanyInfo([FromQuery] int companyId)
        {
            CompanyDeatil company = new CompanyDeatil();

            try
            {
                company = _CompaniesRepository.CompanyInfo(companyId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return company;


        }



    }
}
