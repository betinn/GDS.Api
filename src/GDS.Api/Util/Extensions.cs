using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace GDS.Api.Util
{
    public static class Extensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T JsonToObject<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
