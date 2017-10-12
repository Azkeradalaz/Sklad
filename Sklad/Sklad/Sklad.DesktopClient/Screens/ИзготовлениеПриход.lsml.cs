using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
namespace LightSwitchApplication
{
    public partial class ИзготовлениеПриход
    {
        partial void FinishCraft_Execute()
        {
            
            try
            {
                if (this.CraftAction.SelectedItem.Status == "Изготавливается")
                {
                //    this.CraftAction.SelectedItem.Status = "Завершен";
                //    this.CraftAction.SelectedItem.DateRealisation = DateTime.Today;
                //    foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                //    {
                //        foreach (CraftItem CI in this.Craft)
                //        {
                //            if (CI.RecipesItem.MatsAndGoodsItem == MAGQI.MatsAndGoodsItem && this.CraftAction.SelectedItem.SkladiItem == MAGQI.SkladiItem)
                //            {
                //                MAGQI.Quantity += CI.Quantity;

                //            }

                //        }
                //    }
                //    this.Save();
                //    this.Refresh();
                 this.OpenModalWindow("Apply");
                }
                
            }
            catch
            {

            }

        }

        partial void OkApply_Execute()
        {
            if (this.CraftAction.SelectedItem.Status == "Изготавливается")
            {
                this.CraftAction.SelectedItem.Status = "Завершен";
                this.CraftAction.SelectedItem.DateRealisation = DateTime.Today;
                foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                {
                    foreach (CraftItem CI in this.Craft)
                    {
                        if (CI.RecipesItem.MatsAndGoodsItem == MAGQI.MatsAndGoodsItem && this.CraftAction.SelectedItem.SkladiItem == MAGQI.SkladiItem)
                        {
                            MAGQI.Quantity += CI.Quantity;

                        }

                    }
                }
                this.CloseModalWindow("Apply");
                this.Save();
                this.Refresh();
            }

        }

        partial void CancelAppy_Execute()
        {
            this.CloseModalWindow("Apply");
            // Добавьте сюда свой код.

        }

        partial void ИзготовлениеПриход_Saving(ref bool handled)
        {
            // Добавьте сюда свой код.

        }

        partial void SearchDefault_Execute()
        {
            this.Status = null;
            this.SkladName = null;
            this.DateCreationLess = null;
            this.DateCreation = null;
            this.ResponsibleName = null;

        }

        partial void SearchClose_Execute()
        {
            this.CloseModalWindow("Search");

        }
    }
}
           