using System;

namespace PromedanAPI.Controllers
{
    internal class ScriptMethodAttribute : Attribute
    {
        public object ResponseFormat { get; set; }
    }
}