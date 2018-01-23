using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Keutmann.SharePointManager.Components
{
    public class SPMStandardMenuStrips
    {



        public ContextMenuStripBase Refresh = null;
        public ContextMenuStripBase Standard = null;


        public Dictionary<Type, ContextMenuStrip> MenuStore = new Dictionary<Type, ContextMenuStrip>();


       

        //public FieldMenuStrip _FieldMenu = null;
        //public FieldMenuStrip FieldMenu
        //{
        //    get
        //    {
        //        if (_FieldMenu == null)
        //        {
        //            _FieldMenu = new FieldMenuStrip();
        //        }
        //        return _FieldMenu;
        //    }
        //}

        public SPMStandardMenuStrips()
        {
            this.Refresh = new MenuStripRefresh();
            this.Standard = new MenuStripStandard();
        }

        public ContextMenuStrip GetMenu(Type menuType)
        {
            ContextMenuStrip menu = null;
            if (MenuStore.ContainsKey(menuType))
            {
                menu = MenuStore[menuType];
            }
            else
            {
                menu = (ContextMenuStrip)Activator.CreateInstance(menuType);
                MenuStore.Add(menuType, menu);
            }

            return menu;
        }


    }
}
