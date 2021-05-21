using System;
using System.Collections.Generic;
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
        public int Time { get; set; }

        public List<Words> WordsList = new List<Words>()
        {
            new Words("int"),
            new Words("class"),
            new Words("double")
        };


        public MainPage()
        {
            Time = 5 * 60;
            InitializeComponent();
            WordCollection.ItemsSource = WordsList;
            UpdateScoreLabel();
            Task.Run(async () =>
            {
                while (Score < WordsList.Count &&
                      Time > 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        TimerLabel.Text = $"TIMER {Time} SECONDS";
                    });
                       await Task.Delay(1000);
                    Time = Time - 1;
                }                
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
