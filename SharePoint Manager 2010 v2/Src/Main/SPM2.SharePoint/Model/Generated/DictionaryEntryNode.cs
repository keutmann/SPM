/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[Title("Properties")]
	[AdapterItemType("System.Collections.DictionaryEntry, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
	[AttachTo("SPM2.SharePoint.Model.SPPropertyBagNode")]
	public partial class DictionaryEntryNode : SPNode
	{
	}
}
