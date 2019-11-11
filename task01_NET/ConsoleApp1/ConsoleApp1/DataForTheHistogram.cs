namespace ConsoleApp1
{
    public class DataForTheHistogram
    {
        private string numberOfParameters;
        private long elapsedMsForEuclidGCD;
        private long elapsedMsForBinaryGCD;

        public DataForTheHistogram() { }
        public DataForTheHistogram(string numberOfParameters, long elapsedMsForEuclidGCD, long elapsedMsForBinaryGCD)
        {
            this.numberOfParameters = numberOfParameters;
            this.elapsedMsForEuclidGCD = elapsedMsForEuclidGCD;
            this.elapsedMsForBinaryGCD = elapsedMsForBinaryGCD;
        }

        public string NumberOfParameters { get => numberOfParameters; set => numberOfParameters = value; }
        public long ElapsedMsForEuclidGCD { get => elapsedMsForEuclidGCD; set => elapsedMsForEuclidGCD = value; }
        public long ElapsedMsForBinaryGCD { get => elapsedMsForBinaryGCD; set => elapsedMsForBinaryGCD = value; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is DataForTheHistogram o))
                return false;

            return ((o.elapsedMsForBinaryGCD == elapsedMsForBinaryGCD) &&
                (o.elapsedMsForEuclidGCD == elapsedMsForEuclidGCD) &&
                (o.numberOfParameters == numberOfParameters));
        }
        public override int GetHashCode()
        {
            return (numberOfParameters.GetHashCode() + elapsedMsForEuclidGCD.GetHashCode()
                + elapsedMsForBinaryGCD.GetHashCode());
        }
    }
}