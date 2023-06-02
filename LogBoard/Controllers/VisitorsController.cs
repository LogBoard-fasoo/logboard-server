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

        [HttpGet("category")]
        public List<CategoryVisitor> Test([FromQuery] int count, string startDate, string endDate)
        {
            string result = string.Empty;

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


    }
}
