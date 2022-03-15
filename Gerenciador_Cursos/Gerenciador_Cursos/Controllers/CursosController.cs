using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gerenciador_Cursos.Data;
using Gerenciador_Cursos.Models;
using Gerenciador_Cursos.Repository;
using Microsoft.AspNetCore.Authorization;
using Gerenciador_Cursos.ValueObjects;

namespace Gerenciador_Cursos.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ProjetoContext _context;
        private readonly IRepository CursoRepository;

        public CursosController(ProjetoContext context, IRepository repository)
        {
            _context = context;
            CursoRepository = repository;
        }

        // GET: api/Cursos
        
        [HttpGet]
        public ActionResult GetCursos()
        {
            var retorno = CursoRepository.ObterTodosOsCursos();
            return Ok(retorno);
        }

        [HttpGet("Status")]
        public IActionResult GetCursosModel(StatusCurso Status)
        {
            var curso = CursoRepository.ObterCursosPorStatus(Status);

            return Ok(curso);
        }                    
    }
}
