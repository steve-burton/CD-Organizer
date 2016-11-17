using System.Collections.Generic;

namespace CDOrganizer.Objects
{
  public class Artist
  {
    private static List<Artist> _allArtists = new List<Artist> {};
    private string _artistName;
    private int _id;
    private List<CD> _library = new List<CD> {};

    public Artist(string artistName)
    {
      _artistName = artistName;
      _allArtists.Add(this);
      _id = _allArtists.Count;
    }

    public static List<Artist> GetAll()
    {
      return _allArtists;
    }

    public static bool ArtistExists(string artistName)
    {
      bool artistFound = false;
      foreach (Artist artist in _allArtists)
      {
        if (artist.GetName() == artistName)
        {
          artistFound = true;
        }
      }
      return artistFound;
    }

    public static List<Artist> GetMatchingArtists(string artistName)
    {
      List<Artist> MatchingArtists = new List<Artist> {};
      foreach (Artist MatchingArtist in _allArtists)
      {
        if (MatchingArtist.GetName().ToLower().Contains(artistName.ToLower()))
        {
          MatchingArtists.Add(MatchingArtist);
        }
      }
      return MatchingArtists;
    }

    public static int GetFoundArtistID(string artistName)
    {
      int artistID = 0;
      foreach (Artist artist in _allArtists)
      {
        if (artist.GetName() == artistName)
        {
          artistID = artist.GetID();
        }
      }
      return artistID;
    }

    public static Artist Find(int searchID)
    {
      return _allArtists[searchID-1];
    }

    public List<CD> GetLibrary()
    {
      return _library;
    }

    public string GetName()
    {
      return _artistName;
    }

    public int GetID()
    {
      return _id;
    }

    public bool IsInLibrary(string albumName)
    {
      bool albumFound = false;
      foreach (CD cd in _library)
      {
        if (cd.GetAlbumTitle() == albumName)
        {
          albumFound = true;
        }
      }
      return albumFound;
    }

    public void AddToLibrary(CD cd)
    {
      _library.Add(cd);
    }
  }
}
