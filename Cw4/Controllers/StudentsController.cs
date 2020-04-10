using System;
using System.Data.SqlClient;
using Cw4.DAL;
using Cw4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace Cw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _dbService.GetStudent(id);
            if (student != null)
                return Ok(student);
            else
                return NotFound("Nie znaleziono studneta");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (_dbService.CreateStudent(student) > 0)
                return Ok(student);
            return Conflict(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            if (_dbService.UpdateStudent(id, student) > 0)
                return Ok("Aktualizacja dokończona");
            else
                return NotFound("Nie znaleziono studneta");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if(_dbService.DeleteStudent(id) > 0)
                return Ok("Usuwanie ukończone");
            else
                return NotFound("Nie znaleziono studneta");
        }
    }
}