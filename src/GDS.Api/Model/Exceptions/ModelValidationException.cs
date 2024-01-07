using GDS.Api.Util;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GDS.Api.Model.Exceptions
{
    public class ModelValidationException : Exception
    {
        public int statuscode = StatusCodes.Status400BadRequest;
        public Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        public ModelValidationException(ModelStateDictionary modelState) : base("ModelValidation foi false")
        {
            foreach(var item in modelState)
            {
                var lserrors = new List<string>();
                foreach (var itemError in item.Value.Errors)
                    lserrors.Add(itemError.ErrorMessage);
                errors.Add(item.Key, lserrors);
            }
            
        }
    }
}
