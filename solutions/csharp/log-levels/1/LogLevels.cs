using System.Diagnostics;
using System.Text.RegularExpressions;

static class LogLine
{
    public static string Message(string logLine)
    {
        Match match = Regex.Match(logLine, @"\[(\w+)\]\: (.+)");

        // String level = match.Groups[1].Value.ToLower();
        String message = match.Groups[2].Value.Trim();

        return message;
    }

    public static string LogLevel(string logLine)
    {
        Match match = Regex.Match(logLine, @"\[(\w+)\]\: (.+)");

        String level = match.Groups[1].Value.ToLower();
        // String message = match.Groups[2].Value.Trim();

        return level;
    }

    public static string Reformat(string logLine)
    {
        Match match = Regex.Match(logLine, @"\[(\w+)\]\: (.+)");

        String level = match.Groups[1].Value.ToLower();
        String message = match.Groups[2].Value.Trim();

        return $"{message} ({level})";
    }
}
