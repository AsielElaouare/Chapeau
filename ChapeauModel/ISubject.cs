using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public interface ISubject
    {
        public Order SubjectOrder { get; set; }
        public void Attach(IObserver observer);
        public void Deattach(IObserver observer);
        public void NotifyOberservers();
    }
}
