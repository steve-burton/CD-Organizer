namespace CDOrganizer
{
  public class CD
  {
    private static List<CD> _allCDs = new List<CD> {};
    private int _id;
    private string _artist;
    private string _albumTitle;
  }

  private static List<CD> GetAll()
  {
    return _allCDs;
  }
}
