using Galaktika.External.Module.BusinessObjects;
using PromAktiv.Core.Module.LogicControllers;
using PromAktiv.Module.LogicControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.External.Module.LogicControllers
{
    public class LogicControllerRegistrator
    {
        public static void Register()
        {
            //просьба добавлять по алфавиту  по типу объекта, для удобного поиска:
            LogicControllerService.Register<ExternalDocument>(typeof(ExternalDocumentLogicController), ExternalDocumentLogicController.CreateInstance);
        }
    }
}
