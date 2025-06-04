using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EventTracker.Data;
using EventTracker.Models;

namespace EventTracker.Controllers;

public class EventsController : Controller
{
    private readonly EventContext _context;

    public EventsController(EventContext context)
    {
        _context = context;
    }

    // GET: Events (Tüm etkinlikleri listele)
    public IActionResult Index()
    {
        var eventList = _context.Events.ToList();
        return View(eventList);
    }

    //GET: Events/Create (Yeni etkinlik formu)
    public IActionResult Create()
    {
        return View();
    }

    //POST: Events/Create (Formdan gönderilen yeni etkinlik verisi kaydetme)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EventModel eventModel)
    {
        if (ModelState.IsValid)
        {
            _context.Events.Add(eventModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        //Eğer model doğrulama hataları varsa formu tekrar gönder.
        return View(eventModel);

    }


    //GET: Events/Edit/5 (Id=5 olan etkinlik için düzenleme formu)
    public IActionResult Edit(int id)
    {
        var eventItem = _context.Events.Find(id);
        if (eventItem == null)
        {
            return NotFound();
        }
        return View(eventItem);
    }


    //POST: Events/Edit/5 (Formdan gelen verilerle Id=5 etkinliğini güncelle)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EventModel eventModel)
    {
        if (id != eventModel.Id)
        {
            return BadRequest();


        }

        if (ModelState.IsValid)
        {
            _context.Events.Update(eventModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Hatalıysa aynı formu mevcut  verilerle tekrar göster
        return View(eventModel);


    }


    // GET: Events/Delete/5 (Id=5 olan etkinliği silme işlemi)
    public IActionResult Delete(int id)
    {
        var eventItem = _context.Events.Find(id);
        if (eventItem != null)
        {
            _context.Events.Remove(eventItem);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}