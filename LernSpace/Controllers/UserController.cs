using LernSpace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LernSpace.Controllers
{
    public class UserController : ApiController
    {
        SlowlernerDbEntities db= new SlowlernerDbEntities();
        [HttpGet]
        public HttpResponseMessage TodayAppointmrnts()
        {
            var request = HttpContext.Current.Request;
            var Did =int.Parse( request["uid"]);
            var data=db.appointment.Where(e=>e.userId == Did && e.nextAppointDate==DateTime.Now).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        public  HttpResponseMessage AddAppointment(appointment appoint)
        {
            appoint.appointmentDate = DateTime.Parse("12/12/2024");
            appoint.nextAppointDate = DateTime.Now;
            db.appointment.Add(appoint);
            Console.WriteLine(appoint);
            
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpGet]
        public HttpResponseMessage showSpacificAppointment(int id)
        {
            var data= db.appointment.Where(e=>e.app_Id == id).ToList();
            return Request.CreateResponse(statusCode: HttpStatusCode.OK, data);
        }
    }
}
