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

    public partial class ПланированиеЗакупок
    {
        private ModalWindow WaybillHC;
        private ModalWindow QuantsHC;
        private Dictionary<MatsAndGoodsItem, decimal> tmpMAGQright = new Dictionary<MatsAndGoodsItem, decimal>();
        private Dictionary<MatsAndGoodsItem, decimal> tmpMAGQleft = new Dictionary<MatsAndGoodsItem, decimal>();

        partial void ПланированиеЗакупок_Created()
        {
            WaybillHC.Initialise();
            QuantsHC.Initialise();
        }

        partial void ПланированиеЗакупок_Saving(ref bool handled)
        {
            this.DataWorkspace.skladData.Details.DiscardChanges();
            handled = true;
        }


        partial void ПланированиеЗакупок_InitializeDataWorkspace(List<IDataService> saveChangesTo)
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
                tmpMAGQleft.Add(MAGI, Convert.ToDecimal(MAGI.TotalQuantity));
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
                decimal tmpTotalNum = 0;
                foreach (MatsAndGoodsQuantitiesItem MAGQI in this.MatsAndGoodsQuantities)
                {
                    tmpTotalNum += Convert.ToDecimal(MAGQI.Quantity);
                }
                tmpMAGQright.Add(MAGI, tmpTotalNum);
            }
            IDForTotalNum = null;
            foreach (KeyValuePair<MatsAndGoodsItem, decimal> tmpEntry in tmpMAGQright)
            {
                foreach(MatsAndGoodsItem MAG in MatsAndGoods1)
                {
                    if (MAG.ID == tmpEntry.Key.ID)
                    {
                        MAG.TotalQuantity = tmpEntry.Value;
                    }
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

         private Dictionary<MatsAndGoodsItem, decimal> MergeTwoDictionaries(Dictionary<MatsAndGoodsItem, decimal> dicOne, Dictionary<MatsAndGoodsItem, decimal> dicTwo)
         {
             Dictionary<MatsAndGoodsItem, decimal> tmpDic = new Dictionary<MatsAndGoodsItem, decimal>();
             foreach (KeyValuePair<MatsAndGoodsItem, decimal> tmpEntry in dicOne)
             {
                 tmpDic.Add(tmpEntry.Key, tmpEntry.Value);

             }
             foreach (KeyValuePair<MatsAndGoodsItem, decimal> tmpEntry in dicTwo)
             {
                 tmpDic.Add(tmpEntry.Key, tmpEntry.Value);
             }
             return tmpDic;
         }
         


         partial void QuantsCompute_Execute()
         {
             Dictionary<MatsAndGoodsItem, decimal> tmpDic = new Dictionary<MatsAndGoodsItem, decimal>();
             tmpDic = MergeTwoDictionaries(tmpMAGQleft, tmpMAGQright);

             QuantsHC.AddEntity();
             this.FindControl("Quants").DisplayName = "";
             foreach (MatsAndGoodsItem MAG in this.MatsAndGoods)
             {
                     if (MAG.Category == "Готовое изделие" && MAG.TotalQuantityNeeded > 0)
                     {

                         var newMag = this.ActionsFiller1.AddNew();
                         newMag.MatsAndGoodsItem = MAG;
                         decimal tmp = Math.Round(Convert.ToDecimal(MAG.TotalQuantityNeeded), 0);
                         newMag.Quantity = tmp;
                         newMag.PricePerUnit = 1;
                         MAGICalc2(MAG, tmp, QuantsHC, 2, tmpDic);
                     }
                 }
             

         }


         private void MAGICalc2(MatsAndGoodsItem _MAGI, decimal _count, ModalWindow _quants, int _startLevel, Dictionary<MatsAndGoodsItem, decimal> _tmpDic)
         {
         
             // decimal count = Math.Round((Convert.ToDecimal(M.TotalQuantityNeeded - M.TotalQuantity) > 0) ? Convert.ToDecimal(M.TotalQuantityNeeded - M.TotalQuantity) : 0 ,2);
             foreach (RecipesItem RI in this.Recipes)//цикл по рецептам
             {
                 if (RI.MatsAndGoodsItem.ID == _MAGI.ID)//если  рецепт и изделие совпадают
                 {

                     IDRecipe = RI.ID; //сортировка для компонентов, что бы найти компоненты только этого рецепта
                     bool ActDeeper = false;
                     foreach (RecipesComponentsItem RCI in this.RecipesComponents)// цикл по компонентам рецепта
                     {
                         var newMag1 = this.ActionsFiller1.AddNew();
                         newMag1.MatsAndGoodsItem = RCI.MatsAndGoodsItem;
                         decimal tmp = Math.Round(Convert.ToDecimal(RCI.Quantity) * _count, 0);
                         decimal tmp2 = 8008;
                         decimal tmp3 = 80088008;

                         foreach (KeyValuePair<MatsAndGoodsItem, decimal> tmpEntry in _tmpDic)
                         {
                             if (RCI.MatsAndGoodsItem == tmpEntry.Key)
                             {
                                 if (tmpEntry.Value - tmp >= 0)
                                 {
                                     _tmpDic[tmpEntry.Key] = tmpEntry.Value - tmp;
                                     tmp2 = 0;
                                     tmp3 = _tmpDic[tmpEntry.Key];
                                     break;
                                 }
                                 else if (tmpEntry.Value - tmp < 0)
                                 {
                                     _tmpDic[tmpEntry.Key] = 0;
                                     tmp2 = Math.Abs(tmpEntry.Value - tmp);
                                     tmp3 = _tmpDic[tmpEntry.Key];
                                     break;
                                 }
                             }
                         }


                         newMag1.Quantity = tmp;
                         newMag1.Quantity1 = tmp2;
                         newMag1.Quantity2 = tmp3;
                         newMag1.PricePerUnit = _startLevel;
                        

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
                                         MAGICalc2(RI1.MatsAndGoodsItem, tmp, _quants, _startLevel+1, _tmpDic);
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

         partial void ПланированиеЗакупок_Closing(ref bool cancel)
         {
             this.DataWorkspace.skladData.Details.DiscardChanges();

         }
    }
    
}



