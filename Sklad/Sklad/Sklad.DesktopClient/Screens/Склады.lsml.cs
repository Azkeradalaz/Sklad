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
    
   

    public partial class Склады
    {


        #region Variables
        private ModalWindow NewSkladHC;
        private ModalWindow EditSkladHC;
        #endregion


        partial void Склады_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            NewSkladHC = new ModalWindow(this.SkladiModalWindow, "SkladiModal", "склад");
            EditSkladHC = new ModalWindow(this.Skladi, "EditSkladModal", "склад");
        }
        #region New Sklad
        partial void Склады_Created()
        {
            NewSkladHC.Initialise();
            EditSkladHC.Initialise();
            this.SuppressEnterKeyForControl("SkladiModalWindow_SelectedItem_Name");
            this.SuppressEnterKeyForControl("SkladiModalWindow_SelectedItem_Adress");
            this.SuppressEnterKeyForControl("SkladiModalWindow_SelectedItem_Note");
            this.SuppressEnterKeyForControl("Skladi_SelectedItem_Name");
            this.SuppressEnterKeyForControl("Skladi_SelectedItem_Adress");
            this.SuppressEnterKeyForControl("Skladi_SelectedItem_Note");
        }
        partial void Skladi_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add){
                SkladiItem SI = (SkladiItem)e.NewItems[0];
                SI.Status = "Функционирует";
            }
            
        }


        partial void SkladOk_Execute()
        {
            if ((SkladiModalWindow.SelectedItem.Name != null) && (SkladiModalWindow.SelectedItem.Name != "")) 
            {
                NewSkladHC.DialogOk();
                this.Save();
                this.Refresh();
            }
        }

        partial void SkladCancel_Execute()
        {
            NewSkladHC.DialogCancel();
            

        }

        partial void gridAddAndEditNew_CanExecute(ref bool result)
        {
            result = NewSkladHC.CanAdd();

        }

        partial void gridAddAndEditNew_Execute()
        {
            NewSkladHC.AddEntity();

        }
        #endregion 

        
        #region Edit Sklad

        partial void gridEditSelected_CanExecute(ref bool result)
        {
            result = EditSkladHC.CanView();

        }

        partial void gridEditSelected_Execute()
        {
            EditSkladHC.ViewEntity();

        }

 
        partial void SkladEditCancel_Execute()
        {
            EditSkladHC.DialogCancel();

        }

        partial void SkladEditOk_Execute()
        {
            if ((Skladi.SelectedItem.Name != null)&&(Skladi.SelectedItem.Name != "")) 
            { 
                EditSkladHC.DialogOk();
                this.Save(); 
                this.Refresh();
            }
        }
        #endregion

        partial void gridDeleteSelected_CanExecute(ref bool result)
        {
            // Добавьте сюда свой код.

        }

        partial void gridDeleteSelected_Execute()
        {
            bool del = true;
            foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
            {
                if (MAGQI.SkladiItem.ID == this.Skladi.SelectedItem.ID)
                {
                    if (MAGQI.Quantity != 0)
                    {
                        del = false;
                        break;
                    }
                }
            }
            if (del)
            {
                this.Skladi.SelectedItem.Status = "Удален";
                this.Save();
                this.Refresh();
            }
        }

        

       

    }
}
