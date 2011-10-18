﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Contexts.Models;
using AutoEscola.Models;
using AutoEscola.Models.Repositorios;

namespace AutoEscola.Repository
{
    public class RepositorioOcorrencia : IRepositorioOcorrencia
    {
        private AutoEscolaContext _context;

        public RepositorioOcorrencia(AutoEscolaContext context)
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