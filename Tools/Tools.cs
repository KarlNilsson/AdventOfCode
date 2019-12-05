using System;

public static class Tools 
{
    public static string RootPath = @"C:\Users\Karl\source\repos\AdventOfCode";
    public static string GetFileContents(string day)
    {
        return System.IO.File.ReadAllText($"resources/{day}/{day}.txt");
    }
}
