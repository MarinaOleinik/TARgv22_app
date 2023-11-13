using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateTimePage : ContentPage
    {
        Label lbl;
        DatePicker datePicker;
        TimePicker timePicker;
        public DateTimePage()
        {
            lbl = new Label
            {
                Text = "Vali mingi kuupäev",
                BackgroundColor = Color.BurlyWood
            };
            datePicker = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-10),
                MaximumDate = DateTime.Now.AddDays(10),
                TextColor = Color.Black
            };
            datePicker.DateSelected += DatePicker_DateSelected;
            timePicker = new TimePicker
            {
                Time = new TimeSpan(12, 0, 0),
            };
            timePicker.PropertyChanged += TimePicker_PropertyChanged;
            AbsoluteLayout abs=new AbsoluteLayout { Children = { lbl,datePicker,timePicker } };
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1, 0.2, 200, 100));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(datePicker, new Rectangle(0.1, 0.5, 300, 100));
            AbsoluteLayout.SetLayoutFlags(datePicker, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(timePicker, new Rectangle(0.5, 0.7, 400, 100));
            AbsoluteLayout.SetLayoutFlags(timePicker, AbsoluteLayoutFlags.PositionProportional);
            Content=abs;
        }

        private void TimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lbl.Text = timePicker.Time.ToString();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            lbl.Text=e.NewDate.ToString("G");
        }
    }
}