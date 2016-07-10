//// Copyright (c) 2011 AlphaSierraPapa for the SharpDevelop Team
//// 
//// Permission is hereby granted, free of charge, to any person obtaining a copy of this
//// software and associated documentation files (the "Software"), to deal in the Software
//// without restriction, including without limitation the rights to use, copy, modify, merge,
//// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
//// to whom the Software is furnished to do so, subject to the following conditions:
//// 
//// The above copyright notice and this permission notice shall be included in all copies or
//// substantial portions of the Software.
//// 
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
//// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
//// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//// DEALINGS IN THE SOFTWARE.

//using System;
//using System.ComponentModel;
//using System.ComponentModel.Composition;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Input;
//using System.Xml.Linq;

//using ICSharpCode.AvalonEdit.Rendering;
//using ICSharpCode.Decompiler;
//using ICSharpCode.ILSpy.TextView;

//namespace ICSharpCode.ILSpy
//{
//    [ExportMainMenuCommand(Menu = "帮助(_H)", Header = "关于(_A)", MenuOrder = 99999)]
//    sealed class AboutPage : SimpleCommand
//    {
//        [Import]
//        DecompilerTextView decompilerTextView = null;
		
//        public override void Execute(object parameter)
//        {
//            MainWindow.Instance.UnselectAll();
//            Display(decompilerTextView);
//        }
		
//        static readonly Uri UpdateUrl = new Uri("http://ilspy.net/update.xml");
//        const string band = "stable";
		
//        static AvailableVersionInfo latestAvailableVersion;
		
//        public static void Display(DecompilerTextView textView)
//        {
//            AvalonEditTextOutput output = new AvalonEditTextOutput();
//            output.WriteLine("ILSpy 版本 " + RevisionClass.FullVersion);
//            output.AddUIElement(
//                delegate {
//                    StackPanel stackPanel = new StackPanel();
//                    stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
//                    stackPanel.Orientation = Orientation.Horizontal;
//                    if (latestAvailableVersion == null) {
//                        AddUpdateCheckButton(stackPanel, textView);
//                    } else {
//                        // we already retrieved the latest version sometime earlier
//                        ShowAvailableVersion(latestAvailableVersion, stackPanel);
//                    }
//                    CheckBox checkBox = new CheckBox();
//                    checkBox.Margin = new Thickness(4);
//                    checkBox.Content = "每周自动检查更新";
//                    UpdateSettings settings = new UpdateSettings(ILSpySettings.Load());
//                    checkBox.SetBinding(CheckBox.IsCheckedProperty, new Binding("AutomaticUpdateCheckEnabled") { Source = settings });
//                    return new StackPanel {
//                        Margin = new Thickness(0, 4, 0, 0),
//                        Cursor = Cursors.Arrow,
//                        Children = { stackPanel, checkBox }
//                    };
//                });
//            output.WriteLine();
//            foreach (var plugin in App.CompositionContainer.GetExportedValues<IAboutPageAddition>())
//                plugin.Write(output);
//            output.WriteLine();
//            using (Stream s = typeof(AboutPage).Assembly.GetManifestResourceStream(typeof(AboutPage), "README.txt")) {
//                using (StreamReader r = new StreamReader(s)) {
//                    string line;
//                    while ((line = r.ReadLine()) != null) {
//                        output.WriteLine(line);
//                    }
//                }
//            }
//            output.AddVisualLineElementGenerator(new MyLinkElementGenerator("SharpDevelop", "http://www.icsharpcode.net/opensource/sd/"));
//            output.AddVisualLineElementGenerator(new MyLinkElementGenerator("MIT License", "resource:license.txt"));
//            output.AddVisualLineElementGenerator(new MyLinkElementGenerator("LGPL", "resource:LGPL.txt"));
//            output.AddVisualLineElementGenerator(new MyLinkElementGenerator("iFish(木鱼)", "http://www.fishlee.net/about/"));
//            textView.ShowText(output);
			
//            //reset icon bar
//            textView.manager.Bookmarks.Clear();
//        }
		
