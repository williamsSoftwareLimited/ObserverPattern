using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern {
    class Program {
        static void Main(string[] args) {
            var subject = new Subject();
            var observerA = new Observer("observerA");
            var observerB = new Observer("observerB");
            var observerC = new Observer("observerC");

            var observerD = new Observer("observerD");

            observerA.Subscribe(subject);
            observerB.Subscribe(subject);

            // change the subjects number
            subject.SetNumber(10);

            observerC.Subscribe(subject);
            observerB.Unsubscribe();

            // weirdly I can subscribe observerD here but to unsubscribe I need to keep the unsubscribe object returned
            Console.WriteLine("Subscribing observerD from somewhere else!");
            var unsubcriberD = subject.Subscribe(observerD);

            subject.SetNumber(99);

            Console.WriteLine("Unsubscribing observerD from somewhere else!");
            unsubcriberD.Dispose();


            subject.SetNumber(321);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
