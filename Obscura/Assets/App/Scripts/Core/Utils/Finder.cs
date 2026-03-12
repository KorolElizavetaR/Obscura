namespace App.Scripts.Core.Utils
{
    public static class Finder
    {
        private class Logger : ILogDistributor
        {
            public string DistributorName => nameof(Finder);
        }

        private static readonly Logger _logger = new ();
        
    }
}