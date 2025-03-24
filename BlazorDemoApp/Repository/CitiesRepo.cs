namespace BlazorDemoApp.Repository
{
    public static class CitiesRepo
    {
        private static List<string> cities = new List<string>()
        {
            "Madison",
            "Huntsville",
            "Gadsden",
            "WallaceSelma",
            "Calhoun",
            "Bishop"
        };

        public static List<string> GetCities () => cities;

    }
}
