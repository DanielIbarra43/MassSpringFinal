//============================================================================
// MSV2: Class for simulating mass spring with inheritance
//============================================================================

using System;

namespace Sim
{
    public class MSV2 : Simulator
    {
        protected double m1; // Mass 1
        protected double m2; // Mass 2
        protected double k1; // Spring constant 1
        protected double k2; // Spring constant 2 

        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        public Simulator()
        {
           Console.WriteLine("MSV2 Constructor"); 
        }

    }
}