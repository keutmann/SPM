using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SPM2.ClassGenerator
{
    public class NodeBuilder
    {
        public string Filename = null;
        public string Contents = null;
        public string Template = null;
        public string Path = null;
        public ReplacementParameters Param = null;

        public NodeBuilder(string template, string path, ReplacementParameters param)
        {
            this.Template = template;
            this.Path = path;
            this.Param = param;
        }

        public void Bind()
        {
            this.Filename = this.Path + "\\" + this.Param.ClassName + ".cs";
            this.Contents = this.Template;

            this.Contents = this.Contents.Replace("[#ItemUsing#]", this.Param.ItemUsing);
            this.Contents = this.Contents.Replace("[#Title#]", this.Param.TitlePropertyName);
            this.Contents = this.Contents.Replace("[#Icon#]", this.Param.Icon);
            this.Contents = this.Contents.Replace("[#AttachTo#]", this.Param.AttachTo);
            this.Contents = this.Contents.Replace("[#ClassName#]", this.Param.ClassName);
            this.Contents = this.Contents.Replace("[#BaseType#]", this.Param.BaseType);
            this.Contents = this.Contents.Replace("[#SharePointType#]", this.Param.SharePointType);
            this.Contents = this.Contents.Replace("[#SharePointTypeName#]", this.Param.SharePointTypeName);
            this.Contents = this.Contents.Replace("[#SharePointTypeSimpleName#]", this.Param.SharePointTypeSimpleName);
            this.Contents = this.Contents.Replace("[#SharePointTypeUsing#]", this.Param.SharePointTypeUsing);
            this.Contents = this.Contents.Replace("[#SharePointTypeProperty#]", this.Param.SharePointTypeProperty);
            
        }

        public void Save()
        {
            try
            {

                File.WriteAllText(this.Filename, this.Contents);
            }
            catch 
            {
                
                
            }
        }
    }
}
