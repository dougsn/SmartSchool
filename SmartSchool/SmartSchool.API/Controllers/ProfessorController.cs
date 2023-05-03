using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public SmartContext _context { get; }
        public ProfessorController(SmartContext context)
        {
            _context = context;
        }
            
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(aluno == null) return BadRequest("Professor não encontrado.");

            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var aluno = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if(aluno == null) return BadRequest("Professor não encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado.");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado.");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");

            _context.Remove(prof);
            _context.SaveChanges();
            return Ok("Professor deletado.");
        }

    }
}