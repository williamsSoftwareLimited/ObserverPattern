namespace ObserverPattern {

    // this is the information sent for the observer pattern from the Subject to it's observers
    // we're just going to have a string property - Detail
    // the class is immutable
    class Message {
        public Message(string detail) {
            Detail = detail;
        }
        public string Detail { get; }
    }
}