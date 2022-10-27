//============================================================================
// MS.cs class to model mass spring system
//============================================================================
using System;

namespace Sim
{
    public class MS
    {
        private double m1; // Mass 1
        private double m2; // Mass 2
        private double k1; // Spring constant 1
        private double k2; // Spring constant 2

        private double[] x1;    // array of states m1
        private double[] x1i;    // array of intermediate states
        private double[] x2;    // array of states m2
        private double[] x2i;   // array of intermediate states
        private double[][] f1;    // array that holds values of rhs of m1
        private double[][] f2;    // array that holds values of rhs of m2
        
        private int n;      // number of first order ODEs

        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        public MS()
        {
            // Console.WriteLine("MS object created");
            m1 = 1;
            m2 = 2;
            k1 = 10;
            k2 = 20;

            n = 4;
            x1 = new double[n];
            x1i = new double[n];
            x2 = new double[n];
            x2i = new double[n];
            f1 = new double[2][];
            f2 = new double[2][];
            f1[0] = new double[n];
            f1[1] = new double[n];
            f2[0] = new double[n];
            f2[1] = new double[n];

             // set initial conditions 
            x1[0] = 10;      // initial displacement m1
            x1[1] = 0.0;     // initial velocity m1
            x2[0] = 10;      // initial displacement m2
            x2[1] = 0.0;     // initial velocity m2
        }

        //--------------------------------------------------------------------
        // Step RK2 Executes one intergration step using RK2
        //--------------------------------------------------------------------
        public void StepRK2first(double time, double dtime)
        {
            int i;

            RhsFuncSpringMass1(x1,x2,time,f1[0]);
            for(i=0;i<2;++i)
            {
                x1i[i] = x1[i] + f1[0][i] * dtime;
            }

            RhsFuncSpringMass1(x1i,x2i,time+dtime,f1[1]);
            for(i=0;i<2;++i)
            {
                x1[i] += 0.5*(f1[0][i] + f1[1][i])*dtime;
            }


        }
        public void StepRK2second(double time, double dtime)
        {
            int i;

            RhsFuncSpringMass2(x1,x2,time,f2[0]);
            for(i=0;i<2;++i)
            {
                x2i[i] = x2[i] + f2[0][i] * dtime;
            }

            
            RhsFuncSpringMass2(x1i,x2i,time+dtime,f2[1]);
            for(i=0;i<2;++i)
            {
                x1[i] += 0.5*(f2[0][i] + f2[1][i])*dtime;
            }
        }

        //--------------------------------------------------------------------
        // State string creates a string in CSV format containing the states
        //--------------------------------------------------------------------
        public string StateString(double time)
        {
            string s = time.ToString();

            for (int i = 0;i<n;++i)
            {
                s += ',' + x1[i].ToString();
                s += ',' + x2[i].ToString();
            }
            return s;
        }
        // public void TestFunc()
        // {
        //     Console.WriteLine("TestFunc called");
        //     Console.WriteLine("m1 = " + m1.ToString() + "m2 = " + m2.ToString() 
        //     + "k1 = " + k1.ToString() + "k2 = " + k2.ToString());

        // }

        //------------------------------------------------------------------------
        // RhsFuncSpringMass: Calculates the right side of the DiffEQs
        //------------------------------------------------------------------------
        void RhsFuncSpringMass1(double[] st, double[] st2, double t, double[] ff1)
        {   
        
            ff1[0] = st[1];
            ff1[0] = st2[1];
            ff1[1] = (k1/m2)*st[1]+(k2/m2)*(st2[0]-st[0]);
        }

        void RhsFuncSpringMass2(double[] st, double[] st2, double t, double[] ff2)
        {   
        
            ff2[0] = st[1];
            ff2[0] = st2[1];
            ff2[1] = (-k1/m1)*(st2[0]-st[0]);
        }

        //--------------------------------------------------------------------
        // Define getters and setters
        //--------------------------------------------------------------------
        public double Mass1 
        {
            get{return m1;}

            set
            {
                if(value > 0.0)
                {
                    m1 = value;
                }
            }
        }

        public double Mass2 
        {
            get{return m2;}

            set
            {
                if(value > 0.0)
                {
                    m2 = value;
                }
            }
        }

        public double Constant1 
        {
            get{return k1;}

            set
            {
                if(value > 0.0)
                {
                    k1 = value;
                }
            }
        }

        public double Constant2 
        {
            get{return k2;}

            set
            {
                if(value > 0.0)
                {
                    k2 = value;
                }
            }
        }
    }
}