﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramStories.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoriesPage : ContentPage
    {
        public StoriesPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}