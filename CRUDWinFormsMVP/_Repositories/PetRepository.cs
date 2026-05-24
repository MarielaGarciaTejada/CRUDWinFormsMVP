using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CRUDWinFormsMVP.Models;

namespace CRUDWinFormsMVP._Repositories
{
    /// <summary>
    /// Maneja las operaciones de acceso a datos (CRUD) para la entidad Pet utilizando ADO.NET.
    /// </summary>

    public class PetRepository : BaseRepository, IPetRepository
    {
        /// <summary>
        /// Inicializa una nueva instancia del repositorio con la cadena de conexión a la base de datos.
        /// </summary>
        /// <param name="connectionString">La cadena de conexión SQL.</param>
        public PetRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        //metodos

        /// <summary>
        /// Inserta un nuevo registro de mascota en la base de datos.
        /// </summary>
        /// <param name="petModel">El modelo con los datos de la mascota a guardar.</param>
        public void Add(PetModel petModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Pet values (@name, @type, @colour)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = petModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = petModel.Colour;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Elimina un registro de mascota de la base de datos utilizando su identificador.
        /// </summary>
        /// <param name="id">El identificador único de la mascota.</param>
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Pet where Pet_Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
     
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Actualiza los datos de una mascota existente en la base de datos.
        /// </summary>
        /// <param name="petModel">El modelo con los datos actualizados.</param>
        public void Edit(PetModel petModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Pet 
                                        set Pet_Name=@name,Pet_Type=@type, Pet_Colour=@colour
                                        where Pet_Id=@id";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = petModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = petModel.Colour;
                command.Parameters.Add("@id", SqlDbType.Int).Value = petModel.Id;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Obtiene una lista con todas las mascotas registradas, ordenadas de forma descendente por su ID.
        /// </summary>
        /// <returns>Una colección de objetos PetModel.</returns>
        public IEnumerable<PetModel> GetAll()
        {
            var petList = new List<PetModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select *from Pet order by Pet_Id desc";
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Id = (int)reader[0];
                        petModel.Name = reader[1].ToString();
                        petModel.Type = reader[2].ToString();
                        petModel.Colour = reader[3].ToString();
                        petList.Add(petModel);

                    }
                }
            }

                return petList;
        }

        /// <summary>
        /// Busca mascotas en la base de datos que coincidan con el ID proporcionado o cuyo nombre comience con el valor dado.
        /// </summary>
        /// <param name="value">El ID (numérico) o el nombre (texto) a buscar.</param>
        /// <returns>Una colección de mascotas que coinciden con el criterio de búsqueda.</returns>
        public IEnumerable<PetModel> GetByValue(string value)
        {
            var petList = new List<PetModel>();
            //campo de busqueda local
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select *from Pet
                                        where Pet_Id=@id or Pet_Name like @name+'%'
                                        order by Pet_Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = petId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Id = (int)reader[0];
                        petModel.Name = reader[1].ToString();
                        petModel.Type = reader[2].ToString();
                        petModel.Colour = reader[3].ToString();
                        petList.Add(petModel);

                    }
                }
            }

            return petList;
        }
    }
}
