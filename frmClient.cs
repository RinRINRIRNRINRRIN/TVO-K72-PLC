using Serilog;
using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Simulator_PLC
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
            Log.Logger = new LoggerConfiguration().
                WriteTo.File(Application.StartupPath + "\\Logs\\Log-.txt", rollingInterval: RollingInterval.Day).
                CreateLogger();
        }

        string modeSilo1 = "";
        string modeSilo2 = "";


        private void btnConnectPLC_Click(object sender, EventArgs e)
        {
            switch (btnConnectPLC.Text)
            {
                case "Connect":

                    try
                    {
                        foreach (var cbb in pnPLC.Controls.OfType<ComboBox>())
                        {
                            if (cbb.Text.Contains('-'))
                            {
                                MessageBox.Show("กรุณาตั้งค่า PLC ให้เรียบร้อยก่อนทำการ เชื่อมต่อ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string _comport = cbbCom.Text;
                        string _buadrate = cbbBuadrate.Text;
                        string _parity = cbbParitys.Text;
                        string _stopbits = cbbStopbits.Text;
                        string _databits = cbbDatabits.Text;

                        Parity parity = (Parity)Enum.Parse(typeof(Parity), _parity);
                        StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopbits);

                        spPLC.PortName = _comport;
                        spPLC.BaudRate = int.Parse(_buadrate);
                        spPLC.Parity = parity;
                        spPLC.StopBits = stopBits;
                        spPLC.DataBits = int.Parse(_databits);

                        spPLC.Open();
                        pnPLC.Enabled = false;
                        btnConnectPLC.Text = "Disconnect";
                        MessageBox.Show("เชื่อมต่อ PLC สำเร็จ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SerializationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show($"ไม่สามารถเชื่อมต่อ PLC \n {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Disconnect":
                    try
                    {
                        spPLC.Close();
                        pnPLC.Enabled = true;
                        btnConnectPLC.Text = "Connect";
                        MessageBox.Show("ยกเลิกเชื่อมต่อ PLC สำเร็จ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show($"ไม่สามารถเชื่อมต่อ PLC \n {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
            }
        }

        private void cbbCom_DropDown(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            switch (cbb.Name)
            {
                case "cbbCom":
                    string[] comList = SerialPort.GetPortNames();
                    cbb.Items.Clear();
                    foreach (var element in comList)
                    {
                        cbb.Items.Add(element);
                    }
                    break;
                case "cbbBuadrate":
                    cbb.Items.Clear();
                    cbb.Items.Add(9600);
                    cbb.Items.Add(14400);
                    cbb.Items.Add(19200);
                    cbb.Items.Add(38400);
                    cbb.Items.Add(115200);
                    break;
                case "cbbStopbits":
                    cbb.Items.Clear();
                    cbb.Items.Add("One");
                    cbb.Items.Add("Two");
                    cbb.Items.Add("OnePointFive");
                    break;
                case "cbbParitys":
                    cbb.Items.Clear();
                    cbb.Items.Add("None");
                    cbb.Items.Add("Odd");
                    cbb.Items.Add("Even");
                    cbb.Items.Add("Mark");
                    cbb.Items.Add("Space");
                    break;
                case "cbbDatabits":
                    cbb.Items.Clear();
                    cbb.Items.Add(4);
                    cbb.Items.Add(5);
                    cbb.Items.Add(6);
                    cbb.Items.Add(7);
                    cbb.Items.Add(8);
                    break;
            }
        }

        private void cbbStopbits_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.Text == "")
            {
                cbb.Items.Clear();
                switch (cbb.Name)
                {
                    case "cbbCom":
                        cbb.Items.Add("--COM--");
                        cbb.SelectedIndex = 0;
                        break;
                    case "cbbBuadrate":
                        cbbBuadrate.Items.Add("--Buadrate--");
                        cbbBuadrate.SelectedIndex = 0;
                        break;
                    case "cbbStopbits":

                        cbbStopbits.Items.Add("--Stopbits--");
                        cbbStopbits.SelectedIndex = 0;
                        break;
                    case "cbbParitys":
                        cbbParitys.Items.Add("--Parity--");
                        cbbParitys.SelectedIndex = 0;
                        break;
                    case "cbbDatabits":
                        cbbDatabits.Items.Add("--Databits--");
                        cbbDatabits.SelectedIndex = 0;
                        break;
                }
            }
        }

        private async void spPLC_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string reqPLC = spPLC.ReadLine();
                byte[] value = Encoding.UTF8.GetBytes(reqPLC);
                string reqconvert = BitConverter.ToString(value);
                Log.Information("RX : " + reqconvert);

                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    richTextBox1.AppendText("\n ====================================");
                    richTextBox1.AppendText("\nRX : " + reqconvert);
                }));

                byte[] res45 = { 0x02, 0x00, 0x45, 0x0D, 0x0A };
                byte[] res06 = { 0x02, 0x00, 0x06, 0x0D, 0x0A };

                byte[] resModeMN = { 0x02, 0x00, 0x01, 0x0d, 0x0a };
                byte[] resModeSMA = { 0x02, 0x00, 0x02, 0x0d, 0x0a };
                byte[] resModeAT = { 0x02, 0x00, 0x03, 0x0d, 0x0a };


                byte[] alertAckKnowLage = { 0x02, 0x00, 0x07, 0x0D, 0x0A };
                byte[] erSilo1 = { 0x02, 0x00, 0x08, 0x0D, 0x0A };
                byte[] erSilo2 = { 0x02, 0x00, 0x09, 0x0D, 0x0A };

                if (cbAckKnowLage.Checked)
                {
                    spPLC.Write(alertAckKnowLage, 0, alertAckKnowLage.Length);
                    return;
                }
                switch (reqconvert.Replace('-', ' '))
                {
                    case "02 00 15 0D":
                        await Task.Delay(1000);
                        spPLC.Write(res45, 0, res45.Length);

                        this.BeginInvoke(new MethodInvoker(delegate ()
                        {
                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res45));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));
                        Log.Information("TX : " + BitConverter.ToString(res45));
                        break;
                    case "02 00 16 0D":
                        await Task.Delay(1000);
                        spPLC.Write(res45, 0, res45.Length);
                        this.BeginInvoke(new MethodInvoker(delegate ()
                        {
                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res45));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));
                        Log.Information("TX : " + BitConverter.ToString(res45));
                        break;
                    case "02 00 17 0D":
                        if (radioButton1.Checked)
                        {
                            spPLC.Write(resModeMN, 0, resModeMN.Length);
                            Log.Information("TX : " + BitConverter.ToString(resModeMN));
                            this.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                richTextBox1.AppendText("\nTX : " + BitConverter.ToString(resModeMN));
                                richTextBox1.AppendText("\n====================================");
                                richTextBox1.ScrollToCaret();
                            }));
                        }
                        if (radioButton2.Checked)
                        {
                            spPLC.Write(resModeSMA, 0, resModeSMA.Length);
                            Log.Information("TX : " + BitConverter.ToString(resModeSMA));
                            this.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                richTextBox1.AppendText("\nTX : " + BitConverter.ToString(resModeSMA));
                                richTextBox1.AppendText("\n====================================");
                                richTextBox1.ScrollToCaret();
                            }));
                        }
                        if (radioButton3.Checked)
                        {
                            spPLC.Write(resModeAT, 0, resModeAT.Length);
                            Log.Information("TX : " + BitConverter.ToString(resModeAT));
                            this.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                richTextBox1.AppendText("\nTX : " + BitConverter.ToString(resModeAT));
                                richTextBox1.AppendText("\n====================================");
                                richTextBox1.ScrollToCaret();
                            }));
                        }
                        break;
                    case "02 00 18 0D":
                        byte[] dataMN = { 0x02, 0x00, 0x11, 0x0D, 0x0A };
                        byte[] dataSMA = { 0x02, 0x00, 0x12, 0x0D, 0x0A };
                        byte[] dataAT = { 0x02, 0x00, 0x13, 0x0D, 0x0A };
                        if (radioButton6.Checked)
                        {
                            spPLC.Write(dataMN, 0, dataMN.Length);
                            Log.Information("TX : " + BitConverter.ToString(dataMN));
                            this.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                richTextBox1.AppendText("\nTX : " + BitConverter.ToString(dataMN));
                                richTextBox1.AppendText("\n====================================");
                                richTextBox1.ScrollToCaret();
                            }));
                        }
                        if (radioButton5.Checked)
                        {
                            spPLC.Write(dataSMA, 0, dataSMA.Length);
                            Log.Information("TX : " + BitConverter.ToString(dataSMA));
                            this.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                richTextBox1.AppendText("\nTX : " + BitConverter.ToString(dataSMA));
                                richTextBox1.AppendText("\n====================================");
                                richTextBox1.ScrollToCaret();
                            }));
                        }
                        if (radioButton4.Checked)
                        {
                            spPLC.Write(dataAT, 0, dataAT.Length);
                            Log.Information("TX : " + BitConverter.ToString(dataAT));
                            this.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                richTextBox1.AppendText("\nTX : " + BitConverter.ToString(dataAT));
                                richTextBox1.AppendText("\n====================================");
                                richTextBox1.ScrollToCaret();
                            }));
                        }
                        break;
                    case "02 00 41 0D":
                        spPLC.Write(res06, 0, res06.Length);
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label4.Text = "100%";
                            Log.Information("TX : " + BitConverter.ToString(res06));

                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res06));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();

                        }));
                        break;
                    case "02 00 42 0D":

                        spPLC.Write(res06, 0, res06.Length);
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label4.Text = "25%";
                            Log.Information("TX : " + BitConverter.ToString(res06));

                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res06));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));
                        break;
                    case "02 00 43 0D":
                        spPLC.Write(res06, 0, res06.Length);
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label4.Text = "ปิดวาล์ว";
                            Log.Information("TX : " + BitConverter.ToString(res06));

                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res06));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));
                        break;
                    case "02 00 31 0D":
                        spPLC.Write(res06, 0, res06.Length);
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label1.Text = "100%";
                            Log.Information("TX : " + BitConverter.ToString(res06));

                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res06));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));
                        break;
                    case "02 00 32 0D":
                        spPLC.Write(res06, 0, res06.Length);
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label1.Text = "25%";
                            Log.Information("TX : " + BitConverter.ToString(res06));

                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res06));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));
                        break;
                    case "02 00 33 0D":
                        spPLC.Write(res06, 0, res06.Length);
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label1.Text = "ปิดวาล์ว";
                            Log.Information("TX : " + BitConverter.ToString(res06));

                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res06));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));
                        break;
                    case "02 00 1A 0D":
                        spPLC.Write(res06, 0, res06.Length);
                        Log.Information("TX : " + BitConverter.ToString(res06));
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            btnManualBB300.Enabled = false;
                            btnManualBB400.Enabled = false;
                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res06));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));


                        break;
                    case "02 00 1B 0D":
                        spPLC.Write(res06, 0, res06.Length);
                        Log.Information("TX : " + BitConverter.ToString(res06));
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            btnManualBB300.Enabled = true;
                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res06));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));

                        break;
                    case "02 00 2B 0D":
                        spPLC.Write(res06, 0, res06.Length);
                        Log.Information("TX : " + BitConverter.ToString(res06));
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            btnManualBB400.Enabled = true;
                            richTextBox1.AppendText("\nTX : " + BitConverter.ToString(res06));
                            richTextBox1.AppendText("\n====================================");
                            richTextBox1.ScrollToCaret();
                        }));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;

            byte[] MN = { 0x02, 0x00, 0x01, 0x0D, 0x0A };
            byte[] SMA = { 0x02, 0x00, 0x02, 0x0D, 0x0A };
            byte[] AT = { 0x02, 0x00, 0x03, 0x0D, 0x0A };

            if (rdb.Checked)
            {
                switch (rdb.Name)
                {
                    case "radioButton1":
                        spPLC.Write(MN, 0, MN.Length);
                        break;
                    case "radioButton2":
                        spPLC.Write(SMA, 0, AT.Length);
                        break;
                    case "radioButton3":
                        spPLC.Write(AT, 0, SMA.Length);
                        break;
                }
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;

            byte[] MN = { 0x02, 0x00, 0x11, 0x0D, 0x0A };
            byte[] SMA = { 0x02, 0x00, 0x12, 0x0D, 0x0A };
            byte[] AT = { 0x02, 0x00, 0x13, 0x0D, 0x0A };

            if (rdb.Checked)
            {
                switch (rdb.Name)
                {
                    case "radioButton6":
                        spPLC.Write(MN, 0, MN.Length);
                        break;
                    case "radioButton5":
                        spPLC.Write(SMA, 0, AT.Length);
                        break;
                    case "radioButton4":
                        spPLC.Write(AT, 0, SMA.Length);
                        break;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.BackColor = Color.Green;
            tmBB300.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.BackColor = Color.Green;
            tmBB400.Start();
        }

        private void cbErrSilo1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbErrSilo1.Checked)
            {
                byte[] erSilo1 = { 0x02, 0x00, 0x08, 0x0D, 0x0A };
                spPLC.Write(erSilo1, 0, erSilo1.Length);
                richTextBox1.AppendText("\nTX : " + BitConverter.ToString(erSilo1));
                richTextBox1.ScrollToCaret();
            }
        }

        private void cbErrSIlo2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbErrSIlo2.Checked)
            {
                byte[] erSilo2 = { 0x02, 0x00, 0x09, 0x0D, 0x0A };
                spPLC.Write(erSilo2, 0, erSilo2.Length);
                richTextBox1.AppendText("\nTX : " + BitConverter.ToString(erSilo2));
                richTextBox1.ScrollToCaret();
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            Log.Information("=========================================== Open program");
        }

        private void cbAckKnowLage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tmBB300_Tick(object sender, EventArgs e)
        {
            label2.BackColor = Color.Red;
            tmBB300.Stop();
        }

        private void tmBB400_Tick(object sender, EventArgs e)
        {
            label3.BackColor = Color.Red;
            tmBB400.Stop();
        }
    }
}
