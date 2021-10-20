using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceMateria" in both code and config file together.
    [ServiceContract]
    public interface IServiceMateria
    {
        [OperationContract]
        string Saludar(string Nombre);

        [OperationContract]
        SL_WCF1.Result Add(ML.Materia materia);

        [OperationContract]
        SL_WCF1.Result Update(ML.Materia materia);

        [OperationContract]
        SL_WCF1.Result Delete(int IdMateria);
        
    }
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public object Object { get; set; }
        [DataMember]
        public List<object> Objects { get; set; }
        [DataMember]
        public Exception Ex { get; set; }
    }

}
