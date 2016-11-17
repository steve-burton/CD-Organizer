using System.Collections.Generic;

namespace CDOrganizer.Objects
{
  public class CD
  {
    private static List<CD> _allCDs = new List<CD> {};
    private int _id;
    private string _artist;
    private string _albumTitle;

    public CD(string artist, string albumTitle)
    {
      _artist = artist;
      _albumTitle = albumTitle;
      _allCDs.Add(this);
      _id = _allCDs.Count;
      if (Artist.ArtistExists(_artist))
      {
        int foundArtistID = Artist.GetFoundArtistID(_artist);
        Artist foundArtist = Artist.Find(foundArtistID);
        if (!(foundArtist.IsInLibrary(_albumTitle)))
        {
          foundArtist.AddToLibrary(this);
        }
      }
      else
      {
        Artist newArtist = new Artist(_artist);
        newArtist.AddToLibrary(this);
      }
    }

    public static List<CD> GetAll()
    {
      return _allCDs;
    }

    public static CD Find(int searchID)
    {
      return _allCDs[searchID-1];
    }

    public int GetID()
    {
      return _id;
    }

    public string GetArtist()
    {
      return _artist;
    }

    public string GetAlbumTitle()
    {
      return _albumTitle;
    }
  }
}
