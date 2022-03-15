using Gerenciador_Cursos.Data;
using Gerenciador_Cursos.Models;
using Gerenciador_Cursos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_Cursos.Repository
{
    public class CursoRepository : IRepository
    {
        private readonly ProjetoContext _context;

        public CursoRepository(ProjetoContext context)
        {
            _context = context;
        }

        public IEnumerable<Curso> ObterTodosOsCursos()
        {

            return _context.Cursos.ToList();
        }
        public IEnumerable<Curso> ObterCursosPorStatus(StatusCurso Status)
        {

            return _context.Cursos.Where((Curso curso) => curso.Status == Status);

        }
        

    }
}
