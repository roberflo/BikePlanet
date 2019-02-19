namespace GFShop.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
       public ConnectionStrings ConnectionStrings { get; set; }
}

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
