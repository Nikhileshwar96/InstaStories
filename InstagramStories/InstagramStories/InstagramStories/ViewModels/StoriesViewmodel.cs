﻿using InstagramStories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstagramStories.ViewModels
{
    class StoriesViewmodel : INotifyPropertyChanged
    {
        private int storyProgress;

        private UserStories currentUser;

        public List<UserStories> Stories { get; set; }

        public ICommand SeeMoreCommand { get; set; }

        public ICommand LeftSideStatusTappedCommand { get; set; }

        public ICommand RightSideStatusTappedCommand { get; set; }

        public ICommand CurentStoriesChangedCommand { get; set; }

        public int StoryProgress 
        {
            get
            {
                return this.storyProgress;
            }
            set
            {
                this.storyProgress = value;
                NotifyPropertyChanged();
            }
        }


        public UserStories CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                if (this.currentUser != value)
                {
                    this.currentUser = value;              
                    NotifyPropertyChanged();
                }
            }
        }


        public StoriesViewmodel()
        {
            LeftSideStatusTappedCommand = new Command<UserStories>(MoveToPreviousStory);
            RightSideStatusTappedCommand = new Command<UserStories>(MoveToNextStory);
            CurentStoriesChangedCommand = new Command(CurentStoriesChanged);
            SeeMoreCommand = new Command(SeeMore);
            Stories = new List<UserStories>()
            {
                new UserStories()
                {
                    UserId = "1",
                    UserProfile = "Tom",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg", Index = 0},
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4", Index = 1},
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg", Index = 2},
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4", Index = 3},
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg", Index = 4},
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4", Index = 5},
                    },
                    CurrentStories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                    }
                },

                new UserStories()
                {
                    UserId = "2",
                    UserProfile = "Ben",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                    },
                    CurrentStories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                    }
                },

                new UserStories()
                {
                    UserId = "3",
                    UserProfile = "Ronald",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                    },
                },

                new UserStories()
                {
                    UserId = "4",
                    UserProfile = "Joe",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                    },
                   },
                new UserStories()
                {
                    UserId = "4",
                    UserProfile = "Someone",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                    },
                   },
                new UserStories()
                {
                    UserId = "4",
                    UserProfile = "User user",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                    },
                   },
                new UserStories()
                {
                    UserId = "4",
                    UserProfile = "Christopher",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                    },
                   },
                new UserStories()
                {
                    UserId = "4",
                    UserProfile = "Jhon",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                    },
                   },
            };

            StartTimer();
        }

        private bool StoryTimedOut()
        {
                this.StoryProgress = this.StoryProgress + 1;
                if (this.StoryProgress % 100 == 0)
                {
                    MoveToNextStory(this.CurrentUser);
                }

            return true;
        }

        private void StartTimer()
        {
            this.StoryProgress = 0;
            Device.StartTimer(TimeSpan.FromMilliseconds(45), StoryTimedOut);
        }

        private void CurentStoriesChanged()
        {
            this.CurrentUser.CurrentStories.Clear();
            this.CurrentUser.CurrentStories.Add(this.CurrentUser.Stories.FirstOrDefault());
            this.StoryProgress = 0;
        }

        private void MoveToPreviousStory(UserStories userStories)
        {
            var newCurrentIndex = userStories.Stories.IndexOf(userStories.CurrentStories.FirstOrDefault()) - 1;
            if (newCurrentIndex >= 0)
            {
                userStories.CurrentStories.Clear();
                this.StoryProgress = 0;
                this.StoryProgress = this.StoryProgress + (newCurrentIndex * 100);
                userStories.CurrentStories.Add(userStories.Stories[newCurrentIndex]);
                userStories.CurrentIndex = newCurrentIndex;
            }
            else
            {
                if (this.CurrentUser != this.Stories.FirstOrDefault())
                    this.CurrentUser = this.Stories[this.Stories.IndexOf(this.CurrentUser) - 1];
            }
        }

        private void MoveToNextStory(UserStories userStories)
        {            
            var newCurrentIndex = userStories.Stories.IndexOf(userStories.CurrentStories.FirstOrDefault()) + 1;
            if (newCurrentIndex <= userStories.Stories.Count - 1)
            {
                userStories.CurrentStories.Clear();
                this.StoryProgress = 0;
                this.StoryProgress = this.StoryProgress + (newCurrentIndex * 100);
                userStories.CurrentStories.Add(userStories.Stories[newCurrentIndex]);
            }
            else
            {
                if (this.CurrentUser != this.Stories.Last())
                    this.CurrentUser = this.Stories[this.Stories.IndexOf(this.CurrentUser) + 1];
            }
        }

        void SeeMore()
        {
            Xamarin.Essentials.Browser.OpenAsync(this.CurrentUser.CurrentStories.First().StorySource);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
