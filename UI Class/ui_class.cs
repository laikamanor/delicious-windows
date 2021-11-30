using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DeliciousPartnerApp.UI_Class
{
    class ui_class
    {

        public string delegateControl(Control c)
        {
            string result = "";
            c.Invoke(new Action(delegate ()
            {
                result = c.Text;
            }));
            return result;
        }
    }
}
