using System;
using System.Collegctions.Generic;          // (DG) using System.Collegctions.Generic; => using System.Collections.Generic; 
using System.Linq;                          // (DG) Unnecessary reference.

namespace Utility.Valocity.ProfileHelper
{
                                            // (DG) POCO, perhaps Serializable?
    public class People                     // (DG) Suggestion move this class to a new file; (ASSUMPTION - not strictly required / dependant on coding guidlines). Also renamed People => Person.
    {                                       // (DG) Incorrect indendation lines 9 - 16; class members should be tab-indented.
     private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);  // (DG) readonly? 
     public string Name { get; private set; }                                               // (DG) If only set privatly mechanisms should be defined to accomodate this.
     public DateTimeOffset DOB { get; private set; }                                        // (DG) If only set privatly mechanisms should be defined to accomodate this.
     public People(string name) : this(name, Under16.Date) { }                              // (DG) All people 
     public People(string name, DateTime dob) {                                             // (DG) pening bracket should be on the next line.
         Name = name;
         DOB = dob;
     }}                                                                                     // (DG) closing bracket should be on its own line.

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve                  // (DG) Remove <summary> this is not required for a member 
        /// </summary>
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }


        /*  
            [ASSUMPTION REQUIRED / UNCLEAR] - The GetPeople method name does not describe what the mehtod does based on the contained logic.
            If the method name is correct: 
                - The method would have no <params>. 
                - The body of the method would be try-catch wrapped.
                - The logic of the body would fetch ALL existing "People" from some form of persistence (either a cache or a DB).
            ACTUAL ASSUMPTION MADE: The method body is correct and the name needs to be made to match; Reasoning - it provides more to talk about for this exercise! ~ Is this breaking the fourth-wall?
        */

        /// <summary>
        /// GetPeoples                          // (DG) Alter the <summary> tag contents to be a description of the method in plain english; Suggestion: "This method creates new People named Bob or Betty"
        /// </summary>
        /// <param name="i"></param>            // (DG) Include description of what the <param> tagged here should represent.
        /// <returns>List<object></returns>     // (DG) Alter the <returns> tag contents to be a description of the method-return in plain english; suggestion: "A list of Bob's and Betty's."
        public List<People> GetPeople(int i)    // (DG) Input should be named descriptively AND the method name should describe the contained logic. 
        {
            for (int j = 0; j < i; j++)         // (DG) Suggestion: "For"-loop could be replaced "While"; Reasoning - the index is not being utalized for the iterated logic.
            {
                try                             // (DG) The try-catch block needs to encapsulate the entire body for a getter.
                {
                    // Creates a dandon Name    // (DG) Substitue: "dandon" => "random"
                    string name = string.Empty; // (DG) Suggestion: replace string.Empty => "" AND 'name' can be declared oustide of the loop / re-used.
                    var random = new Random();  // (DG) 'random' can be moved outside of the loop / reused.
                    if (random.Next(0, 1) == 0) {       // (DG) random.Next(0,1) can only return 0 as the boundary is non-inclusive; suggestion alter the boundary to 2. 
                        name = "Bob";                   // (DG) 
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen                                       // (DG) Remove this comment; or modify to be more specific.
                    throw new Exception("Something failed in user creation");                   // (DG) Alter error message contents to be more descriptive of the failure; suggestion: "An error occured when creating Bob's and Betty's. Consult logging for more details..."
                }
            }
            return _people;
        }

        /*
            (DG) The GetBobs() method has the following issue:
            - This method is private-scoped but unused.
            - The TimeSpan math fails to account for leap-years.
            - It could be made more extensible if refactored as "GetName", an additional <param> 'Name' could be supplied accepting any name-string and the existing bool <param> could be replaced with int and called 'olderThan'.
        */
        private IEnumerable<People> GetBobs(bool olderThan30)  
        {
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(People p, string lastName)     // (DG) "GetMarried" does not seem like it belongs in the "BirthingUnit" class; this method needs to be relocated to a more applicable class.
        {
            if (lastName.Contains("test"))                      // (DG) [ASSUMPTION] "test" hardcoded string is fragile + suggests that the affiliated case is for a unit-test (i.e. a variant of this code belongs in an associated unit-test or just should not exist)...
                return p.Name;                                  // (DG) [ASSUMPTION] Assuming this is related to a unit-test; the early-returning of a different output invalidates any testing performed on this method.
            if ((p.Name.Length + lastName).Length > 255)        // (DG) Substitute: p.Name.Length => p.Name
            {
                (p.Name + " " + lastName).Substring(0, 255);    // (DG) Missing wrapper? suggestion: return string.Join();
            }

            return p.Name + " " + lastName;                     // (DG) Avoid repetitiion of string-building by declaring "var 'fullName' = p.Name + " " + lastName" at the top of this method; and replacing all duplicate references with 'fullName'
        }
    }
}