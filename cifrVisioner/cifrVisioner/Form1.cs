using System;
using System.Drawing;
using System.Windows.Forms;

namespace cifrVisioner
{
    public partial class Form1 : Form
    {
        char[] letters;
        // Инициализация элементов
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Label lbl4 = new Label();
        Label lbl5 = new Label();
        Label lbl6 = new Label();
        Label lbl7 = new Label();
        Label lbl8 = new Label();
        Label lbl9 = new Label();
        ComboBox cmb1 = new ComboBox();
        RichTextBox rtb1 = new RichTextBox();
        RichTextBox rtb2 = new RichTextBox();
        RichTextBox rtb3 = new RichTextBox();
        RichTextBox rtb4 = new RichTextBox();
        TextBox tbx1 = new TextBox();
        TextBox tbx2 = new TextBox();
        Button btn1 = new Button();
        Button btn2 = new Button();

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.PapayaWhip;
            this.Size = new Size(685, 470);
            elementsCreate();
        }

        private void elementsCreate() // Создание, дизайн, расположение и отображение элементов UI
        {
            Font fontStyle = new Font("Microsoft Sans Serif", 12);
            rtb2.ReadOnly = true;
            rtb4.ReadOnly = true;

            // UI Шифровки
            lbl1.Font = fontStyle;
            lbl1.Location = new Point(21, 16);
            lbl1.Size = new Size(188, 20);
            lbl1.Text = "Шифрование";
            rtb1.Font = fontStyle;
            rtb1.Location = new Point(25, 39);
            rtb1.Size = new Size(208, 96);
            rtb1.KeyPress += new KeyPressEventHandler(rtb1_KeyPress);
            lbl2.Font = fontStyle;
            lbl2.Location = new Point(239, 79);
            lbl2.Size = new Size(28, 20);
            lbl2.Text = "-->";
            lbl3.Font = fontStyle;
            lbl3.Location = new Point(269, 16);
            lbl3.Text = "Результат";
            rtb2.Font = fontStyle;
            rtb2.Location = new Point(273, 39);
            rtb2.Size = new Size(208, 96);
            lbl4.Location = new Point(21, 161);
            lbl4.Font = fontStyle;
            lbl4.Size = new Size(50, 20);
            lbl4.Text = "Ключ";
            tbx1.Font = fontStyle;
            tbx1.Location = new Point(25, 184);
            tbx1.Size = new Size(208, 26);
            tbx1.KeyPress += new KeyPressEventHandler(tbx1_KeyPress);
            lbl9.Font = fontStyle;
            lbl9.Size = new Size(81, 20);
            lbl9.Location = new Point(506, 16);
            lbl9.Text = "Алфавит";
            cmb1.Font = fontStyle;
            cmb1.Size = new Size(150, 28);
            cmb1.Location = new Point(507, 39);
            cmb1.Items.Add("Кириллица");
            cmb1.Items.Add("Латиница");
            cmb1.SelectedIndex = 0;
            cmb1.DropDownStyle = ComboBoxStyle.DropDownList;
            btn1.Font = fontStyle;
            btn1.Location = new Point(273, 159);
            btn1.Size = new Size(208, 51);
            btn1.BackColor = Color.DarkSeaGreen;
            btn1.Text = "Ввод";
            btn1.Click += new EventHandler(btn1_Click);

            // UI Расшифровки
            lbl5.Font = fontStyle;
            lbl5.Location = new Point(21, 228);
            lbl5.Size = new Size(188, 20);
            lbl5.Text = "Расшифрование";
            rtb3.Font = fontStyle;
            rtb3.Location = new Point(25, 251);
            rtb3.Size = new Size(208, 96);
            rtb3.KeyPress += new KeyPressEventHandler(rtb3_KeyPress);
            lbl6.Font = fontStyle;
            lbl6.Location = new Point(239, 285);
            lbl6.Size = new Size(28, 20);
            lbl6.Text = "-->";
            lbl7.Font = fontStyle;
            lbl7.Location = new Point(269, 228);
            lbl7.Text = "Результат";
            rtb4.Font = fontStyle;
            rtb4.Location = new Point(273, 251);
            rtb4.Size = new Size(208, 96);
            lbl8.Location = new Point(21, 362);
            lbl8.Font = fontStyle;
            lbl8.Size = new Size(50, 20);
            lbl8.Text = "Ключ";
            tbx2.Font = fontStyle;
            tbx2.Location = new Point(25, 385);
            tbx2.Size = new Size(208, 26);
            tbx2.KeyPress += new KeyPressEventHandler(tbx2_KeyPress);
            btn2.Font = fontStyle;
            btn2.Location = new Point(273, 362);
            btn2.Size = new Size(208, 51);
            btn2.BackColor = Color.DarkSeaGreen;
            btn2.Text = "Ввод";
            btn2.Click += new EventHandler(btn2_Click);

            // Отображение элементов
            //this.Controls.AddRange(); Мэтт
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);
            this.Controls.Add(lbl4);
            this.Controls.Add(lbl5);
            this.Controls.Add(lbl6);
            this.Controls.Add(lbl7);
            this.Controls.Add(lbl8);
            this.Controls.Add(lbl9); 
            this.Controls.Add(cmb1);
            this.Controls.Add(tbx1);
            this.Controls.Add(tbx2);
            this.Controls.Add(rtb1);
            this.Controls.Add(rtb2);
            this.Controls.Add(rtb3);
            this.Controls.Add(rtb4);
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            // Проверка на наличие всех данных
            if ((tbx1.Text == "" || tbx1.Text == " ") && (rtb1.Text == "" || rtb1.Text == " "))
            {
                MessageBox.Show("Ошибка.\nНеобходимые данные не заполнены");
            }
            // Проверка на наличие данных ключа
            if (tbx1.Text == "" || tbx1.Text == " ")
            {
                MessageBox.Show("Ошибка.\nПоле ввода ключа пустое");
            }
            // Проверка на наличие данных сообщения
            if (rtb1.Text == "" || rtb1.Text == " ")
            {
                MessageBox.Show("Ошибка.\nПоле ввода сообщения пустое");
            }
            else
            {
 
                // Проверка на выбор кириллицы
                if (cmb1.SelectedIndex == 0)
                {
                    // Запись алфавита в массив
                    letters = new char[]
                    {
                    'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З',
                    'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                    'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы',
                    'Ь', 'Э', 'Ю', 'Я'
                    };
                }
                // Проверка на выбор латиницы
                else
                {
                    // Запись алфавита в массив
                    letters = new char[]
                    {
                    'A', 'B', 'C', 'D', 'E','F','G','H','I',
                    'J','K','L','M','N','O','P','Q','R',
                    'S','T','U','V','W','X','Y','Z'
                    };
                }
                // Вызов функции шифровки
                Encrypt();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            // Проверка на наличие всех данных
            if ((tbx2.Text == "" || tbx2.Text == " ") && (rtb3.Text == "" || rtb3.Text == " "))
            {
                MessageBox.Show("Ошибка.\nНеобходимые данные не заполнены");
            }
            // Проверка на наличие данных ключа
            if (tbx2.Text == "" || tbx2.Text == " ")
            {
                MessageBox.Show("Ошибка.\nПоле ввода ключа пустое");
            }
            // Проверка на наличие данных сообщения
            if (rtb3.Text == "" || rtb3.Text == " ")
            {
                MessageBox.Show("Ошибка.\nПоле ввода сообщения пустое");
            }
            else
            {
                // Проверка на выбор кириллицы
                if (cmb1.SelectedIndex == 0)
                {
                    letters = new char[]
                    {
                    'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З',
                    'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                    'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы',
                    'Ь', 'Э', 'Ю', 'Я'
                    };
                }
                // Проверка на выбор латиницы
                else
                {
                    letters = new char[]
                    {
                    'A', 'B', 'C', 'D', 'E','F','G','H','I',
                    'J','K','L','M','N','O','P','Q','R',
                    'S','T','U','V','W','X','Y','Z'
                    };
                }
                // Вызов функции расшифровки
                Decrypt();
            }
        }

