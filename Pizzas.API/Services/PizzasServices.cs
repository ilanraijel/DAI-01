using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using System.Data.SqlClient;
using Pizzas.API.Utils;
using Dapper;

namespace Pizzas.API.Services
{
    public class PizzasBD
    {
        public static List<Pizza> TraerPizzas(){
            List<Pizza> Pizzas = new List<Pizza>();
            string sql = "SELECT * FROM Pizzas";
            using (SqlConnection db = BD.GetConnection()){
                Pizzas = db.Query<Pizza>(sql).ToList();
            } 
            return Pizzas;  
        }

        public static Pizza TraerPizzasId(int Id){
            Pizza Pizza = null;
            string sql = "SELECT * FROM Pizzas WHERE Id = @pId";
            using (SqlConnection db = BD.GetConnection()){
                Pizza = db.QueryFirstOrDefault<Pizza>(sql, new {pId = Id});
            }
            return Pizza;   
        }
        
        public static int CrearPizzas(Pizza PizzaACrear){
            int NuevaPizza = 0;
            string sql = "INSERT INTO Pizzas (Nombre, LibreGluten, Importe, Descripcion) Values (@pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
            using (SqlConnection db = BD.GetConnection()){
                NuevaPizza = db.Execute(sql, new {pNombre = PizzaACrear.Nombre, pLibreGluten=PizzaACrear.LibreGluten, pImporte = PizzaACrear.Importe, pDescripcion = PizzaACrear.Descripcion});
            }   
            return NuevaPizza;
        }

        public static int ActualizarPizzas(Pizza PizzaACambiar){
            int PizzaActualizada = 0;
            string sql="UPDATE Pizzas SET Nombre = @pNombre, LibreGluten = @pLibreGluten, Importe = @pImporte, Descripcion = @pDescripcion WHERE Id = @pId";
            using (SqlConnection db = BD.GetConnection()){
                PizzaActualizada = db.Execute(sql, new {pId = PizzaACambiar.Id, pNombre = PizzaACambiar.Nombre, pLibreGluten = PizzaACambiar.LibreGluten, pImporte = PizzaACambiar.Importe, pDescripcion = PizzaACambiar.Descripcion});
            }
            return PizzaActualizada;   
        }

        public static void EliminarPizzas(int Id){
            string sql = "DELETE FROM Pizzas WHERE Id = @pId";
            using (SqlConnection db = BD.GetConnection()){
                db.Execute(sql, new {pId = Id});
            }   
        }
    }  
}