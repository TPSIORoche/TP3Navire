using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier

{
    interface ICroisierable
    {
        void Embarquer(List<Object> objects);
        void Debarquer(List<Object> objects);
    }
}
