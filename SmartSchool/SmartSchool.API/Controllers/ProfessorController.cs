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
        private readonly IRepository _repo;
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado.");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não encontrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor não encontrado.");

            _repo.Update(professor);
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não encontrado");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor não encontrado.");

            _repo.Update(professor);
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não encontrado");
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id);
            if(prof == null) return BadRequest("Professor não encontrado.");

            _repo.Delete(prof);

            if(_repo.SaveChanges())
            {
                return Ok("Professor deletado.");
            }
            return BadRequest("Professor não encontrado.");
        }

    }
}