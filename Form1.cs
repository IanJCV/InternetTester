using System.Net.NetworkInformation;
using System.Text;
using System.Runtime.InteropServices;

namespace InternetTester
{

    public partial class InternetTester : Form
    {
        private Ping pingSender = new Ping();
        private PingOptions options = new PingOptions()
        {
            DontFragment = true
        };

        PingReply latestReply;

        // Mouse drag
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public InternetTester()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(255, 180, 174, 181);

            CancellationTokenSource cts = new CancellationTokenSource();

            Task task = new Task(() =>
            {
                while (true)
                {
                    SendPing();

                    if (latestReply.Status == IPStatus.Success)
                    {
                        UpdateLabel(upDownText, "UP");
                        UpdateLabelColor(upDownText, Color.Green);
                    }
                    else
                    {
                        UpdateLabel(upDownText, "DOWN");
                        UpdateLabelColor(upDownText, Color.Red);
                    }

                    UpdateLabel(lastPingText, $"last ping: {latestReply.RoundtripTime} ms");
                    UpdateLabel(lastUpdatedText, $"last updated at: {DateTime.Now:hh:mm:ss:fff}");

                    Thread.Sleep(100);
                }
            }, cts.Token);

            FormClosing += (s, e) => { cts.Cancel(); };
            openPanel1.MouseDown += Drag_MouseDown;

            lastUpdatedText.MouseDown += Passthrough;
            lastPingText.MouseDown += Passthrough;
            upDownText.MouseDown += Passthrough;

            task.Start();
        }

        private void Passthrough(object? sender, MouseEventArgs e)
        {
            if (sender == null || sender is not DraggableLabel l)
                return;

            if (l.Parent is OpenPanel p)
            {
                p.DoMouseDown(e);
            }
        }

        private void Drag_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void UpdateLabel(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(() => { UpdateLabel(label, text); });
                return;
            }

            label.Text = text;
        }

        private void UpdateLabelColor(Label label, Color color)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(() => { UpdateLabelColor(label, color); });
                return;
            }

            label.ForeColor = color;
        }

        private void SendPing()
        {
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 100;
            latestReply = pingSender.Send("8.8.8.8", timeout, buffer, options);
        }

        private void check_onTop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = check_onTop.Checked;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class DraggableLabel : Label
    {
        public void DoClick(EventArgs e)
        {
            base.OnClick(e);
        }
    }

    public class OpenPanel : Panel
    {
        public OpenPanel() : base()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public void DoClick(EventArgs e)
        {
            base.OnClick(e);
        }

        public void DoMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }
    }
}
