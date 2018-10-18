// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.PersistantPackage
{
    [DataContract]
    public class UpdatePackageBox
    {
        public UpdatePackageBox()
        {
            insertBox = new PersistanceBox();
            deleteBox = new PersistanceBox();
            updateBox = new PersistanceBox();
        }
        [DataMember]
        public PersistanceBox insertBox {get;set;}
        [DataMember]
        public PersistanceBox deleteBox {get;set;}
        [DataMember]
        public PersistanceBox updateBox {get;set;}

    }
}