//        sealed class MyLinkElementGenerator : LinkElementGenerator
//        {
//            readonly Uri uri;
			
//            public MyLinkElementGenerator(string matchText, string url) : base(new Regex(Regex.Escape(matchText)))
//            {
//                this.uri = new Uri(url);
//                this.RequireControlModifierForClick = false;
//            }
			
//            protected override Uri GetUriFromMatch(Match match)
//            {
//                return uri;
//            }
//        }
		
//        static void AddUpdateCheckButton(StackPanel stackPanel, DecompilerTextView textView)
//        {
//            Button button = new Button();
//            button.Content = "检查更新";
//            button.Cursor = Cursors.Arrow;
//            stackPanel.Children.Add(button);
			
//            button.Click += delegate {
//                button.Content = "检查更新中...";
//                button.IsEnabled = false;
//                GetLatestVersionAsync().ContinueWith(
//                    delegate (Task<AvailableVersionInfo> task) {
//                        try {
//                            stackPanel.Children.Clear();
//                            ShowAvailableVersion(task.Result, stackPanel);
//                        } catch (Exception ex) {
//                            AvalonEditTextOutput exceptionOutput = new AvalonEditTextOutput();
//                            exceptionOutput.WriteLine(ex.ToString());
//                            textView.ShowText(exceptionOutput);
//                        }
//                    }
//                    , TaskScheduler.FromCurrentSynchronizationContext());
//            };
//        }
		
//        static readonly Version currentVersion = new Version(RevisionClass.Major + "." + RevisionClass.Minor + "." + RevisionClass.Build + "." + RevisionClass.Revision);
		
//        static void ShowAvailableVersion(AvailableVersionInfo availableVersion, StackPanel stackPanel)
//        {
//            if (currentVersion == availableVersion.Version) {
//                stackPanel.Children.Add(
//                    new Image {
//                        Width = 16, Height = 16,
//                        Source = Images.OK,
//                        Margin = new Thickness(4,0,4,0)
//                    });
//                stackPanel.Children.Add(
//                    new TextBlock {
//                        Text = "您正在使用的是最新版本.",
//                        VerticalAlignment = VerticalAlignment.Bottom
//                    });
//            } else if (currentVersion < availableVersion.Version) {
//                stackPanel.Children.Add(
//                    new TextBlock {
//                        Text = "版本 " + availableVersion.Version + " 可用.",
//                        Margin = new Thickness(0,0,8,0),
//                        VerticalAlignment = VerticalAlignment.Bottom
//                    });
//                if (availableVersion.DownloadUrl != null) {
//                    Button button = new Button();
//                    button.Content = "下载";
//                    button.Cursor = Cursors.Arrow;
//                    button.Click += delegate {
//                        Process.Start(availableVersion.DownloadUrl);
//                    };
//                    stackPanel.Children.Add(button);
//                }
//            } else {
//                stackPanel.Children.Add(new TextBlock { Text = "您正在使用比正式版更新的每夜版." });
//            }
//        }
		
//        static Task<AvailableVersionInfo> GetLatestVersionAsync()
//        {
//            var tcs = new TaskCompletionSource<AvailableVersionInfo>();
//            WebClient wc = new WebClient();
//            IWebProxy systemWebProxy = WebRequest.GetSystemWebProxy();
//            systemWebProxy.Credentials = CredentialCache.DefaultCredentials;
//            wc.Proxy = systemWebProxy;
//            wc.DownloadDataCompleted += delegate(object sender, DownloadDataCompletedEventArgs e) {
//                if (e.Error != null) {
//                    tcs.SetException(e.Error);
//                } else {
//                    try {
//                        XDocument doc = XDocument.Load(new MemoryStream(e.Result));
//                        var bands = doc.Root.Elements("band");
//                        var currentBand = bands.FirstOrDefault(b => (string)b.Attribute("id") == band) ?? bands.First();
//                        Version version = new Version((string)currentBand.Element("latestVersion"));
//                        string url = (string)currentBand.Element("downloadUrl");
//                        if (!(url.StartsWith("http://", StringComparison.Ordinal) || url.StartsWith("https://", StringComparison.Ordinal)))
//                            url = null; // don't accept non-urls
//                        latestAvailableVersion = new AvailableVersionInfo { Version = version, DownloadUrl = url };
//                        tcs.SetResult(latestAvailableVersion);
//                    } catch (Exception ex) {
//                        tcs.SetException(ex);
//                    }
//                }
//            };
//            wc.DownloadDataAsync(UpdateUrl);
//            return tcs.Task;
//        }
		
