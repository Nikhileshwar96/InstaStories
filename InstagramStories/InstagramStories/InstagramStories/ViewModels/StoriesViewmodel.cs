using InstagramStories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramStories.ViewModels
{
    class StoriesViewmodel
    {
        public List<UserStories> Stories { get; set; }

        public StoriesViewmodel()
        {
            Stories = new List<UserStories>()
            {
                new UserStories()
                {
                    UserId = "1",
                    UserProfile = "1",
                    Stories = new List<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"},
                    }
                },

                 new UserStories()
                {
                    UserId = "2",
                    UserProfile = "2",
                    Stories = new List<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                    }
                },

                  new UserStories()
                {
                    UserId = "3",
                    UserProfile = "3",
                    Stories = new List<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4"},
                    }
                },

                   new UserStories()
                {
                    UserId = "4",
                    UserProfile = "4",
                    Stories = new List<Story>()
                    {
                        new Story(){StorySource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                    }
                   },
            };
        }
    }
}
