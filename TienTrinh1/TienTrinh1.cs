using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Messaging;
using System.Collections;
using Message = System.Messaging.Message;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Text;

namespace TienTrinh1
{
    public partial class TienTrinh1_Matrix : Form
    {
        private MessageQueue messageQueueInput;
        private MessageQueue messageQueueOutputMatrix;

        private MessageQueue messageQueueInputTXT;
        private MessageQueue messageQueueOutputTXT;

        private Queue DataInputMatrix;
        private Queue DataOutputMatrix;
        private List<string> ListInputMatrix;

        private Queue DataInputTXT;
        private Queue DataOutputTXT;
        private List<string> ListInputTXT;

        private void Form_Load()
        {
            var dict = new Dictionary<int, string>();
            dict.Add(1, "Xử lý phép tính");
            dict.Add(2, "Xử lý ma trận");

            comboBox1.DataSource = new BindingSource(dict, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }

        public TienTrinh1_Matrix()
        {
            InitializeComponent();
            Form_Load();
            messageQueueInput = new MessageQueue();
            messageQueueOutputMatrix = new MessageQueue();

            messageQueueInputTXT = new MessageQueue();
            messageQueueOutputTXT = new MessageQueue();

            DataInputMatrix = new Queue();
            DataOutputMatrix = new Queue();
            ListInputMatrix = new List<string>();

            DataInputTXT = new Queue();
            DataOutputTXT = new Queue();
            ListInputTXT = new List<string>();
            this.CenterToScreen();
        }

        private bool Input_txt()
        {
            try
            {
                FileStream fs = new FileStream(tb_para1_Matrix.Text, FileMode.Open);
                var sr = new StreamReader(fs, Encoding.UTF8);
                string line = String.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    ListInputTXT.Add(line);
                }
                foreach (string item in ListInputTXT)
                {
                    DataInputTXT.Enqueue(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn file phù hợp!!!!");
                return false;
            }
            
        }

        private bool Input_excel()
        {
            try
            {
                // Lấy stream file
                FileStream fs = new FileStream(tb_para1_Matrix.Text, FileMode.Open);

                // Khởi tạo workbook để đọc
                XSSFWorkbook wb = new XSSFWorkbook(fs);

                // Lấy sheet đầu tiên
                ISheet sheet = wb.GetSheetAt(0);

                // đọc sheet này bắt đầu từ row 2 (0, 1 bỏ vì tiêu đề)
                int rowIndex = 0;

                // xuất thong báo
                //Console.OutputEncoding = Encoding.UTF8; // để xuất ra console tv có dấu
                //Console.WriteLine("Thông tin SV từ file Excel XLSX");

                // nếu vẫn chưa gặp end thì vẫn lấy data
                int row1 = Convert.ToInt32(sheet.GetRow(0).GetCell(0).ToString());
                int col1 = Convert.ToInt32(sheet.GetRow(0).GetCell(2).ToString());
                int row2 = Convert.ToInt32(sheet.GetRow(1 + row1).GetCell(0).ToString());
                int col2 = Convert.ToInt32(sheet.GetRow(1 + row1).GetCell(2).ToString());
                int d = 0;
                bool check = false;
                while (sheet.GetRow(rowIndex).GetCell(0).ToString() != "end")
                {
                    // lấy row hiện tại
                    var nowRow = sheet.GetRow(rowIndex);
                    string data = "";

                    if(nowRow.GetCell(1).ToString() == "x")
                    {
                        for(int i = 0; i < 3; i++)
                        {
                            if (i == 2)
                            {
                                data += nowRow.GetCell(i).ToString();
                                break;
                            }
                            data += nowRow.GetCell(i).ToString() + " ";
                            
                        }
                        ListInputMatrix.Add(data);
                    }
                    else if (check == false)
                    {
                        d++;
                        for (int i = 0; i < col1; i++)
                        {
                            if(i == (col1 - 1))
                            {
                                data += nowRow.GetCell(i).ToString();
                                break;
                            }
                            data += nowRow.GetCell(i).ToString() + " ";
                            
                        }
                        ListInputMatrix.Add(data);
                        if (d == row1)
                        {
                            check = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < col2; i++)
                        {
                            if (i == (col2 - 1))
                            {
                                data += nowRow.GetCell(i).ToString();
                                break;
                            }
                            data += nowRow.GetCell(i).ToString() + " ";

                        }
                        ListInputMatrix.Add(data);
                    }

                    // vì ta dùng 3 cột A, B, C => data của ta sẽ như sau
                    //var MSSV = nowRow.GetCell(0).ToString();
                    //var Name = nowRow.GetCell(1).ToString();
                    //var Phone = nowRow.GetCell(2).ToString();

                    // Xuất ra thông tin lên màn hình
                    //Console.WriteLine("MSSV: {0} | Họ & Tên: {1} | SDT: {2}", MSSV, Name, Phone);

                    // tăng index khi lấy xong
                    rowIndex++;
                }
                ListInputMatrix.Add("end");

                //ListInput = (File.ReadAllLines(tb_para1.Text)).ToList();
                foreach(string item in ListInputMatrix)
                {
                    DataInputMatrix.Enqueue(item);
                }  
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn file phù hợp");
                return false;
            }
        }

        private  void btn_ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file chứa dữ liệu đầu vào";
            openFileDialog.InitialDirectory = @"C:\Users\PC\Desktop";
            if (comboBox1.SelectedIndex == 0)
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt";            
            }
            else
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            }
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_para1_Matrix.Text = openFileDialog.FileName;
            }
        }

        private  void btn_InputData_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                    messageQueueInput = new MessageQueue(@".\private$\inputTXT");
                else
                    messageQueueInput = new MessageQueue(@".\private$\inputMatrix");
                messageQueueInput.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra lại hàng đợi!");
                return;
            }
            if (DataInputMatrix == null || DataInputMatrix.Count <= 0)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (Input_txt() == false)
                        return;
                    while (DataInputTXT.Count > 0)
                    {
                        messageQueueInput.Send(Convert.ToString(DataInputTXT.Dequeue()));
                    }
                }
                else
                {
                    if (Input_excel() == false)
                        return;
                    while (DataInputMatrix.Count > 0)
                    {
                        messageQueueInput.Send(Convert.ToString(DataInputMatrix.Dequeue()));
                    }
                }
                MessageBox.Show("Nạp dữ liệu vào hàng đợi thành công!!!");
            }
        }

        private  void btn_Pull_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(Pull_Data);
            thrd.Start();
        }
        
        private void Pull_Data()
        {
            while (true)
            {
                try
                {
                    messageQueueOutputMatrix = new MessageQueue(@".\private$\inputMatrix");
                    // Set the formatter to indicate body contains an Order.
                    messageQueueOutputMatrix.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại hàng đợi");
                    return;
                }
                Message message = new Message();
                message = messageQueueOutputMatrix.Receive();
                if (message.Body != null)
                {
                    this.Invoke(new MethodInvoker(delegate () {
                        label_Result_Matrix.Text += (message.Body.ToString()) + "\n";
                    }));
                    Thread.Sleep(1000);
                }
                else
                {
                    break;
                }
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate () {
                label_Result_Matrix.Text = "-----------------------------Kết quả-----------------------------";
            }));
            ListInputMatrix.Clear();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Matrix_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 1)
            {
                txt_bieuthuc.Enabled = false;
                btn_napdulieu_txt.Enabled = false;
                btn_reset.Enabled = false;
            }
            else
            {
                txt_bieuthuc.Enabled = true;
                btn_napdulieu_txt.Enabled = true;
                btn_reset.Enabled = true;
            }
        }

        private void label_Result_Matrix_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_napdulieu_txt_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                    messageQueueInput = new MessageQueue(@".\private$\inputTXT");
                else
                    messageQueueInput = new MessageQueue(@".\private$\inputMatrix");
                messageQueueInput.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra lại hàng đợi!");
                return;
            }
            String txt_input = txt_bieuthuc.Text;
            if (DataInputMatrix == null || DataInputMatrix.Count <= 0)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    messageQueueInput.Send(txt_input);
                }
                MessageBox.Show("Nạp dữ liệu vào hàng đợi thành công!!!");
                txt_bieuthuc.Text = "";
            }
        }
    }
}
