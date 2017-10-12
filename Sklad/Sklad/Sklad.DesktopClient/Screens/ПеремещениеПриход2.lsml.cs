using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using Microsoft.LightSwitch.Details;

namespace LightSwitchApplication
{
    public partial class ПеремещениеПриход2
    {
        partial void FinishMove_Execute()
        { 
            
            try
            {
                if (this.Actions.SelectedItem.Status == "Отправлен")
                {
                    this.OpenModalWindow("Apply");
                    //this.Actions.SelectedItem.Status = "Завершен";
                    //this.Actions.SelectedItem.RealiationDate = DateTime.Today;
                    //foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                    //{
                    //    foreach (ActionsFillerItem AFI4 in this.ActionsFiller)
                    //    {
                    //            if (MAGQI.SkladiItem == this.Actions.SelectedItem.SkladiItem1 && MAGQI.MatsAndGoodsItem == AFI4.MatsAndGoodsItem)
                    //            {
                    //                MAGQI.Quantity += AFI4.Quantity;
                    //            }
                    //    }
                    //}

                    //this.Save();
                    //this.Refresh();
                }
            }
            catch
            {

            }

        }

        partial void OkApply_Execute()
        {
            if (this.Actions.SelectedItem.Status == "Отправлен")
            {
                this.Actions.SelectedItem.Status = "Завершен";
                this.Actions.SelectedItem.RealiationDate = DateTime.Today;
                foreach (MatsAndGoodsQuantitiesItem MAGQI in this.DataWorkspace.skladData.MatsAndGoodsQuantities)
                {
                    foreach (ActionsFillerItem AFI4 in this.ActionsFiller)
                    {
                        if (MAGQI.SkladiItem == this.Actions.SelectedItem.SkladiItem1 && MAGQI.MatsAndGoodsItem == AFI4.MatsAndGoodsItem)
                        {
                            MAGQI.Quantity += AFI4.Quantity;
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
            this.NumberDirect = null;
            this.NumberIn = null;
            this.Status = null;
            this.CreationDateLess = null;
            this.CreationDateMore = null;
            this.SkladNameIn = null;
            this.SkladNameOut = null;

        }

        partial void SearchClose_Execute()
        {
            this.CloseModalWindow("Search");

        }

        //partial void ПеремещениеПриход2_Saving(ref bool handled)
        //{
        //    handled = true;
        //    try
        //    {
        //        this.DataWorkspace.skladData.SaveChanges();
        //    }
        //    catch (ConcurrencyException e)
        //    {
        //        foreach 
        //    }

        //}
    }
}
