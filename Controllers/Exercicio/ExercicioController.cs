using Microsoft.AspNetCore.Mvc;

public class ExercicioController : Controller {

    IExercicioRepository exercicioRepository;

    public ExercicioController(IExercicioRepository exercicioRepository){
        this.exercicioRepository = exercicioRepository;
    }

    public ActionResult Index()
    {
        return View(exercicioRepository.Read());
    }

    [HttpGet]
     public ActionResult Create() {
        
        // /View/Exercicio/Create.cshtml
        return View();
    }

    [HttpPost]
     public ActionResult Create(Exercicio exercicio) {
         
        exercicioRepository.Create(exercicio);
        return RedirectToAction("Index", "Exercicio");
    }

    public ActionResult Details(int id) {

        Exercicio e = exercicioRepository.Read(id);
        if (e != null)
            return View(e);
        return NotFound();
    }
    public ActionResult Delete(int id) {      
        
        exercicioRepository.Delete(id);
        return RedirectToAction("Index");
    }

    public ActionResult Update(int id) {
        Exercicio e = exercicioRepository.Read(id);
            if(e != null)
                return View(e);
            return NotFound();
    }


    [HttpPost]
    public ActionResult Update(int id, Exercicio model)
    {
    Exercicio exercicioExistente = exercicioRepository.Read(id);
    
        if (exercicioExistente != null)
        {
            exercicioExistente.Dia = model.Dia;
            exercicioExistente.Musculo = model.Musculo;
            exercicioExistente.Nome = model.Nome;
            exercicioExistente.Repeticao = model.Repeticao;
            
            
            exercicioRepository.Update(id, exercicioExistente);
            List<Exercicio> exerciciosAtualizados = exercicioRepository.Read();
            
            return RedirectToAction("Index", exerciciosAtualizados);
        }   
    
        return NotFound();
    }


    [HttpPost]
    public ActionResult Search(IFormCollection form)
    {
        var exercicioRepository = new ExercicioRepository();
        string searchKeyword = form["searchKeyword"].ToString();
        return View("Index", exercicioRepository.Search(searchKeyword));
    }

}
