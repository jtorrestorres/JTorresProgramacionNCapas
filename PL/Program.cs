using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace PL
{
    class Program
    {

        
        static void Main(string[] args)
        {
            ServiceCalculator.CalculatorSoapClient calculadora = new ServiceCalculator.CalculatorSoapClient();
            calculadora.Add(6, 6);
            
            //BL.Semestre.GetAll(); //static
            //BL.Semestre semestre = new BL.Semestre();
           // semestre.GetAll();


            ServiceReferenceTest.Service1Client TestServicio = new ServiceReferenceTest.Service1Client();
            var Result = TestServicio.Saludar("Jesús");
           // PL.Materia.Add(); //SQL Cliente  //EF
            //PL.Materia.GetAll();
           // PL.Venta.Add();
           // Console.ReadKey();

            int numero;
            Console.Write("Digite el numero del tamaño de la piramide: ");
            numero = int.Parse(Console.ReadLine());

            for (int i = 0; i < numero; i++)
            {
                Console.WriteLine(new String(' ', numero - i - 1) + new String('*', i + i + 1));
            }
            Console.ReadLine();
                    
        }
    }
}
