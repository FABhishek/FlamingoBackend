using SOTI.Capstone.FlamingoDAL.Interfaces;
using SOTI.Capstone.FlamingoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOTI.Capstone.Flamingo.Controllers
{
    [RoutePrefix("Cards")]
    public class CardInfoController : ApiController
    {
        private readonly ICardInfo _cardInfo = null;
        public CardInfoController(ICardInfo cardInfo) //Dependency Injection
        {
            _cardInfo = cardInfo;
        }

        //Validate wheather the entered record matches the existing record or not
        //for this we will do the get request to check if it exists
        [HttpGet]
        [Route("cardcheck")]
        public IHttpActionResult ValidateCard([FromBody] CardInfo card)
        {
            var result = _cardInfo.ValidateCardDetails(card);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
       
    }
}
