using DiApi.DataServices;

namespace DiApi.Data
{
    public class NoSqlDataRepo : IDataRepo
    {
        private readonly IServiceScopeFactory _scopeFactory;

        // private readonly IDataService _dataService;

        public NoSqlDataRepo(IServiceScopeFactory scopeFactory)
        {
            // _dataService = dataService;
            _scopeFactory = scopeFactory;
        }

        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--> Getting data from No SQL Database...");

            using (var scope = _scopeFactory.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetRequiredService<IDataService>();
                dataService.GetProductData("https://something.com/api");
                Console.ResetColor();

                return ("No SQL Data from DB");
            }

            // _dataService.GetProductData("https://something.com/api");

        }
    }
}