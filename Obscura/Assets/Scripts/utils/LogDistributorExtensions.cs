using UnityEngine;

public static class LogDistributorExtensions
{
    private static string GetStandardMessage(ILogDistributor distributor, string message)
    {
        return $"[{distributor.DistributorName}] - {message}.";
    }

    private static string GetTimeMessage(ILogDistributor distributor, string message)
    {
        return $"[{Time.unscaledTime}] - {GetStandardMessage(distributor, message)}.)";
    }
    
    public static void Log(this ILogDistributor distributor, string message)
    {
        Debug.Log(GetStandardMessage(distributor, message));
    }

    public static void LogError(this ILogDistributor distributor, string message)
    {
        Debug.LogError(GetStandardMessage(distributor, message));
    }

    public static void LogTime(this ILogDistributor distributor, string message)
    {
        Debug.Log(GetTimeMessage(distributor, message));
    }
}