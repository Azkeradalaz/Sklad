using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Controls;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Client;
using Microsoft.LightSwitch.Threading;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using System.Windows;
using System.Windows.Input;
using Microsoft.LightSwitch.Model;
using Microsoft.LightSwitch.Details;

namespace LightSwitchApplication
{
    public partial class Поставщики
    {
        #region Variables
        private ModalWindow NewSuppHC;
        private ModalWindow EditSuppHC;
        #endregion


        partial void Suppliers_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                SuppliersItem SI = (SuppliersItem)e.NewItems[0];
                SI.NDS = "-";

            }
        }
        partial void Поставщики_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            NewSuppHC = new ModalWindow(this.Suppliers1, "NewSupplier", "поставщика");
            EditSuppHC = new ModalWindow(this.Suppliers, "EditSupplier", "поставщика");
        }
        partial void Поставщики_Created()
        {
            NewSuppHC.Initialise();
            EditSuppHC.Initialise();
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_Name");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_FullName");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_Country");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_Region");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_City");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_Adress");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_Postcode");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_INN_KPP");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_OGRN");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_OKPO");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_OKVED");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_ContactName");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_PhoneNumber");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_FaxNumber");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_Note");
            this.SuppressEnterKeyForControl("Suppliers1_SelectedItem_NDS");

            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_Name");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_FullName");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_Country");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_Region");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_City");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_Adress");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_Postcode");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_INN_KPP");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_OGRN");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_OKPO");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_OKVED");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_ContactName");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_PhoneNumber");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_FaxNumber");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_Note");
            this.SuppressEnterKeyForControl("Suppliers_SelectedItem_NDS");

        }
        partial void gridAddAndEditNew_CanExecute(ref bool result)
        {

            result = NewSuppHC.CanAdd();

        }

        partial void gridAddAndEditNew_Execute()
        {
            NewSuppHC.AddEntity();

        }

        partial void gridEditSelected_CanExecute(ref bool result)
        {
            result = EditSuppHC.CanView();

        }

        partial void gridEditSelected_Execute()
        {
            EditSuppHC.ViewEntity();

        }

        partial void NewSupplierCancel_Execute()
        {
            NewSuppHC.DialogCancel();

        }

        partial void EditSupplierCancel_Execute()
        {
            EditSuppHC.DialogCancel();

        }

        partial void EditSupplierOk_Execute()
        {
            if ((Suppliers.SelectedItem.Name != null) && (Suppliers1.SelectedItem.Name != ""))
            {
                EditSuppHC.DialogOk();
                this.Save();
                this.Refresh();
            }

        }

        partial void NewSupplierOk_Execute()
        {
            if ((Suppliers1.SelectedItem.Name != null) && (Suppliers1.SelectedItem.Name != ""))
            {
                NewSuppHC.DialogOk();
                this.Save();
                this.Refresh();
            }

        }

        partial void gridDeleteSelected_CanExecute(ref bool result)
        {

        }

        partial void gridDeleteSelected_Execute()
        {

        }

        partial void ExcelSuppliers_Execute()
        {



            
            List<OfficeIntegration.ColumnMapping> custFields = new List<OfficeIntegration.ColumnMapping>();
            List<OfficeIntegration.ColumnMapping> custFields1 = new List<OfficeIntegration.ColumnMapping>();
            custFields.Add(new OfficeIntegration.ColumnMapping("Название", "Name"));       
            custFields.Add(new OfficeIntegration.ColumnMapping("НДС", "NDS"));
            custFields.Add(new OfficeIntegration.ColumnMapping("Телефон", "PhoneNumber"));
            OfficeIntegration.Excel.Export(this.Suppliers, custFields);
            //OfficeIntegration.Excel.Export(this.Suppliers, "c:/Sklad/Sheet.xlsx", "Лист1", "A1", custFields);
            //custFields.Add(new OfficeIntegration.ColumnMapping("", "Название"));
            //custFields.Add(new OfficeIntegration.ColumnMapping(" ", "НДС"));
            //custFields.Add(new OfficeIntegration.ColumnMapping(" ", "Номер"));
            //OfficeIntegration.Excel.Export(this.Suppliers, "c:/Sklad/Sheet.xlsx", "Лист1", "A1", custFields1);

            //OfficeIntegration.Excel.Export(this.Suppliers, "D:/VS_PRO/ExcelSheet.xlsx","Лист1", "A1",custFields);




            //OfficeIntegration.Excel.Import(this.Suppliers,@"D:\VS_PRO\ExcelSheet.xlsx",
            //    "Sheet1",
            //    "A1:C3",
            //    custFields); }






            //    string MyDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);  
            //    string WordFile = MyDocs + "\\Customer.docx";
            //    if (File.Exists(WordFile)) 
            //    {
            ////Map the content control tag names in the word document to the entity field names


            //OfficeIntegration.Word.Export(WordFile, "Supps", 2, false, this.Suppliers, custFields);

            // OfficeIntegration.Word.ExportEntityCollection(WordFile, "OrderTable", 2, False, this.Customer.Orders, orderFields);


            //dynamic doc = OfficeIntegration.Word.GenerateDocument(WordFile, this.Supplier, custFields);

            //Export specific fields to the bookmarked "OrderTable" in Word

            //List<OfficeIntegration.ColumnMapping> orderFields = new List<OfficeIntegration.ColumnMapping>();
            //orderFields.Add(new OfficeIntegration.ColumnMapping("ShipName", "ShipName")); 
            //orderFields.Add(new OfficeIntegration.ColumnMapping("OrderDate", "OrderDate")); 
            //orderFields.Add(new OfficeIntegration.ColumnMapping("ShippedDate", "ShippedDate")); 

            //OfficeIntegration.Word.ExportEntityCollection(doc, "OrderTable", 2, False, this.Customer.Orders, orderFields);

            //OfficeIntegration.Word.SaveAsPDF(doc, MyDocs + "\\Customer.pdf", True);
        }
    }
}
