using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Pathfinder
{
    public partial class ShowResult : Form
    {
        private readonly Bitmap _bitmap;

        public ShowResult(Bitmap bitmap)
        {
            const int scale = 8;

            _bitmap = bitmap;

            InitializeComponent();

            ClientSize = new Size(_bitmap.Width * scale, _bitmap.Height * scale);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            e.Graphics.DrawImage(
                _bitmap,
                new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
        }
    }
}
