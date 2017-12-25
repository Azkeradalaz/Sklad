using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class ActionsItem
    {
        partial void day_Compute(ref string result)
        {
            if (CreationDate.Day.ToString().Length != 1)
            { 
                result = CreationDate.Day.ToString();
            }
            else
            {
                result = "0" + CreationDate.Day.ToString();
            }
        }

        partial void month_Compute(ref string result)
        {
            int i = CreationDate.Month;
            switch (i)
            {
                case 1: result = "января";
                    break;
                case 2: result = "февраля";
                    break;
                case 3: result = "марта";
                    break;
                case 4: result = "апреля";
                    break;
                case 5: result = "мая";
                    break;
                case 6: result = "июня";
                    break;
                case 7: result = "июля";
                    break;
                case 8: result = "августа";
                    break;
                case 9: result = "сентября";
                    break;
                case 10: result = "октября";
                    break;
                case 11: result = "ноября";
                    break;
                case 12: result = "декабря";
                    break;
            }
        }

        partial void year_Compute(ref string result)
        {
            result = CreationDate.Year.ToString();

        }
    }
}
