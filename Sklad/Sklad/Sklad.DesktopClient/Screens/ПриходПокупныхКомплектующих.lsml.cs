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
    public partial class ПриходПокупныхКомплектующих
    {
        partial void Actions_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //ActionsFiller1.SelectedItem.PriceTotal = ActionsFiller1.SelectedItem.PricePerUnit * ActionsFiller1.SelectedItem.Quantity;
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                ActionsItem AI = (ActionsItem)e.NewItems[0];
                AI.Action = "Накладная";
                AI.Status = "Приход";
                AI.SkladiItem = null;
            }
        }

        partial void ActionsFiller1_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //foreach (ActionsFillerItem AFI3 in this.ActionsFiller1)
            //{
            //    AFI3.PriceTotal = AFI3.Quantity * AFI3.PricePerUnit;
            //}

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                ActionsFillerItem AFI = (ActionsFillerItem)e.NewItems[0];
                AFI.Quantity = 1;
                AFI.PricePerUnit = 0;
                AFI.PriceTotal = AFI.Quantity * AFI.PricePerUnit;

            }

            
                
        }

        private ModalWindow NewActionHC;

        partial void ПриходПокупныхКомплектующих_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            NewActionHC = new ModalWindow(this.Actions1, "NewAction", "накладную");
        }

        partial void ПриходПокупныхКомплектующих_Created()
        {
            NewActionHC.Initialise();
        }

        partial void ActionsItemListAddAndEditNew_CanExecute(ref bool result)
        {
            result = NewActionHC.CanAdd();
            

        }

        #region Add new entity with selected data

        partial void ActionsItemListAddAndEditNew_Execute()
        {
            NewActionHC.AddEntity();

        }

        partial void AddAsWas_Execute()
        {
            NewActionHC.AddEntity();
            this.Actions1.SelectedItem.Number = this.Actions.SelectedItem.Number;
            this.Actions1.SelectedItem.CreationDate = this.Actions.SelectedItem.CreationDate;
            this.Actions1.SelectedItem.RealiationDate = this.Actions.SelectedItem.RealiationDate;
            this.Actions1.SelectedItem.SkladiItem1 = this.Actions.SelectedItem.SkladiItem1;
            this.Actions1.SelectedItem.SuppliersItem = this.Actions.SelectedItem.SuppliersItem;
            this.Actions1.SelectedItem.Price = this.Actions.SelectedItem.Price;
            this.Actions1.SelectedItem.Note = this.Actions.SelectedItem.Note;

            foreach (ActionsFillerItem AFI in this.ActionsFiller)
            {
                var NAFI = this.ActionsFiller1.AddNew();
                NAFI.MatsAndGoodsItem = AFI.MatsAndGoodsItem;
                NAFI.Quantity = AFI.Quantity;
                NAFI.PricePerUnit = AFI.PricePerUnit;
                NAFI.PriceTotal = AFI.PriceTotal;
                
            }
        }

        #endregion

        partial void AddAsWas_CanExecute(ref bool result)
        {
            result = NewActionHC.CanAdd();

        }

        partial void NewActionOk_Execute()
        {
           

            if (Actions1.SelectedItem.Number != null &&
              Actions1.SelectedItem.SkladiItem1 != null &&
              Actions1.SelectedItem.SuppliersItem != null &&
              Actions1.SelectedItem.CreationDate != null &&
              Actions1.SelectedItem.RealiationDate != null &&
              Actions1.SelectedItem.Price != null)
            {
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
                    this.OpenModalWindow("Apply");
                }

            }
            else
            {
                //добавить окно с подсказкой
            }
            //foreach (ActionsFillerItem AFI3 in this.ActionsFiller1)
            //{
            //    AFI3.PriceTotal = AFI3.Quantity * AFI3.PricePerUnit;
            //}

            //if (Actions1.SelectedItem.Number!= null && 
            //    Actions1.SelectedItem.SkladiItem1 != null && 
            //    Actions1.SelectedItem.SuppliersItem != null && 
            //    Actions1.SelectedItem.CreationDate!= null &&
            //    Actions1.SelectedItem.RealiationDate!= null &&
            //    Actions1.SelectedItem.Price != null) 
            //{ 

            //    NewActionHC.DialogOk();
            //    foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities){
            //        foreach (ActionsFillerItem AFI4 in this.ActionsFiller1)
            //        {
            //            foreach (ActionsItem AI in this.Actions1)
            //            {
            //                if (MAGQI.SkladiItem == AI.SkladiItem1 && MAGQI.MatsAndGoodsItem == AFI4.MatsAndGoodsItem)
            //                {
            //                    MAGQI.Quantity += AFI4.Quantity;
            //                }
            //            }
            //        }
            //    }

            //    this.Save();
            //    this.Refresh();
            //}

        }

        partial void NewActionCancel_Execute()
        {
            NewActionHC.DialogCancel();
            this.DataWorkspace.skladData.Details.DiscardChanges();

        }

        partial void Total_Execute()
        {
            this.Actions1.SelectedItem.Price = 0;

            foreach (ActionsFillerItem AFI in this.ActionsFiller1)
            {
                AFI.PriceTotal = AFI.PricePerUnit * AFI.Quantity;
                this.Actions1.SelectedItem.Price += AFI.PriceTotal;
            }


        }

        partial void OkApply_Execute()
        {
            
            foreach (ActionsFillerItem AFI3 in this.ActionsFiller1)
            {
                AFI3.PriceTotal = AFI3.Quantity * AFI3.PricePerUnit;
            }

            if (Actions1.SelectedItem.Number != null &&
                Actions1.SelectedItem.SkladiItem1 != null &&
                Actions1.SelectedItem.SuppliersItem != null &&
                Actions1.SelectedItem.CreationDate != null &&
                Actions1.SelectedItem.RealiationDate != null &&
                Actions1.SelectedItem.Price != null)
            {


                foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                {
                    foreach (ActionsFillerItem AFI4 in this.ActionsFiller1)
                    {
                        foreach (ActionsItem AI in this.Actions1)
                        {
                            if (MAGQI.SkladiItem == AI.SkladiItem1 && MAGQI.MatsAndGoodsItem == AFI4.MatsAndGoodsItem)
                            {
                                MAGQI.Quantity += AFI4.Quantity;
                            }
                        }
                    }
                }
                this.CloseModalWindow("Apply");
                NewActionHC.DialogOk();
                this.Save();
                this.Refresh();
            }

        }

        partial void CancelApply_Execute()
        {
            this.CloseModalWindow("Apply");
            // Добавьте сюда свой код.

        }

        partial void SearchDefault_Execute()
        {
            this.NumberDirect = null;
            this.NumberIn = null;
            this.Name = null;
            this.SkladName = null;
            this.CreationDateLess = null;
            this.CreationDateMore = null;
            this.PriceLess = null;
            this.PriceMore = null;
            this.SuppName = null;

        }

        partial void SearchClose_Execute()
        {
            this.CloseModalWindow("Search");

        }

       

        



    }
}
