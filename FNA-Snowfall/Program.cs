namespace FNA_Snowfall
{
    internal static class Program
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
