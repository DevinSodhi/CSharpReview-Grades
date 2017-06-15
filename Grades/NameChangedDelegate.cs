using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{

    //public delegate void NameChangedDelegate(string existingName, string newName);
    //typically the first argument for an event is "itself", and the second is all the information it wants to send.
    //this means we need to build a custom class for existingName and newName and pass them along as objects.
    //The parameter that passes along teh argument for the event, the name of its type will always end with the words "EventArgs"

        //object means we can pass anything as a value here. Gradebook is Sender of the event? then we pass Gradebook.
        //of coursse to the below you need to make changes to the Gradebook class as well
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
