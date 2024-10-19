namespace FNA_Snowfall
{
    static internal class Program
    {
        private static void Main(string[] args)
        {
            using (var snowfall = new Snowfall())
            {
                snowfall.Run();
            }
        }
    }
}
