using System;
using System.Collections.Generic;
using System.Text;

namespace Keutmann.SharePointManager.Components
{
    public sealed class SPMMenu
    {
        SPMMenu()
        {
        }

        public static SPMStandardMenuItems Items
        {
            get
            {
                return StandardMenuItems.Items;
            }
        }

        public static SPMStandardMenuStrips Strips
        {
            get
            {
                return StandardMenuStrips.Strips;
            }
        }

        class StandardMenuItems
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static StandardMenuItems()
            {
            }

            internal static readonly SPMStandardMenuItems Items = new SPMStandardMenuItems();
        }

        class StandardMenuStrips
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static StandardMenuStrips()
            {
            }

            internal static readonly SPMStandardMenuStrips Strips = new SPMStandardMenuStrips();
        }

    }

    

}
