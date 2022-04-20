using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Pizzas.API.Utils;
using System.Data.SqlClient;
using Dapper;
using Pizzas.API.Helpers;
using Pizzas.API.Services;

namespace Pizzas.API.Services
{
    public class UsuariosBD
    {
        public static List<Usuario> TraerUsuarios(){
            List<Usuario> Usuarios = new List<Usuario>();
            string sql = "SELECT * FROM Usuarios";
            using (SqlConnection db = BD.GetConnection()){
                Usuarios = db.Query<Usuario>(sql).ToList();
            } 
            return Usuarios;  
        }
        
        public static int CrearUsuarios(Usuario UsuarioACrear){
            int NuevoUsuario = 0;
            string sql = "INSERT INTO Usuarios () Values ()";
            using (SqlConnection db = BD.GetConnection()){
                NuevoUsuario = db.Execute(sql, new {});
            }   
            return NuevoUsuario;
        }

        public static int ActualizarUsuarios(Usuario UsuarioACambiar){
            int UsuarioActualizado = 0;
            string sql="UPDATE Usuarios SET WHERE ";
            using (SqlConnection db = BD.GetConnection()){
                UsuarioActualizado = db.Execute(sql, new {});
            }
            return UsuarioActualizado;   
        }

        public static int EliminarUsuarios(int Id){
            int UsuarioEliminado = 0;
            string sql = "DELETE FROM Usuarios WHERE Id = @pId";
            using (SqlConnection db = BD.GetConnection()){
                db.Execute(sql, new {pId = Id});
            }   
            return UsuarioEliminado;
        }
    }
}