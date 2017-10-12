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
    public partial class Application
    {


        //partial void Блоки_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewBloki))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}
        //partial void ГотовыеИзделия_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewProducts))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void ИзготовлениеОтправка_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewCraftOut))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void ИзготовлениеПриход_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewCraftIn))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void Материалы_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewMaterials))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}
        //partial void Остатки_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewRemains))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void ПеремещениеОтправка_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewMoveOut))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void ПеремещениеПриход2_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewMoveIn))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void Поставщики_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewSuppliers))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void ПриходПокупныхКомплектующих_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewWayBills))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void Склады_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewStorages))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void Спецификации_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewRecipes))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void Списание_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewDefect))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //}

        //partial void ОтчетКоличества_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewQuantitiesReport))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }


        //}

        //partial void MatsAndGoodsListDetail_CanRun(ref bool result)
        //{
        //    if (Current.User.HasPermission(Permissions.ViewAdminRed))
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }

        //}

    }
   
}
