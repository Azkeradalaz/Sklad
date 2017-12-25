using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class MatsAndGoodsPricesItem
    {
        partial void SupplyOnSklads_Compute(ref string result)
        {
            string tmp = "";
            bool first = true;
            string tmpFormat = "";
            foreach (MatsAndGoodsQuantitiesItem MAGQI in DataWorkspace.skladData.MatsAndGoodsQuantities)
            {
                
                if (MAGQI.MatsAndGoodsItem.ID == MatsAndGoodsItem.ID && MAGQI.SkladiItem.Status == "Функционирует")
                {
                    if (MAGQI.MatsAndGoodsItem.Category != "Материал")
                    {
                        result = "";
                        break;
                    }
                    if (!first) { tmpFormat = "\n"; }
                    tmp += tmpFormat + MAGQI.SkladiItem.Name + ": " + MAGQI.Quantity.ToString();
                    if (first)
                        first = false;
                }

            }
            result = tmp;

        }

        partial void SupplyOnSkladsAll_Compute(ref decimal result)
        {
            decimal tmp = 0;
            try
            {
                foreach (MatsAndGoodsQuantitiesItem MAGQI in DataWorkspace.skladData.MatsAndGoodsQuantities)
                {
                    if (MAGQI.MatsAndGoodsItem.Category != "Материал")
                    {
                        result = 0;
                        break;
                    }
                    if (MAGQI.MatsAndGoodsItem.ID == MatsAndGoodsItem.ID && MAGQI.SkladiItem.Status == "Функционирует")
                    {
                        tmp += (decimal)MAGQI.Quantity;
                    }
                }
            }
            catch
            {
                result = tmp;
            }
            result = tmp;

        }

        partial void LastPriceSumm_Compute(ref decimal result)
        {
            decimal tmp = 0;
            if (LastPrice != null)
            {
                tmp = (decimal)(SupplyOnSkladsAll * LastPrice);
            }
            result = tmp;

        }
    }
}
