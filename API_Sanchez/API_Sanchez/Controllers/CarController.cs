using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
using Utilities;

namespace API_Sanchez.Controllers
{
    public class CarController : ApiController
    {

        [HttpPost]
        [ActionName("addCar")]
        public IHttpActionResult addCar(Car pCar)
        {
            Car objCar = new DBConnector().addCar(pCar);
            return Ok();
        }
        
        [HttpDelete]
        [ActionName("deleteCar")]
        public IHttpActionResult deleteCar(Car pCar)
        {
            Car objCar = new DBConnector().deleteCar(pCar);
            return Ok();
        }

        [HttpGet]
        [ActionName("getAllCars")]
        public IEnumerable<Car> getAllCars()
        {
            return new DBConnector().getCars();
        }

        [HttpGet]
        [ActionName("getCar")]
        public Car getCar(Car pCar)
        {
            return new DBConnector().getCars(pCar);
        }

        [HttpPut]
        [ActionName("updateCar")]
        public IHttpActionResult updateCar(Car pCar)
        {
            Car objCar = new DBConnector().updateCar(pCar);
            return Ok();
        }
    }
}
