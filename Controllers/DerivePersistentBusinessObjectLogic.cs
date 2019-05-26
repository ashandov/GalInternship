using PromAktiv.Core.Module;
using PromAktiv.Module.Активы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PromAktiv.Module.Активы.ОбъектРемонта;

namespace Galaktika.External.Module.Controllers
{
    public class DerivePersistentBusinessObjectLogic : ОбъектРемонта.Logic
    {
        public static new DerivePersistentBusinessObjectLogic CreateInstance()
        {
            return new DerivePersistentBusinessObjectLogic();
        }

        public override void AfterConstruction(ОбъектРемонта instance)
        {
            base.AfterConstruction(instance);
            instance.SetMemberValue("ExternalFactor",1);
            
    
        }
      
    }
}

