using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class prueba : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public prueba()
        {
           prueba prueba1 = new prueba();

            var prueba = (Object)prueba1;
            prueba prueba2 = new prueba();

            if (prueba1 == prueba2)
            {

            }
            else
            {

            }
        }
    }
}
