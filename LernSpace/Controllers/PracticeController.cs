using LernSpace.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LernSpace.Controllers
{
    public class PracticeController : ApiController
    {
       SlowlernerDbEntities db = new SlowlernerDbEntities();
        [HttpPost]
        public HttpResponseMessage AddNewPractic(List<collection> collection,Practic practic)
        {
            db.Practic.Add(practic);
            practicCollection p = new practicCollection();
            p.pracId = practic.PracId;
            foreach (collection item in collection)
            {
                p.collectId = item.Collect_id;
                db.practicCollection.Add(p);
            }
            db.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage myPractices(int did)
        {
            var data=db.Practic.Where(e=>e.createBy == did)
                .Join(db.practicCollection,practic=>practic.PracId,pracCollection=>pracCollection.pracId, (practic, pracCollection) => new { practic, pracCollection })
                .Join(db.collection,ppc=>ppc.pracCollection.collectId,collect=>collect.Collect_id,(ppc,collect)=> new
                {
                    Collectid=collect.Collect_id,
                    uText=collect.uText,
                    eText=collect.eText,
                    type=collect.type, 
                    picPath=collect.picPath,
                    C_grpup=collect.C_group
                });
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }
    }
}
