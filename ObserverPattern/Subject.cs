using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern {

    // not to reuse code (DRY) we'll use the Microsoft Interface IObservable<T>
    // the interface requires the information (Message class) to be sent in the notification (T) 
    // and the implementation of the method Subscribe which also (just to make this easy!) needs another 
    // class which implements IDisposible (this is adding too much complexity)
    class Subject : IObservable<Message> {

        List<IObserver<Message>> _observers;
        int _numberToTrack;

        public Subject() {
            _observers = new List<IObserver<Message>>();
            _numberToTrack = 0;
        }

        public IDisposable Subscribe(IObserver<Message> observer) {
            if (!_observers.Contains(observer)) {
                _observers.Add(observer);
            }

            // I'm not sure I agree with this, why not just have an unsubscribe method!
            return new Unsubscriber<Message>(_observers, observer); 
        }

        // a simple change state method 
        public void SetNumber(int newNumber) {
            _numberToTrack = newNumber;
            notifyObservers(new Message("The new number is " + _numberToTrack));
        }

        // a method that sends a message to the observers(subscribers)
        void notifyObservers(Message message) {
            foreach(var observer in _observers) {
                observer.OnNext(message);
            }
        }

        // this is the Unsubscriber this adds complexity but is what Microsoft require
        // which asks the question - why do all this just to remove an observer from the list?
        class Unsubscriber<Message> : IDisposable {
            List<IObserver<Message>> _observers;
            IObserver<Message> _observer;

            public Unsubscriber(List<IObserver<Message>> observers, IObserver<Message> observer) {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose() {
                if (_observers.Contains(_observer)) {
                    _observers.Remove(_observer);
                }
            }
        }
    }
}
