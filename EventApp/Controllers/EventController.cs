using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventApp.Controllers
{
    public class EventController : Controller
    {
        private EventRepo _repo;

        public EventController()
        {
            _repo = new EventRepo();
        }

        //index method of the app

        public IActionResult GetEventList()
        {
            List<DataAccess.Model.Event> DataList = _repo.ViewAllEvents();
            List<Models.Event> ViewList = new List<Models.Event>();

            foreach(var row in DataList)
            {
                Models.Event temp = new Models.Event();
                temp.EventId = row.EventId;
                temp.Name = row.Name;
                temp.Date = row.Date;
                temp.Location = row.Location;
                temp.Type = row.Type;
                temp.Budget = row.Budget;
                ViewList.Add(temp);
            }
            return View(ViewList);
        }

        //Route[/Create]

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEvent(Models.Event events)
        {
            DataAccess.Model.Event DataEvent = new DataAccess.Model.Event();

            if (events != null)
            {
                DataEvent.EventId = events.EventId;
                DataEvent.Name = events.Name;
                DataEvent.Date = events.Date;
                DataEvent.Location = events.Location;
                DataEvent.Type = events.Type;
                DataEvent.Budget = events.Budget;
                bool result= _repo.CreateEvent(DataEvent);
                if (!result)
                {
                    return View("Error");
                }
            }
            return RedirectToAction("GetEventList");
        }

        //Route[/Edit]

        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            DataAccess.Model.Event DataEvent = null;
            Models.Event events = new Models.Event();
            try
            {
                DataEvent = _repo.ViewEventById(id);
                
                events.EventId = DataEvent.EventId;
                events.Name = DataEvent.Name;
                events.Date = DataEvent.Date;
                events.Budget = DataEvent.Budget;
                events.Type = DataEvent.Type;
                events.Location = DataEvent.Location;

            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(events);
        }

        [HttpPost]
        public IActionResult EditEvent(Models.Event events)
        {
            DataAccess.Model.Event DataEvent = new DataAccess.Model.Event();

            if (events != null)
            {
                DataEvent.EventId = events.EventId;
                DataEvent.Name = events.Name;
                DataEvent.Date = events.Date;
                DataEvent.Location = events.Location;
                DataEvent.Type = events.Type;
                DataEvent.Budget = events.Budget;
                bool result = _repo.UpdateEvent(DataEvent);
                if (!result)
                {
                    return View("Error");
                }
            }
            return RedirectToAction("GetEventList");

        }
    }
}
