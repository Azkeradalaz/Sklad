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
    public partial class ОстаткиПоСпецификациям
    {
        partial void ОстаткиПоСпецификациям_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            //ComputeProps();
        }

        //private void ComputeProps()
        //{
        //    foreach (RecipesItem RI in this.Recipes)
        //    {
        //        foreach (RecipesComponentsItem RCI in this.RecipesComponents)
        //        {
        //            if (RCI.RecipesItem == RI)
        //            {
        //                foreach (MatsAndGoodsQuantitiesItem MAGQI in this.MatsAndGoodsQuantities)
        //                {
        //                    if (RI.MatsAndGoodsItem == MAGQI.MatsAndGoodsItem)
        //                    {
        //                        RCI.QuantitySkladiString += MAGQI.SkladiItem.Name + ": " + MAGQI.Quantity.ToString();
        //                        RCI.QuantityAll += MAGQI.Quantity;


        //                    }
        //                }
        //            }
        //        }


        //    }


        //}


    }
}
