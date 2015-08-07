using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarcodeClocking
{
    static class HelperClass
    {
        static public void OnKeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(IsNumberKey(e.KeyChar) || IsActionKey(e.KeyChar));
        }

        static private bool IsNumberKey(char key)
        {
            //Allow 0-9 in Card ID TextBoxes
            if (key < 48 || key > 57)
            {
                    return false;
            }
            return true;
        
        }

        static private bool IsActionKey(char key)
        {
            //Allow DEL and BS keys in Card ID TextBoxes
            return (key == 127 || key == 8);
        }
    }
}
