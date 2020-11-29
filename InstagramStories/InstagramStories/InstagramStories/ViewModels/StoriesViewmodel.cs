using InstagramStories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstagramStories.ViewModels
{
    class StoriesViewmodel
    {
        public double storyProgress { get; set; }

        public List<UserStories> Stories { get; set; }

        public ICommand StatusTappedCommand { get; set; }

        public StoriesViewmodel()
        {
            StatusTappedCommand = new Command<UserStories>(StatusTapped);
            Stories = new List<UserStories>()
            {
                new UserStories()
                {
                    UserId = "1",
                    UserProfile = "1",
                    Stories = new ObservableCollection<Story>()
                    {
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                        new Story(){StorySource = "https://nikhileshwar96.github.io/Showcase/sunflower.jpg"},
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
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
        }

        private void StatusTapped(UserStories userStories)
        {
            var currentIndex = userStories.CurrentIndex;
            var newCurrentIndex = userStories.CurrentIndex + 1;
            if (newCurrentIndex < userStories.Stories.Count - 1)
            {
                userStories.CurrentStories.Clear();
                userStories.CurrentStories.Add(userStories.Stories[newCurrentIndex]);
                userStories.CurrentIndex = newCurrentIndex;
            }
        }
    }
}
