using ComicBookGallery.Models;
using ComicBookGallery.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookGallery.Controllers
{
  public class ComicBooksController : Controller
  {
    private ComicBookRespository _comicBookrepository = null;

    public ComicBooksController()
    {
      _comicBookrepository = new ComicBookRespository();
    }

    public ActionResult Index()
    {
      var comicBooks = _comicBookrepository.GetComicBooks();
      return View(comicBooks);
    }

    public ActionResult Detail(int? id)  // the ? allows the int type to be nullable
    {
      if (id == null)
      {
        return HttpNotFound();
      }
      var comicBook = _comicBookrepository.GetComicBook((int)id);  //or id.Value

      return View(comicBook);
    }
  }
}