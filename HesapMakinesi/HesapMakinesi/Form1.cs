using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //ÇALINTI
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        void UstBorder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // ÇALINTI

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(400, 550);
            this.Location = new Point(470, 140);
            this.BackColor = Color.FromArgb(35, 35, 35);
            NesnelerOlustur();
        }

        double islem1, islem2;

        char operate = '\0';

        bool islemyapildi = false;

        void ExitMouseEnter(Object sender, EventArgs e)
        {
            Label exit = sender as Label;
            exit.BackColor = Color.IndianRed;
            exit.ForeColor = Color.White;
        }
        void ExitMouseLeave(Object sender, EventArgs e)
        {
            Label exit = sender as Label;
            exit.BackColor = Color.Red;
            exit.ForeColor = SystemColors.Control;
        }
        void ExitMouseDown(Object sender, MouseEventArgs e)
        {
            Label exit = sender as Label;
            exit.BackColor = Color.DarkRed;
            exit.ForeColor = SystemColors.ControlDark;
        }
        void ExitMouseClick(Object sender, MouseEventArgs e)
        {
            Application.Exit();
        }


        Label islemLabel = new Label();
        void NesnelerOlustur()
        {
            Panel ustBorder = new Panel();
            this.Controls.Add(ustBorder);
            ustBorder.Size = new Size(400, 36);
            ustBorder.BackColor = Color.Transparent;


            Panel anaPanel = new Panel();
            this.Controls.Add(anaPanel);
            anaPanel.BackColor = Color.FromArgb(40, 40, 40);
            anaPanel.Size = new Size(388, 508);
            anaPanel.Location = new Point(6, 36);
            anaPanel.BorderStyle = BorderStyle.FixedSingle;


            int sayac = 0, x = -80, y = 106, yek = 0;
            string[] dizi = { "×", "÷", "DEL", "CLR", "7", "8", "9", "+", "4", "5", "6", "-", "1", "2", "3", "=", "+/-", "0", "," };
            for (int i = 0; i < 19; i++)
            {
                Button buton = new Button();
                anaPanel.Controls.Add(buton);
                buton.FlatStyle = FlatStyle.Popup;
                buton.Name = "buton" + (sayac + 1);
                buton.ForeColor = Color.White;
                buton.Font = new Font("Calibri", 16, FontStyle.Bold);
                buton.Size = new Size(84, 60);
                if (buton.Name == "buton3")
                {
                    buton.BackColor = Color.FromArgb(200, 200, 90);
                }
                else if (buton.Name == "buton4")
                {
                    buton.BackColor = Color.FromArgb(220, 70, 70);
                }
                else if (buton.Name == "buton1" || buton.Name == "buton2" || buton.Name == "buton8" || buton.Name == "buton12")
                {
                    buton.BackColor = Color.FromArgb(170, 170, 170);
                    buton.ForeColor = SystemColors.ControlText;
                    if (buton.Name == "buton12")
                    {
                        buton.Font = new Font("Calibri", 20, FontStyle.Bold);
                    }
                }
                else if (buton.Name == "buton16")
                {
                    buton.Size = new Size(84, 130);
                    buton.BackColor = Color.White;
                    buton.ForeColor = Color.Black;
                }
                else
                {
                    buton.BackColor = Color.FromArgb(80, 80, 80);
                }
                if (Convert.ToInt32(Math.Floor((decimal)sayac / 4)) > yek)
                {
                    yek += 1;
                    x = -80;
                }
                buton.Location = new Point(x + 84 + 6, y + (60 * yek + yek * 10) + 40);
                x = x + 89 + 6;
                buton.Text = dizi[sayac];
                buton.Click += new EventHandler(buton_click);
                sayac++;
            }


            Panel islemPanel = new Panel();
            anaPanel.Controls.Add(islemPanel);
            islemPanel.BackColor = Color.FromArgb(71, 171, 102);
            islemPanel.Size = new Size(368, 100);
            islemPanel.Location = new Point(10, 20);
            islemPanel.BorderStyle = BorderStyle.Fixed3D;

            islemLabel.AutoSize = false;
            islemLabel.Text = "";
            islemLabel.Font = new Font("Calibri", 25, FontStyle.Bold);
            islemLabel.TextAlign = ContentAlignment.MiddleRight;
            islemPanel.Controls.Add(islemLabel);
            islemLabel.Size = new Size(368, 100);
            islemLabel.BackColor = Color.Transparent;

            Label exitApp = new Label();
            this.Controls.Add(exitApp);
            exitApp.Size = new Size(30, 30);
            exitApp.Location = new Point(370, 0);
            exitApp.TextAlign = ContentAlignment.MiddleCenter;
            exitApp.Text = "X";
            exitApp.Font = new Font("Calibri", 13, FontStyle.Bold);
            exitApp.BackColor = Color.Red;
            exitApp.ForeColor = SystemColors.Control;
            exitApp.Cursor = Cursors.Hand;
            exitApp.BringToFront();
            exitApp.MouseEnter += new EventHandler(ExitMouseEnter);
            exitApp.MouseLeave += new EventHandler(ExitMouseLeave);
            exitApp.MouseDown += new MouseEventHandler(ExitMouseDown);
            exitApp.MouseClick += new MouseEventHandler(ExitMouseClick);

            Label mainText = new Label();
            ustBorder.Controls.Add(mainText);
            mainText.Font = new Font("Calibri", 18, FontStyle.Bold);
            mainText.ForeColor = SystemColors.ControlLight;
            mainText.AutoSize = false;
            mainText.Size = new Size(394, 36);
            mainText.Location = new Point(0, 0);
            mainText.TextAlign = ContentAlignment.MiddleCenter;
            mainText.MouseDown += new MouseEventHandler(UstBorder_MouseDown);
            mainText.Text = "Hesap Makinesi";
        }

        //ÇALINTI
        public bool IsDouble(string text)
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDouble = Double.TryParse(text, out num);

            return isDouble;
        }
        //ÇALINTI

        int virgulburada1 = -1, virgulburada2 = -1;
        bool selectedIslem = false;
        char[] simdiki = new char[20];
        int takipsayisi = 0;
        void buton_click(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (IsDouble(btn.Text) && takipsayisi < 7)
            {
                if (islemyapildi == true)
                {
                    islem1 = 0;
                    selectedIslem = false;
                    for (int i = 0; i < 8; i++)
                    {
                        simdiki[i] = '\0';
                    }
                    takipsayisi = 0;
                    islemyapildi = false;
                }
                if (!selectedIslem)
                {
                    simdiki[takipsayisi] = Convert.ToChar(btn.Text);
                    takipsayisi++;
                    islemLabel.Text = new string(simdiki);
                }
                else
                {
                    simdiki[takipsayisi] = Convert.ToChar(btn.Text);
                    takipsayisi++;
                    islemLabel.Text = islem1 + " " + Convert.ToString(operate) + " " + new string(simdiki);
                }
            }
            else if (btn.Text == "+" || btn.Text == "-" || btn.Text == "×" || btn.Text == "÷")
            {
                if (islemyapildi == true)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        simdiki[i] = '\0';
                    }
                    takipsayisi = 0;
                    islemyapildi = false;
                }
                if (!selectedIslem)
                {
                    if (simdiki[0] != '\0')
                    {
                        try
                        {
                            islem1 = Convert.ToDouble(islemLabel.Text);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.ToString());
                        }
                    }
                }
                operate = Convert.ToChar(btn.Text);
                islemLabel.Text = islem1 + " " + Convert.ToString(operate) + " ";
                selectedIslem = true;
                for (int i = 0; i < 8; i++)
                {
                    simdiki[i] = '\0';
                }
                takipsayisi = 0;
            }
            else if (btn.Text == "=")
            {
                if (selectedIslem && simdiki[0] == '-' && simdiki[1] == '\0')
                {
                    islemLabel.Text = "Fuzuli şeyler denema -.-";
                    islemyapildi = true;
                }
                else if (selectedIslem && simdiki[0] != '\0')
                {


                    islem2 = Convert.ToDouble(islemLabel.Text.Remove(0, Convert.ToString(islem1).Length + 2));
                    int sonsayi = 0;
                    for (int i = 0; i < Convert.ToString(islem2).Length; i++)
                    {
                        if (Char.IsDigit(Convert.ToString(islem2)[i]))
                        {
                            sonsayi = i;
                        }
                    }
                    islem2 = Convert.ToDouble(Convert.ToString(islem2));
                    IslemDerle();
                    islem2 = 0;
                    operate = '\0';
                    selectedIslem = false;
                    takipsayisi = Convert.ToString(islem1).Length;
                }
            }
            else if (btn.Text == "CLR")
            {
                selectedIslem = islemyapildi = false;
                islem1 = islem2 = 0;
                virgulburada1 = virgulburada2 = -1;
                for (int i = 0; i < 8; i++)
                {
                    simdiki[i] = '\0';
                }
                takipsayisi = 0;
                islemLabel.Text = "";
                operate = '\0';
            }
            else if (btn.Text == "DEL")
            {
                if (islemyapildi)
                {
                    selectedIslem = islemyapildi = false;
                    islem1 = islem2 = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        simdiki[i] = '\0';
                    }
                    takipsayisi = 0;
                    operate = '\0';
                }
                if (!selectedIslem)
                {
                    if (takipsayisi > 0)
                    {
                        if (simdiki[takipsayisi - 1] == ',')
                        {
                            if (!selectedIslem)
                            {
                                virgulburada1 = -1;
                            }
                            else
                            {
                                virgulburada2 = -1;
                            }
                        }
                        simdiki[takipsayisi - 1] = '\0';
                        if (takipsayisi > 0)
                        {
                            takipsayisi--;
                        }
                        islemLabel.Text = new string(simdiki);
                    }
                }
                else
                {
                    if (takipsayisi > 0)
                    {
                        simdiki[takipsayisi - 1] = '\0';
                        simdiki[takipsayisi - 1] = '\0';
                        if (takipsayisi > 0)
                        {
                            takipsayisi--;
                        }
                        islemLabel.Text = islem1 + " " + Convert.ToString(operate) + " " + new string(simdiki);
                    }
                }
                islemyapildi = false;
            }
            else if (btn.Text == "+/-")
            {
                if (islemyapildi == true)
                {
                    selectedIslem = islemyapildi = false;
                    islem1 = islem2 = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        simdiki[i] = '\0';
                    }
                    takipsayisi = 0;
                    operate = '\0';
                }
                if (!selectedIslem)
                {
                    if (simdiki[0] == '\0')
                    {
                        simdiki[0] = '-';
                        takipsayisi++;
                        islemLabel.Text = new string(simdiki);
                    }
                    else if (simdiki[0] == '-' && simdiki[1] == '\0')
                    {
                        simdiki[0] = '\0';
                        takipsayisi--;
                        islemLabel.Text = new string(simdiki);
                    }
                    else if (simdiki[0] == '-' && simdiki[1] != '\0')
                    {
                        int i = 0;
                        for (i = 0; i < simdiki.Length - 1; i++)
                        {
                            simdiki[i] = simdiki[i + 1];
                        }
                        simdiki[i] = 'q';
                        takipsayisi--;
                        islemLabel.Text = new string(simdiki);
                    }
                    else
                    {
                        if (simdiki[takipsayisi] < simdiki.Length)
                        {
                            for (int i = takipsayisi; i > 0; i--)
                            {

                                simdiki[i] = simdiki[i - 1];
                            }
                            simdiki[0] = '-';
                            takipsayisi++;
                            islemLabel.Text = new string(simdiki);
                        }
                    }
                }
                else
                {
                    if (simdiki[0] == '\0')
                    {
                        simdiki[0] = '-';
                        takipsayisi++;
                        islemLabel.Text = islem1 + " " + Convert.ToString(operate) + " " + new string(simdiki);
                    }
                    else if (simdiki[0] == '-' && simdiki[1] == '\0')
                    {
                        simdiki[0] = '\0';
                        takipsayisi--;
                        islemLabel.Text = islem1 + " " + Convert.ToString(operate) + " " + new string(simdiki);
                    }
                    else if (simdiki[0] == '-' && simdiki[1] != '\0')
                    {
                        int i = 0;
                        for (i = 0; i < simdiki.Length - 1; i++)
                        {
                            simdiki[i] = simdiki[i + 1];
                        }
                        simdiki[i] = 'q';
                        takipsayisi--;
                        islemLabel.Text = islem1 + " " + Convert.ToString(operate) + " " + new string(simdiki);
                    }
                    else
                    {
                        if (simdiki[takipsayisi] < simdiki.Length)
                        {
                            for (int i = takipsayisi; i > 0; i--)
                            {

                                simdiki[i] = simdiki[i - 1];
                            }
                            simdiki[0] = '-';
                            takipsayisi++;
                            islemLabel.Text = islem1 + " " + Convert.ToString(operate) + " " + new string(simdiki);
                        }
                    }
                }
            }
            else if (btn.Text == ",")
            {
                if (islemyapildi)
                {
                    selectedIslem = islemyapildi = false;
                    islem1 = islem2 = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        simdiki[i] = '\0';
                    }
                    takipsayisi = 0;
                    operate = '\0';
                }
                if (takipsayisi > 0)
                {
                    if (!selectedIslem)
                    {
                        if (virgulburada1 >= 0)
                        {
                            return;
                        }
                        else
                        {
                            simdiki[takipsayisi] = ',';
                            virgulburada1 = takipsayisi;
                            islemLabel.Text = new string(simdiki);
                            takipsayisi++;
                        }
                    }
                    else
                    {
                        if (virgulburada2 >= 0)
                        {
                            return;
                        }
                        else
                        {
                            simdiki[takipsayisi] = ',';
                            virgulburada2 = takipsayisi;
                            islemLabel.Text = islem1 + " " + operate + " " + new string(simdiki);
                            takipsayisi++;
                        }
                    }
                }
            }
        }

        void IslemDerle()
        {
            try
            {
                if (operate == '+')
                {
                    islemLabel.Text = Convert.ToString(Math.Round(islem1 + islem2, 5));
                }
                else if (operate == '-')
                {
                    islemLabel.Text = Convert.ToString(Math.Round(islem1 - islem2, 5));
                }
                else if (operate == '×')
                {
                    islemLabel.Text = Convert.ToString(Math.Round(islem1 * islem2, 5));
                }
                else if (operate == '÷')
                {
                    if (islem2 == 0)
                    {
                        islemLabel.Text = "Buralar yanar...";
                    }
                    else
                    {
                        islemLabel.Text = Convert.ToString(Math.Round(islem1 / islem2, 5));
                    }
                }
                else
                {
                    MessageBox.Show("nE?");
                    return;
                }
                if (islemLabel.Text == "Buralar yanar...")
                {
                    selectedIslem = islemyapildi = false;
                    islem1 = islem2 = 0;
                    virgulburada1 = virgulburada2 = -1;
                    for (int i = 0; i < 8; i++)
                    {
                        simdiki[i] = '\0';
                    }
                    takipsayisi = 0;
                    operate = '\0';
                }
                else if (islemLabel.Text.Length > 17)
                {
                    islemLabel.Text = "Eee noldu şimdi?";
                    for (int i = 0; i < 8; i++)
                    {
                        simdiki[i] = '\0';
                    }
                    islem1 = islem2 = 0;
                    virgulburada1 = virgulburada2 = -1;
                }
                else
                {
                    islem1 = double.Parse(islemLabel.Text);
                    islemyapildi = true;
                    virgulburada1 = virgulburada2 = -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
