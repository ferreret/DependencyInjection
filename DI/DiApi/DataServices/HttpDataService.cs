namespace DiApi.DataServices
{
    public class HttpDataService : IDataService
    {
        public string GetProductData(string url)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--> Getting Product Data...");
            Console.ResetColor();

            return "Some PRODUCT data...";
            
        }
    }
}