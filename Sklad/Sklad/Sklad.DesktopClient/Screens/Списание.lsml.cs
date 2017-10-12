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
    public partial class Списание

    {
        partial void Actions_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                ActionsItem AI = (ActionsItem)e.NewItems[0];
                AI.Action = "Списание";
                AI.Status = "Уход";
                AI.SkladiItem = null;

            }
        }

        private ModalWindow NewActionHC;

        partial void Списание_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            NewActionHC = new ModalWindow(this.Actions1, "NewAction", "списание");
        }

        partial void Списание_Created()
        {
            this.SuppressEnterKeyForControl("Actions1_SelectedItem_CreationDate");
            this.SuppressEnterKeyForControl("Actions1_SelectedItem_SkladiItem");
            this.SuppressEnterKeyForControl("Actions1_SelectedItem_Note");

            NewActionHC.Initialise();
        }

        partial void ActionsItemListAddAndEditNew_CanExecute(ref bool result)
        {
            result = NewActionHC.CanAdd();

        }

        partial void ActionsItemListAddAndEditNew_Execute()
        {
            NewActionHC.AddEntity();

        }

        partial void NewActionOk_Execute()
        {
            string All = "";
            bool afi3notnull = true;

            foreach (ActionsFillerItem AFI3 in this.ActionsFiller1)
            {
                if (afi3notnull)
                {
                    if (AFI3.Quantity <= 0)
                    {
                        afi3notnull = false;
                        break;
                    }
                }
            }

            if (!afi3notnull)
            {
                this.ShowMessageBox("В одном или более полей значение количества менее, либо равно 0", "Ошибка заполнения", MessageBoxOption.Ok);

            }

            else
            {
                if (Actions1.SelectedItem.SkladiItem != null && ActionsFiller1.Count > 0)
                {

                    foreach (ActionsFillerItem AFI in this.ActionsFiller1)
                    {
                        foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                        {

                            if (Actions1.SelectedItem.SkladiItem == MAGQI.SkladiItem && AFI.MatsAndGoodsItem == MAGQI.MatsAndGoodsItem)
                            {

                                if (AFI.Quantity > MAGQI.Quantity)
                                {
                                    All += AFI.MatsAndGoodsItem.Name.ToString() + "\n" + "    В запросе: " + AFI.Quantity.ToString() + "\n" + "    На складе: " + MAGQI.Quantity.ToString() + "\n";

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
                    //NewActionHC.DialogOk();
                    //foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                    //{
                    //    foreach (ActionsFillerItem AFI4 in this.ActionsFiller1)
                    //    {
                    //        foreach (ActionsItem AI in this.Actions1)
                    //        {
                    //            if (MAGQI.SkladiItem == AI.SkladiItem && MAGQI.MatsAndGoodsItem == AFI4.MatsAndGoodsItem)
                    //            {
                    //                MAGQI.Quantity -= AFI4.Quantity;
                    //            }
                    //        }
                    //    }
                    //}

                    //this.Save();
                    //this.Refresh();
                }

            }
        }

        partial void NewActionCancel_Execute()
        {
            NewActionHC.DialogCancel();
            this.DataWorkspace.skladData.Details.DiscardChanges();

        }

        partial void ActionsItemListEditSelected_CanExecute(ref bool result)
        {
            // Добавьте сюда свой код.

        }

        partial void ActionsItemListEditSelected_Execute()
        {
            

        }

        partial void OkApply_Execute()
        {
            if (Actions1.SelectedItem.SkladiItem != null && ActionsFiller1.Count > 0)
            {
                NewActionHC.DialogOk();
                foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                {
                    foreach (ActionsFillerItem AFI4 in this.ActionsFiller1)
                    {
                        foreach (ActionsItem AI in this.Actions1)
                        {
                            if (MAGQI.SkladiItem == AI.SkladiItem && MAGQI.MatsAndGoodsItem == AFI4.MatsAndGoodsItem)
                            {
                                MAGQI.Quantity -= AFI4.Quantity;
                            }
                        }
                    }
                }
                this.CloseModalWindow("Apply");
                this.Save();
                this.Refresh();
            }

        }

        partial void CancelApply_Execute()
        {
            this.CloseModalWindow("Apply");

        }

        partial void SearchDefault_Execute()
        {
            this.CreationDateLess = null;
            this.CreationDateMore = null;
            this.SkladName = null;

        }

        partial void SearchClose_Execute()
        {
            this.CloseModalWindow("Search");

        }




    }
}
