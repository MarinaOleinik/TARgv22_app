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
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Frame fr;
        string[] lehed = new string[4] { "https://moodle.edu.ee", "https://www.tthk.ee/", "https://tahvel.edu.ee/#/", "https://thk.edupage.org/timetable/view.php?fullscreen=1" };
        public PickerPage()
        {
            picker = new Picker
            {
                Title = "Lehed"
            };
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Tahvel");
            picker.Items.Add("Tunniplaan");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView();
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;
            fr = new Frame
            {
                BorderColor = Color.Red,
                BackgroundColor = Color.Green
            };
            fr.GestureRecognizers.Add(swipe);
            st=new StackLayout { Children = {picker, fr} };
            Content = st;
        }
        int ind = 0;
        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[ind] };
            ind++;
            if (ind == lehed.Length)
            {
                ind = 0;
            }
        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            st.Children.Add(webView);
        }
    }
}