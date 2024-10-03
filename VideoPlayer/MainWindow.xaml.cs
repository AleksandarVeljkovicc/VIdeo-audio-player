using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace VideoPlayer
{
    public partial class MainWindow : Window
    {
        DispatcherTimer tmr;
        DispatcherTimer hideButtonTimer;
        bool autoPosition;
        private bool isFullscreen = false;
        private WindowState previousWindowState;
        private WindowStyle previousWindowStyle;
        private ResizeMode previousResizeMode;
        private Thickness previousMargin;

        public MainWindow()
        {
            InitializeComponent();

            tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(1);
            tmr.Tick += Tmr_Tick;

            hideButtonTimer = new DispatcherTimer();
            hideButtonTimer.Interval = TimeSpan.FromSeconds(3);
            hideButtonTimer.Tick += HideButtonTimer_Tick;

            autoPosition = false;
        }

        private void Tmr_Tick(object? sender, EventArgs e)
        {
            // Ako video fajl ima trajanje, azuriraj positionSlider
            if (media.NaturalDuration.HasTimeSpan)
            {
                positionSlider.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
                positionSlider.Value = media.Position.TotalSeconds;
            }
        }

        private void btnToggleFullscreen_Click(object sender, RoutedEventArgs e)
        {
            if (isFullscreen)
            {
                ExitFullscreen();
            }
            else
            {
                EnterFullscreen();
            }

            isFullscreen = !isFullscreen;
        }

        private void EnterFullscreen()
        {
            // Sacuvaj trenutna podesavanja prozora
            previousWindowState = this.WindowState;
            previousWindowStyle = this.WindowStyle;
            previousResizeMode = this.ResizeMode;
            previousMargin = media.Margin;

            // Sakrij sve kontrole osim dugmeta za fullscreen
            audioTrackPanel.Visibility = Visibility.Collapsed;
            volumePanel.Visibility = Visibility.Collapsed;
            balancePanel.Visibility = Visibility.Collapsed;
            positionPanel.Visibility = Visibility.Collapsed;
            cmdPlay.Visibility = Visibility.Collapsed;
            cmdStop.Visibility = Visibility.Collapsed;
            cmdPause.Visibility = Visibility.Collapsed;
            cmdLoad.Visibility = Visibility.Collapsed;

            btnToggleFullscreen.Content = "Exit Fullscreen";

            // Prebaci prozor u fullscreen rezim
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;

            // Prosiri video preko celog ekrana
            media.Margin = new Thickness(0);
            Grid.SetRowSpan(media, 7);

            // Pokreni tajmer za automatsko sakrivanje dugmeta
            hideButtonTimer.Start();
        }

        private void ExitFullscreen()
        {
            // Vrati originalna podesavanja prozora
            this.WindowState = previousWindowState;
            this.WindowStyle = previousWindowStyle;
            this.ResizeMode = previousResizeMode;
            media.Margin = previousMargin;

            // Vrati kontrole
            audioTrackPanel.Visibility = Visibility.Visible;
            volumePanel.Visibility = Visibility.Visible;
            balancePanel.Visibility = Visibility.Visible;
            positionPanel.Visibility = Visibility.Visible;

            // Prikazi kontrole za reprodukciju
            cmdPlay.Visibility = Visibility.Visible;
            cmdStop.Visibility = Visibility.Visible;
            cmdPause.Visibility = Visibility.Visible;
            cmdLoad.Visibility = Visibility.Visible;

            btnToggleFullscreen.Content = "Fullscreen";

            // Vrati video na prvobitni red
            Grid.SetRowSpan(media, 1);

            // Zaustavi tajmer za automatsko skrivanje
            hideButtonTimer.Stop();
        }
        // Ove metode se pozivaju kada korisnik klikne na Play, Stop, Pause ili Load dugmad
        private void cmdPlay_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
            tmr.Start();  // Pokrece tajmer kada se video pusta
        }


        private void cmdStop_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            tmr.Stop();  // Zaustavlja tajmer kada se video zaustavi
            positionSlider.Value = 0;  // Resetuje poziciju na pocetak
        }


        private void cmdPause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        private void cmdLoad_Click(object sender, RoutedEventArgs e)
        {
            
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

                     
            if (openFileDialog.ShowDialog() == true)
            {               
                media.Source = new Uri(openFileDialog.FileName);
                fileName.Content = System.IO.Path.GetFileName(openFileDialog.FileName);

                // Proveri da li fajl ima trajanje i odmah postavi vrednosti za positionSlider
                media.LoadedBehavior = MediaState.Manual;
                media.MediaOpened += (s, ev) =>
                {
                    if (media.NaturalDuration.HasTimeSpan)
                    {
                        positionSlider.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
                        positionSlider.Value = 0; // Resetuj slider na pocetak
                    }
                };
            }
        }


        // Ova metoda ce se pozivati kad korisnik menja vrednost na volumeSlider-u
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = e.NewValue;
        }

        // Ova metoda ce se pozivati kad korisnik menja vrednost na balanceSlider-u
        private void balanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Balance = e.NewValue;
        }

        // Ova metoda ce se pozivati kad korisnik menja poziciju na positionSlider-u
        private void positionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = TimeSpan.FromSeconds(e.NewValue);
        }


        private void HideButtonTimer_Tick(object? sender, EventArgs e)
        {
            // Sakrij dugme za fullscreen ako je u fullscreen rezimu
            if (isFullscreen)
            {
                btnToggleFullscreen.Visibility = Visibility.Collapsed;
            }
        }



        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // Prikazi dugme za fullscreen kad se pomeri mis
            if (isFullscreen)
            {
                btnToggleFullscreen.Visibility = Visibility.Visible;

                // Resetuj tajmer
                hideButtonTimer.Stop();
                hideButtonTimer.Start();
            }
        }
    }
}
