using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dinamico
{
    public partial class Reflection
    {
        //    Proyect_01 Proyect_01.Class2 usuario { "Name":"Johan","Id":1}
        string nameDll = "", proyectClass = "", method = "", param = "";

        Assembly Assembly;

        Type type;

        MethodInfo Method;

        MethodInfo[] methodInfos;

        ParameterInfo[] parametrosMetodoEjecutar;

        List<MethodInfo> metodosEjecutar;

        List<Type> listaTiposParaElMetodo;

        List<Type> typesParamsEnterUser;

        string[] dirFail;

        object[] envio;

        string currDir;

        string cadena;

        object instance;

        int countParam = 0;

        bool enterMethod = false;

        object result;

        int cont = 0;

        object[] arrayParam;

        bool isNumeric = false;

        float num;

        object typeValue;

        dynamic parameter;

        bool enterJson = false;

        public void Cargar()
        {
            Console.WriteLine("Escribe la DLL/nombre del paquete.nombre de la clase/Nombre del metodo/parametros a enviar");

            cadena = Console.ReadLine();

            Console.WriteLine();

            dirFail = cadena.Split(' ');

            nameDll = dirFail[0] + ".dll";

            proyectClass = dirFail[1];

            method = dirFail[2];

            currDir = AppDomain.CurrentDomain.BaseDirectory;

            Assembly = Assembly.LoadFile(currDir + nameDll);

            type = Assembly.GetType(proyectClass);

            instance = Activator.CreateInstance(type);

            methodInfos = type.GetMethods();

            if (!ValidateParameter()) //Validamos el tipo de parametro y que este exista.
            {
                Method = type.GetMethod(method, new Type[0]);

                result = Method.Invoke(instance, new object[0]);
            }
        }
    }
}
