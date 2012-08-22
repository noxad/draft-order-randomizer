using System;
using System.Windows.Forms;

namespace DraftOrderRandomizer
{
    public partial class DraftOrderRandomizer : Form
    {
        public DraftOrderRandomizer()
        {
            InitializeComponent();
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string[] initialArray;
            string[] splitArray = new string[1];
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            int length;
            int index;
                        
            splitArray[0] = Environment.NewLine; // Used to split the list of owners in the textbox

            // Add contents of textbox to array
            list.AddRange(initialArray = txtList.Text.Split(splitArray, StringSplitOptions.RemoveEmptyEntries));
            
            txtList.Clear();

            length = list.Count;

            // Loop through list, randomly selecting an item, adding it to the output list, 
            // then removing it from the list
            for (int x = 0; x < length; x++)
            {
                index = random.Next(list.Count);

                txtList.Text +=  list[index].ToString() + Environment.NewLine;
                list.Remove(list[index].ToString());
            }

            // Add output to clipboard 
            if (!String.IsNullOrEmpty(txtList.Text))
                Clipboard.SetText(txtList.Text);           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtList.Clear();
        }
    }
}
