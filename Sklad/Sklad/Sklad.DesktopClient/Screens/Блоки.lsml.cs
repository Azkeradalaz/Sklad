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
    public partial class Блоки
    {
        private ModalWindow NewMAGHC;
        private ModalWindow EditMAGHC;
        partial void MatsAndGoods_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                MatsAndGoodsItem MAGI = (MatsAndGoodsItem)e.NewItems[0];
                MAGI.Category = "Блок";
                MAGI.Unit = "шт.";

            }

        }

        partial void Блоки_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            NewMAGHC = new ModalWindow(this.MatsAndGoods1, "NewMAG", "блок");
            EditMAGHC = new ModalWindow(this.MatsAndGoods, "EditMAG", "блок");


        }

        partial void Блоки_Created()
        {
            NewMAGHC.Initialise();
            EditMAGHC.Initialise();

            this.SuppressEnterKeyForControl("MatsAndGoods1_SelectedItem_Name");
            this.SuppressEnterKeyForControl("MatsAndGoods1_SelectedItem_FullName");
            this.SuppressEnterKeyForControl("MatsAndGoods1_SelectedItem_Note");

            this.SuppressEnterKeyForControl("MatsAndGoods_SelectedItem_Name");
            this.SuppressEnterKeyForControl("MatsAndGoods_SelectedItem_FullName");
            this.SuppressEnterKeyForControl("MatsAndGoods_SelectedItem_Note");
        }

        #region New Block
        partial void gridAddAndEditNew_CanExecute(ref bool result)
        {
            result = NewMAGHC.CanAdd();

        }

        partial void gridAddAndEditNew_Execute()
        {
            NewMAGHC.AddEntity();

        }

        partial void CancelNewMAG_Execute()
        {
            NewMAGHC.DialogCancel();

        }

        partial void OkNewMAG_Execute()
        {
            if (MatsAndGoods1.SelectedItem.Name != null &&
                MatsAndGoods1.SelectedItem.Unit != null &&
                MatsAndGoods1.SelectedItem.Name != "" &&
                MatsAndGoods1.SelectedItem.Unit != "")
            {
                NewMAGHC.DialogOk();
                this.Save();
                this.Refresh();
            }

        }
        #endregion

        #region Edit Material
        partial void gridEditSelected_CanExecute(ref bool result)
        {
            result = EditMAGHC.CanView();

        }

        partial void gridEditSelected_Execute()
        {
            EditMAGHC.ViewEntity();

        }

        partial void CancelEditMAG_Execute()
        {
            EditMAGHC.DialogCancel();

        }


        partial void OkEdit_Execute()
        { 
            if (MatsAndGoods1.SelectedItem.Name != null &&
                MatsAndGoods1.SelectedItem.Unit != null &&
                MatsAndGoods1.SelectedItem.Name != "" &&
                MatsAndGoods1.SelectedItem.Unit != "")
            {
                EditMAGHC.DialogOk();
                this.Save();
                this.Refresh();
            }

        }
        #endregion

        



    }
}
