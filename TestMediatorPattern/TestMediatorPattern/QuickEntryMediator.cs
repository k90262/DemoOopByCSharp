using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMediatorPattern
{
    // Ref. book <<Agile Principles, Patterns, Practices in C#>>
    /// <summary>
    /// QuickEntryMediator
    /// 
    /// Syntax Example:
    /// TextBox t = new TextBox();
    /// ListBox l = new ListBox();
    /// 
    /// QuickEntryMediator qem = new QuickEntryMediator(t, l);
    /// </summary>
    public class QuickEntryMediator
    {
        private TextBox itsTextBox;
        private ListBox itsList;

        public QuickEntryMediator(TextBox t, ListBox l)
        {
            this.itsTextBox = t;
            this.itsList = l;
            this.itsTextBox.TextChanged += new EventHandler(TextFieldChanged);
        }

        private void TextFieldChanged(object? source, EventArgs e)
        {
            string prefix = itsTextBox.Text;

            if (prefix.Length == 0) 
            {
                itsList.ClearSelected();
                return;
            }

            ListBox.ObjectCollection listItems = itsList.Items;
            bool found = false;
            for (int i = 0; found == false && i < listItems.Count; i++) 
            {
                Object o = listItems[i];
                string s = o.ToString();
                if (s.StartsWith(prefix)) 
                {
                    itsList.SetSelected(i, true);
                    found = true;
                }
            }

            if (!found)
                itsList.ClearSelected();
        }
    }
}
