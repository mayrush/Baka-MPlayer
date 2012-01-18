﻿using System.Collections.Generic;

/// <summary>
/// Enum for mplayer's current playStates
/// </summary>
public enum PlayStates
{
    Unidentified = 0,
    Playing = 1,
    Paused = 2,
    Stopped = 3
}

/// <summary>
/// Stores subtitle info
/// </summary>
public class Sub
{
    public string TrackID;
    public string Name;
    public string Lang; // language (jpn, eng, ...)
	
    public Sub() { }
	public Sub(string trackID, string name, string lang)
	{
		this.TrackID = trackID;
		this.Name = name;
		this.Lang = lang;
	}
}

/// <summary>
/// Stores chapter's first frame and name
/// </summary>
public class Chapter
{
	public long StartFrame;
	public string ChapterName;

    public Chapter() { }
	public Chapter(long startFrame, string chapterName)
	{
		this.StartFrame = startFrame;
		this.ChapterName = chapterName;
	}
}

/// <summary>
/// Stores ID info
/// </summary>
public class Info
{
	public string ID;
	public string Value;

    public Info() { }
	public Info(string ID, string value)
	{
		this.ID = ID;
		this.Value = value;
	}
}

/// <summary>
/// Stores audio track info
/// </summary>
public class AudioTrack
{
	public string ID;
	public string Name;
	public string Lang;
	
    public AudioTrack() { }
	public AudioTrack(string ID, string name, string lang)
	{
		this.ID = ID;
		this.Name = name;
		this.Lang = lang;
	}
}

/// <summary>
/// Holds media information on the currently playing file.
/// </summary>
public static class PlayingFile
{
    // FileInfo
    public static string URL { get; set; }
    public static string FileName { get; set; } // w/ extension

    public static class Current
    {
        public static int Duration { get; set; }
        public static int TotalLength { get; set; }
		public static int Volume { get; set; }
        public static PlayStates PlayState = PlayStates.Unidentified;
    }

    public static class MiscInfo
    {
		public static List<Sub> Subs = new List<Sub>();
		public static List<Chapter> Chapters = new List<Chapter>();
        public static List<Info> OtherInfo = new List<Info>();
    }
	
	public static class VideoInfo
	{
		public static bool HasVideo { get; set; }
		public static double AspectRatio { get; set;} // ex. 1.7778
		public static double FPS { get; set; } // ex. 23.976
	}
	
	public static class AudioInfo
	{
		public static List<AudioTrack> AudioTracks = new List<AudioTrack>();
	}

    public static class ID3Tags
    {
        // ID_CLIP_INFO
        public static string Album_Artist { get; set; }
        public static string Encoder { get; set; }
        public static string Artist { get; set; }
        public static string Genre { get; set; }
        public static int Track { get; set; }
        public static int Disc { get; set; }
        public static string Title { get; set; }
        public static string Album { get; set; }
        public static string Date { get; set; }
		public static string Comment { get; set; }
    }

    /// <summary>
    /// Always call before playing next file.
    /// </summary>
    public static void ResetInfo()
    {
		// FileInfo
		// set on MPlayer file information output
		
		// Current
		
		// MiscInfo
		
		// VideoInfo
		
		// AudioInfo
				
		
		// ID3Tags
		ID3Tags.Album_Artist = string.Empty;
		ID3Tags.Encoder = string.Empty;
		ID3Tags.Artist = string.Empty;
		ID3Tags.Genre = string.Empty;
		ID3Tags.Track = 0;
		ID3Tags.Disc = 0;
		ID3Tags.Title = string.Empty;
		ID3Tags.Album = string.Empty;
		ID3Tags.Date = string.Empty;
    }
}
