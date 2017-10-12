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

    public partial class ОтчетКоличества
    {
        private ModalWindow WaybillHC;
        private ModalWindow QuantsHC;


        partial void ОтчетКоличества_Created()
        {
            WaybillHC.Initialise();
            QuantsHC.Initialise();
        }

        partial void ОтчетКоличества_Saving(ref bool handled)
        {
            this.DataWorkspace.skladData.Details.DiscardChanges();
            handled = true;
        }


        partial void ОтчетКоличества_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            QuantsHC = new ModalWindow(this.Actions1, "Quants", "123");
            WaybillHC = new ModalWindow(this.Actions, "Waybill", "накладную");
            TotalNum();
        }


        private void TotalNum()
        {
            foreach (MatsAndGoodsItem MA in this.MatsAndGoods)
            {
                MA.TotalQuantityNeeded = 0;
                MA.TotalQuantity = 0;
                MA.TotalQuantityDifference = 0;
            }

            foreach (MatsAndGoodsItem MAGI in this.MatsAndGoods)
            {
                IDForTotalNum = MAGI.ID;
                foreach (MatsAndGoodsQuantitiesItem MAGQI in this.MatsAndGoodsQuantities)
                {
                    MAGI.TotalQuantity += Convert.ToDecimal(MAGQI.Quantity);
                }
            }
            IDForTotalNum = null;

            foreach (MatsAndGoodsItem MA in this.MatsAndGoods1)
            {
                MA.TotalQuantityNeeded = 0;
                MA.TotalQuantity = 0;
                MA.TotalQuantityDifference = 0;
            }

            foreach (MatsAndGoodsItem MAGI in this.MatsAndGoods1)
            {
                IDForTotalNum = MAGI.ID;
                foreach (MatsAndGoodsQuantitiesItem MAGQI in this.MatsAndGoodsQuantities)
                {
                    MAGI.TotalQuantity += Convert.ToDecimal(MAGQI.Quantity);
                }
            }
            IDForTotalNum = null;
        }
        private void MAGICalc(MatsAndGoodsItem M, decimal count)
        {
            // decimal count = Math.Round((Convert.ToDecimal(M.TotalQuantityNeeded - M.TotalQuantity) > 0) ? Convert.ToDecimal(M.TotalQuantityNeeded - M.TotalQuantity) : 0 ,2);
            foreach (RecipesItem RI in this.Recipes)//цикл по рецептам
            {
                if (RI.MatsAndGoodsItem.ID == M.ID)//если  рецепт и изделие совпадают
                {

                    IDRecipe = RI.ID; //сортировка для компонентов, что бы найти компоненты только этого рецепта
                    bool ActDeeper = false;
                    foreach (RecipesComponentsItem RCI in this.RecipesComponents)// цикл по компонентам рецепта
                    {
                        foreach (RecipesItem RI1 in this.Recipes)// проверка нет ли у компонента рецепта
                        {

                            if (RCI.MatsAndGoodsItem.ID == RI1.MatsAndGoodsItem.ID)
                            {

                                ActDeeper = true;
                                IDRecipe = null;
                                foreach (MatsAndGoodsItem MM in this.MatsAndGoods2)
                                {
                                    if (RCI.MatsAndGoodsItem == MM)
                                    {
                                        MM.TotalQuantityNeeded = Math.Round(Convert.ToDecimal(MM.TotalQuantityNeeded + M.TotalQuantityNeeded * RCI.Quantity), 1);

                                        MAGICalc(RI1.MatsAndGoodsItem, Math.Round(Convert.ToDecimal(count * RCI.Quantity), 0));
                                        break;
                                    }
                                }
                                break;
                            }
                            ActDeeper = false;
                        }
                        if (!ActDeeper)
                        {
                            foreach (MatsAndGoodsItem MAGI1 in this.MatsAndGoods1)//цикл по списку для добавления компонентов на закупку
                            {
                                if (RCI.MatsAndGoodsItem.ID == MAGI1.ID)// если компонент совпадает со списком
                                {
                                    MAGI1.TotalQuantityNeeded += Math.Round(Convert.ToDecimal(RCI.Quantity * count), 0);//прибавить
                                    break;
                                }
                            }
                        }
                        //else
                        //{
                        //    foreach (MatsAndGoodsItem MAG in this.MatsAndGoods2)
                        //    {
                        //        if (MAG.ID == RCI.MatsAndGoodsItem.ID)
                        //        {
                        //            MAGICalc(MAG);
                        //            break;

                        //        }
                        //    }
                        //}
                    }

                }
                IDRecipe = null;

            }
        }

       
        partial void Calculate_Execute()
        {
            foreach (MatsAndGoodsItem MAG in this.MatsAndGoods1)//обнуление количества закупаемых материалов
            {
                MAG.TotalQuantityNeeded = 0;
            }
            foreach (MatsAndGoodsItem MAGI in this.MatsAndGoods)
            {
                if (MAGI.Category == "Блок")
                {

                }
                else if (MAGI.Category == "Готовое изделие")
                {
                    MAGICalc(MAGI, Math.Round((Convert.ToDecimal(MAGI.TotalQuantityNeeded - MAGI.TotalQuantity) > 0) ? Convert.ToDecimal(MAGI.TotalQuantityNeeded - MAGI.TotalQuantity) : 0, 0));
                }

            }
            foreach (MatsAndGoodsItem MAG in this.MatsAndGoods)
            {
                MAG.TotalQuantityDifference = Math.Round((Convert.ToDecimal(MAG.TotalQuantityNeeded - MAG.TotalQuantity) > 0) ? Convert.ToDecimal(MAG.TotalQuantityNeeded - MAG.TotalQuantity) : 0, 0);
            }

            foreach (MatsAndGoodsItem MAG in this.MatsAndGoods1)
            {
                MAG.TotalQuantityDifference = Math.Round((Convert.ToDecimal(MAG.TotalQuantityNeeded - MAG.TotalQuantity) > 0) ? Convert.ToDecimal(MAG.TotalQuantityNeeded - MAG.TotalQuantity) : 0, 0);
            }


        }


        partial void Clear_Execute()
        {
            foreach (MatsAndGoodsItem M1 in this.MatsAndGoods)
            {
                M1.TotalQuantityNeeded = 0;
                M1.TotalQuantityDifference = 0;

            }
            foreach (MatsAndGoodsItem M2 in this.MatsAndGoods1)
            {
                M2.TotalQuantityNeeded = 0;
                M2.TotalQuantityDifference = 0;
            }
        }


        


        partial void HideZero_Execute()
        {
            WaybillHC.AddEntity();
            this.FindControl("Waybill").DisplayName = "";
            foreach (MatsAndGoodsItem MAGI in this.MatsAndGoods1)
            {
                if (MAGI.TotalQuantityNeeded > 0)
                {
                    var newMag = this.ActionsFiller.AddNew();
                    newMag.MatsAndGoodsItem = MAGI;

                    newMag.Quantity1 = Math.Round(Convert.ToDecimal(MAGI.TotalQuantity), 0);
                    newMag.Quantity2 = Math.Round(Convert.ToDecimal(MAGI.TotalQuantityNeeded), 0);

                    newMag.Quantity = Math.Round(Convert.ToDecimal(MAGI.TotalQuantityDifference), 0);
                }
            }
            //foreach (MatsAndGoodsItem M3 in this.MatsAndGoods1)
            //{
            //    if (M3.TotalQuantityNeeded==0)
            //    {

            //        //this.MatsAndGoods1.

            //        this.FindControlInCollection("Name1", M3).IsVisible = false;

            //        this.FindControlInCollection("Unit", M3).IsVisible = false;
            //        this.FindControlInCollection("TotalQuantity1", M3).IsVisible = false;
            //        this.FindControlInCollection("TotalQuantityNeeded1", M3).IsVisible = false;
            //        this.FindControlInCollection("TotalQuantityDifference1", M3).IsVisible = false;

            //    }
            //}

        }

        partial void CloseWaybill_Execute()
        {
            WaybillHC.DialogCancel();

        }

        private void CreateDetailedReport()
        {
            List<List<MatsAndGoodsItem>> Matsng = new List<List<MatsAndGoodsItem>>();
            List<MatsAndGoodsItem> materials = new List<MatsAndGoodsItem>();

            //foreach

        }


         private string ColumnIndexToColumnLetter(int colIndex)
         {
             int div = colIndex;
             string colLetter = String.Empty;
             int mod = 0;

             while (div > 0)
             {
                 mod = (div - 1) % 26;
                 colLetter = (char)(65 + mod) + colLetter;
                 div = (int)((div - mod) / 26);
             }
             return colLetter;
         }



         partial void HideZero_CanExecute(ref bool result)
         {
             result = WaybillHC.CanAdd();


         }

         partial void QuantsCompute_Execute()
         {
             QuantsHC.AddEntity();
             this.FindControl("Quants").DisplayName = "";
             foreach (MatsAndGoodsItem MAG in this.MatsAndGoods)
             {
                 if (MAG.Category == "Готовое изделие" && MAG.TotalQuantityNeeded >0)
                 {
                     var newMag = this.ActionsFiller1.AddNew();
                     newMag.MatsAndGoodsItem = MAG;
                     decimal tmp = Math.Round(Convert.ToDecimal(MAG.TotalQuantityNeeded), 0);
                     newMag.Quantity = tmp;

                     MAGICalc2(MAG, tmp, QuantsHC);
                     
                 }
             }

         }


         private void MAGICalc2(MatsAndGoodsItem M, decimal count, ModalWindow quants)
         {
             // decimal count = Math.Round((Convert.ToDecimal(M.TotalQuantityNeeded - M.TotalQuantity) > 0) ? Convert.ToDecimal(M.TotalQuantityNeeded - M.TotalQuantity) : 0 ,2);
             foreach (RecipesItem RI in this.Recipes)//цикл по рецептам
             {
                 if (RI.MatsAndGoodsItem.ID == M.ID)//если  рецепт и изделие совпадают
                 {

                     IDRecipe = RI.ID; //сортировка для компонентов, что бы найти компоненты только этого рецепта
                     bool ActDeeper = false;
                     foreach (RecipesComponentsItem RCI in this.RecipesComponents)// цикл по компонентам рецепта
                     {
                         var newMag1 = this.ActionsFiller1.AddNew();
                         newMag1.MatsAndGoodsItem = RCI.MatsAndGoodsItem;
                         decimal tmp = Math.Round(Convert.ToDecimal(RCI.Quantity) * count, 0);
                         newMag1.Quantity = tmp;

                         foreach (RecipesItem RI1 in this.Recipes)// проверка нет ли у компонента рецепта
                         {

                             if (RCI.MatsAndGoodsItem.ID == RI1.MatsAndGoodsItem.ID)
                             {

                                 ActDeeper = true;
                                 IDRecipe = null;
                                 foreach (MatsAndGoodsItem MM in this.MatsAndGoods2)
                                 {
                                     if (RCI.MatsAndGoodsItem == MM)
                                     {
                                         MAGICalc2(RI1.MatsAndGoodsItem, tmp, quants);
                                         break;
                                     }
                                 }
                                 break;
                             }
                             ActDeeper = false;
                         }
                         //if (!ActDeeper)
                         //{
                         //    foreach (MatsAndGoodsItem MAGI1 in this.MatsAndGoods1)//цикл по списку для добавления компонентов на закупку
                         //    {
                         //        if (RCI.MatsAndGoodsItem.ID == MAGI1.ID)// если компонент совпадает со списком
                         //        {
                         //            MAGI1.TotalQuantityNeeded += Math.Round(Convert.ToDecimal(RCI.Quantity * count), 0);//прибавить
                         //            break;
                         //        }
                         //    }
                         //}
                     }

                 }
                 IDRecipe = null;

             }
         }
         partial void QuantsCompute_CanExecute(ref bool result)
         {
             result = QuantsHC.CanAdd();

         }

         partial void CloseQuants_Execute()
         {
             QuantsHC.DialogCancel();

         }

         partial void ОтчетКоличества_Closing(ref bool cancel)
         {
             this.DataWorkspace.skladData.Details.DiscardChanges();

         }
    }
    
}



