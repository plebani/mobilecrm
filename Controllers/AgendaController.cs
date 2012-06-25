using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using mobileCRM.Models;

namespace mobileCRM.Controllers
{
    public class AgendaController : Controller
    {
        //
        // GET: /Agenda/

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// DayPilot backend
        /// </summary>
        /// <returns></returns>
        public ActionResult Backend()
        {
            return new Dpc().CallBack(this);
        }

        /// <summary>
        /// DayPilot handler class
        /// </summary>
        class Dpc : DayPilotCalendar
        {
            CRMEntities db = new CRMEntities();

            protected override void OnInit(InitArgs e)
            {
                Update(CallBackUpdateType.Full);
            }

            protected override void OnEventResize(EventResizeArgs e)
            {
                int idAux = Convert.ToInt32(e.Id);
                var toBeResized = (from ev in db.Event where ev.id == idAux select ev).FirstOrDefault();
                toBeResized.eventstart = e.NewStart;
                toBeResized.eventend = e.NewEnd;
                db.SaveChanges();
                Update();
            }

            protected override void OnEventMove(EventMoveArgs e)
            {
                int idAux = Convert.ToInt32(e.Id);
                var toBeResized = (from ev in db.Event where ev.id == idAux select ev).FirstOrDefault();
                toBeResized.eventstart = e.NewStart;
                toBeResized.eventend = e.NewEnd;
                db.SaveChanges();
                Update();
            }

            protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
            {
                Event toBeCreated = new Event { eventstart = e.Start, eventend = e.End, text = (string)e.Data["name"] };
                db.AddToEvent(toBeCreated);
                db.SaveChanges();
                Update();
            }

            protected override void OnFinish()
            {
                if (UpdateType == CallBackUpdateType.None)
                {
                    return;
                }

                Events = from ev in db.Event select ev;

                DataIdField = "id";
                DataTextField = "text";
                DataStartField = "eventstart";
                DataEndField = "eventend";
            }

        }

    }
}
