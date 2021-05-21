using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NovoApp
{
    public partial class MainPage : ContentPage
    {
        public int Score { get; set; }
        public TimeSpan Time { get; set; }

        public List<Words> WordsList = new List<Words>()
        {
            new Words("int"),
            new Words("class"),
            new Words("double")
        };


        public MainPage()
        {
            Time = new TimeSpan(0,5,0);
            InitializeComponent();
            WordCollection.ItemsSource = WordsList;
            UpdateScoreLabel();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if(Score < WordsList.Count &&
                      Time.TotalSeconds > 0)
                {

                    TimerLabel.Text = $"{Time.ToString("mm\\:ss")} SECONDS REMAINING !";
                    Time = Time.Add(TimeSpan.FromSeconds(-1));
                    return true;
                }
                return false;
            });
        }

        private void IncrementScore() => Score++;

        private void UpdateScoreLabel() => ScoreLabel.Text = $"SCORE {Score}/{WordsList.Count}";

        private void Button_Clicked(object sender, EventArgs e)
        {
            var word = WordEntry.Text;
            WordEntry.Text = "";

            var wordFound = WordsList.FirstOrDefault(p => p.Name == word);
            if (wordFound != null) {
                wordFound.Found = true;
                IncrementScore();
                UpdateScoreLabel();
            }
        }
    }
}
