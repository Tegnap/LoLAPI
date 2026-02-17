using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoLAPI;


namespace WPFLoLAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Champion> champions = new List<Champion>();
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private async void LoadChampionsAsync()
        {
           
            string selectedLang = "hu_HU";

           
            if (Langcbx != null && Langcbx.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag != null)
            {
                selectedLang = selectedItem.Tag.ToString();
            }

          
            string url = $"https://ddragon.leagueoflegends.com/cdn/16.3.1/data/{selectedLang}/champion.json";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    
                    string jsonString = await client.GetStringAsync(url);

                   
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<ChampionDatas>(jsonString, options);

                 
                    if (result != null && result.Data != null)
                    {
                        
                        ChampListBox.ItemsSource = result.Data.Values.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"Hiba a letöltéskor:\n{ex.Message}", "Hálózati Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Langcbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (IsLoaded)
            {
                LoadChampionsAsync();
            }
        }
        private void ChampListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChampListBox.SelectedItem is Champion selectedChampion)
            {
                ChampionInfoWindow popup = new ChampionInfoWindow(selectedChampion);

                popup.Owner = this;
                popup.ShowDialog();
                ChampListBox.SelectedItem = null;
            }
        }


    }
}