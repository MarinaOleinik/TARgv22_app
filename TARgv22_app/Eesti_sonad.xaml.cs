
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
    public partial class Eesti_sonad : ContentPage
    {
        List<string> eesti_sonad = new List<string>() { "LAUSE", "TEKST", "TURSK", "TUISK", "KEVAD" };
        Grid grid;
        public Eesti_sonad()
        {
            grid = new Grid();

            char[] sona = eesti_sonad[0].ToCharArray();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grid.Children.Add(new Label { Text = sona[i].ToString() }, i, j);
                }
            }
            Content = grid;
        }
    }
}