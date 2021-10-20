using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Venta
    {
        public static void Add()
        {
            Console.WriteLine("Deseas iniciar una compra? 1.- SI 2.- NO");
            byte opcion=byte.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();  // 

            ML.Venta venta = new ML.Venta();
            venta.Total = 0;

            while(opcion==1)
            {
                PL.Materia.GetAll();

                Console.WriteLine("Ingrese el Id de la materia que desee comprar");

                ML.VentaMateria ventaMateria = new ML.VentaMateria();
                
                ventaMateria.Materia = new ML.Materia();
                ventaMateria.Materia.IdMateria = int.Parse(Console.ReadLine());

                ventaMateria.Cantidad = int.Parse(Console.ReadLine());

                ML.Result resultMateria = BL.Materia.GetById(ventaMateria.Materia.IdMateria);

                if(resultMateria.Correct)
                {
                    //unboxing 
                    venta.Total += ((ML.Materia)resultMateria.Object).Costo * ventaMateria.Cantidad;
                    //venta.Total = venta.Total + ((ML.Materia)resultMateria.Object).Costo * ventaMateria.Cantidad;
                    result.Objects.Add(ventaMateria);

                    Console.WriteLine("Deseas continuar con la compra? 1.- SI 2.- NO");
                    opcion = byte.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Ocurrió un error al consultar la materia " +result.ErrorMessage);
                }
                
                
            }


            //venta.Cliente = new ML.Cliente();
            //venta.Cliente.IdCliente = 1;

            BL.Venta.AddSP(venta, result.Objects);



        }
    }
}
