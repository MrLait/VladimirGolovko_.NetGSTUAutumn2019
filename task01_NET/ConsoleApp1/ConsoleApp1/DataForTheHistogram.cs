namespace ConsoleApp1
{
    public class DataForTheHistogram
    {
        private string numberOfParameters;
        private double elapsedMsForEuclidGCD;
        private double elapsedMsForBinaryGCD;

        public DataForTheHistogram() { }
        public DataForTheHistogram(string numberOfParameters, double elapsedMsForEuclidGCD, double elapsedMsForBinaryGCD)
        {
            this.numberOfParameters = numberOfParameters;
            this.elapsedMsForEuclidGCD = elapsedMsForEuclidGCD;
            this.elapsedMsForBinaryGCD = elapsedMsForBinaryGCD;
        }
    }
}