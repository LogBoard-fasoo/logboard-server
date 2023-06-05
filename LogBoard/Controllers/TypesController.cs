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


    }
}
