using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astontech.Common
{
    public static class StateHelper
    {
        public static Dictionary<string, string> States
        {
            get
            {
                Dictionary<string, string> states = new Dictionary<string, string>();

                states.Add("AL", "Alabama");
                states.Add("AK", "Arkansas");
                states.Add("KS", "Kansas");
                states.Add("MD", "Maryland");
                states.Add("MN", "Minnesota");
                states.Add("CO", "Colorado");
                states.Add("CA", "California");

                return states;
            }
        }

        public static string GetStateName(string stateAbbreviation)
        {
            if (States.ContainsKey(stateAbbreviation))
                return States[stateAbbreviation];
            else
            {
                return "Not Valid Abbreviation";
            }
        }
    }
}
