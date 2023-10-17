using System.Net;

namespace notepad4Me
{
    public partial class frmMain : Form
    {
        string OurFileName;


        void DoSave(string filename)
        {
            OurFileName = filename;
            textBox.SaveFile(filename);
        }

        void DoSaveAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DoSave(saveFileDialog1.FileName);
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        bool CheckChanges() //boolean for checking if there are some changes(we are going to use this boolean below in the "Open" method)
        {
            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            if (CheckChanges()) //checking for changes
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox.LoadFile(openFileDialog1.FileName);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OurFileName)) // if there isn't a string(null or empty) we are going to "save as" the file
            {
                DoSaveAs();
            }
            else // if there is a string(not a null string or empty string) we are going to "save" the file
            {
                DoSave(OurFileName); //calling the method with the our filename variable (it will only run if there is a value !!!)
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFind find = new frmFind();
            find.Show(this);
        }

        //public void DoFind(string search, bool down, bool match_case) 
        //{
        //    LastFindWord = search;
        //    LastFindDown = down;
        //    LastFindMatchCase = match_case;

        //    if (down)
        //    {
        //        textBox.Find(search, textBox.SelectionStart + 1,
        //            match_case ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None);
        //    }
        //}


    }
}