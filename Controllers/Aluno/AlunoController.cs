using Microsoft.AspNetCore.Mvc;

public class AlunoController : Controller {

    IAlunoRepository alunoRepository;
    IExercicioRepository exercicioRepository;

    public AlunoController(IAlunoRepository alunoRepository, IExercicioRepository ExercicioRepository){
        this.alunoRepository = alunoRepository;
        this.exercicioRepository = exercicioRepository;
    }

    public ActionResult CreateExercicio(int id)
    {
        Aluno aluno = alunoRepository.Read(id);
        if (aluno != null)
        {
            ViewBag.AlunoId = id;
            return RedirectToAction("Create2", "Exercicio", new { alunoId = id });
        }
        return RedirectToAction("Index");
    }

    public ActionResult Index()
    {
        return View(alunoRepository.Read());
    }

    [HttpGet]
     public ActionResult Create() {
        
        // /View/Aluno/Create.cshtml
        return View();
    }

    [HttpPost]
     public ActionResult Create(Aluno aluno) {
         
        alunoRepository.Create(aluno);
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id) {

        Aluno a = alunoRepository.Read(id);
        a.exercicios = alunoRepository.ReadExercicios(id);
        
        if (a != null)
            return View(a);
        return RedirectToAction("Index");
    }
    public ActionResult Delete(int id) {      
        
        alunoRepository.Delete(id);
        return RedirectToAction("Index");
    }

    public ActionResult Update(int id) {
        Aluno a = alunoRepository.Read(id);
            if(a != null)
                return View(a);
            return NotFound();
    }


    [HttpPost]
      public ActionResult Update(int id, Aluno model)
{
    alunoRepository.Update(id, model);
    return RedirectToAction("Index");
}

    [HttpPost]
    public ActionResult Search(IFormCollection form)
    {
        var alunoRepository = new AlunoRepository();
        string searchKeyword = form["searchKeyword"].ToString();
        return View("Index", alunoRepository.Search(searchKeyword));
    }

}
