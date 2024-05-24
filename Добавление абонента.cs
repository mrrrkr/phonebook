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
    public partial class Добавление_абонента : Form
    {
        public Note MyRecord;

        public Добавление_абонента (Note _MyRecord, AddOrEdit MyType)
        {
            InitializeComponent();
            MyRecord = _MyRecord;
            // если форма открыта для добавления
            if (MyType == AddOrEdit.Add)
            {
                Text = "Добавление абонента";
                AddButton.Text = "Добавить";
            }
            else    // если форма открыта для изменения записи
            {
                Text = "Изменение абонента";
                AddButton.Text = "Изменить";
                // определяем значение компонентов на форме

                LastNameTextBox.Text = MyRecord.LastName;
                NameTextBox.Text = MyRecord.Name;
                PatronymicTextBox.Text = MyRecord.Patronymic;
                PhoneMaskedTextBox.Text = MyRecord.Phone;
                StreetTextBox.Text = MyRecord.Street;
                HouseNumericUpDown.Value = MyRecord.House;
                FlatNumericUpDown.Value = MyRecord.Flat;
            }
        }


        private void Добавление_абонента_Load(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if ((LastNameTextBox.Text != "" || NameTextBox.Text != "" || PatronymicTextBox.Text != "") && PhoneMaskedTextBox.Text != "(   )    -")
            {
                MyRecord.LastName = LastNameTextBox.Text;
                MyRecord.Name = NameTextBox.Text;
                MyRecord.Patronymic = PatronymicTextBox.Text;
                MyRecord.Phone = PhoneMaskedTextBox.Text;
                MyRecord.Street = StreetTextBox.Text;
                MyRecord.House = (ushort)HouseNumericUpDown.Value;
                MyRecord.Flat = (ushort)FlatNumericUpDown.Value;
                Close(); 		// закрываем форму
            }
            else
            {
                MessageBox.Show("Введите данные!");
            }
        }



        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void LastNameTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
