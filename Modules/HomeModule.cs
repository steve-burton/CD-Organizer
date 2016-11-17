using Nancy;
using System.Collections.Generic;
using CDOrganizer.Objects

namespace CDOrganizer
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        List<CD> allCDs = CD.GetAll();
        return View["index.cshtml", allCDs];
      };
    }
  }
}
