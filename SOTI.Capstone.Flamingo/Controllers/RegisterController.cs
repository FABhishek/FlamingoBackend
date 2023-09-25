using SOTI.Capstone.FlamingoDAL.Interfaces;
using SOTI.Capstone.FlamingoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SOTI.Capstone.Flamingo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Register")]
    public class RegisterController : ApiController
    {
        private readonly IRegister _registerTable = null;

        public RegisterController(IRegister register)
        {
            _registerTable = register;
        }


        [HttpPost]
        [Route("Add")]
        public IHttpActionResult AddRegister([FromBody] Register register)
        {
            bool result = _registerTable.AddRegistration(register);

            if (result == false)
            {
                return BadRequest("Email already exists!");
            }

            return Created("api/register/getall", register);
        }


        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAllData()
        {
            Register[] result = _registerTable.GetAllRegisterData();

            if (result == null)
            {
                return InternalServerError();
            }

            return Ok(result);
        }

    }
}
