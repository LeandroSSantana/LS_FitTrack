using Microsoft.AspNetCore.Mvc;

public class TreinoExercicioController : Controller
{

    ITreinoExercicioRepository TreinoExercicioRepository;

    public TreinoExercicioController(ITreinoExercicioRepository TreinoExercicioRepository)
    {
        this.TreinoExercicioRepository = TreinoExercicioRepository;
    }

    public ActionResult CreateTreino(int id)
    {
        TreinoExercicio TreinoExercicio = TreinoExercicioRepository.Read(id);
        if (TreinoExercicio != null)
        {
            ViewBag.TreinoExercicioId = id;
            return RedirectToAction("CreateTreino", "TreinoExercicioTreino", new { TreinoExercicioId = id });
        }
        return RedirectToAction("Index");
    }

    public ActionResult Index()
    {
        return View(TreinoExercicioRepository.Read());
    }

    [HttpGet(Name = "CreateTreinoExercicio")]
    public ActionResult Create()
    {

        // /View/TreinoExercicio/Create.cshtml
        return View();
    }

    [HttpPost(Name = "CreateTreinoExercicio")]
    public ActionResult Create(TreinoExercicio TreinoExercicio)
    {

        TreinoExercicioRepository.Create(TreinoExercicio);
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {

        TreinoExercicio a = TreinoExercicioRepository.Read(id);

        if (a != null)
            return View(a);
        return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {

        TreinoExercicioRepository.Delete(id);
        return RedirectToAction("Index");
    }

    public ActionResult Update(int id)
    {
        TreinoExercicio a = TreinoExercicioRepository.Read(id);
        if (a != null)
            return View(a);
        return NotFound();
    }

    [HttpPost]
    public ActionResult Update(int id, TreinoExercicio model)
    {
        TreinoExercicioRepository.Update(id, model);
        return RedirectToAction("Index");
    }
}
