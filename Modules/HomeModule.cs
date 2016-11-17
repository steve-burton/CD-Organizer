using Nancy;
using System.Collections.Generic;
using CDOrganizer.Objects;
using System;

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
      Post["/"] = _ =>
      {
        string artist = Request.Form["artist-name"];
        string albumTitle = Request.Form["album-title"];
        if (artist != "" & albumTitle != "")
        {
          CD newCD = new CD(artist, albumTitle);
          List<CD> allCDs = CD.GetAll();
          return View["index.cshtml", allCDs];
        }
        else
        {
          return View["new_cd_form.cshtml"];
        }
      };
      Get["/CD/new"] = _ =>
      {
        return View["new_cd_form.cshtml"];
      };
      Get["/CD/{id}"] = parameters =>
      {
        return View["album.cshtml", CD.Find(int.Parse(parameters.id))];
      };
      Get["/CD/search"] = _ =>
      {
        return View["search_by_artist.cshtml"];
      };
      Post["/CD/search_results"] = _ =>
      {
        string searchArtistName = Request.Form["artist-name"];
        List<Artist> matchingArtists = Artist.GetMatchingArtists(searchArtistName);
        return View["search_results.cshtml", matchingArtists];
      };
    }
  }
}
