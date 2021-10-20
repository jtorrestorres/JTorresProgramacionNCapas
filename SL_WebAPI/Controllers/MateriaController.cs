using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class MateriaController : ApiController
    {
        // GET api/materia
        [Route("api/materia")]
        [HttpGet]        
        public IHttpActionResult Get()
        {
            ML.Result result = BL.Materia.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // GET api/materia/5
        [Route("api/materia/{IdMateria}")] //Enviar parámetros ->IdMateria
        [HttpGet]
        public IHttpActionResult GetById(int IdMateria)
        {
            ML.Result result = BL.Materia.GetById(IdMateria);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // POST api/materia
        [Route("api/materia")] //Enviar parámetros desde el body
        [HttpPost]
        public IHttpActionResult Add([FromBody]ML.Materia materia)
        {
            ML.Result result = BL.Materia.AddEF(materia);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // PUT api/materia/5
        [HttpPut]
        [Route("api/materia/{IdMateria}")]
        public void Put(int IdMateria, [FromBody]ML.Materia materia)
        {
        }

        [Route("api/materia/{FechaInicio}/{FechaFin}")]
        // DELETE api/materia/5
        public void Delete(int id)
        {
        }
    }
}
