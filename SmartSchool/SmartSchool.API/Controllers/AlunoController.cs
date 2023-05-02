using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "452104512"
            },
            new Aluno() {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "211661233"
            },
            new Aluno() {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Maria",
                Telefone = "6547415574"
            }
        };

        public AlunoController(){}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null){
                return BadRequest("O Aluno não foi encontrado.");
            }

            return Ok(aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome == nome);

            if(aluno == null){
                return BadRequest("O Aluno não foi encontrado.");
            }

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno) {
            return Ok(aluno);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno) {
            return Ok(aluno);
        }
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno) {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok("Aluno excluído com sucesso.");
        }
        

    }
}