using InstagramStories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstagramStories.ViewModels
{
    class StoriesViewmodel : INotifyPropertyChanged
    {
        private int storyProgress;

        private int currentUserIndex;

        public List<UserStories> Stories { get; set; }

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


        public int CurrentUserIndex
        {
            get
            {
                return this.currentUserIndex;
            }
            set
            {
                if (this.currentUserIndex != value)
                {
                    this.currentUserIndex = value;              
                    NotifyPropertyChanged();
                }
            }
        }


        public StoriesViewmodel()
        {
            LeftSideStatusTappedCommand = new Command<UserStories>(MoveToPreviousStory);
            RightSideStatusTappedCommand = new Command<UserStories>(MoveToNextStory);
            CurentStoriesChangedCommand = new Command(CurentStoriesChanged);
            Stories = new List<UserStories>()
            {
                new UserStories()
                {
                    UserId = "1",
                    UserProfile = "1",
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
                    UserProfile = "2",
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
                    UserProfile = "3",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4"},
                    },
                    CurrentStories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                    }
                },

                   new UserStories()
                {
                    UserId = "4",
                    UserProfile = "4",
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
                    UserId = "4",
                    UserProfile = "4",
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
                    UserId = "4",
                    UserProfile = "4",
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
                    UserId = "4",
                    UserProfile = "4",
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
                    UserId = "4",
                    UserProfile = "4",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                    },
                    CurrentStories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                    }
                   },
            };

            Device.StartTimer(TimeSpan.FromMilliseconds(45), StoryTimedOut);
        }

        private bool StoryTimedOut()
        {
            if (this.CurrentUserIndex < this.Stories.Count)
            {
                this.StoryProgress = this.StoryProgress + 1;
                if (this.StoryProgress % 100 == 0)
                {
                    MoveToNextStory(this.Stories[this.CurrentUserIndex]);
                }

                return true;
            }
            else
            {
                return false;
            }
        }


        private void CurentStoriesChanged()
        {
            this.StoryProgress = 0;
        }

        private void MoveToPreviousStory(UserStories userStories)
        {
            var currentIndex = userStories.CurrentIndex;
            var newCurrentIndex = userStories.CurrentIndex - 1;
            if (newCurrentIndex != -1 && newCurrentIndex <= userStories.Stories.Count - 1)
            {
                userStories.CurrentStories.Clear();
                this.StoryProgress = 0;
                this.StoryProgress = this.StoryProgress + (newCurrentIndex * 100);
                userStories.CurrentStories.Add(userStories.Stories[newCurrentIndex]);
                userStories.CurrentIndex = newCurrentIndex;
            }
        }

        private void MoveToNextStory(UserStories userStories)
        {            
            var currentIndex = userStories.CurrentIndex;
            var newCurrentIndex = userStories.CurrentIndex + 1;
            if (newCurrentIndex <= userStories.Stories.Count - 1)
            {
                userStories.CurrentStories.Clear();
                this.StoryProgress = 0;
                this.StoryProgress = this.StoryProgress + (newCurrentIndex * 100);
                userStories.CurrentStories.Add(userStories.Stories[newCurrentIndex]);
                userStories.CurrentIndex = newCurrentIndex;                
            }
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
