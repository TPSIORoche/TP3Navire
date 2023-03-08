using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNavire.Exceptions
{
    class GestionPortException : Exception
    {
        public GestionPortException(string message)
            : base("Erreur de : " + Environment.UserName + " le " + DateTime.Now.ToLocalTime() + "\n" + message) { }
    }
}
