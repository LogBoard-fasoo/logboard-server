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
    [Route("visitors")]

    public class VisitorsController : ControllerBase
    {
        private readonly SshTunnelService _sshTunnelService;
        private readonly VisitorsRepository _visitRepository;

        public VisitorsController(SshTunnelService sshTunnelService, VisitorsRepository visitRepository)
        {
            _sshTunnelService = sshTunnelService;
            _visitRepository = visitRepository;
        }



        /// <summary>
        /// 주어진 기간 내의 카테고리별 방문자 수를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 이 API는 주어진 기간 내의 각 카테고리별 방문자 수를 조회합니다.
        /// </remarks>
        /// <param name="count">상위 N개의 결과를 반환할 개수</param>
        /// <param name="startDate">조회 시작일</param>
        /// <param name="endDate">조회 종료일</param>
        /// <returns>주어진 기간 내의 카테고리별 방문자 수 목록</returns>
        [HttpGet("category")]
        public List<CategoryVisitor> VistorsByCategory([FromQuery] int count, string startDate, string endDate)
        {
            List<CategoryVisitor> visitors = new List<CategoryVisitor>();

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
        

        [HttpGet("industry")]
        public List<IndustryVisitor> VistorsByIndustry([FromQuery] int count, string startDate, string endDate)
        {
            List<IndustryVisitor> visitors = new List<IndustryVisitor>();

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


    }
}
