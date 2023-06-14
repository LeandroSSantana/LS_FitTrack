using Microsoft.AspNetCore.Mvc;

public class TreinoController : Controller {

    ITreinoRepository treinoRepository;
    
    
    public TreinoController(ITreinoRepository treinoRepository){
        this.treinoRepository = treinoRepository;
              
    }
    
    public ActionResult Index()
    {
        return View(treinoRepository.Read());
    }
   
    [HttpGet]
     public ActionResult CreateTreino(int alunoId, string nomeAluno) {

        ViewBag.AlunoId = alunoId;
        ViewBag.NomeAluno = nomeAluno;
        Treino treino = new Treino();
        treino.exercicios = treinoRepository.ReadExercicios();
          
        // /View/Treino/Create.cshtml
        return View(treino);
    }

    [HttpPost]
     public ActionResult Create(Treino treino) {
         
        treinoRepository.Create(treino);
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Treino treino = treinoRepository.Read(id);
        if (treino != null)
            return View(treino);
        return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id) {      
        
        treinoRepository.Delete(id);
        return RedirectToAction("Index");
    }

    public ActionResult Update(int id) {
        Treino t = treinoRepository.Read(id);
            if(t != null)
                return View(t);
            return NotFound();
    }


        [HttpPost]
    public ActionResult Update(int id, Treino model)
    {
        treinoRepository.Update(id, model);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Search(IFormCollection form)
    {
        var treinoRepository = new TreinoRepository();
        string searchKeyword = form["searchKeyword"].ToString();
        return View("Index", treinoRepository.Search(searchKeyword));
    }
}