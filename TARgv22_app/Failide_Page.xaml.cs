using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Failide_Page : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public Failide_Page()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateFileList();
        }

        private void UpdateFileList()
        {
            filesList.ItemsSource = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
            filesList.SelectedItem = null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string fileName = fileNameEntry.Text;
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }
            if (File.Exists(Path.Combine(folderPath, fileName)))
            {
                bool isRewrited = await DisplayAlert("Kinnitus", "Fail on juba olemas, Kas kirjutame ümber?", "jah", "ei");
                if (isRewrited == false) return;
            }
            File.WriteAllText(Path.Combine(folderPath, fileName), textEditor.Text);
            UpdateFileList();
        }

        private void filesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            string fileName = (string)e.SelectedItem;
            textEditor.Text = File.ReadAllText(Path.Combine(folderPath, fileName));
            fileNameEntry.Text = fileName;
            filesList.SelectedItem = null;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            string fileName = (string)((MenuItem)sender).BindingContext;
            File.Delete(Path.Combine(folderPath, fileName));
            UpdateFileList();
        }

        private void ToList_Clicked(object sender, EventArgs e)
        {
            string fileName = (string)((MenuItem)sender).BindingContext;
            List<string> järjend = File.ReadLines(Path.Combine(folderPath, fileName)).ToList();
            list.ItemsSource = järjend;
        }
    }
}