//        sealed class AvailableVersionInfo
//        {
//            public Version Version;
//            public string DownloadUrl;
//        }
		
//        sealed class UpdateSettings : INotifyPropertyChanged
//        {
//            public UpdateSettings(ILSpySettings spySettings)
//            {
//                XElement s = spySettings["UpdateSettings"];
//                this.automaticUpdateCheckEnabled = (bool?)s.Element("AutomaticUpdateCheckEnabled") ?? true;
//                try {
//                    this.lastSuccessfulUpdateCheck = (DateTime?)s.Element("LastSuccessfulUpdateCheck");
//                } catch (FormatException) {
//                    // avoid crashing on settings files invalid due to
//                    // https://github.com/icsharpcode/ILSpy/issues/closed/#issue/2
//                }
//            }
			
//            bool automaticUpdateCheckEnabled;
			
//            public bool AutomaticUpdateCheckEnabled {
//                get { return automaticUpdateCheckEnabled; }
//                set {
//                    if (automaticUpdateCheckEnabled != value) {
//                        automaticUpdateCheckEnabled = value;
//                        Save();
//                        OnPropertyChanged("AutomaticUpdateCheckEnabled");
//                    }
//                }
//            }
			
//            DateTime? lastSuccessfulUpdateCheck;
			
//            public DateTime? LastSuccessfulUpdateCheck {
//                get { return lastSuccessfulUpdateCheck; }
//                set {
//                    if (lastSuccessfulUpdateCheck != value) {
//                        lastSuccessfulUpdateCheck = value;
//                        Save();
//                        OnPropertyChanged("LastSuccessfulUpdateCheck");
//                    }
//                }
//            }
			
//            public void Save()
//            {
//                XElement updateSettings = new XElement("UpdateSettings");
//                updateSettings.Add(new XElement("AutomaticUpdateCheckEnabled", automaticUpdateCheckEnabled));
//                if (lastSuccessfulUpdateCheck != null)
//                    updateSettings.Add(new XElement("LastSuccessfulUpdateCheck", lastSuccessfulUpdateCheck));
//                ILSpySettings.SaveSettings(updateSettings);
//            }
			
//            public event PropertyChangedEventHandler PropertyChanged;
			
//            void OnPropertyChanged(string propertyName)
//            {
//                if (PropertyChanged != null) {
//                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
//                }
//            }
//        }
		
//        /// <summary>
//        /// If automatic update checking is enabled, checks if there are any updates available.
//        /// Returns the download URL if an update is available.
//        /// Returns null if no update is available, or if no check was performed.
//        /// </summary>
//        public static Task<string> CheckForUpdatesIfEnabledAsync(ILSpySettings spySettings)
//        {
//            var tcs = new TaskCompletionSource<string>();
//            UpdateSettings s = new UpdateSettings(spySettings);
//            if (s.AutomaticUpdateCheckEnabled) {
//                // perform update check if we never did one before;
//                // or if the last check wasn't in the past 7 days
//                if (s.LastSuccessfulUpdateCheck == null
//                    || s.LastSuccessfulUpdateCheck < DateTime.UtcNow.AddDays(-7)
//                    || s.LastSuccessfulUpdateCheck > DateTime.UtcNow)
//                {
//                    GetLatestVersionAsync().ContinueWith(
//                        delegate (Task<AvailableVersionInfo> task) {
//                            try {
//                                s.LastSuccessfulUpdateCheck = DateTime.UtcNow;
//                                AvailableVersionInfo v = task.Result;
//                                if (v.Version > currentVersion)
//                                    tcs.SetResult(v.DownloadUrl);
//                                else
//                                    tcs.SetResult(null);
//                            } catch (AggregateException) {
//                                // ignore errors getting the version info
//                                tcs.SetResult(null);
//                            }
//                        });
//                } else {
//                    tcs.SetResult(null);
//                }
//            } else {
//                tcs.SetResult(null);
//            }
//            return tcs.Task;
//        }
//    }
	
