

namespace Dinamico
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;


    public partial class Reflection
    {       
        public void Ejecutar()
        {
            metodosEjecutar = new List<MethodInfo>();

            listaTiposParaElMetodo = new List<Type>();

            envio = new object[countParam];

            foreach (MethodInfo methodItem in methodInfos)
                if (methodItem.Name == method) metodosEjecutar.Add(methodItem); // Obtenemos los nombres de los metodos iguales al metodo ingresado por el usuario 

          

            foreach (MethodInfo metodoEjecutar in metodosEjecutar) //Recorrer de nuevo los metodos  filtrados en el paso anterios, para obtener los parametros del metodo especificado
            {
                parametrosMetodoEjecutar = metodoEjecutar.GetParameters();

                if (countParam != 0)
                {
                    if (param[0].ToString() == "{" && param[param.Length - 1].ToString() == "}")
                    {
                        enterMethod = true;

                        foreach (ParameterInfo parametroMetodoEjecutar in parametrosMetodoEjecutar)
                        {
                            Type tipoParametro = parametroMetodoEjecutar.ParameterType;

                            listaTiposParaElMetodo.Add(tipoParametro);

                            parameter = JsonConvert.DeserializeObject(arrayParam[cont].ToString(), tipoParametro);

                            enterJson = true;
                        }
                    }
                    else
                    {
                        if (countParam == parametrosMetodoEjecutar.Count()
                        && parametrosMetodoEjecutar
                        .Where(x =>
                        {
                            return typesParamsEnterUser.Contains(x.ParameterType);
                        }).Count() == countParam)
                        {
                            enterMethod = true;

                            foreach (ParameterInfo parametroMetodoEjecutar in parametrosMetodoEjecutar)
                            {
                                Type tipoParametro = parametroMetodoEjecutar.ParameterType;

                                listaTiposParaElMetodo.Add(tipoParametro);

                                envio[cont] = Convert.ChangeType(arrayParam[cont], tipoParametro);

                                cont++;
                            }
                        }
                    }
                }
                else
                {
                    envio = null;
                    enterMethod = true;
                }
            }
            if (!enterMethod)
            {
                Console.WriteLine("\n los parametros no son de este methodo  \n{0}.", param);

                return;
            }
            else
            {
                Method = type.GetMethod(method, listaTiposParaElMetodo.ToArray());

                if (enterJson)
                {
                    result = Method.Invoke(instance , new object[] { parameter });
                }
                else
                {
                    result = Method.Invoke(instance, envio);
                }

                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine("\n El metodo ha retornado= \n{0}.", result);
        }
    }
}
