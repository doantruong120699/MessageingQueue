using System;
using System.Windows.Forms;
using System.Messaging;
using Message = System.Messaging.Message;
using System.Collections;
using System.Threading;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Collections.Generic;
delegate void SetTextCallback(string text);

namespace TienTrinh2
{
    public partial class TienTrinh2_Matrix : Form
    {
        private MessageQueue messageQueueInput;
        private MessageQueue messageQueueOutput;

        private Queue DataInputMatrix;
        private Queue DataOutputMatrix;

        private Queue DataInputTXT;
        private Queue DataOutputTXT;

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.Text = text;
            }
        }
        private void Form_Load()
        {
            var dict = new Dictionary<int, string>();
            dict.Add(1, "Processing calculations");
            dict.Add(2, "Matrix processing");

            comboBox1.DataSource = new BindingSource(dict, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }

        public TienTrinh2_Matrix()
        {
            InitializeComponent();
            Form_Load();

            messageQueueInput = new MessageQueue();
            messageQueueOutput = new MessageQueue();

            DataInputMatrix = new Queue();
            DataOutputMatrix = new Queue();

            DataInputTXT = new Queue();
            DataOutputTXT = new Queue();

            this.CenterToScreen();
        }

        private void Cancel()
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                this.Close();
            }
        }

        private async void btn_Calculator_Click(object sender, EventArgs e)
        {
            Thread thrdMatrix = new Thread(AutoRun);
            thrdMatrix.Start();
        }

        private Boolean Count(MessageQueue queue)
        {
            int count = 0;
            var enumerator = queue.GetMessageEnumerator2();
            while (enumerator.MoveNext())
                return false;
            return true;
        }

        private void AutoRun()
        {
            int task = 0;
            comboBox1.Invoke(
                new Action(() => task =(int) comboBox1.SelectedValue));
            try
            {
                if (task == 1)
                {
                    messageQueueInput = new MessageQueue(@".\private$\inputTXT");
                    messageQueueOutput = new MessageQueue(@".\private$\outputTXT");
                }
                else
                {
                    messageQueueInput = new MessageQueue(@".\private$\inputMatrix");
                    messageQueueOutput = new MessageQueue(@".\private$\outputMatrix");
                }
                messageQueueInput.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
                messageQueueOutput.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the queue again!", "Warring!");
            }
            Message message = new Message();
            if (Count(messageQueueInput))
            {
                MessageBox.Show("The queue is empty!", "Warring!");
            }
            else if (task == 1)
            {
                String str, result, str_show="";
                while (true)
                {
                    message = messageQueueInput.Receive();

                    if (!message.Body.ToString().Equals("end"))
                    {
                        str = message.Body.ToString();
                        DataInputTXT.Enqueue(str);
                        result = str + "= " + TinhBieuThuc.calculator(str);
                        //MessageBox.Show(result);
                        str_show = result + "\n";
                        this.Invoke(new MethodInvoker(delegate () {
                            richTextBox1.AppendText(str_show);
                        }));
                        DataOutputTXT.Enqueue(result);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                while (true)
                {
                    message = messageQueueInput.Receive();

                    if (!message.Body.ToString().Equals("end"))
                    {
                        DataInputMatrix.Enqueue(message.Body.ToString());
                    }
                    else
                    {
                        break;
                    }
                }

                //tính toán
                Calculator();
            }

        }

        private void Calculator()
        {
            string kq = "";
            double[,] arr1 = new double[1000, 1000];
            double[,] arr2 = new double[1000, 1000];
            double[,] ma_tran_tich = new double[1000, 1000];
            double sum = 0;
            int i = 0, c1 = 0, r1 = 0, c2 = 0, r2 = 0, d = 0, a = 0, b = 0, i1 = 0, d1 = 0;
            bool check = false;
            // khởi tạo wb rỗng
            XSSFWorkbook wb = new XSSFWorkbook();

            // Tạo ra 1 sheet
            ISheet sheet = wb.CreateSheet();

            // Bắt đầu ghi lên sheet

            while (DataInputMatrix.Count > 0)
            {
                string bt = Convert.ToString(DataInputMatrix.Dequeue());
                #region Thực hiện phép tính
                try
                {
                    bt.Trim();
                    if (bt.Contains("x"))
                    {
                        string[] toan = bt.Split('x');
                        a = Convert.ToInt32(toan[0].Trim());
                        toan[1] = toan[1].Substring(0);
                        b = Convert.ToInt32(toan[1].Trim());
                    }
                    else if (check == false)
                    {
                        string[] numbers = bt.Split(' ');
                        for (int j = 0; j < numbers.Length; j++)
                        {
                            arr1[i, j] = Convert.ToInt32(numbers[j].Trim());
                        }
                        i++; // tăng chỉ số phần tử trong mỗi hàng
                        d++; // tăng dòng
                        if (d == a) // đến khi số dòng bằng số hàng trong file input
                        {
                            check = true;
                            r1 = a; // r1: số hàng ma trận 1
                            c1 = b; // c1: số cột ma trận 1
                        }
                    }
                    else if (check == true)
                    {
                        string[] numbers = bt.Split(' ');
                        for (int j = 0; j < numbers.Length; j++)
                        {
                            arr2[i1, j] = Convert.ToInt32(numbers[j].Trim());
                        }
                        i1++;
                        d1++;
                        if (d1 == a)
                        {
                            r2 = a; // r2: số hàng ma trận 2
                            c2 = b; // c2: số cột ma trận 2
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error!");
                    return;
                }
                #endregion
            }
            if (c1 != r2)
            {
                this.Invoke(new MethodInvoker(delegate () {
                    label_ViewR_Matrix.Text += "\n Can't multiply two matrices!";
                }));
                MessageBox.Show("Can't multiply two matrices!");
            }
            else
            {                
                // Nhân hai ma trận
                for (i = 0; i < r1; i++)
                    for (int j = 0; j < c2; j++)
                        ma_tran_tich[i, j] = 0;
                for (i = 0; i < r1; i++)    // Hàng của ma trận thứ nhất
                {
                    for (int j = 0; j < c2; j++)    // Cột của ma trận thứ hai
                    {
                        sum = 0;
                        for (int k = 0; k < c1; k++)
                            sum = sum + arr1[i, k] * arr2[k, j];
                        ma_tran_tich[i, j] = sum;
                        
                    }
                }
                var row0 = sheet.CreateRow(0);
                row0.CreateCell(0).SetCellValue(r1);
                row0.CreateCell(1).SetCellValue("x");
                row0.CreateCell(2).SetCellValue(c2);
                for (i = 0; i < r1; i++)
                {
                    var newRow = sheet.CreateRow(i + 1);
                    for (int j = 0; j < c2; j++)
                    {
                        //kq += String.Format("{0} ", ma_tran_tich[i, j]);
                        
                        newRow.CreateCell(j).SetCellValue(ma_tran_tich[i, j]);
                    }

                    //kq += "\n";
                }
                
                // xong hết thì save file lại
                if (tb_para2_Matrix.Text.Length < 5 || tb_para2_Matrix.Text.IndexOf(".xlsx", tb_para2_Matrix.Text.Length - 5, 5) == -1)
                {
                    MessageBox.Show("Yêu cầu nhập đúng định dạng văn bản (.xlsx)");
                }
                else
                {
                    kq = "Nhân ma trận thành công\n File kết quả: " + tb_para2_Matrix.Text;
                    DataOutputMatrix.Enqueue(kq);
                    this.Invoke(new MethodInvoker(delegate () {
                        richTextBox1.Text += kq;
                    }));
                    FileStream fs = new FileStream(tb_para2_Matrix.Text, FileMode.CreateNew);
                    wb.Write(fs);
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate () {
                label_ViewR_Matrix.Text = "---------------------------Result----------------------------";
            }));

            this.Invoke(new MethodInvoker(delegate () {
                richTextBox1.Text = "";
            }));
        }

        private void TienTrinh2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                tb_para2_Matrix.Enabled = true;
            }
            else
            {
                tb_para2_Matrix.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_ViewR_Matrix_Click(object sender, EventArgs e)
        {

        }

        private void label4_Matrix_Click(object sender, EventArgs e)
        {

        }
    }

    public class TinhBieuThuc
    {
        private static int priority(char c)
        {
            if (c == '+' || c == '-') return 1;
            else if (c == '*' || c == '/') return 2;
            else return 0;
        }

        private static Boolean isOperator(Char c)
        {
            Char[] a = { '+', '-', '*', '/', ')', '(' };
            for (int i = 0; i < a.Length; i++)
            {
                if (c == a[i]) return true;
            }
            return false;
        }

        // change string to operator array
        private static String[] processString(String sMath2)
        {

            String sMath = "";
            for (int i = 0; i < sMath2.Length; i++)
            {
                if (sMath2.ToCharArray()[i] != ' ') sMath += sMath2.ToCharArray()[i];
            }
            String s1 = "";
            String[] elementMath = null;
            sMath = sMath.Trim();
            sMath = sMath.Replace("s+", " ");
            Boolean preIsOpe = false;
            for (int i = 0; i < sMath.Length; i++)
            {
                char c = sMath[i];
                if (!isOperator(c))
                {
                    s1 = s1 + c;
                    preIsOpe = true;
                }
                else
                {
                    if (preIsOpe) s1 += " ";
                    preIsOpe = false;
                    s1 = s1 + c + " ";
                }
            }
            s1 = s1.Trim();
            s1 = s1.Replace("s+", " ");
            elementMath = s1.Split(' '); // split s1 to operators of array elementMath
            return elementMath;
        }

        private static String[] postfix(String[] elementMath)
        {
            String s1 = "";
            String[] E;
            Char[] elementMath_Array = elementMath[0].ToCharArray();
            Stack<String> S = new Stack<String>();

            for (int i = 0; i < elementMath.Length; i++)
            {
                char c = elementMath[i].ToCharArray()[0];

                if (!isOperator(c)) s1 = s1 + " " + elementMath[i];
                else
                {
                    if (c == '(') S.Push(elementMath[i]);
                    else
                    {
                        if (c == ')')
                        {
                            char c1;
                            do
                            {
                                c1 = S.Peek()[0];
                                if (c1 != '(') s1 = s1 + " " + S.Peek();
                                S.Pop();
                            } while (c1 != '(');
                        }
                        else
                        {
                            while (!(S.Count == 0) && priority(S.Peek()[0]) >= priority(c))
                            {
                                s1 = s1 + " " + S.Peek();
                                S.Pop();
                            }
                            S.Push(elementMath[i]);
                        }
                    }
                }
            }
            while (!(S.Count == 0))
            {
                s1 = s1 + " " + S.Peek();
                S.Pop();
            }
            s1 = s1.Trim();
            E = s1.Split(' ');
            return E;
        }

        private static String valueMath(String[] elementMath)
        {
            Stack<String> S = new Stack<String>();
            for (int i = 0; i < elementMath.Length; i++)
            {
                char c = elementMath[i].ToCharArray()[0];
                if (!isOperator(c)) S.Push(elementMath[i]);
                else
                {
                    double num = 0f;
                    double num1 = float.Parse(S.Pop());
                    double num2 = float.Parse(S.Pop());
                    switch (c)
                    {
                        case '+': num = num2 + num1; break;
                        case '-': num = num2 - num1; break;
                        case '*': num = num2 * num1; break;
                        case '/': num = num2 / num1; break;
                        default:
                            break;
                    }
                    S.Push(num.ToString());
                }
            }
            return S.Pop();
        }

        public static String calculator(String s_math)
        {
            if (checkString(s_math) == false) return "The expression is not correct!";
            String[] eMath = processString(s_math);
            eMath = postfix(eMath);
            return valueMath(eMath);
        }

        private static Boolean checkString(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!(str.ToCharArray()[i] == ' ' ||
                   (str.ToCharArray()[i] >= '0' && str.ToCharArray()[i] <= '9') ||
                   isOperator(str.ToCharArray()[i])))
                {
                    return false;
                }
            }
            return true;
        }

    }


}
