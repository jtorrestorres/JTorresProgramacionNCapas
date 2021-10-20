using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceMateria" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceMateria.svc or ServiceMateria.svc.cs at the Solution Explorer and start debugging.
    public class ServiceMateria : IServiceMateria
    {
        public string Saludar(string Nombre)
        {
            //return string.Format("You entered: {0}", value);
            return "Hola " + Nombre;
        }

        public SL_WCF1.Result Add(ML.Materia materia)
        {
            ML.Result resultMateria = BL.Materia.AddSP(materia);

            //return new Result { Correct = resultMateria.Correct, ErrorMessage = resultMateria.ErrorMessage, Ex = resultMateria.Ex };
            SL_WCF1.Result result= new Result();
            result.Correct=resultMateria.Correct;
            result.ErrorMessage=resultMateria.ErrorMessage;
           // result.Ex = resultMateria.Ex;
            return result;
        }

        public SL_WCF1.Result Update(ML.Materia materia)
        {
            ML.Result resultMateria = BL.Materia.Update(materia);
            return new Result { Correct = resultMateria.Correct, ErrorMessage = resultMateria.ErrorMessage, Ex = resultMateria.Ex };
        }

        public SL_WCF1.Result Delete(int IdMateria)
        {
            ML.Result resultMateria = BL.Materia.Delete(IdMateria);
            return new Result { Correct = resultMateria.Correct, ErrorMessage = resultMateria.ErrorMessage, Ex = resultMateria.Ex };
        }
    }

}
