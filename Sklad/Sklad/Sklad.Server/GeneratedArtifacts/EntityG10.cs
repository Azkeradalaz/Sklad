﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LightSwitchApplication
{
    #region Entities
    
    /// <summary>
    /// Отсутствует описание модели
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
    public sealed partial class RecipesItem : global::Microsoft.LightSwitch.Framework.Base.EntityObject<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass>
    {
        #region Constructors
    
        /// <summary>
        /// Инициализирует новый экземпляр сущности RecipesItem.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public RecipesItem()
            : this(null)
        {
        }
    
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public RecipesItem(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.RecipesItem> entitySet)
            : base(entitySet)
        {
            global::LightSwitchApplication.RecipesItem.DetailsClass.Initialize(this);
        }
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void RecipesItem_Created();
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void RecipesItem_AllowSaveWithErrors(ref bool result);
    
        #endregion
    
        #region Private Properties
        
        /// <summary>
        /// Получает объект Application для данного приложения.  Объект Application предоставляет доступ к активным экранам, методы для открытых экранов и доступ к текущему пользователю.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::Microsoft.LightSwitch.IApplication<global::LightSwitchApplication.DataWorkspace> Application
        {
            get
            {
                return (global::Microsoft.LightSwitch.IApplication<global::LightSwitchApplication.DataWorkspace>)global::LightSwitchApplication.Application.Current;
            }
        }
        
        /// <summary>
        /// Получает вмещающую рабочую область данных.  Рабочая область данных предоставляет доступ ко всем источникам данных в приложении.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::LightSwitchApplication.DataWorkspace DataWorkspace
        {
            get
            {
                return (global::LightSwitchApplication.DataWorkspace)this.Details.EntitySet.Details.DataService.Details.DataWorkspace;
            }
        }
        
        #endregion
    
        #region Public Properties
    
        /// <summary>
        /// Отсутствует описание модели
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public decimal ID
        {
            get
            {
                return global::LightSwitchApplication.RecipesItem.DetailsClass.GetValue(this, global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.ID);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void ID_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void ID_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void ID_Changed();

        /// <summary>
        /// Отсутствует описание модели
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Nullable<decimal> QuantityDone
        {
            get
            {
                return global::LightSwitchApplication.RecipesItem.DetailsClass.GetValue(this, global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.QuantityDone);
            }
            set
            {
                global::LightSwitchApplication.RecipesItem.DetailsClass.SetValue(this, global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.QuantityDone, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void QuantityDone_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void QuantityDone_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void QuantityDone_Changed();

        /// <summary>
        /// Отсутствует описание модели
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::LightSwitchApplication.MatsAndGoodsItem MatsAndGoodsItem
        {
            get
            {
                return global::LightSwitchApplication.RecipesItem.DetailsClass.GetValue(this, global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.MatsAndGoodsItem);
            }
            set
            {
                global::LightSwitchApplication.RecipesItem.DetailsClass.SetValue(this, global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.MatsAndGoodsItem, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void MatsAndGoodsItem_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void MatsAndGoodsItem_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void MatsAndGoodsItem_Changed();

        /// <summary>
        /// Отсутствует описание модели
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.LightSwitch.Framework.EntityCollection<global::LightSwitchApplication.RecipesComponentsItem> RecipesComponents
        {
            get
            {
                return global::LightSwitchApplication.RecipesItem.DetailsClass.GetValue(this, global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.RecipesComponents);
            }
        }
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Microsoft.LightSwitch.IDataServiceQueryable<global::LightSwitchApplication.RecipesComponentsItem> RecipesComponentsQuery
        {
            get
            {
                return global::LightSwitchApplication.RecipesItem.DetailsClass.GetQuery(this, global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.RecipesComponents);
            }
        }

        /// <summary>
        /// Отсутствует описание модели
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.LightSwitch.Framework.EntityCollection<global::LightSwitchApplication.CraftItem> Craft
        {
            get
            {
                return global::LightSwitchApplication.RecipesItem.DetailsClass.GetValue(this, global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.Craft);
            }
        }
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Microsoft.LightSwitch.IDataServiceQueryable<global::LightSwitchApplication.CraftItem> CraftQuery
        {
            get
            {
                return global::LightSwitchApplication.RecipesItem.DetailsClass.GetQuery(this, global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.Craft);
            }
        }

        #endregion
    
        #region Details Class
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public sealed class DetailsClass : global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<
                global::LightSwitchApplication.RecipesItem,
                global::LightSwitchApplication.RecipesItem.DetailsClass,
                global::LightSwitchApplication.RecipesItem.DetailsClass.IImplementation,
                global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySet,
                global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass>,
                global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass>>
        {
    
            static DetailsClass()
            {
                var initializeEntry = global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.ID;
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass>.Entry
                __RecipesItemEntry = new global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass>.Entry(
                    global::LightSwitchApplication.RecipesItem.DetailsClass.__RecipesItem_CreateNew,
                    global::LightSwitchApplication.RecipesItem.DetailsClass.__RecipesItem_Created,
                    global::LightSwitchApplication.RecipesItem.DetailsClass.__RecipesItem_AllowSaveWithErrors);
            private static global::LightSwitchApplication.RecipesItem __RecipesItem_CreateNew(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.RecipesItem> es)
            {
                return new global::LightSwitchApplication.RecipesItem(es);
            }
            private static void __RecipesItem_Created(global::LightSwitchApplication.RecipesItem e)
            {
                e.RecipesItem_Created();
            }
            private static bool __RecipesItem_AllowSaveWithErrors(global::LightSwitchApplication.RecipesItem e)
            {
                bool result = false;
                e.RecipesItem_AllowSaveWithErrors(ref result);
                return result;
            }
    
            public DetailsClass() : base()
            {
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass> Commands
            {
                get
                {
                    return base.Commands;
                }
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass> Methods
            {
                get
                {
                    return base.Methods;
                }
            }
    
            public new global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySet Properties
            {
                get
                {
                    return base.Properties;
                }
            }
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public sealed class PropertySet : global::Microsoft.LightSwitch.Details.Framework.Base.EntityPropertySet<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass>
            {
    
                public PropertySet() : base()
                {
                }
    
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, decimal> ID
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.ID) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, decimal>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::System.Nullable<decimal>> QuantityDone
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.QuantityDone) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::System.Nullable<decimal>>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.MatsAndGoodsItem> MatsAndGoodsItem
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.MatsAndGoodsItem) as global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.MatsAndGoodsItem>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.RecipesComponentsItem> RecipesComponents
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.RecipesComponents) as global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.RecipesComponentsItem>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.CraftItem> Craft
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.Craft) as global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.CraftItem>;
                    }
                }
                
            }
    
            #pragma warning disable 109
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            public interface IImplementation : global::Microsoft.LightSwitch.Internal.IEntityImplementation
            {
                new decimal ID { get; }
                new global::System.Nullable<decimal> QuantityDone { get; set; }
                new global::Microsoft.LightSwitch.Internal.IEntityImplementation MatsAndGoodsItem { get; set; }
                new global::System.Collections.IEnumerable RecipesComponents { get; }
                new global::System.Collections.IEnumerable Craft { get; }
            }
            #pragma warning restore 109
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "12.1.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal class PropertySetProperties
            {
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, decimal>.Entry
                    ID = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, decimal>.Entry(
                        "ID",
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._ID_Stub,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._ID_ComputeIsReadOnly,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._ID_Validate,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._ID_GetImplementationValue,
                        null,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._ID_OnValueChanged);
                private static void _ID_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.RecipesItem.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, decimal>.Data> c, global::LightSwitchApplication.RecipesItem.DetailsClass d, object sf)
                {
                    c(d, ref d._ID, sf);
                }
                private static bool _ID_ComputeIsReadOnly(global::LightSwitchApplication.RecipesItem e)
                {
                    bool result = false;
                    e.ID_IsReadOnly(ref result);
                    return result;
                }
                private static void _ID_Validate(global::LightSwitchApplication.RecipesItem e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.ID_Validate(r);
                }
                private static decimal _ID_GetImplementationValue(global::LightSwitchApplication.RecipesItem.DetailsClass d)
                {
                    return d.ImplementationEntity.ID;
                }
                private static void _ID_OnValueChanged(global::LightSwitchApplication.RecipesItem e)
                {
                    e.ID_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::System.Nullable<decimal>>.Entry
                    QuantityDone = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::System.Nullable<decimal>>.Entry(
                        "QuantityDone",
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._QuantityDone_Stub,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._QuantityDone_ComputeIsReadOnly,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._QuantityDone_Validate,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._QuantityDone_GetImplementationValue,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._QuantityDone_SetImplementationValue,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._QuantityDone_OnValueChanged);
                private static void _QuantityDone_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.RecipesItem.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::System.Nullable<decimal>>.Data> c, global::LightSwitchApplication.RecipesItem.DetailsClass d, object sf)
                {
                    c(d, ref d._QuantityDone, sf);
                }
                private static bool _QuantityDone_ComputeIsReadOnly(global::LightSwitchApplication.RecipesItem e)
                {
                    bool result = false;
                    e.QuantityDone_IsReadOnly(ref result);
                    return result;
                }
                private static void _QuantityDone_Validate(global::LightSwitchApplication.RecipesItem e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.QuantityDone_Validate(r);
                }
                private static global::System.Nullable<decimal> _QuantityDone_GetImplementationValue(global::LightSwitchApplication.RecipesItem.DetailsClass d)
                {
                    return d.ImplementationEntity.QuantityDone;
                }
                private static void _QuantityDone_SetImplementationValue(global::LightSwitchApplication.RecipesItem.DetailsClass d, global::System.Nullable<decimal> v)
                {
                    d.ImplementationEntity.QuantityDone = v;
                }
                private static void _QuantityDone_OnValueChanged(global::LightSwitchApplication.RecipesItem e)
                {
                    e.QuantityDone_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.MatsAndGoodsItem>.Entry
                    MatsAndGoodsItem = new global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.MatsAndGoodsItem>.Entry(
                        "MatsAndGoodsItem",
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._MatsAndGoodsItem_Stub,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._MatsAndGoodsItem_ComputeIsReadOnly,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._MatsAndGoodsItem_Validate,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._MatsAndGoodsItem_GetCoreImplementationValue,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._MatsAndGoodsItem_GetImplementationValue,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._MatsAndGoodsItem_SetImplementationValue,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._MatsAndGoodsItem_Refresh,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._MatsAndGoodsItem_OnValueChanged);
                private static void _MatsAndGoodsItem_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.RecipesItem.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.MatsAndGoodsItem>.Data> c, global::LightSwitchApplication.RecipesItem.DetailsClass d, object sf)
                {
                    c(d, ref d._MatsAndGoodsItem, sf);
                }
                private static bool _MatsAndGoodsItem_ComputeIsReadOnly(global::LightSwitchApplication.RecipesItem e)
                {
                    bool result = false;
                    e.MatsAndGoodsItem_IsReadOnly(ref result);
                    return result;
                }
                private static void _MatsAndGoodsItem_Validate(global::LightSwitchApplication.RecipesItem e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.MatsAndGoodsItem_Validate(r);
                }
                private static global::Microsoft.LightSwitch.Internal.IEntityImplementation _MatsAndGoodsItem_GetCoreImplementationValue(global::LightSwitchApplication.RecipesItem.DetailsClass d)
                {
                    return d.ImplementationEntity.MatsAndGoodsItem;
                }
                private static global::LightSwitchApplication.MatsAndGoodsItem _MatsAndGoodsItem_GetImplementationValue(global::LightSwitchApplication.RecipesItem.DetailsClass d)
                {
                    return d.GetImplementationValue<global::LightSwitchApplication.MatsAndGoodsItem, global::LightSwitchApplication.MatsAndGoodsItem.DetailsClass>(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.MatsAndGoodsItem, ref d._MatsAndGoodsItem);
                }
                private static void _MatsAndGoodsItem_SetImplementationValue(global::LightSwitchApplication.RecipesItem.DetailsClass d, global::LightSwitchApplication.MatsAndGoodsItem v)
                {
                    d.SetImplementationValue(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.MatsAndGoodsItem, ref d._MatsAndGoodsItem, (i, ev) => i.MatsAndGoodsItem = ev, v);
                }
                private static void _MatsAndGoodsItem_Refresh(global::LightSwitchApplication.RecipesItem.DetailsClass d)
                {
                    d.RefreshNavigationProperty(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.MatsAndGoodsItem, ref d._MatsAndGoodsItem);
                }
                private static void _MatsAndGoodsItem_OnValueChanged(global::LightSwitchApplication.RecipesItem e)
                {
                    e.MatsAndGoodsItem_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.RecipesComponentsItem>.Entry
                    RecipesComponents = new global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.RecipesComponentsItem>.Entry(
                        "RecipesComponents",
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._RecipesComponents_Stub,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._RecipesComponents_GetReferencedEntities,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._RecipesComponents_GetEntityCollection);
                private static void _RecipesComponents_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.RecipesItem.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.RecipesComponentsItem>.Data> c, global::LightSwitchApplication.RecipesItem.DetailsClass d, object sf)
                {
                    c(d, ref d._RecipesComponents, sf);
                }
                private static global::System.Collections.Generic.IEnumerable<global::LightSwitchApplication.RecipesComponentsItem> _RecipesComponents_GetReferencedEntities(global::LightSwitchApplication.RecipesItem.DetailsClass d)
                {
                    return d.GetReferencedEntities<global::LightSwitchApplication.RecipesComponentsItem, global::LightSwitchApplication.RecipesComponentsItem.DetailsClass>(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.RecipesComponents, ref d._RecipesComponents);
                }
                private static global::System.Collections.IEnumerable _RecipesComponents_GetEntityCollection(global::LightSwitchApplication.RecipesItem.DetailsClass d)
                {
                    return d.ImplementationEntity.RecipesComponents;
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.CraftItem>.Entry
                    Craft = new global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.CraftItem>.Entry(
                        "Craft",
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._Craft_Stub,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._Craft_GetReferencedEntities,
                        global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties._Craft_GetEntityCollection);
                private static void _Craft_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.RecipesItem.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.CraftItem>.Data> c, global::LightSwitchApplication.RecipesItem.DetailsClass d, object sf)
                {
                    c(d, ref d._Craft, sf);
                }
                private static global::System.Collections.Generic.IEnumerable<global::LightSwitchApplication.CraftItem> _Craft_GetReferencedEntities(global::LightSwitchApplication.RecipesItem.DetailsClass d)
                {
                    return d.GetReferencedEntities<global::LightSwitchApplication.CraftItem, global::LightSwitchApplication.CraftItem.DetailsClass>(global::LightSwitchApplication.RecipesItem.DetailsClass.PropertySetProperties.Craft, ref d._Craft);
                }
                private static global::System.Collections.IEnumerable _Craft_GetEntityCollection(global::LightSwitchApplication.RecipesItem.DetailsClass d)
                {
                    return d.ImplementationEntity.Craft;
                }
    
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, decimal>.Data _ID;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::System.Nullable<decimal>>.Data _QuantityDone;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.MatsAndGoodsItem>.Data _MatsAndGoodsItem;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.RecipesComponentsItem>.Data _RecipesComponents;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityCollectionProperty<global::LightSwitchApplication.RecipesItem, global::LightSwitchApplication.RecipesItem.DetailsClass, global::LightSwitchApplication.CraftItem>.Data _Craft;
            
        }
    
        #endregion
    }
    
    #endregion
}
