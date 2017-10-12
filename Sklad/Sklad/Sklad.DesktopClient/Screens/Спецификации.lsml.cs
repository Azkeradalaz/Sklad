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
    public partial class Спецификации
    {
        #region Variables
        private ModalWindow NewRecHC;
        private ModalWindow EditRecHC;
        #endregion


        
        /*partial void MainFields2_Changed(global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                MainFieldsItem MFI = (MainFieldsItem)e.NewItems[0];
                MFI.Storage = "Склад 1";
                MFI.InOut = "Приход";

            }
        }*/

        partial void Recipes1_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                RecipesItem RI = (RecipesItem)e.NewItems[0];
                RI.QuantityDone = 1;
            }

        }
        partial void RecipesComponents1_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                RecipesComponentsItem RCI = (RecipesComponentsItem)e.NewItems[0];
                RCI.Quantity = 1;
            }

        }


        partial void Спецификации_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            NewRecHC = new ModalWindow(this.Recipes1, "NewRecipe", "спецификацию");
            EditRecHC = new ModalWindow(this.Recipes, "EditRecipe", "спецификацию");
            
        }
        partial void Спецификации_Created()
        {
            NewRecHC.Initialise();
            EditRecHC.Initialise();

            this.SuppressEnterKeyForControl("Recipes1_SelectedItem_MatsAndGoodsItem");
            this.SuppressEnterKeyForControl("Recipes1_SelectedItem_QuantityDone");


            this.SuppressEnterKeyForControl("Recipes_SelectedItem_MatsAndGoodsItem");
            this.SuppressEnterKeyForControl("Recipes_SelectedItem_QuantityDone");


        }

        partial void RecipesItemListAddAndEditNew_CanExecute(ref bool result)
        {
            result = NewRecHC.CanAdd();
            // Добавьте сюда свой код.

        }

        partial void RecipesItemListAddAndEditNew_Execute()
        {
            NewRecHC.AddEntity();
            // Добавьте сюда свой код.

        }

        partial void NewRecCancel_Execute()
        {
            NewRecHC.DialogCancel();
            this.DataWorkspace.skladData.Details.DiscardChanges();

            // Добавьте сюда свой код.

        }

        partial void NewRecOk_Execute()
        {
            NewRecHC.DialogOk();
            this.Save();
            this.Refresh();
            // Добавьте сюда свой код.

        }

        partial void RecipesItemListEditSelected_CanExecute(ref bool result)
        {
            result = EditRecHC.CanView();

        }

        partial void RecipesItemListEditSelected_Execute()
        {
            EditRecHC.ViewEntity();

        }

        partial void EdicRecCancel_Execute()
        {
            EditRecHC.DialogCancel();
            this.DataWorkspace.skladData.Details.DiscardChanges();

        }

        partial void EditRecOk_Execute()
        {
            EditRecHC.DialogOk();
            this.Save();
            this.Refresh();

        }
    }
}

