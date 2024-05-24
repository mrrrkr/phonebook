using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phonebook
{
    public partial class delete : Form
    {
        List<Note> PhoneNote;
        int current;

        public delete(List<Note> _PhoneNote, int _current)
        {
            InitializeComponent();
            PhoneNote = _PhoneNote;
            current = _current;
        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count != 0)
            {
                Note MyRecord = PhoneNote[current];
                PhoneNote.RemoveAt(current);
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
