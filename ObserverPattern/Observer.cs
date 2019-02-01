using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern {

    // as this is using IObserver it has very low cohesion with unused methods!
    class Observer : IObserver<Message> {
        private string _name;
        private IDisposable _unsubscriber;

        public Observer(string name) {
            _name = name;
        }

        public void Subscribe(IObservable<Message> subject) {
            Console.WriteLine("{0} subscribed",_name);
            _unsubscriber = subject.Subscribe(this);
        }

        public void Unsubscribe() {
            Console.WriteLine("{0} unsubscribed", _name);
            _unsubscriber.Dispose();
        }

        public void OnCompleted() {
            throw new NotImplementedException();
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }

        // each observer will replicate, in the real world this would be doing a real action
        public void OnNext(Message value) {
            Console.WriteLine("{0}: {1}", _name, value.Detail);
        }
    }
}
