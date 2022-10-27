//============================================================================
// Simulator.cs defines the base class for creating simulations
//============================================================================

using System;

namespace Sim
{
    public class Simulator
    {
        protected double m1; // Mass 1
        protected double m2; // Mass 2
        protected double k1; // Spring constant 1
        protected double k2; // Spring constant 2    

        protected int n;
        private double[] x1;    // array of states m1
        private double[] x1i;    // array of intermediate states
        private double[] x2;    // array of states m2
        private double[] x2i;   // array of intermediate states
        private double[][] f1;    // 2D array that holds values of rhs of m1
        private double[][] f2;    // 2Darray that holds values of rhs of m2
    }
}