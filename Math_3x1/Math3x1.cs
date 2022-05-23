/*
public static void Fast(double min, double max, int lowI = 10, int highI = 100, bool showLminMax = true, bool showHminMax = true, bool showLowI = false, bool showHighI = false, bool showTime = true)
    {
        DateTime init = DateTime.Now;
        List<double> highValues = new();
        List<double> lowValues = new();
        List<int> highIteraction = new();
        List<int> lowIteraction = new();
        if (min > max)
        {
            double temp = min;
            min = max;
            max = temp;
        }

        for (double k = min; k < max; k++)
        {
            double value = k;
            int iteraction = 0;
            while (value != 1)
            {
                if (value >= double.MaxValue / 3) { Console.WriteLine("Max Value Reashed -- Calculation Stopped"); return; }

                iteraction++;

                if (value % 2 != 0) { value = (3 * value) + 1; }
                else { value /= 2; }
            }
            // Insert values to Lists
            if (iteraction >= highI)
            {
                highValues.Add(k);
                highIteraction.Add(iteraction);
            }
            if (iteraction <= lowI)
            {
                lowValues.Add(k);
                lowIteraction.Add(iteraction);
            }
        }

        TimeSpan operationTime = DateTime.Now - init;

        if (showHighI)
        {
            Program.ConsLine("HighValues", true, "", "green");
            for (int k = 0; k < highValues.Count; k++) { Console.WriteLine("V.{0, -20} I.{1, -10}", highValues[k], highIteraction[k]); }
        }
        if (showLowI)
        {
            Program.ConsLine("\nLowValues", true, "", "blue");
            for (int k = 0; k < lowValues.Count; k++) { Console.WriteLine("V.{0, -20} I.{1, -10}", lowValues[k], lowIteraction[k]); }
        }
        if (showHminMax)
        {
            if (highValues.Count == 0) { Console.WriteLine("No Values with the number of iteration superior to " + highI); }
            else
            {
                int vmax = 0, vmin = int.MaxValue, kmax = 0, kmin = 0;
                for (int k = 0; k < highValues.Count; k++)
                {
                    if (highIteraction[k] < vmin) { vmin = highIteraction[k]; kmin = k; }
                    if (highIteraction[k] > vmax) { vmax = highIteraction[k]; kmax = k; }
                }
                Console.WriteLine("Max Iteration: " + highIteraction[kmax] + " V. " + highValues[kmax]);
                Console.WriteLine("Min Iteration: " + highIteraction[kmin] + " V. " + highValues[kmin]);
            }
        }
        if (showLminMax)
        {
            if (lowValues.Count == 0) { Console.WriteLine("No Values with the number of iteration inferior to " + lowI); }
            else
            {
                int vmax = 0, vmin = int.MaxValue, kmax = 0, kmin = 0;
                for (int k = 0; k < lowValues.Count; k++)
                {
                    if (lowIteraction[k] < vmin) { vmin = lowIteraction[k]; kmin = k; }
                    if (lowIteraction[k] > vmax) { vmax = lowIteraction[k]; kmax = k; }
                }
                Console.WriteLine("Max Iteration: " + lowIteraction[kmax] + " V. " + lowValues[kmax]);
                Console.WriteLine("Min Iteration: " + lowIteraction[kmin] + " V. " + lowValues[kmin]);
            }
        }
        if (showTime)
        {
            Program.ConsLine("\nTempo Operação: " + operationTime + "  - Tempo Real Total: " + (DateTime.Now - init), true, "magenta", "white");
        }

    }

    public static void Show(double min, double max, int lowI = 10, int highI = 100, bool showLminMax = true, bool showHminMax = true, bool showLowI = false, bool showHighI = false, bool showTime = true, bool showDetails = true)
    {
        DateTime init = DateTime.Now;
        List<double> highValues = new();
        List<double> lowValues = new();
        List<int> highIteraction = new();
        List<int> lowIteraction = new();
        if (min > max)
        {
            double temp = min;
            min = max;
            max = temp;
        }

        for (double k = min; k < max; k++)
        {
            double value = k;
            int iteraction = 0;
            Console.WriteLine("\nInitial Value: " + value);
            while (value != 1)
            {
                if (value >= double.MaxValue / 3) { Console.WriteLine("Max Value Reashed -- Calculation Stopped"); return; }

                iteraction++;

                if (value % 2 != 0) { value = (3 * value) + 1; }
                else { value /= 2; }

                if (showDetails)
                {
                    if (k % 2 == 0) { Program.ConsLine(string.Format("I.{0,10} - V.{1,10}", iteraction, value), true, "gray"); }
                    else { Program.ConsLine(string.Format("I.{0,10} - V.{1,10}", iteraction, value), true); }
                }
            }
            if (iteraction >= highI)
            {
                highValues.Add(k);
                highIteraction.Add(iteraction);
            }
            if (iteraction <= lowI)
            {
                lowValues.Add(k);
                lowIteraction.Add(iteraction);
            }
        }

        TimeSpan operationTime = DateTime.Now - init;

        if (showHighI)
        {
            Program.ConsLine("HighValues", true, "", "green");
            for (int k = 0; k < highValues.Count; k++) { Console.WriteLine("V.{0, -20} I.{1, -10}", highValues[k], highIteraction[k]); }
        }
        if (showLowI)
        {
            Program.ConsLine("\nLowValues", true, "", "blue");
            for (int k = 0; k < lowValues.Count; k++) { Console.WriteLine("V.{0, -20} I.{1, -10}", lowValues[k], lowIteraction[k]); }
        }
        if (showHminMax)
        {
            if (highValues.Count == 0) { Console.WriteLine("No Values with the number of iteration superior to " + highI); }
            else
            {
                int vmax = 0, vmin = int.MaxValue, kmax = 0, kmin = 0;
                for (int k = 0; k < highValues.Count; k++)
                {
                    if (highIteraction[k] < vmin) { vmin = highIteraction[k]; kmin = k; }
                    if (highIteraction[k] > vmax) { vmax = highIteraction[k]; kmax = k; }
                }
                Console.WriteLine("Max Iteration: " + highIteraction[kmax] + " V. " + highValues[kmax]);
                Console.WriteLine("Min Iteration: " + highIteraction[kmin] + " V. " + highValues[kmin]);
            }
        }
        if (showLminMax)
        {
            if (lowValues.Count == 0) { Console.WriteLine("No Values with the number of iteration inferior to " + lowI); }
            else
            {
                int vmax = 0, vmin = int.MaxValue, kmax = 0, kmin = 0;
                for (int k = 0; k < lowValues.Count; k++)
                {
                    if (lowIteraction[k] < vmin) { vmin = lowIteraction[k]; kmin = k; }
                    if (lowIteraction[k] > vmax) { vmax = lowIteraction[k]; kmax = k; }
                }
                Console.WriteLine("Max Iteration: " + lowIteraction[kmax] + " V. " + lowValues[kmax]);
                Console.WriteLine("Min Iteration: " + lowIteraction[kmin] + " V. " + lowValues[kmin]);
            }
        }
        if (showTime)
        {
            Program.ConsLine("\nTempo Operação: " + operationTime + "  - Tempo Real Total: " + (DateTime.Now - init), true, "magenta", "white");
        }
    }



*/


class Math3x1
{
    static void SpeedTest()
    {
        Console.WriteLine("Starting the speedtest, can take a long time");
        ulong v = ulong.MinValue;
        DateTime start = DateTime.Now;
        while (v < 10000000000) { v++; }
        DateTime end = DateTime.Now;
        Console.Write("End in: ");
        Console.WriteLine(end - start);
    }


    static void FastCheck() 
    { 
    
    }













    static void Main()
    {
        //SpeedTest();
        Math_3x1.SQL.CreateDBFileSQLite();
    }
}