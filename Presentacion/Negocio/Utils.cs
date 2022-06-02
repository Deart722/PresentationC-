using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Utils
    {

        public static void parse<T>(object sourceObject, ref T destObject)
        {
            
            //si cualquiera de las dos entidades es nula devuelve el flujo del programa
            if (sourceObject == null || destObject == null)
            {
                return;
            }

                //Conseguir el tipo de las entidades 
            Type sourceType = sourceObject.GetType();
            Type targetType = destObject.GetType();

            //Entrar en el bucle de la fuente de las propiedades

            foreach(PropertyInfo p in sourceType.GetProperties())
            {
                PropertyInfo targetObjt = targetType.GetProperty(p.Name);

                if(targetObjt == null)
                {
                    continue;
                }
                targetObjt.SetValue(destObject, p.GetValue(sourceObject, null), null);



            }

        }
    }
}
