using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(AppMovil.TxtCaja), typeof(AppMovil.Droid.MiBoxing))]
namespace AppMovil.Droid
{
    public class MiBoxing : EntryRenderer
    {
        public MiBoxing(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;
                var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.White.ToAndroid();
                shape.Paint.SetStyle(Paint.Style.Stroke);
                shape.Paint.TextSize = 14;                
                nativeEditText.Background = shape;
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.LightGray);
                gd.SetCornerRadius(5);
                gd.SetStroke(2, Android.Graphics.Color.Black);
                nativeEditText.SetBackground(gd);
                
            }
            //if (Control != null)
            //{
            //    GradientDrawable gd = new GradientDrawable();

            //    //this line sets the bordercolor
            //    gd.SetColor(global::Android.Graphics.Color.Red);

            //    this.Control.SetBackgroundDrawable(gd);
            //    this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
            //    Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.White));
            //}
        }
    }
}