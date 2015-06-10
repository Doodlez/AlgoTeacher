using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing.Drawing2D;

namespace UserControls
{
    public class MyLabelControlPainter : LabelControlPainter
    {
        protected override void DrawContent(ControlGraphicsInfoArgs info)
        {
            Rectangle captionRect = info.Bounds;
            string caption = (info.ViewInfo as LabelControlViewInfo).LabelInfoArgs.DisplayText;
            (info.ViewInfo as LabelControlViewInfo).LabelInfoArgs.DisplayText = "";
            Matrix transform = new Matrix();
            transform.RotateAt(90, new PointF(info.Bounds.Width/2.0f, info.Bounds.Height/2.0f));
            float factor =
                (float) Math.Sqrt(info.Bounds.Width*info.Bounds.Width + info.Bounds.Height*info.Bounds.Height)/2.0f;
            transform.Translate(info.Bounds.Width/2.0f, info.Bounds.Height/2.0f);
            transform.Scale(factor/info.Bounds.Width, factor/info.Bounds.Height);
            transform.Translate(-info.Bounds.Width/2.0f, -info.Bounds.Height/2.0f);
            info.Graphics.Transform = transform;
            base.DrawContent(info);
            (info.ViewInfo as LabelControlViewInfo).LabelInfoArgs.DisplayText = caption;
            SizeF size = info.Cache.CalcTextSize(caption, info.ViewInfo.Appearance.Font,
                                                 info.ViewInfo.Appearance.GetStringFormat(), 0);
            captionRect.X += (int) (captionRect.Width/2 - size.Width/2);
            info.Cache.Graphics.Transform = new Matrix();
            info.Cache.DrawString(caption, info.ViewInfo.Appearance.Font, new SolidBrush(Color.Black), captionRect,
                                  info.ViewInfo.Appearance.GetStringFormat());

        }
    }
}
