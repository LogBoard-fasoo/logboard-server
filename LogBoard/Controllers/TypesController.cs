using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogBoard.Models;
using System.Data;
using MySql.Data.MySqlClient;
using LogBoard.Repository;
using Type = LogBoard.Models.Type;

namespace LogBoard.Controllers
{

    [ApiController]
    [Route("types")]

    public class TypesController : ControllerBase
    {
        private readonly TypesRepository _typesRepository;

        public TypesController(TypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        /// <summary>
        /// 카테고리의 종류를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>4</strong> <br></br> 카테고리의 종류를 가져옵니다.
        /// </remarks>
        [HttpGet("category")]
        public List<Type> CategoryTypes()
        {
            List<Type> types = new List<Type>();

            try
            {
                types = _typesRepository.CategoryTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return types;
        }

        /// <summary>
        /// 산업군의 종류를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>5</strong> <br></br> 산업군의 종류를 가져옵니다.
        /// </remarks>
        [HttpGet("industry")]
        public List<Type> IndustryTypes()
        {
            List<Type> types = new List<Type>();

            try
            {
                types = _typesRepository.IndustryTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return types;
        }

        /// <summary>
        /// 기술의 종류를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>6</strong> <br></br> 기술의 종류를 가져옵니다.
        /// </remarks>
        [HttpGet("technology")]
        public List<Type> TechnologyTypes()
        {
            List<Type> types = new List<Type>();

            try
            {
                types = _typesRepository.TechnologyTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return types;
        }

        /// <summary>
        /// 회사의 목록을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>8</strong> <br></br> 회사의 목록을 가져옵니다.
        /// </remarks>
        [HttpGet("company")]
        public List<Type> CompanyTypes()
        {
            List<Type> types = new List<Type>();

            try
            {
                types = _typesRepository.CompanyTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return types;
        }

        /// <summary>
        /// URL의 목록을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// API CODE : <strong>9</strong> <br></br> URL의 목록을 가져옵니다. <br></br> 🚫URL의 Index는 서버에서 이용할 수 없습니다. URL의 경우 Index 대신 URL문자열을 직접 서버로 전송해야합니다.
        /// </remarks>
        [HttpGet("url")]
        public List<Type> URLTypes()
        {
            List<Type> types = new List<Type>();

            try
            {
                types = _typesRepository.URLTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(BadRequest(ex.Message));
            }

            return types;
        }


    }
}
