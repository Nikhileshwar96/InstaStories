using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramStories.Models
{
    class UserStories
    {
        public string UserId { get; set; }

        public string UserProfile { get; set; }

        public List<Story> Stories { get; set; }

    }
}
