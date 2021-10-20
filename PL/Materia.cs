using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        
        //ADD
        public static void Add()
        {
            //var x = 1; //int
            //x = "hola";

            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingresa el nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa los créditos de la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Id del semestre");
            //ML.Semestre semestre = new ML.Semestre(); //SET
            materia.Semestre = new ML.Semestre();
            materia.Semestre.IdSemestre = byte.Parse(Console.ReadLine());


            //ML.Result result = BL.Materia.AddSP(materia);
            ServiceReferenceMateria.ServiceMateriaClient client = new ServiceReferenceMateria.ServiceMateriaClient();
            var result = client.Add(materia);
            
            //ML.Result result = BL.Materia.AddSP(materia);

            if (result.Correct)
            {
                Console.WriteLine("Materia ingresada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Materia " + result.ErrorMessage);
            }
        }

        public static void GetAll()
        {

            ML.Result result=BL.Materia.GetAll();

            if (result.Correct)
            {
                foreach (ML.Materia materia in result.Objects)
                {
                    Console.WriteLine("IdMateria: " + materia.IdMateria);
                    Console.WriteLine("Nombre: " + materia.Nombre);
                    Console.WriteLine("Creditos: " + materia.Creditos);
                    Console.WriteLine("Costo: " + materia.Costo);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }

        public static void GetById()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingrese el Id de la materia a seleccionar");
            materia.IdMateria = int.Parse(Console.ReadLine());

            ML.Result result = BL.Materia.GetById(materia.IdMateria);
            
            if (result.Correct)            
            {
                // (TipoDeDatoAlmacenadoEnElObjecto)VariableDelObject
                //Unboxing  object -> variable
                materia.Nombre = ((ML.Materia)result.Object).Nombre;
                materia.Costo = ((ML.Materia)result.Object).Costo;
                materia.Creditos = ((ML.Materia)result.Object).Creditos;
                                
                Console.WriteLine("IdMateria: " + materia.IdMateria);
                Console.WriteLine("Nombre: " + materia.Nombre);
                Console.WriteLine("Costo: " + materia.Costo);
                Console.WriteLine("Creditos: " + materia.Creditos);                                                           
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
    }
}
