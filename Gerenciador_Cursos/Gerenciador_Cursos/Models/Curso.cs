using Gerenciador_Cursos.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_Cursos.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int DuracaoMes { get; set; }
        public StatusCurso Status { get; set; }
       

    }
}
