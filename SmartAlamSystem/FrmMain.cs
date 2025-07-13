using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartAlamSystem
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
        }
    }

    public partial class FrmMain : Form
    {
        private System.Windows.Forms.Timer timer;
        private int counter = 0;
        private Label label1;
        private Button btnStart;
        private Button btnStop;
        private Panel panel1;

        public FrmMain()
        {
            InitializeComponent();

            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //             ControlStyles.AllPaintingInWmPaint |
            //             ControlStyles.UserPaint, true);

            //// ʹ���Զ���Panel
            //panel1 = new DoubleBufferedPanel
            //{
            //    Location = new Point(20, 120),
            //    Size = new Size(360, 150),
            //    BackColor = Color.White,
            //    BorderStyle = BorderStyle.FixedSingle
            //};
            //panel1.Paint += Panel1_Paint;

            this.Text = "WinForms ��˸ʾ��";
            this.ClientSize = new Size(400, 300);

            // �����ؼ�
            label1 = new Label
            {
                Text = "��˸������: 0",
                Location = new Point(20, 20),
                Size = new Size(200, 30),
                Font = new Font("Microsoft YaHei", 12)
            };

            btnStart = new Button
            {
                Text = "��ʼ��˸",
                Location = new Point(20, 70),
                Size = new Size(100, 30)
            };

            btnStop = new Button
            {
                Text = "ֹͣ��˸",
                Location = new Point(140, 70),
                Size = new Size(100, 30),
                Enabled = false
            };

            panel1 = new Panel
            {
                Location = new Point(20, 120),
                Size = new Size(360, 150),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // ��ӿؼ�������
            this.Controls.Add(label1);
            this.Controls.Add(btnStart);
            this.Controls.Add(btnStop);
            this.Controls.Add(panel1);

            // �����¼�����
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;

            // ������ʱ��
            timer = new System.Windows.Forms.Timer
            {
                Interval = 50 // ���ý϶̵ļ������ǿ��˸Ч��
            };
            timer.Tick += Timer_Tick;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            timer.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            label1.Text = $"��˸������: {counter}";

            // ����������˸Ч��
            panel1.BackColor = (counter % 2 == 0) ? Color.Red : Color.Blue;

            // ������ϻ������ͼ��
            using (Graphics g = panel1.CreateGraphics())
            {
                g.Clear(panel1.BackColor);

                // �����������
                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int x1 = rand.Next(panel1.Width);
                    int y1 = rand.Next(panel1.Height);
                    int x2 = rand.Next(panel1.Width);
                    int y2 = rand.Next(panel1.Height);
                    g.DrawLine(Pens.Black, x1, y1, x2, y2);
                }

                // ��������ı�
                for (int i = 0; i < 5; i++)
                {
                    int x = rand.Next(panel1.Width - 50);
                    int y = rand.Next(panel1.Height - 20);
                    g.DrawString($"Text {i}", this.Font, Brushes.White, x, y);
                }
            }
        }

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0014) // WM_ERASEBKGND
        //    {
        //        m.Result = (IntPtr)1;
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}

        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    counter++;
        //    label1.Text = $"��˸������: {counter}";

        //    Color newColor = (counter % 2 == 0) ? Color.Red : Color.Blue;
        //    if (panel1.BackColor != newColor)
        //    {
        //        panel1.BackColor = newColor;
        //        panel1.Invalidate();
        //    }
        //}

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Random rand = new Random();

            // �����������
            for (int i = 0; i < 10; i++)
            {
                int x1 = rand.Next(panel1.Width);
                int y1 = rand.Next(panel1.Height);
                int x2 = rand.Next(panel1.Width);
                int y2 = rand.Next(panel1.Height);
                e.Graphics.DrawLine(Pens.Black, x1, y1, x2, y2);
            }

            // ��������ı�
            for (int i = 0; i < 5; i++)
            {
                int x = rand.Next(panel1.Width - 50);
                int y = rand.Next(panel1.Height - 20);
                e.Graphics.DrawString($"Text {i}", this.Font, Brushes.White, x, y);
            }
        }
    }
}