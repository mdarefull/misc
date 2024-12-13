using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I will calculate the amount of words a chapter should contains\nto be confortable to read with TSR\n");

            Console.Write("Enter first try ppm: ");
            int firstTryPpm = int.Parse(Console.ReadLine());

            Console.Write("Enter second try ppm: ");
            int secondTryPpm = int.Parse(Console.ReadLine());

            Console.Write("Enter third try ppm: ");
            int thirdTryPpm = int.Parse(Console.ReadLine());

            Console.WriteLine();
            int wordsCant = CalculateWordsCount(firstTryPpm, secondTryPpm, thirdTryPpm);
            Console.WriteLine("Prefered amount of words: {0}", wordsCant);

            double minutesFirstTry = CalculateMinutes(wordsCant, firstTryPpm);
            Console.WriteLine("Time for first try: {0,2} minutes", minutesFirstTry);

            double minutesSecondTry = CalculateMinutes(wordsCant, secondTryPpm);
            Console.WriteLine("Time for second try: {0} minutes", minutesSecondTry);

            double minutesThirdTry = CalculateMinutes(wordsCant, thirdTryPpm);
            Console.WriteLine("Time for third try: {0} minutes", minutesThirdTry);

            Console.WriteLine();
            Console.WriteLine("Pres enter to exit");
            Console.ReadLine();
        }


        private static int CalculateWordsCount(int firstTryPpm, int secondTryPpm, int thirdTryPpm)
        {
            double numerator = 10 * firstTryPpm * secondTryPpm * thirdTryPpm;
            double denominator = firstTryPpm * secondTryPpm + secondTryPpm * thirdTryPpm + firstTryPpm * thirdTryPpm;
            double division = numerator / denominator;

            int upperInteger = (int) Math.Ceiling(division);
            return upperInteger;
        }

        private static double CalculateMinutes(int wordsCant, int tryPpm)
        {
            double result = (double) wordsCant / tryPpm;

            return result;
        }
    }
}
