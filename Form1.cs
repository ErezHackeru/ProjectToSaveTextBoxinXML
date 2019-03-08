using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveLoadState
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string fileName = @"D:\DataFiles\state1.xml";
        string Foldername = string.Empty;
        private void saveStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("No checked items");
            }
            else
            {
                fileName = Foldername + "\\state2.xml";
                List<string> AllCheckediTems = new List<string>();
                foreach (string itemChecked in checkedListBox1.CheckedItems)
                {
                    MessageBox.Show(itemChecked.ToString());
                    AllCheckediTems.Add(itemChecked);
                }
                DataToSave DataBlock1 = new DataToSave(textBox1.Text, textBox2.Text, textBox3.Text, AllCheckediTems);
                DataToSave.SerializeADataToSave(fileName, DataBlock1);
            }
        }

        private void loadStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = Foldername + "\\state2.xml";

            DataToSave DataToResult = DataToSave.DeserializeACar(fileName);
            textBox1.Text = DataToResult.Textbox1;
            textBox2.Text = DataToResult.Textbox2;
            textBox3.Text = DataToResult.Textbox3;

            int[] itemindex = new int[checkedListBox1.Items.Count];
            int itemIndex = 0;
            foreach (string item in checkedListBox1.Items)
            {
                for (int i = 0; i < DataToResult.AllCheckeditems.Count; i++)
                {
                    if (item == DataToResult.AllCheckeditems[i])
                    {
                        //MessageBox.Show(item.ToString());

                        itemindex[itemIndex] = 1;
                    }
                }
                itemIndex++;
            }

            for (int i = 0; i < itemindex.Length; i++)
            {
                if (itemindex[i] == 1)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
                
                
            
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.Filter = "XML files (*.xml, *.accdb)|*.xml;*.accdb";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                //...
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fldrDlg = new FolderBrowserDialog())
            {
                //fldrDlg.Filter = "Png Files (*.png)|*.png";
                //fldrDlg.Filter = "Excel Files (*.xls, *.xlsx)|*.xls;*.xlsx|CSV Files (*.csv)|*.csv"

                if (fldrDlg.ShowDialog() == DialogResult.OK)
                {
                    Foldername = fldrDlg.SelectedPath;// -- your result
                }
            }
        }
    }
}
