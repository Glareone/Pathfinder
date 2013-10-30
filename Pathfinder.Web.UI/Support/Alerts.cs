namespace Pathfinder.Web.UI.Support
{
    public static class Alerts
    {
        public static string ATTENTION = "warning";

        public static string SUCCESS = "success";

        public static string INFORMATION = "info";

        public static string ERROR = "danger";

        public static string[] ALL
        {
            get
            {
                return new[]
                    {
                        ATTENTION,
                        SUCCESS,
                        INFORMATION,
                        ERROR
                    };
            }
        }
    }
}