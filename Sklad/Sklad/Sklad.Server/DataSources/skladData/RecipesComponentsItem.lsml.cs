using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class RecipesComponentsItem
    {

        partial void QuantitySkladiString_Compute(ref string result)
        {
            string tmp = "";
            bool first = true;
            string tmpFormat = "";
            foreach (MatsAndGoodsQuantitiesItem MAGQI in DataWorkspace.skladData.MatsAndGoodsQuantities)
            {
                
                if (MAGQI.MatsAndGoodsItem.ID == MatsAndGoodsItem.ID && MAGQI.SkladiItem.Status == "Функционирует")
                {
                    if (!first) { tmpFormat = "\n"; }
                    tmp += tmpFormat + MAGQI.SkladiItem.Name + ": " + MAGQI.Quantity.ToString();
                    if (first)
                        first = false;
                }
                
            }
            result = tmp;

        }

        partial void QuantityAll_Compute(ref decimal? result)
        {
            decimal tmp = 0;
            foreach (MatsAndGoodsQuantitiesItem MAGQI in DataWorkspace.skladData.MatsAndGoodsQuantities)
            {
                if (MAGQI.MatsAndGoodsItem.ID == MatsAndGoodsItem.ID && MAGQI.SkladiItem.Status == "Функционирует")
                {
                    tmp += (decimal)MAGQI.Quantity;
                }
            }
            result = tmp;

        }

    }
}
