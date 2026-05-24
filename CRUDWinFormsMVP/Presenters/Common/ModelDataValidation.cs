using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUDWinFormsMVP.Presenters.Common
{
    /// <summary>
    /// Proporciona métodos compartidos para la validación de modelos utilizando DataAnnotations.
    /// </summary>
    public class ModelDataValidation
    {
        /// <summary>
        /// Evalúa las anotaciones de datos de un modelo y lanza una excepción si alguna regla no se cumple.
        /// </summary>
        /// <param name="model">El objeto modelo a validar.</param>
        /// <exception cref="Exception">Lanzada cuando el modelo contiene datos inválidos, devolviendo los mensajes de error.</exception>
        public void Validate(object model)
        {
            string errorMessage = "";
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            if (!isValid)
            {
                foreach(var item in results)
                    errorMessage += item.ErrorMessage + "\n";
                throw new Exception(errorMessage);
            }
        }
    }
}
