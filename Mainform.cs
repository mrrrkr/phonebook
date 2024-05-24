using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using phonebook.Save;
using phonebook.Open;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace phonebook
{
    public partial class Mainform : Form
    {
        [XmlElement("Notes")]
        public List<Note> PhoneNote { get; set; }
        private int current;
        ISave saveBehavior;
        IOpen openBehavior;

        public Mainform()
        {
            InitializeComponent();
            PhoneNote = new List<Note>();
            current = -1;
            openFileDialog1.Filter = @"txt files(*.txt) | *.txt| xml files(*.xml) | *.xml| json files(*.json) | *.json| dat files(*dat) | *.dat";
            saveFileDialog1.Filter = @"txt files(*.txt) | *.txt| xml files(*.xml) | *.xml| json files(*.json) | *.json| dat files(*dat) | *.dat";
        }

        private void PrintElement()
        {
            if ((current >= 0) && (current < PhoneNote.Count))
            {   // если есть что выводить
                // MyRecord - запись списка PhoneNote номер current
                Note MyRecord = PhoneNote[current];
                // записываем в соответствующие элементы на форме 
                // поля из записи MyRecord 
                LastNameTextBox.Text = MyRecord.LastName;
                NameTextBox.Text = MyRecord.Name;
                PatronymicTextBox.Text = MyRecord.Patronymic;
                PhoneMaskedTextBox.Text = MyRecord.Phone;
                StreetTextBox.Text = MyRecord.Street;
                HouseNumericUpDown.Value = MyRecord.House;
                FlatNumericUpDown.Value = MyRecord.Flat;
            }
            else // если current равно -1, т. е. список пуст
            {   // очистить поля формы 
                LastNameTextBox.Text = "";
                NameTextBox.Text = "";
                PatronymicTextBox.Text = "";
                PhoneMaskedTextBox.Text = "";
                StreetTextBox.Text = "";
                FlatNumericUpDown.Value = 1;
                HouseNumericUpDown.Value = 1;
            }
            // обновление строки состояния
            NumberToolStripStatusLabel.Text = (current + 1).ToString();
            QuantityToolStripStatusLabel.Text = PhoneNote.Count.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (current > 0)
            {
                current--;      // уменьшаем номер текущей записи на 1
                PrintElement();     // выводим элемент с номером current
            }
            else
            {
                MessageBox.Show("Предыдущей записи не существует!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((current != PhoneNote.Count-1) && PhoneNote.Count != 0)
            {
                current++;
                PrintElement();
            }
            else
            {
                MessageBox.Show("Следующей записи не существует!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Mainform_Click(object sender, EventArgs e)
        {
          
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // создаем запись - экземпляр класса Note
            Note MyRecord = new Note();

            // создаем экземпляр формы AddForm
            Добавление_абонента _AddForm = new Добавление_абонента(MyRecord, AddOrEdit.Add);

            // открываем форму для добавления записи
            _AddForm.ShowDialog();

            // текущей записью становится последняя
            current = PhoneNote.Count;

            // добавляем к списку PhoneNote новый элемент - запись MyRecord,
            // взятую из формы AddForm
            if (current == 0)
            {
                PhoneNote.Add(_AddForm.MyRecord);
                PrintElement();
            }
            else
            {
                int count = 0;
                for (int i = 0; i < current; i++)
                {
                    if (MyRecord.Equals(PhoneNote[i]) == true)
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    PhoneNote.Add(_AddForm.MyRecord);
                    PrintElement();
                }
                else
                {
                    MessageBox.Show("Данная запись существует");
                    current--;
                }
            }
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
        }

        private void поискПоФИОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchName _Search = new searchName(PhoneNote);
            _Search.ShowDialog();

        }

        private void поискПоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchAdress _Search = new searchAdress(PhoneNote);
            _Search.ShowDialog();
        }

        private void поискПоНомеруТелефонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchNum _Search = new searchNum(PhoneNote);
            _Search.ShowDialog();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                // создаем запись - экземпляр класса Note
                Note MyRecord = new Note();
                // определяем поля записи
                // (берем значения из соответствующих компонентов на форме)
                MyRecord.LastName = LastNameTextBox.Text;
                MyRecord.Name = NameTextBox.Text;
                MyRecord.Patronymic = PatronymicTextBox.Text;
                MyRecord.Phone = PhoneMaskedTextBox.Text;
                MyRecord.Street = StreetTextBox.Text;
                MyRecord.House = (ushort)HouseNumericUpDown.Value;
                MyRecord.Flat = (ushort)FlatNumericUpDown.Value;
                // создаем экземпляр формы и открываем эту форму
                Добавление_абонента _AddForm = new Добавление_абонента(MyRecord, AddOrEdit.Edit);
                _AddForm.ShowDialog();
                // изменяем текущую запись
                int count = 0;
                for (int i = 0; i < PhoneNote.Count; i++)
                {
                    if (MyRecord.Equals(PhoneNote[i]) == true)
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    PhoneNote[current] = _AddForm.MyRecord;
                    
                }
                else
                {
                    MessageBox.Show("Данная запись существует");
                    //current--;
                }
            }
            PrintElement();

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete delete = new delete(PhoneNote, current);
            delete.ShowDialog();
            if (current != 0) current--;
            if (current >= 0)
            {
                if (current != PhoneNote.Count)
                {
                    Note MyRecord = PhoneNote[current];
                    LastNameTextBox.Text = MyRecord.LastName;
                    NameTextBox.Text = MyRecord.Name;
                    PatronymicTextBox.Text = MyRecord.Patronymic;
                    PhoneMaskedTextBox.Text = MyRecord.Phone;
                    StreetTextBox.Text = MyRecord.Street;
                    HouseNumericUpDown.Value = MyRecord.House;
                    FlatNumericUpDown.Value = MyRecord.Flat;
                    NumberToolStripStatusLabel.Text = (current + 1).ToString();
                    QuantityToolStripStatusLabel.Text = PhoneNote.Count.ToString();
                }
                else
                {
                    LastNameTextBox.Text = "";
                    NameTextBox.Text = "";
                    PatronymicTextBox.Text = "";
                    PhoneMaskedTextBox.Text = "";
                    StreetTextBox.Text = "";
                    HouseNumericUpDown.Value = 1;
                    FlatNumericUpDown.Value = 1;
                    NumberToolStripStatusLabel.Text = (current).ToString();
                    QuantityToolStripStatusLabel.Text = PhoneNote.Count.ToString();
                }
            }
        }

        private void QuantityToolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void поФамилииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)    // если список не пуст
            {
                // сортировка списка по фамилии
                PhoneNote.Sort(new CompareByLastName());
                current = 0;        // задаем номер текущего элемента
                PrintElement(); // вывод текущего элемента
            }
        }

        private void поКвартиреToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new CompareByFlat());
                current = 0;
                PrintElement();
            }
        }

        private void поИмениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new CompareName());
                current = 0;
                PrintElement();
            }
        }

        private void поОтчествуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new ComparePatronymic());
                current = 0;
                PrintElement();
            }
        }

        private void поНазваниюУлицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new CompareStreet());
                current = 0;
                PrintElement();
            }
        }

        private void поНомеруДомаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new CompareHouse());
                current = 0;
                PrintElement();
            }
        }

        private void поНомеруТелефонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new ComparePhone());
                current = 0;
                PrintElement();
            }
        }

        private void поУбываниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void поУбываниюToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                var sortedList = PhoneNote.OrderByDescending(x => x.House).ToList();
                current = 0;
                PhoneNote = sortedList;
                PrintElement();
            }
        }

        private void изБинарногоФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try         // обработчик исключительных ситуаций
                {
                    openBehavior = new DeserializeBin();
                    string FilePath1 = openFileDialog1.FileName;
                    openBehavior.OpenAdd(PhoneNote, FilePath1);
                    if (PhoneNote.Count == 0) current = -1;
                    else current = 0;
                    PrintElement();
                }
                catch (Exception ex)    // если произошла ошибка
                {
                    MessageBox.Show("При открытии файла произошла ошибка: " +
                    ex.Message);
                }
            }
        }

        private void вБинарныйФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            // Если в диалоговом окне нажали ОК
            {
                try         
                {
                    saveBehavior = new SerializeBin();
                    string FilePath = saveFileDialog1.FileName;
                    saveBehavior.Save(PhoneNote, FilePath);
                }
                catch (Exception ex)    // перехватываем ошибку
                {
                    // выводим информацию об ошибке
                    MessageBox.Show("Не удалось сохранить данные! Ошибка: " +
                    ex.Message);
                }
            }
        }

        private void изТекстовогоФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note MyRecord;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try         // обработчик исключительных ситуаций
                {
                    MyRecord = new Note();
                    openBehavior = new OpenTXT();
                    string FilePath1 = openFileDialog1.FileName;
                    openBehavior.Open(PhoneNote, FilePath1);
                    // если список пуст, то current устанавливаем в -1,
                    // иначе текущей является первая с начала запись (номер 0)
                    if (PhoneNote.Count == 0) current = -1;
                    else current = 0;
                    // выводим текущий элемент
                    PrintElement();
                }
                catch (Exception ex)    // если произошла ошибка
                {
                    MessageBox.Show("При открытии файла произошла ошибка: " +
                    ex.Message);
                }
            }
        }

        private void вТекстовыйФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            // Если в диалоговом окне нажали ОК
            {
                try         // обработчик исключительных ситуаций
                {
                    // используя sw (экземпляр класса StreamWriter),
                    // создаем файл с заданным в диалоговом окне именем
                    saveBehavior = new SaveTXT();
                    string FilePath = saveFileDialog1.FileName;
                    saveBehavior.Save(PhoneNote, FilePath);
                }
                catch (Exception ex)    // перехватываем ошибку
                {
                    // выводим информацию об ошибке
                    MessageBox.Show("Не удалось сохранить данные! Ошибка: " +
                    ex.Message);
                }
            }
        }

        private void вXMLФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try       
                {
                    saveBehavior = new SerializeXML();
                    string FilePath = saveFileDialog1.FileName;
                    saveBehavior.Save(PhoneNote, FilePath);
                }
                catch (Exception ex)    
                {
                    MessageBox.Show("Не удалось сохранить данные! Ошибка: " +
                    ex.Message);
                }
            }
        }

        private void изXMLФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note MyRecord;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try         
                {
                    MyRecord = new Note();
                    openBehavior = new DeserialiseXML();
                    string FilePath1 = openFileDialog1.FileName;
                    openBehavior.OpenAdd(PhoneNote, FilePath1);

                    if (PhoneNote.Count == 0) current = -1;
                    else current = 0;
                    PrintElement();
                }
                catch (Exception ex)    // если произошла ошибка
                {
                    MessageBox.Show("При открытии файла произошла ошибка: " +
                    ex.Message);
                }
            }
        }

        private void вJSONФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    saveBehavior = new SerializeJson();
                    string FilePath = saveFileDialog1.FileName;
                    saveBehavior.Save(PhoneNote, FilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось сохранить данные! Ошибка: " +
                    ex.Message);
                }
            }
        }

        private void изJSONФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    openBehavior = new DeserializeJson();
                    string FilePath1 = openFileDialog1.FileName;
                    openBehavior.OpenAdd(PhoneNote, FilePath1);

                    if (PhoneNote.Count == 0) current = -1;
                    else current = 0;
                    PrintElement();
                }
                catch (Exception ex)    // если произошла ошибка
                {
                    MessageBox.Show("При открытии файла произошла ошибка: " +
                    ex.Message);
                }
            }
        }

        private void изБинарногоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count != 0)
            {
                сохранитьToolStripMenuItem_Click(sender, e);
                Show();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    PhoneNote.Clear();
                    try         
                    {
                        openBehavior = new DeserializeBin();
                        string FilePath1 = openFileDialog1.FileName;
                        openBehavior.OpenAdd(PhoneNote, FilePath1);
                        if (PhoneNote.Count == 0) current = -1;
                        else current = 0;
                        PrintElement();
                    }
                    catch (Exception ex)  
                    {
                        MessageBox.Show("При открытии файла произошла ошибка: " +
                        ex.Message);
                    }
                }
                
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }

    public enum AddOrEdit
    {
        Add,
        Edit
    }
    
}

