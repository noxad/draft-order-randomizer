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
            var random = new Random();
            var splitArray = new string[1];
            var list = new System.Collections.ArrayList();

            splitArray[0] = Environment.NewLine; // Used to split the list of owners in the textbox

            // Add contents of textbox to array
            list.AddRange(txtList.Text.Split(splitArray, StringSplitOptions.RemoveEmptyEntries));
            
            txtList.Clear();

            var length = list.Count;

            // Loop through list, randomly selecting an item, adding it to the output list, 
            // then removing it from the list
            for (var x = 0; x < length; x++)
            {
                var index = random.Next(list.Count);

                txtList.Text +=  list[index] + Environment.NewLine;
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
