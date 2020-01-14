using API_Sanchez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Sanchez.Controllers
{
    public class carroController : ApiController
    {
        Carro[] carros = new Carro[]
        {
            new Carro{idCarro=1,marca="Ferrari",modelo=2012},
            new Carro{idCarro=2,marca="BMW",modelo=2016},
            new Carro{idCarro=3,marca="Hyunday",modelo=2001},
            new Carro{idCarro=4,marca="Honda",modelo=1992},
            new Carro{idCarro=5,marca="Mercedez",modelo=2005},
            new Carro{idCarro=6,marca="Nissan",modelo=2014}
        };

        public IEnumerable<Carro> getAllCarro()
        {
            return carros;
        }


        public IHttpActionResult getCarro(int id)
        {
            var carro = carros.FirstOrDefault(obj => obj.idCarro == id);
            if (carro != null)
            {
                return Ok(carro);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
