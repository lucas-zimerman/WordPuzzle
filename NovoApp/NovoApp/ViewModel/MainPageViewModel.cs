﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace NovoApp.ViewModel
{
    public class MainPageViewModel : BasePropertyChanged
    {
        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                RaisePropertyChanged();
            }
        }

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                RaisePropertyChanged();
            }
        }

        private TimeSpan _timer;
        public TimeSpan Timer
        {
            get => _timer;
            set
            {
                _timer = value;
                RaisePropertyChanged();
            }
        }

        private bool _finished;
        public bool Finished
        {
            get => _finished;
            set
            {
                _finished = value;
                RaisePropertyChanged();
            }
        }

        public List<Words> WordsList { get; }

        public Command CheckInputTextCmd { get; }

        public MainPageViewModel()
        {
            Timer = new TimeSpan(0, 1, 0);
            CheckInputTextCmd = new Command(ValidateInputText);

            WordsList = new List<Words>()
            {
                new Words("int"),
                new Words("class"),
                new Words("double")
            };

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (Score < WordsList.Count &&
                      Timer.TotalSeconds > 0 &&
                      !Finished)
                {
                    Timer = Timer.Add(TimeSpan.FromSeconds(-1));
                    return true;
                }
                Finished = true;
                return false;
            });
        }

        private Action ValidateInputText => () =>
        {
            var word = InputText;
            InputText = "";

            var wordFound = WordsList.FirstOrDefault(p => p.Name == word);
            if (wordFound != null)
            {
                wordFound.Found = true;
                IncrementScore();
            }
        };

        private void IncrementScore()
        {
            Score++;
            if (Score == WordsList.Count)
            {
                Finished = true;
            }
        }
    }
}