        private void rtb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char lang = e.KeyChar;
            if ((lang >= 'А' && lang < 'я') && cmb1.SelectedIndex == 1)
            {
                e.Handled = true; // Отменяем ввод символа
            }
            if ((lang >= 'A' && lang < 'z') && cmb1.SelectedIndex == 0)
            {
                e.Handled = true; // Отменяем ввод символа
            }
        }
        private void tbx1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char lang = e.KeyChar;
            if ((lang >= 'А' && lang < 'я') && cmb1.SelectedIndex == 1)
            {
                e.Handled = true; // Отменяем ввод символа
            }
            if ((lang >= 'A' && lang < 'z') && cmb1.SelectedIndex == 0)
            {
                e.Handled = true; // Отменяем ввод символа
            }
        }

        private void rtb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char lang = e.KeyChar;
            if ((lang >= 'А' && lang < 'я') && cmb1.SelectedIndex == 1)
            {
                e.Handled = true; // Отменяем ввод символа
            }
            if ((lang >= 'A' && lang < 'z') && cmb1.SelectedIndex == 0)
            {
                e.Handled = true; // Отменяем ввод символа
            }
        }
        private void tbx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char lang = e.KeyChar;
            if ((lang >= 'А' && lang < 'я') && cmb1.SelectedIndex == 1)
            {
                e.Handled = true; // Отменяем ввод символа
            }
            if ((lang >= 'A' && lang < 'z') && cmb1.SelectedIndex == 0)
            {
                e.Handled = true; // Отменяем ввод символа
            }
        }

        private void Encrypt() // Шифровка
        {
            int letterIndex; // Индекс буквы в алфавите
            int offset; // Смещение
            int j, k; // Переменные для записи буквы
            int keyIndex = 0; // Нумерация символов ключа
            string result = string.Empty; // Результат
            char[] message = rtb1.Text.ToUpper().ToCharArray(); // Сообщение
            char[] key = tbx1.Text.ToUpper().ToCharArray(); // Ключ
            // Перебор каждого символа сообщения
            for (int i = 0; i < message.Length; i++)
            {
                // Поиск индекса буквы
                for (j = 0; j < letters.Length; j++)
                {
                    if (message[i] == letters[j])
                    {
                        break;
                    }
                }
                // Символ относится к алфавиту
                if (j != letters.Length)
                {
                    letterIndex = j; // Индекс буквы
                    // После конца ключа следует начало ключа
                    if (keyIndex > key.Length - 1)
                    {
                        keyIndex = 0;
                    }
                    // Поиск индекса буквы ключа
                    for (k = 0; k < letters.Length; k++)
                    {
                        if (key[keyIndex] == letters[k])
                        {
                            break;
                        }
                    }
                    keyIndex++;
                    // Символ относится к алфавиту
                    if (k != letters.Length)
                    {
                        offset = letterIndex + k; // Смещение = индекс символа + индекс буквы ключа
                    }
                    else
                    {
                        offset = letterIndex;
                    }
                    // Проверка на выход за пределы алфавита
                    if (offset > (letters.Length - 1))
                    {
                        offset = offset - letters.Length;
                    }
                    // Замена буквы
                    message[i] = letters[offset];
                }
            }
            // Запись результата
            result = new string(message);
            rtb2.Text = result;
        }

        private void Decrypt() // Дешифровка
        {
            int letterIndex; // Индекс буквы в алфавите
            int offset; // Смещение
            int j, k; // Переменные для записи буквы
            int keyIndex = 0; // Нумерация символов ключа
            string result = string.Empty; // Результат
            char[] message = rtb3.Text.ToUpper().ToCharArray(); // Сообщение 
            char[] key = tbx2.Text.ToUpper().ToCharArray(); // Ключ

            // Перебор каждого символа сообщения
            for (int i = 0; i < message.Length; i++)
            {
                //Поиск индекса буквы
                for (j = 0; j < letters.Length; j++)
                {
                    if (message[i] == letters[j])
                    {
                        break;
                    }
                }
                // Символ относится к алфавиту
                if (j != letters.Length)
                {
                    letterIndex = j; // Индекс буквы
                    // После конца ключа следует начало ключа
                    if (keyIndex > key.Length - 1)
                    {
                        keyIndex = 0;
                    }
                    // Поиск индекса буквы ключа
                    for (k = 0; k < letters.Length; k++)
                    {
                        if (key[keyIndex] == letters[k])
                        {
                            break;
                        }
                    }
                    keyIndex++;

                    //Символ относится к алфавиту
                    if (k != letters.Length)
                    {
                        offset = letterIndex - k; // смещение = индекс символа - индекс буквы ключа
                    }
                    else
                    {
                        offset = letterIndex;
                    }
                    // Обработка отрицательного индекса
                    if (offset < 0)
                    {
                        offset = offset + letters.Length;
                    }
                    // Замена буквы
                    message[i] = letters[offset];
                }
            }
            // Запись результата
            result = new string(message);
            rtb4.Text = result;
        }
    }
}