namespace App.Scripts.Core.Utils
{
    public static class Finder
    {
        private class Logger : ILogDistributor
        {
            public string DistributorName => nameof(Finder);
        }

        private static Logger _logger = new ();
        
    }
}