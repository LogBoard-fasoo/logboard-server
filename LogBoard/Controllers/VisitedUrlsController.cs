#pragma warning disable CS1591
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LogBoard.Models;
using LogBoard.Repository;

namespace LogBoard.Controllers
{

    [ApiController]
    [Route("visited-urls")]

    public class VisitedUrlsController : ControllerBase
    {
        private readonly VisitedUrlsRepository _visitedUrlsRepository;

        public VisitedUrlsController(VisitedUrlsRepository visitedUrlsRepository)
        {
            _visitedUrlsRepository = visitedUrlsRepository;
        }

        /// <summary>
        /// 선택한 카테고리(단수)에서 방문한 URL TOP10을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>4-2</strong> <br></br> 선택한 카테고리의 방문한 URL TOP10을 가져옵니다.
        /// </remarks>
        /// <param name="id">카테고리 ID</param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        [HttpGet("category")]
        public List<VIsitedUrl> VisitedUrlByCategory([FromQuery] int id, string startDate, string endDate)
        {
            List<VIsitedUrl> visitedUrls = new List<VIsitedUrl>();

            try
            {
                visitedUrls = _visitedUrlsRepository.VisitedUrlByCategory(id, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return visitedUrls;
        }

        /// <summary>
        /// 선택한 산업군(단수)에서 방문한 URL TOP10을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>5-2</strong> <br></br> 선택한 산업군에서 방문한 URL TOP10을 가져옵니다.
        /// </remarks>
        /// <param name="id">산업군 ID</param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        [HttpGet("industry")]
        public List<VIsitedUrl> VisitedUrlByIndustry([FromQuery] int id, string startDate, string endDate)
        {
            List<VIsitedUrl> visitedUrls = new List<VIsitedUrl>();

            try
            {
                visitedUrls = _visitedUrlsRepository.VisitedUrlByIndustry(id, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return visitedUrls;
        }

        /// <summary>
        /// 선택한 기술(복수)에서 방문한 URL TOP10을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>6-2</strong> <br></br> 선택한 기술에서 방문한 URL TOP10을 가져옵니다.
        /// </remarks>
        /// <param name="idStr">기술 ID 문자열(1,2,3,4, ...)</param>
        /// <param name="startDate">조회 시작일(YYYY-MM-DD)</param>
        /// <param name="endDate">조회 종료일(YYYY-MM-DD)</param>
        [HttpGet("technology")]
        public List<VIsitedUrl> VisitedUrlByTechnology([FromQuery] string idStr, string startDate, string endDate)
        {
            List<VIsitedUrl> visitedUrls = new List<VIsitedUrl>();

            try
            {
                visitedUrls = _visitedUrlsRepository.VisitedUrlByTechnology(idStr, startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return visitedUrls;
        }



    }
}
