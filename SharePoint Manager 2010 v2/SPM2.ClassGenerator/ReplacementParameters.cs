using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework;
using SPM2.Framework.Reflection;
using SPM2.SharePoint.Model;
using Microsoft.SharePoint.Administration;
using System.Reflection;

namespace SPM2.ClassGenerator
{
    public class ReplacementParameters
    {
        public const string AttachToTemplate = "[AttachTo(\"{0}\")]";
        public const string TitleTemplate = "[Title(\"{0}\")]";
        public const string TitlePropertyNameTemplate = "[Title(PropertyName=\"{0}\")]";
        public const string IconTemplate = "[Icon(Small=\"{0}\")]";
        public const string ItemUsingTemplate = "using {0};";

        public const string BaseTypeTemplate = "SPNode";
        public const string BaseCollectionTypeTemplate = "SPNodeCollection";
        public const string SharePointTypeUsingTemplate = "using {0};\r\n";
        public const string SharePointTypePropertyTemplate = @"public {0} {1}
        {{
            get
            {{
                return ({0})this.SPObject;
            }}
            set
            {{
                this.SPObject = value;
            }}
        }}";
        



        public string[] Namespaces = new string[] {
            "Microsoft.SharePoint.Administration.",
            "Microsoft.SharePoint.",
            "SPM2.Framework."
        };


        public string PropertyTitle = null;
        public NodeDescriptorCollection AttachToDescriptors = null;

        public string ItemUsing = null;
        public string TitlePropertyName = null;
        public string Icon = "BULLET.GIF";
        public string AttachTo = null;
        public string ClassName = null;
        public string SharePointType = null;
        public string SharePointTypeName = null;
        public string SharePointTypeSimpleName = null;
        public string SharePointTypeUsing = null;
        public string SharePointTypeProperty = null;
        public string BaseType = null;


        public NodeDescriptor Descriptor = null;

        public ReplacementParameters(NodeDescriptor descriptor)
        {
            this.Descriptor = descriptor;

            Fillin();
        }

        private void Fillin()
        {
            this.PropertyTitle = this.Descriptor.Title;

            var list = from p in this.Descriptor.AttachTo
                       select String.Format(AttachToTemplate, p.NodeFullName);

            this.AttachTo = String.Join("\r\n\t", list.ToArray());

            this.ClassName = this.Descriptor.NodeName;
            this.SharePointType = this.Descriptor.ObjectType.AssemblyQualifiedName;
            this.SharePointTypeName = this.Descriptor.ObjectType.Name;
            this.SharePointTypeSimpleName = this.SharePointTypeName;
            if(this.SharePointTypeName.StartsWith("SP"))
            {
                this.SharePointTypeSimpleName = this.SharePointTypeName.Substring(2);
            }

            if (this.Descriptor.ObjectType.IsPublic && 
                this.Descriptor.ObjectType.Namespace.StartsWith("Microsoft.SharePoint") &&
                !this.Descriptor.ObjectType.Namespace.StartsWith("Microsoft.SharePoint.Portal"))
            {
                this.SharePointTypeProperty = string.Format(SharePointTypePropertyTemplate, this.SharePointTypeName, this.SharePointTypeSimpleName);
                this.SharePointTypeUsing = string.Format(SharePointTypeUsingTemplate, this.Descriptor.ObjectType.Namespace);
            }

            this.Icon = String.Format(IconTemplate, this.Icon);

            if (this.Descriptor.PropertyTitle != null)
            {
                this.TitlePropertyName = String.Format(TitlePropertyNameTemplate, this.Descriptor.PropertyTitle);
            }
            else
            {
                this.TitlePropertyName = String.Format(TitleTemplate, this.PropertyTitle);
            }


            if (this.Descriptor.IsEnumerable)
            {
                this.BaseType = BaseCollectionTypeTemplate;
                //Type itemType = null;
                //Type[] argTypes = this.Descriptor.ObjectType.GetBaseGenericArguments();
                //if (argTypes != null && argTypes.Length > 0)
                //{
                //    itemType = argTypes[0];
                //    this.BaseType = String.Format(BaseCollectionTypeTemplate, this.SharePointType, GetClassName(itemType.FullName));
                //}
            }
            else
            {
                NodeDescriptor item = FindCollectionItemType();

                if (item != null && item.NodeName != this.Descriptor.NodeName)
                {
                    this.BaseType = item.NodeName;
                }
                else
                {
                    this.BaseType = String.Format(BaseTypeTemplate);
                }
            }

        }

        private NodeDescriptor FindCollectionItemType()
        {
            NodeDescriptor result = null;

            foreach (NodeDescriptor parent in this.Descriptor.AttachTo)
            {
                if (parent.CollectionItem != null)
                {
                    if (result == null || result == parent.CollectionItem)
                    {
                        result = parent.CollectionItem;
                    }
                    else
                    {
                        result = null;
                        break;
                    }
                }
                else
                {
                    result = null;
                    break;
                }
            }

            return result;
        }


        private string GetClassName(string fullname)
        {
            string result = fullname;

            foreach (string item in Namespaces)
            {
                if (fullname.StartsWith(item))
                {
                    string subName = result.Substring(item.Length);
                    if (!subName.Contains("."))
                    {
                        result = subName;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
