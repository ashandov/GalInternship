using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using PromAktiv.Module.Активы;
using DevExpress.Xpo;
using Galaktika.External.Module.BusinessObjects;
using Galaktika.External.Module.Reports;
using Xafari.BC.Numerators;
using Xafari.BC.Numerators.Xpo;
using Xafari.BC.Numerators.DC;
using Galaktika.External.Module.LogicControllers;
//using Galaktika.External.Module.BusinessOperations;

namespace Galaktika.External.Module
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class ExternalModule : ModuleBase
    {
        public ExternalModule()
        {
            InitializeComponent();
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updaterBefore = new UpdaterBefore(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updaterBefore };
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            PromAktiv.Module.Активы.ОбъектРемонта.ОбъектРемонтаLogicHandler = Galaktika.External.Module.Controllers.DerivePersistentBusinessObjectLogic.CreateInstance;
            XafTypesInfo.Instance.RegisterEntity("PersonsReportParameters", typeof(ExtDocParametrs));
            LogicControllerRegistrator.Register();

        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            ITypeInfo typeInfo1 = typesInfo.FindTypeInfo(typeof(ExternalDocument));
            ITypeInfo typeInfo2 = typesInfo.FindTypeInfo(typeof(ОбъектРемонта));
            IMemberInfo memberInfo1 = typeInfo1.FindMember("ОбъектРемонта");
            IMemberInfo memberInfo2 = typeInfo2.FindMember("ExternalDocument");

            if (memberInfo2 == null)
            {
                memberInfo2 = typeInfo2.CreateMember("ExternalDocument", typeof(XPCollection<ExternalDocument>));
                memberInfo2.AddAttribute(new DevExpress.Xpo.AssociationAttribute("A", typeof(ExternalDocument)),true);
                memberInfo2.AddAttribute(new DevExpress.Xpo.AggregatedAttribute(), true);
                
            }
            if (memberInfo1 == null)
            {
                memberInfo1 = typeInfo1.CreateMember("Asset", typeof(ОбъектРемонта));
                memberInfo1.AddAttribute(new DevExpress.Xpo.AssociationAttribute("A", typeof(ОбъектРемонта)), true);
                memberInfo1.AddAttribute(new DevExpress.Persistent.Base.ImmediatePostDataAttribute(), true);
            }

            ((XafMemberInfo)memberInfo1).Refresh();
            ((XafMemberInfo)memberInfo2).Refresh();

            if (typesInfo == null) return;
            ITypeInfo typeInfo;

            // В класс ОбъектРемонта добавляем свойство ExternalFactor
            // Ищем TypeInfo для класса Galaktika.EAM.Module.Активы.ОбъектРемонта
            typeInfo = typesInfo.FindTypeInfo(typeof(ОбъектРемонта));
            if (typeInfo != null)
            {
                // Для типа добавляем свойство Mass с типом decimal
                var exfProperty = typeInfo.CreateMember("ExternalFactor", typeof(decimal));
            }
        }
    }
    }



