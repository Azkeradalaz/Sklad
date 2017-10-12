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
    public partial class ИзготовлениеОтправка
    {
        private ModalWindow NewCraftHC;
        partial void ИзготовлениеОтправка_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            NewCraftHC = new ModalWindow(this.CraftAction1, "NewCraft", "запрос на производство");
        }

        partial void ИзготовлениеОтправка_Created()
        {
            this.SuppressEnterKeyForControl("CraftAction1_SelectedItem_SkladiItem1");
            this.SuppressEnterKeyForControl("CraftAction1_SelectedItem_Note");



            NewCraftHC.Initialise();
        }

        partial void CraftAction_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                CraftActionItem CAI = (CraftActionItem)e.NewItems[0];
                
                CAI.Status = "Изготавливается";


            }
        }
        partial void Craft1_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                CraftItem CI = (CraftItem)e.NewItems[0];

                CI.Quantity = 1;


            }
        }

        partial void CraftActionItemListAddAndEditNew_CanExecute(ref bool result)
        {
            result = NewCraftHC.CanAdd();

        }

        partial void CraftActionItemListAddAndEditNew_Execute()
        {
            NewCraftHC.AddEntity();
            this.FindControl("NewCraftOk").IsEnabled = false;
            

        }
  
        partial void NewCraftOk_Execute()
        {
            string All = "";
            bool craftnotnull = true;

            foreach (CraftItem CI3 in this.Craft1)
            {
                if (CI3.Quantity <= 0)
                {
                    craftnotnull = false;
                    break;
                }
            }

            foreach (CraftFillerItem CFI3 in this.CraftFiller1)
            {
                if (CFI3.Quantity <= 0)
                {
                    craftnotnull = false;
                    break;
                }
                else break;
            }

            if (!craftnotnull)
            {
                this.ShowMessageBox("В одном или более полей значение количества менее, либо равно 0", "Ошибка заполнения", MessageBoxOption.Ok);

            }
            else
            {

                if (this.CraftAction1.SelectedItem.SkladiItem != null)
                {
                    foreach (CraftFillerItem CFI in this.CraftFiller1)
                    {
                        foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                        {
                            if (this.CraftAction1.SelectedItem.SkladiItem == MAGQI.SkladiItem
                                && CFI.MatsAndGoodsItem == MAGQI.MatsAndGoodsItem)
                            {
                                if (CFI.Quantity > MAGQI.Quantity)
                                {
                                    All += CFI.MatsAndGoodsItem.Name.ToString() + "\n" + "    В запросе: " + CFI.Quantity.ToString() + "\n" + "    На складе: " + MAGQI.Quantity.ToString() + "\n";
                                }
                                break;

                            }

                        }

                    }
                    if (All != "")
                    {
                        this.ShowMessageBox(All, "Внимание, недостаточно изделий на складе", MessageBoxOption.Ok);
                    }
                    else
                    {
                        this.OpenModalWindow("Apply");
                    }



                    //NewCraftHC.DialogOk();
                    //foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                    //{
                    //    foreach (CraftFillerItem CFI in this.CraftFiller1)
                    //    {
                    //        if (CFI.MatsAndGoodsItem == MAGQI.MatsAndGoodsItem && this.CraftAction1.SelectedItem.SkladiItem == MAGQI.SkladiItem)
                    //        {
                    //            MAGQI.Quantity -= CFI.Quantity;

                    //        }

                    //    }
                    //}



                    //this.Save();
                    //this.Refresh();
                }


            }
        }

        partial void NewCraftCancel_Execute()
        {

            NewCraftHC.DialogCancel();
            this.DataWorkspace.skladData.Details.DiscardChanges();
            // Добавьте сюда свой код.

        }

        partial void Calculate_Execute()
        {
            bool craftnotnull2 = true;

            foreach (CraftItem CI4 in this.Craft1)
            {
                if (CI4.Quantity <= 0)
                {
                    craftnotnull2 = false;
                    break;
                }
            }
            if (!craftnotnull2 && this.CraftFiller1.Count == 0)
            {
                this.ShowMessageBox("В одном или более полей значение количества менее, либо равно 0", "Ошибка заполнения", MessageBoxOption.Ok);

            }
            else
            {
                if (CraftAction1.SelectedItem.SkladiItem != null && Craft1.Count > 0 && this.CraftFiller1.Count == 0)
                {
                    foreach (CraftItem CI in this.Craft1)
                    {
                        RecID = CI.RecipesItem.ID;
                        foreach (RecipesItem RI in
                        this.Recipes)
                        {
                            RecComID = RI.ID;
                            //selectedID = RI.MatsAndGoodsItem.ID;
                            foreach (RecipesComponentsItem RCI in
                            this.RecipesComponents)
                            {
                                MAGID = RCI.MatsAndGoodsItem.ID;
                                foreach (MatsAndGoodsItem MAGI in
                                    this.MatsAndGoods)
                                {
                                    if (MAGI.ID == RCI.MatsAndGoodsItem.ID && RCI.RecipesItem.ID == RI.ID &&
                                    CI.RecipesItem.ID == RI.ID)
                                    {
                                        if (CraftFiller1.Count == 0)
                                        {
                                            var NCFI = this.CraftFiller1.AddNew();
                                            NCFI.Quantity = RCI.Quantity * CI.Quantity;
                                            NCFI.MatsAndGoodsItem = MAGI;
                                        }
                                        else//REWORK
                                        {
                                            bool CFIdone=false; //проверка на добавление количества материалов, отправляемы на производство (убирание дублей)
                                            foreach (CraftFillerItem CFI in this.CraftFiller1)
                                            {
                                                if (MAGI.ID == CFI.MatsAndGoodsItem.ID)
                                                {
                                                    CFI.Quantity = CFI.Quantity + RCI.Quantity * CI.Quantity;
                                                    CFIdone = true;
                                                    break;   
                                                }
                                               
                                            }
                                            if (CFIdone == false)
                                            {
                                                var NCFI = this.CraftFiller1.AddNew();
                                                NCFI.Quantity = RCI.Quantity * CI.Quantity;
                                                NCFI.MatsAndGoodsItem = MAGI;
                                            }
                                            CFIdone = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            this.FindControl("NewCraftOk").IsEnabled = true;
        } //калькуляция

        partial void Clear_Execute()
        {
            try
            {
                foreach (CraftFillerItem CFI in this.CraftFiller1)
                {
                    CFI.Delete();
                }
            }
            catch
            {

            }

        }


        partial void CraftActionItemListDeleteSelected_Execute()
        {

            if (this.CraftAction.SelectedItem != null && this.CraftAction.SelectedItem.Status == "Изготавливается")
            {
                foreach (CraftFillerItem CFI in this.CraftFiller)
                {
                    foreach (MatsAndGoodsQuantitiesItem MAGI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                    {
                        if (CFI.MatsAndGoodsItem == MAGI.MatsAndGoodsItem && this.CraftAction.SelectedItem.SkladiItem == MAGI.SkladiItem)
                        {
                            MAGI.Quantity += CFI.Quantity;
                            break;

                        }
                    }
                }



                this.CraftAction.SelectedItem.Status = "Удален";
                this.Save();
                this.Refresh();



            }
        }

        partial void CancelApply_Execute()
        {
            this.CloseModalWindow("Apply");

        }

        partial void OkApply_Execute()
        {
            if (this.CraftAction1.SelectedItem.SkladiItem != null)
            {
                
                foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                {
                    foreach (CraftFillerItem CFI in this.CraftFiller1)
                    {
                        if (CFI.MatsAndGoodsItem == MAGQI.MatsAndGoodsItem && this.CraftAction1.SelectedItem.SkladiItem == MAGQI.SkladiItem)
                        {
                            MAGQI.Quantity -= CFI.Quantity;

                        }

                    }
                }

                this.CloseModalWindow("Apply");
                NewCraftHC.DialogOk();
                this.Save();
                this.Refresh();
            }

        }

        partial void ИзготовлениеОтправка_Saving(ref bool handled)
        {
            // Добавьте сюда свой код.

        }

        partial void SearchDefault_Execute()
        {
            this.Status = null;
            this.SkladName = null;
            this.DateCreationLess = null;
            this.DateCreationMore = null;
            this.ResponsibleName = null;

        }

        partial void SearchClose_Execute()
        {
            this.CloseModalWindow("Search");

        }
 
        partial void AddAsWas_CanExecute(ref bool result)
        {
            result = NewCraftHC.CanAdd();
        }

       
        partial void AddAsWas_Execute()
        {
            NewCraftHC.AddEntity();
            this.CraftAction1.SelectedItem.SkladiItem = this.CraftAction.SelectedItem.SkladiItem;
            this.CraftAction1.SelectedItem.ResponsibleItem = this.CraftAction.SelectedItem.ResponsibleItem;
            this.CraftAction1.SelectedItem.DateCreation = this.CraftAction.SelectedItem.DateCreation;
            this.CraftAction1.SelectedItem.Note = this.CraftAction.SelectedItem.Note;  
            foreach (CraftItem CI in this.Craft)
            {

                var NCI = this.Craft1.AddNew();
                NCI.RecipesItem = CI.RecipesItem;
                NCI.Quantity = CI.Quantity;

            }
            foreach (CraftFillerItem CFI in this.CraftFiller)
            {

                var NCFI = this.CraftFiller1.AddNew();
                NCFI.MatsAndGoodsItem = CFI.MatsAndGoodsItem;
                NCFI.Quantity = CFI.Quantity;

            }

        }

       

    }
}

