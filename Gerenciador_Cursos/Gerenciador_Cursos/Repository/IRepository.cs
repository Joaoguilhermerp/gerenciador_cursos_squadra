using Gerenciador_Cursos.Models;
using Gerenciador_Cursos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_Cursos.Repository
{
    public interface IRepository
    {
        IEnumerable<Curso> ObterTodosOsCursos();

        IEnumerable <Curso> ObterCursosPorStatus(StatusCurso Status);
    }
}
