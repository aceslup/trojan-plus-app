﻿using System;
using System.IO;
using TrojanPlusApp.Models;
using TrojanPlusApp.Services;
using TrojanPlusApp.Views;
using Xamarin.Forms;

namespace TrojanPlusApp
{
    public partial class App : Application
    {
        public interface IStart
        {
            // start libtrojan.so
            void Start();

            string GetAppVersion();
            int GetAppBuild();

            string GetTrojanPlusLibVersion();
        }

        public static App Instance
        {
            get { return (App)Current; }
        }

        public IStart Starter { get; private set; }

        public string ConfigPath { get; private set; }
        public string DataPathParent { get; private set; }

        public bool IsStartBtnEnabled { get; private set; }
        public bool GetStartBtnStatus { get; private set; }

        public App(string configPath, IStart starter)
        {
            Starter = starter;
            DataPathParent = configPath.Substring(0, configPath.LastIndexOf(Path.DirectorySeparatorChar));
            ConfigPath = configPath;

            InitializeComponent();
            MainPage = new MainPage();
        }

        public void Start()
        {
            Starter.Start();
        }

        public void OnSetStartBtnEnabled(bool enable)
        {
            IsStartBtnEnabled = enable;
            MessagingCenter.Send(this, "Starter_OnSetStartBtnEnabled", enable);
        }

        public void OnSetStartBtnStatus(bool running)
        {
            GetStartBtnStatus = running;
            MessagingCenter.Send(this, "Starter_OnSetStartBtnStatus", running);
        }

        /*
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        */
    }

}
