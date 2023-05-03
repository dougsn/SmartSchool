using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class; // Onde T é uma classe.
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Alunos
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunossByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        // Professor

        Professor[] GetAllProfessores(bool includeAluno = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAluno = false);
        Professor GetProfessorById(int professorId, bool includeAluno = false);


    }
}