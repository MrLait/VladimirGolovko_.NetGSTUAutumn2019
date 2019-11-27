namespace ConsoleApp1
{
    public class DataForTheHistogram
    {
        public string NumberOfParameters { get; }
        public double ElapsedMsForEuclidGCD { get; }
        public double ElapsedMsForBinaryGCD { get; }

        public DataForTheHistogram() { }

        public DataForTheHistogram(string numberOfParameters, double elapsedMsForEuclidGCD, double elapsedMsForBinaryGCD)
        {
            NumberOfParameters = numberOfParameters;
            ElapsedMsForEuclidGCD = elapsedMsForEuclidGCD;
            ElapsedMsForBinaryGCD = elapsedMsForBinaryGCD;
        }
    }
}