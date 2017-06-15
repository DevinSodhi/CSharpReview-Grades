using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            //we right clicked and added a reference for Speech to use the following.
         //  SpeechSynthesizer synth = new SpeechSynthesizer();
          // synth.Speak("Hello! this is a grade book program");
          
           GradeBook book = new GradeBook();

            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //The delegate sequence above does not need to be explicitly instantiated, the C# compiler will do this for you as shown below
            book.NameChanged += OnNameChanged;


            //we can overwrite the previous delegate with a new assignment. Note that Delegates can actually reference multiple methods. multicast delegates these are called.
            //invoking NameChanged can hold multiple delegates if instead of assignment with =, you do += Why do this? there might be several portions of your app that want to 
            // know when this changes. This += is overloaded for our "NameChanged". You can also use -=. 
          //  book.NameChanged += new NameChangedDelegate(OnNameChanged2);

            //One problem with JUST using delegates is that you don't have enough encapsulation, so if someone were to 

           //book.NameChanged = null;
           //you'd be done. This is not what you want if you want different areas of the application to be able to suscribe to this event that the GradeBook name is changing.
           //changing the NameChangedDelegate event type when you declare it in the Gradebook class with "event" as shown there, will disallow the use of null at all.

            //if you make the Delegates to an Event, and follow the EventArgs naming convention, then you'll need to spend some time fixing how to read them as well.




            book.Name = "Scott's Gradebook";
            book.Name = "Delegate Trigger Gradebook";
            book.Name = "Scott's Gradebook";


           book.AddGrade(91);
           book.AddGrade(89.5f);
          
          
           //References:
           //assigning a new Gradebook to the variable "book" will create a brand new instance of the Gradebook.
           //CLR will clean up the original
          
           //what happens if we do the following?
           GradeBook book2 = book;
           book2.AddGrade(75);
          
           //when we define a class, we're creating a 'reference type' the variable doesn't hold the gradebook, it holds a memory address to that memory.
           //its like holding a business card.
           //multiple variables can point to the same object, and thats what we did above, copy the memory address
          
           //Lets create a new Class/object to store the stats of the Gradebook, while gradebook does the calculations for the stats.
           GradeStatistics stats = book.ComputeStatistics();

            //cw to code snippet for Console.WriteLine
            // Console.WriteLine(stats.AverageGrade);
            // Console.WriteLine(stats.HighestGrade);
            // Console.WriteLine(stats.LowestGrade);

            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Higest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);


            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

        }

        //we demonstrate both function overloading and different types of string formatting here.
        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
        }
        static void WriteResult(string description, int result)
        {
            Console.WriteLine($"{description} : {result:C} " );
        }

        //static void OnNameChanged(string existingName, string newName)
        //{
        //    Console.WriteLine($"GradeBook changing name from {existingName} to {newName}");
        //}

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"GradeBook changing name from {args.ExistingName} to {args.NewName}");
        }

    }
}