//    /// <summary>
//    /// Interface that allows plugins to extend the about page.
//    /// </summary>
//    public interface IAboutPageAddition
//    {
//        void Write(ISmartTextOutput textOutput);
//    }
//}
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.Decompiler;
using ICSharpCode.ILSpy.TextView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace ICSharpCode.ILSpy
{
    [ExportMainMenuCommand(Menu = "帮助(_H)", Header = "关于(_A)", MenuOrder = 99999.0)]
    internal sealed class AboutPage : SimpleCommand
    {
        private sealed class MyLinkElementGenerator : LinkElementGenerator
        {
            private readonly Uri uri;

            public MyLinkElementGenerator(string matchText, string url)
                : base(new Regex(Regex.Escape(matchText)))
            {
                this.uri = new Uri(url);
                base.RequireControlModifierForClick = false;
            }

            protected override Uri GetUriFromMatch(Match match)
            {
                return this.uri;
            }
        }

        private sealed class AvailableVersionInfo
        {
            public Version Version;

            public string DownloadUrl;
        }

        private sealed class UpdateSettings : INotifyPropertyChanged
        {
            private bool automaticUpdateCheckEnabled;

            private DateTime? lastSuccessfulUpdateCheck;

            public event PropertyChangedEventHandler PropertyChanged;

            public bool AutomaticUpdateCheckEnabled
            {
                get
                {
                    return this.automaticUpdateCheckEnabled;
                }
                set
                {
                    if (this.automaticUpdateCheckEnabled != value)
                    {
                        this.automaticUpdateCheckEnabled = value;
                        this.Save();
                        this.OnPropertyChanged("AutomaticUpdateCheckEnabled");
                    }
                }
            }

            public DateTime? LastSuccessfulUpdateCheck
            {
                get
                {
                    return this.lastSuccessfulUpdateCheck;
                }
                set
                {
                    if (this.lastSuccessfulUpdateCheck != value)
                    {
                        this.lastSuccessfulUpdateCheck = value;
                        this.Save();
                        this.OnPropertyChanged("LastSuccessfulUpdateCheck");
                    }
                }
            }

            public UpdateSettings(ILSpySettings spySettings)
            {
                XElement xElement = spySettings["UpdateSettings"];
                this.automaticUpdateCheckEnabled = (((bool?)xElement.Element("AutomaticUpdateCheckEnabled")) ?? true);
                try
                {
                    this.lastSuccessfulUpdateCheck = (DateTime?)xElement.Element("LastSuccessfulUpdateCheck");
                }
                catch (FormatException)
                {
                }
            }

            public void Save()
            {
                XElement xElement = new XElement("UpdateSettings");
                xElement.Add(new XElement("AutomaticUpdateCheckEnabled", this.automaticUpdateCheckEnabled));
                if (this.lastSuccessfulUpdateCheck.HasValue)
                {
                    xElement.Add(new XElement("LastSuccessfulUpdateCheck", this.lastSuccessfulUpdateCheck));
                }
                ILSpySettings.SaveSettings(xElement);
            }

            private void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        private const string band = "stable";

        [Import]
        private DecompilerTextView decompilerTextView=new DecompilerTextView();

        private static readonly Uri UpdateUrl = new Uri("http://www.fishlee.net/service/update/57/updates.xml");

        private static AboutPage.AvailableVersionInfo latestAvailableVersion;

        private static readonly Version currentVersion = new Version("2.1.0.1603");

        public override void Execute(object parameter)
        {
            MainWindow.Instance.UnselectAll();
            AboutPage.Display(this.decompilerTextView);
        }

        public static void Display(DecompilerTextView textView)
        {
            AvalonEditTextOutput avalonEditTextOutput = new AvalonEditTextOutput();
            avalonEditTextOutput.WriteLine("ILSpy 版本 2.1.0.1603");
            avalonEditTextOutput.AddUIElement(delegate
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
                stackPanel.Orientation = Orientation.Horizontal;
                if (AboutPage.latestAvailableVersion == null)
                {
                    AboutPage.AddUpdateCheckButton(stackPanel, textView);
                }
                else
                {
                    AboutPage.ShowAvailableVersion(AboutPage.latestAvailableVersion, stackPanel);
                }
                CheckBox checkBox = new CheckBox();
                checkBox.Margin = new Thickness(4.0);
                checkBox.Content = "每周自动检查更新";
                AboutPage.UpdateSettings source = new AboutPage.UpdateSettings(ILSpySettings.Load());
                checkBox.SetBinding(ToggleButton.IsCheckedProperty, new Binding("AutomaticUpdateCheckEnabled")
                {
                    Source = source
                });
                return new StackPanel
                {
                    Margin = new Thickness(0.0, 4.0, 0.0, 0.0),
                    Cursor = Cursors.Arrow,
                    Children = 
					{
						stackPanel,
						checkBox
					}
                };
            });
            avalonEditTextOutput.WriteLine();
            foreach (IAboutPageAddition current in App.CompositionContainer.GetExportedValues<IAboutPageAddition>())
            {
                current.Write(avalonEditTextOutput);
            }
            avalonEditTextOutput.WriteLine();
            using (Stream manifestResourceStream = typeof(AboutPage).Assembly.GetManifestResourceStream(typeof(AboutPage), "README.txt"))
            {
                using (StreamReader streamReader = new StreamReader(manifestResourceStream))
                {
                    string text;
                    while ((text = streamReader.ReadLine()) != null)
                    {
                        avalonEditTextOutput.WriteLine(text);
                    }
                }
            }
            avalonEditTextOutput.AddVisualLineElementGenerator(new AboutPage.MyLinkElementGenerator("SharpDevelop", "http://www.icsharpcode.net/opensource/sd/"));
            avalonEditTextOutput.AddVisualLineElementGenerator(new AboutPage.MyLinkElementGenerator("MIT License", "resource:license.txt"));
            avalonEditTextOutput.AddVisualLineElementGenerator(new AboutPage.MyLinkElementGenerator("LGPL", "resource:LGPL.txt"));
            avalonEditTextOutput.AddVisualLineElementGenerator(new AboutPage.MyLinkElementGenerator("iFish(木鱼)", "http://www.fishlee.net/about/"));
            textView.ShowText(avalonEditTextOutput);
            textView.manager.Bookmarks.Clear();
        }

        private static void AddUpdateCheckButton(StackPanel stackPanel, DecompilerTextView textView)
        {
            Button button = new Button();
            button.Content = "检查更新";
            button.Cursor = Cursors.Arrow;
            stackPanel.Children.Add(button);
            button.Click += delegate(object param0, RoutedEventArgs param1)
            {
                button.Content = "检查更新中...";
                button.IsEnabled = false;
                AboutPage.GetLatestVersionAsync().ContinueWith(delegate(Task<AboutPage.AvailableVersionInfo> task)
                {
                    try
                    {
                        stackPanel.Children.Clear();
                        AboutPage.ShowAvailableVersion(task.Result, stackPanel);
                    }
                    catch (Exception ex)
                    {
                        AvalonEditTextOutput avalonEditTextOutput = new AvalonEditTextOutput();
                        avalonEditTextOutput.WriteLine(ex.ToString());
                        textView.ShowText(avalonEditTextOutput);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            };
        }

        private static void ShowAvailableVersion(AboutPage.AvailableVersionInfo availableVersion, StackPanel stackPanel)
        {
            if (AboutPage.currentVersion == availableVersion.Version)
            {
                stackPanel.Children.Add(new Image
                {
                    Width = 16.0,
                    Height = 16.0,
                    Source = Images.OK,
                    Margin = new Thickness(4.0, 0.0, 4.0, 0.0)
                });
                stackPanel.Children.Add(new TextBlock
                {
                    Text = "您正在使用的是最新版本.",
                    VerticalAlignment = VerticalAlignment.Bottom
                });
                return;
            }
            if (AboutPage.currentVersion < availableVersion.Version)
            {
                stackPanel.Children.Add(new TextBlock
                {
                    Text = "版本 " + availableVersion.Version + " 可用.",
                    Margin = new Thickness(0.0, 0.0, 8.0, 0.0),
                    VerticalAlignment = VerticalAlignment.Bottom
                });
                if (availableVersion.DownloadUrl != null)
                {
                    Button button = new Button();
                    button.Content = "下载";
                    button.Cursor = Cursors.Arrow;
                    button.Click += delegate(object param0, RoutedEventArgs param1)
                    {
                        Process.Start(availableVersion.DownloadUrl);
                    };
                    stackPanel.Children.Add(button);
                    return;
                }
            }
            else
            {
                stackPanel.Children.Add(new TextBlock
                {
                    Text = "您正在使用比正式版更新的每夜版."
                });
            }
        }

        private static Task<AboutPage.AvailableVersionInfo> GetLatestVersionAsync()
        {
            TaskCompletionSource<AboutPage.AvailableVersionInfo> tcs = new TaskCompletionSource<AboutPage.AvailableVersionInfo>();
            WebClient webClient = new WebClient();
            IWebProxy systemWebProxy = WebRequest.GetSystemWebProxy();
            systemWebProxy.Credentials = CredentialCache.DefaultCredentials;
            webClient.Proxy = systemWebProxy;
            webClient.DownloadDataCompleted += delegate(object sender, DownloadDataCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    tcs.SetException(e.Error);
                    return;
                }
                try
                {
                    XDocument xDocument = XDocument.Load(new MemoryStream(e.Result));
                    IEnumerable<XElement> source = xDocument.Root.Elements("band");
                    XElement xElement = source.FirstOrDefault((XElement b) => (string)b.Attribute("id") == "stable") ?? source.First<XElement>();
                    Version version = new Version((string)xElement.Element("latestVersion"));
                    string text = (string)xElement.Element("downloadUrl");
                    if (!text.StartsWith("http://", StringComparison.Ordinal) && !text.StartsWith("https://", StringComparison.Ordinal))
                    {
                        text = null;
                    }
                    AboutPage.latestAvailableVersion = new AboutPage.AvailableVersionInfo
                    {
                        Version = version,
                        DownloadUrl = text
                    };
                    tcs.SetResult(AboutPage.latestAvailableVersion);
                }
                catch (Exception exception)
                {
                    tcs.SetException(exception);
                }
            };
            webClient.DownloadDataAsync(AboutPage.UpdateUrl);
            return tcs.Task;
        }

        public static Task<string> CheckForUpdatesIfEnabledAsync(ILSpySettings spySettings)
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            AboutPage.UpdateSettings s = new AboutPage.UpdateSettings(spySettings);
            if (s.AutomaticUpdateCheckEnabled)
            {
                if (!s.LastSuccessfulUpdateCheck.HasValue || s.LastSuccessfulUpdateCheck < DateTime.UtcNow.AddDays(-7.0) || s.LastSuccessfulUpdateCheck > DateTime.UtcNow)
                {
                    AboutPage.GetLatestVersionAsync().ContinueWith(delegate(Task<AboutPage.AvailableVersionInfo> task)
                    {
                        try
                        {
                            s.LastSuccessfulUpdateCheck = new DateTime?(DateTime.UtcNow);
                            AboutPage.AvailableVersionInfo result = task.Result;
                            if (result.Version > AboutPage.currentVersion)
                            {
                                tcs.SetResult(result.DownloadUrl);
                            }
                            else
                            {
                                tcs.SetResult(null);
                            }
                        }
                        catch (AggregateException)
                        {
                            tcs.SetResult(null);
                        }
                    });
                }
                else
                {
                    tcs.SetResult(null);
                }
            }
            else
            {
                tcs.SetResult(null);
            }
            return tcs.Task;
        }
    }
}
