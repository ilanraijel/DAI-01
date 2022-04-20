using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Helpers;
using Pizzas.API.Models;
using Pizzas.API.Services;
using Pizzas.API.Utils;
using System.Data.SqlClient;
using Dapper;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(){

            try{
            List<Pizza> ListaPizzas = PizzasBD.TraerPizzas();
            return Ok(ListaPizzas);
            }
             catch(Exception error){
               return NotFound(error);
           }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id){
            
            try{
            Pizza UnaPizza = PizzasBD.TraerPizzasId(Id);
            if (UnaPizza == null){
                return NotFound();
            }
            return Ok(UnaPizza);
            }
             catch(Exception error){
               return NotFound(error);
           }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int Id, Pizza UnaPizza){
            int PizzaCambiada;

            try{ 
            if (Id != UnaPizza.Id){
                return BadRequest();
            }
            Pizza PizzaExistente = PizzasBD.TraerPizzasId(Id);
            if (PizzaExistente == null){
                return NotFound();
            }

            PizzaCambiada = PizzasBD.ActualizarPizzas(UnaPizza);
            if(PizzaCambiada == 0){
                return BadRequest();
            }
            else{
                return Ok();
            }
            }
            catch{return NotFound("Error");}
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id){
            try{ 
            Pizza PizzaExistente = PizzasBD.TraerPizzasId(id);
            if(PizzaExistente == null){
                return NotFound();
            }
            PizzasBD.EliminarPizzas(id);
            return Ok();
            }
             catch(Exception error){
               return NotFound(error);
           }
        }
    }
}
