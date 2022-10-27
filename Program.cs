//============================================================================
// Program to integrate diffeqs for mass spring system (class)
//============================================================================

using System;
using Sim;

class Program
{
    static void Main()
    {
        MS mass = new MS();
        mass.Mass1 = 4;
        mass.Mass2 = 7;
        mass.Constant1 = 10;
        mass.Constant2 = 20;
 
        double t = 0.0f;     // Start Time
        double dt = 0.02;   // Time Step 
        double tEnd = 5.0;  // End Time 

        // simulation loop
        Console.WriteLine(mass.StateString(t));
        while(t < tEnd - dt*0.5)
        {
           mass.StepEuler1(t,dt);
           t += dt;
            Console.WriteLine(mass.StateString(t));

        }
        
        Console.WriteLine(mass.StateString(t));
        while(t < tEnd - dt*0.5)
        {
            mass.StepEuler2(t,dt);
            t += dt;
            Console.WriteLine(mass.StateString(t));
        }
    }
}
