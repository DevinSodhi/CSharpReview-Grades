using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

//a class is a blueprint for creating objects
//a class can be used to type a variable.


namespace Grades
{
    //Making this class public may cause inconsistent accesbility error.
    //GradeStatistics is less accesible than ComputeStatistoc
    //GradeStatistics is returned but its an internal class so watch with
    // you could also mark just that one method internal.
    public class GradeBook
    {
        //ctor starts off a constructor automatically.
        //the keyword (specifically access modifier) public makes the constructor available to outside the class.
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
            
        }

        
        //classes have two member types
        // 1. State -> data
        // 2. Behavior -> do work (methods that are verbs usually)
        //which one is the following? (verb)

        // the keyword "void" means this function doesn't return anything.
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {

            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in grades)
            {
               //if (grade > stats.HighestGrade)
               //{
               //    stats.HighestGrade = grade;
               //}
               //
               //if (grade < stats.LowestGrade)
               //{
               //    stats.LowestGrade = grade;
               //}

                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            //grades.Count gives 0 vals. that would be a problem. we'll come back to this.
            stats.AverageGrade = sum / grades.Count;
            return stats;


        }



        // fields are usually not capital. note that private is an access modifier that makes the variable only available to the class.
        //upper case letters are the convention for Access modifiers. default is private
        private List<float> grades;

        //the static keyword can be applied to a method or a field.
        //you can access the static members of a class without creating an instance.
        //Gradebook.MaximumGrade will yield 100 without even an object.  recall Console.Writeline("HELLO"); that is also a static member

        public static float MinimumGrade = 0;
        public static float MaximumGrade = 100;

       // public string Name;

            //default property. (instead of field). Client doesn't care, but we can look at this a  PROPERTY
            //a field Name is created, as are the default getters and setters
            //some frameworks for serialization will only look at properties and not at fields. Some data binding features will follow this convention too.
        //public string Name
        //{
        //    get;
        //    set;
        //}

        //if we want something thats more than just default values though, we have to do the following where we actually state the _name field as part of the class definition.

        public string Name
        {
            get { return _name; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {

                    if (_name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;
                        //passing self can be done with the "this" keyword"
                        NameChanged(this, args);
                    }
                    _name = value;
                }
            }
        }

        //public NameChangedDelegate NameChanged;
        //we comment the above line to show it can be done better with events in the line below.
        public event NameChangedDelegate NameChanged;
        private string _name;
    }
}
