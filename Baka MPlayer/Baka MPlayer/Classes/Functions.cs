﻿/*****************************
* Functions (by Joshua Park) *
* updated 1/17/2012          *
*****************************/
using System;
using System.Runtime.InteropServices;

public static class Functions
{
    [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
    static extern long PathIsURL(string pszPath);

    public static bool ValidateURL(string url)
    {
        return PathIsURL(url).Equals(1);
    }

    public static bool RunningOnWin7
    {
        get
        {
            return (Environment.OSVersion.Version.Major > 6) ||
                (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 1);
        }
    }

    public static string GetFileSize(string FilePath, int RoundTo)
    {
        try
        {
            var FileProperties = new System.IO.FileInfo(FilePath);
            if (FileProperties.Length < 1024) {
                // Bytes
                return (FileProperties.Length + " B");
            } if (FileProperties.Length >= 1024 && FileProperties.Length < 1048576) {
                // Kilobytes
                return Math.Round(Convert.ToDecimal(FileProperties.Length) / 1024, RoundTo) + "kB";
            } if (FileProperties.Length >= 1048576 && FileProperties.Length < 1073741824) {
                // Megabytes
                return Math.Round(Convert.ToDecimal(FileProperties.Length) / 1048576, RoundTo) + " MB";
            } if (FileProperties.Length >= 1073741824 && FileProperties.Length < 1099511627776L) {
                // Gigabytes
                return Math.Round(Convert.ToDecimal(FileProperties.Length) / 1073741824, RoundTo) + " GB";
            } if (FileProperties.Length >= 1099511627776L && FileProperties.Length < 1099511627776L) {
                // Terabytes
                return Math.Round(Convert.ToDecimal(FileProperties.Length) / 1099511627776L, RoundTo) + " TB";
            }
            return "Not Available";
        }
        catch (Exception ex)
        {
            return ("Error: " + ex.Message);
        }
    }

    public static string GetFolderName(string fileLocation)
    {
        try
        {
            var objInfo = new System.IO.FileInfo(fileLocation);
            return objInfo.Directory.Name;
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }

    public static string DecodeURL(string input)
    {
        return System.Web.HttpUtility.UrlDecode(input);
    }

    public static string RemoveZero(string toUse)
    {
        if (!toUse.StartsWith("00"))
        {
            while (toUse.StartsWith("0"))
                toUse = toUse.Remove(0, 1);
            while (toUse.StartsWith(":"))
                toUse = toUse.Remove(0, 1);
        }
        else
        {
            toUse = toUse.Remove(0, 1);
        }
        return toUse;
    }

    public static string AutoEllipsis(int max, string toUse)
    {
        if (max < toUse.Length)
            return toUse.Remove(max, toUse.Length - max) + "...";
        return toUse;
    }

    public static void CalculateTimeFromSeconds(int time, out int hour, out int min, out int sec)
    {
        hour = time / 3600;
        min = (time % 3600) / 60;
        sec = (time % 3600) % 60;
    }

    public static string ConvertTime(int totalSec)
    {
        int hour, min, sec;
        CalculateTimeFromSeconds(totalSec, out hour, out min, out sec);

        if (hour > 0)
            return hour.ToString("#0") + ":" + min.ToString("00") + ":" + sec.ToString("00");
        return min.ToString("#0") + ":" + sec.ToString("00");
    }

    public static int GetGCD(int x, int y)
    {
        while (x != y)
        {
            if (x > y)
                x = x - y;
            else
                y = y - x;
        }
        return x;
    }
}