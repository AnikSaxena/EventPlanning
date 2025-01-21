using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository
    {
        public List<Event> ViewAllEvents();
        public Event ViewEventById(int id);
        public bool CreateEvent(Event events);
        public bool UpdateEvent(Event events);
    }
}
