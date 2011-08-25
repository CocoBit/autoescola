using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Contexts.Models;
using AutoEscola.Models;

namespace AutoEscola.Repository
{
    public class OcorrenciaRepository : IOcorrenciaRepositoy
    {
        private AutoEscolaContext _context;

        public OcorrenciaRepository(AutoEscolaContext context)
        {
            _context = context;
        }

        public List<Ocorrencia> SelecionarOcorrenciaPorIdAluno(int id)
        {
            List<Ocorrencia> collectionOcorrencia = _context.Ocorrencias.Where(o => o.Aluno.Id == id).ToList();

            return collectionOcorrencia.Count() == 0 ? null : collectionOcorrencia;
        }
    }
}
