namespace Galaktika.External.Module {
	partial class ExternalModule {
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            // 
            // ExternalModule
            // 
          
            this.RequiredModuleTypes.Add(typeof(PromAktiv.Persistent.PromAktivPersistentModule));
            this.RequiredModuleTypes.Add(typeof(PromAktiv.Module.PromAktivModule));



            this.RequiredModuleTypes.Add(typeof(Xafari.Editors.XafariEditorsModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.BC.XafariBCModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.XafariModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.BC.Xas.XafariBCXasModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.Arms.XafariArmsModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.Reports.XafariReportsModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Arm.XafariReportsArmModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Analysis.XafariReportsAnalysisModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Excel.XafariReportsExcelModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.Reports.File.XafariReportsFileModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Xaf.XafariReportsXafModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.BC.Numerators.XafariBCNumeratorsModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.BC.Numerators.Xpo.XafariBCNumeratorsXpoModule));




            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Security.SecurityModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.CloneObject.CloneObjectModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Kpi.KpiModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.StateMachine.StateMachineModule));}

		#endregion
	}
}
