using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public class Repository : IRepository
    {
        public SmartContext _context;

        public Repository(SmartContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0); // Se retornar maior que 0, retorne TRUE pois salvou.
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            // O IQueryable é para realizar uma Query no banco e retornar os dados solicitados.
            IQueryable<Aluno> query = _context.Alunos;

            // Se quiser a disciplina, inclua um Join na disciplina e no professor.
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                            .ThenInclude(ad => ad.Disciplina)
                            .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray(); // Retornando um Array de Alunos, com base no que foi incluido.
        }

        public Aluno[] GetAllAlunossByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            { // Realizando o Join com outras tabelas.
                query = query.Include(a => a.AlunosDisciplinas)
                            .ThenInclude(ad => ad.Disciplina)
                            .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }


        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            { // Realizando o Join com outras tabelas.
                query = query.Include(a => a.AlunosDisciplinas)
                            .ThenInclude(ad => ad.Disciplina)
                            .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(aluno => aluno.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                            .ThenInclude(pd => pd.AlunosDisciplinas)
                            .ThenInclude(pa => pa.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();

        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                            .ThenInclude(pd => pd.AlunosDisciplinas)
                            .ThenInclude(pa => pa.Aluno);
            }

            query = query.AsNoTracking()
                        .OrderBy(aluno => aluno.Id)
                        .Where(aluno => aluno.Disciplinas.Any(
                            d => d.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId)
                        ));

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                            .ThenInclude(pd => pd.AlunosDisciplinas)
                            .ThenInclude(pa => pa.Aluno);
            }

            query = query.AsNoTracking()
                        .OrderBy(p => p.Id)
                        .Where(professor => professor.Id == professorId);


            return query.FirstOrDefault();
        }
    }
}