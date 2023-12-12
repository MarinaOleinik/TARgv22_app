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
    public partial class Valgusfoor : ContentPage
    {
        Frame fr;
        List<Color> colors=new List<Color> { Color.Red,Color.Yellow, Color.Green};
        List<string> reaktion = new List<string>() { "Seisa", "Oota" , "Mine"};
        List<Frame> frames = new List<Frame>();
        Button btn;
        List<string> tekst = new List<string>() { "Sisse", "Välja" };
        StackLayout st=new StackLayout();
        StackLayout vf = new StackLayout();
        StackLayout nd = new StackLayout();
        public Valgusfoor()
        {
            vf.Margin = new Thickness(40);
            for (int i = 0; i < 3; i++)
            {
                fr = new Frame
                {
                    Content = new Label { Text = "Lülita sisse" },
                    HasShadow = true,
                    TabIndex = i,
                    BackgroundColor = Color.Gray,
                    CornerRadius = 70,
                    HeightRequest=150,
                    BorderColor=Color.Black
                };
                frames.Add(fr);
                vf.Children.Add(fr);
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += Tap_Tapped;
                fr.GestureRecognizers.Add(tap);
            }
            nd.Margin = new Thickness(10);
            nd.HorizontalOptions = LayoutOptions.CenterAndExpand;
            nd.Orientation = StackOrientation.Horizontal;
            for (int i = 0;i < 2; i++)
            {
                btn = new Button
                {
                    Text = tekst[i],
                    BackgroundColor = Color.AntiqueWhite,
                    TabIndex=i,
                    HorizontalOptions=LayoutOptions.Fill
                };
                nd.Children.Add(btn);
                btn.Clicked += Btn_Clicked;
            }
            st.Children.Add(vf);
            st.Children.Add(nd);
            Content = st;
        }
        bool startstop = false;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            if (startstop)
            {
                frame.BackgroundColor = colors[frame.TabIndex];
                frame.Content = new Label { Text = reaktion[frame.TabIndex] };
            }
        }
        private void Btn_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text=="Sisse")
            {
                startstop = true;
                for (int i = 0; i < 3; i++)
                {
                    //frames[i].BackgroundColor = colors[i];
                    frames[i].Content = new Label { Text = "Tee oma valik" };
                }
            }
            else
            {
                startstop=false;
                for (int i = 0; i < 3; i++)
                {
                    frames[i].BackgroundColor = Color.Gray;
                    frames[i].Content= new Label {  Text = "Lülita sisse" };
                }
            }
            
        }
    }
}