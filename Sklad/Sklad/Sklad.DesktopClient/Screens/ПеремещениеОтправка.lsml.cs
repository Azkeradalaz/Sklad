using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using OfficeIntegration.Resources;

namespace LightSwitchApplication
{
    public partial class ПеремещениеОтправка
    {
        partial void Actions_Changed(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                ActionsItem AI = (ActionsItem)e.NewItems[0];
                AI.Action = "Перемещение";
                AI.Status = "Отправлен";
                AI.SuppliersItem = null;

            }
        }


        private ModalWindow NewActionHC;



        partial void ПеремещениеОтправка_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            NewActionHC = new ModalWindow(this.Actions1, "NewAction", "перемещение");
        }

        partial void ПеремещениеОтправка_Created()
        {
            this.SuppressEnterKeyForControl("Actions1_SelectedItem_Number");
            this.SuppressEnterKeyForControl("Actions1_SelectedItem_CreationDate");
            this.SuppressEnterKeyForControl("Actions1_SelectedItem_SkladiItem");
            this.SuppressEnterKeyForControl("Actions1_SelectedItem_SkladiItem1");  
            this.SuppressEnterKeyForControl("Actions1_SelectedItem_Note1");

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
            if (Actions1.SelectedItem.CreationDate != null
                && Actions1.SelectedItem.SkladiItem != null
                && Actions1.SelectedItem.SkladiItem1 != null
                && this.ActionsFiller1.Count > 0
                && this.Actions1.SelectedItem.SkladiItem != this.Actions1.SelectedItem.SkladiItem1
                && this.Actions1.SelectedItem.Number != null)
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
                    //NewActionHC.DialogOk();
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

        partial void ActionsItemListDeleteSelected_CanExecute(ref bool result)
        {
            // Добавьте сюда свой код.

        }

        partial void ActionsItemListDeleteSelected_Execute()
        {
            if (this.Actions.SelectedItem != null && this.Actions.SelectedItem.Status == "Отправлен")
            {
                foreach (ActionsFillerItem AFI in this.ActionsFiller)
                {
                    foreach(MatsAndGoodsQuantitiesItem MAGI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                    {
                        if (MAGI.SkladiItem == this.Actions.SelectedItem.SkladiItem && MAGI.MatsAndGoodsItem == AFI.MatsAndGoodsItem)
                        {
                            MAGI.Quantity += AFI.Quantity;
                            break;
                        }

                    }
                }
                this.Actions.SelectedItem.Status = "Удален";         
                this.Save();
                this.Refresh();
            }
            

        }

        partial void OkApply_Execute()
        {
            if (Actions1.SelectedItem.CreationDate != null 
                && Actions1.SelectedItem.SkladiItem != null 
                && Actions1.SelectedItem.SkladiItem1 != null 
                && this.ActionsFiller1.Count > 0
                && this.Actions1.SelectedItem.SkladiItem != this.Actions1.SelectedItem.SkladiItem1
                && this.Actions1.SelectedItem.Number != null)
            {
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
                NewActionHC.DialogOk();
                this.Save();
                this.Refresh();
            }
            
            

        }

        partial void CancelApply_Execute()
        {
            this.CloseModalWindow("Apply");

        }

        partial void ПеремещениеОтправка_Saving(ref bool handled)
        {
            // Добавьте сюда свой код.

        }

        partial void SearchDefault_Execute()
        {
            this.NumberDirect = null;
            this.NumberIn = null;
            this.Status = null;
            this.CreationDateLess = null;
            this.CreationDateMore = null;
            this.SkladInName = null;
            this.SkladOutName = null; 

        }

        partial void SearchClose_Execute()
        {
            this.CloseModalWindow("Search");

        }

        
        partial void AddAsWas_CanExecute(ref bool result)
        {
            result = NewActionHC.CanAdd();
        }



        partial void AddAsWas_Execute()
        {

            NewActionHC.AddEntity();
            this.Actions1.SelectedItem.Number = this.Actions.SelectedItem.Number;
            this.Actions1.SelectedItem.CreationDate = this.Actions.SelectedItem.CreationDate;
            this.Actions1.SelectedItem.RealiationDate = this.Actions.SelectedItem.RealiationDate;
            this.Actions1.SelectedItem.SkladiItem = this.Actions.SelectedItem.SkladiItem;
            this.Actions1.SelectedItem.SkladiItem1 = this.Actions.SelectedItem.SkladiItem1;
            this.Actions1.SelectedItem.SuppliersItem = this.Actions.SelectedItem.SuppliersItem;
            this.Actions1.SelectedItem.Note = this.Actions.SelectedItem.Note; 

            foreach (ActionsFillerItem AFI in this.ActionsFiller)
            {
                var NAFI = this.ActionsFiller1.AddNew();
                NAFI.MatsAndGoodsItem = AFI.MatsAndGoodsItem;
                NAFI.Quantity = AFI.Quantity;
                NAFI.PricePerUnit = AFI.PricePerUnit;
            }





        }

        partial void Excel_Execute() // вывод содержимого в накладную
        {
            //адрес и название файла
            string msDoc = "C:/Sklad/templates/Waybill.doc";

            if (File.Exists(msDoc))
            {
               
                //формирование списка выводимых аргументов
                List<OfficeIntegration.ColumnMapping> custFields = new List<OfficeIntegration.ColumnMapping>();
                custFields.Add(new OfficeIntegration.ColumnMapping("НомерНакладной", "Number"));
                custFields.Add(new OfficeIntegration.ColumnMapping("склад_отправитель", "SkladiItem"));
                custFields.Add(new OfficeIntegration.ColumnMapping("склад_получатель", "SkladiItem1"));
                custFields.Add(new OfficeIntegration.ColumnMapping("дата_число", "day"));
                custFields.Add(new OfficeIntegration.ColumnMapping("дата_месяц", "month"));
                custFields.Add(new OfficeIntegration.ColumnMapping("дата_год", "year"));
                //вывод аргументов
                dynamic doc = OfficeIntegration.Word.GenerateDocument(msDoc, this.Actions.SelectedItem, custFields);



                //формирование списка выводимых вторичных аргументов
                List<OfficeIntegration.ColumnMapping> orderFields = new List<OfficeIntegration.ColumnMapping>();
                orderFields.Add(new OfficeIntegration.ColumnMapping("Название", "MatsAndGoodsItem"));
                orderFields.Add(new OfficeIntegration.ColumnMapping("Ед. измерения", "MAGed"));
                orderFields.Add(new OfficeIntegration.ColumnMapping("Количество", "Quantity"));
                //вывод вторичных аргументов
                OfficeIntegration.Word.ExportEntityCollection(doc, "OrderTable", 2, false, this.Actions.SelectedItem.ActionsFiller,orderFields);

            }
        }  
    }
}
