
namespace Dinamico
{

    using System;
  

    class Program
    {
        static void Main(string[] args)
        {
     
            var reflection = new Reflection();

            try
            {               
                reflection.Cargar();

                reflection.Ejecutar();

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex);

                Console.ReadKey();
            }
        }    
    }
}


//do
//{
////    reflection.Cargar();

////    reflection.Ejecutar();

//    Console.WriteLine("1.Cargar otro ensamblado   2. Salir");

//    opc = int.Parse(Console.ReadLine());          

//} while (opc != 2);