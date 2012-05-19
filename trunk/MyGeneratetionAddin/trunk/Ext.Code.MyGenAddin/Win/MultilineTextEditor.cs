using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Legendigital.Code.MyGenAddin.Win
{
    public class MultilineTextEditor : UITypeEditor
    {

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            try
            {
                IWindowsFormsEditorService svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (svc != null)
                {
                    if (value is string)
                    {
                        TextBox box = new TextBox();

                        box.AcceptsReturn = true;
                        box.Multiline = true;
                        box.Height = 120;
                        box.BorderStyle = BorderStyle.None;
                        box.Text = value as string;
                        svc.DropDownControl(box);

                        return box.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);

                return value;
            }

            return value;
        }
    }

}
