using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EventRepo : IRepository
    {
        private EventDbContext _dbContext;

        //constructor
        public EventRepo()
        {
            _dbContext = new EventDbContext();
        }

        //Create new events
        public bool CreateEvent(Event events)
        {
            if (events == null)
            {
                return false;
            }
            _dbContext.Events.Add(events);
            _dbContext.SaveChanges();
            return true;
        }

        //Update event
        public bool UpdateEvent(Event events)
        {
            if (events == null)
            {
                return false;
            }
            _dbContext.Events.Update(events);
            _dbContext.SaveChanges();
            return true;
        }

        //Get list of events
        public List<Event> ViewAllEvents()
        {
            return _dbContext.Events.ToList();
        }

        //Find event by Id
        public Event ViewEventById(int id)
        {
            Event temp = null;
            try
            {
                temp = _dbContext.Events.Find(id);
            }
            catch (Exception ex) 
            {
                temp = null;
                return temp;
            }
            return temp;
        }
    }
}
