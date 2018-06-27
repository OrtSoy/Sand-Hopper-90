using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Opc.Da;
using AdvancedHMIDrivers;
using System.Linq;

namespace DispensadorDeArena
{
    /// <summary>
    /// Interaction logic for TipoDeArena.xaml
    /// </summary>
    public partial class TipoDeArena : Window
    {
        EthernetIPforSLCMicroCom Micrologix1100Tolvas = new EthernetIPforSLCMicroCom { IPAddress = "10.15.106.208" };
        const int retardo = 10;

        public TipoDeArena()
        {
            InitializeComponent();
            labelFistname.Content = PersonalData.FirstName;
            labelLastname.Content = PersonalData.LastName;
            labelClock.Content = Convert.ToString(PersonalData.Clock);
            labelSandBlast.Content = Record.GetSandBlastName();
            StartClock();
            timer();
            

        }

        private void timer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(retardo);
            timer.Tick += TickEvent2;
            timer.Start();
            labelSandBlast.Content = Record.GetSandBlastName();
        }

        private void TickEvent2(object sender, EventArgs e)
        {
            if (Micrologix1100Tolvas.Read("B3:0/0") == "False")
            {
                ButtonArena90.IsEnabled = false;
            }
            else
            {
                ButtonArena90.IsEnabled = true;
            }
            ///lo otro

          /**  if (Micrologix1400Tolvas.Read("B9:0/0") == "False")
            {
                ButtonArena150.IsEnabled = false;
            }
            else
            {
                ButtonArena150.IsEnabled = true;
            }**/
        }

        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TickEvent;
            timer.Start();
            labelSandBlast.Content = Record.GetSandBlastName();
        }

        private void TickEvent(object sender, EventArgs e)
        {
            datelbl.Text = DateTime.Now.ToString();
        
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            var now = DateTime.Now;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Record.SetTime(now);
            Record.SetArenaType("90");
           
            //Poner la logica para guardar los kilos de arena que se surten en la hora que se pide
            switch (now.Hour)
            {
                case 0:
                    if (now.Minute<30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 1).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        Micrologix1100Tolvas.Read("T4:"+bit+".PRE");
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);

                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 2).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                break;
                   
                case 1:

                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 3).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 4).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                break;

                case 2:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 5).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 6).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }

                 break;
                case 3:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 7).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 8).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }

                break;
                case 4:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 9).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 10).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }

                break;
                case 5:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 11).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 12).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }

                break;
                case 6:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 13).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 14).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }

                break;
                case 7:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 15).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 16).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                break;

                case 8:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 17).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 18).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                break;

                case 9:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 19).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 20).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        Micrologix1100Tolvas.Read("T4:" + bit + ".PRE");
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }

                break;
                case 10:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 21).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);

                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 22).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);


                    }
                    break;
                case 11:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 23).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 24).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                break;
                case 12:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 25).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 26).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    break;
                case 13:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 27).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 28).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                break;
                case 14:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 29).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 30).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);

                    }

                break;
                case 15:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 31).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);


                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 32).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                 break;
                case 16:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 33).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);

                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 34).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }


                break;
                case 17:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 35).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 36).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                break;
                case 18:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 37).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 38).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                break;
                case 19:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 39).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 40).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    break;
                case 20:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 41).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 42).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }

                break;
                case 21:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 43).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 44).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }


                break;
                case 22:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 45).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 46).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                break;
                case 23:
                    if (now.Minute < 30)
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 47).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "False");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }
                    else
                    {
                        var context = new HopperModel();
                        var kilos = context.SetKiloes
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 48).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1100Tolvas.Write("B3:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                        var SleepWindow = Convert.ToInt32(Micrologix1100Tolvas.Read("T4:" + bit + ".PRE"));
                        Thread.Sleep(SleepWindow * 1000);
                    }

                break;
            }
            //aqui lo mando a la base de datos
            try
            {
                var context = new HopperModel();
                var registro = new Registro
                {
                    TipoDeArena = Record.GetArenaType(),
                    HoraYFecha = Record.GetDateTime(),
                    NombreDeSandblast = Record.GetSandBlastName(),
                    Kilos = Convert.ToInt32(Record.GetKilos()),
                    Name = Record.GetBadge(),
                    Clock = Convert.ToString(PersonalData.Clock)

               

                };
                //aqui lo mando a la base de datos
                
                context.Registroes.Add(registro);
                context.SaveChanges();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

            }





            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

            /***

        private void ButtonArena150_Click(object sender, RoutedEventArgs e)
        {
            
            var now = DateTime.Now;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Record.SetTime(now);
            Record.SetArenaType("150");
            //Poner la logica para guardar los kilos de arena que se surten en la hora que se pide
            switch (now.Hour)
            {
                case 0:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 1).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 2).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 1:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 3).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 4).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 2:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 5).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 6).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 3:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 7).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 8).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 4:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 9).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 10).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 5:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 11).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 12).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 6:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 13).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 14).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 7:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 15).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 16).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 8:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 17).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 18).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 9:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 19).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 20).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 10:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 21).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 22).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 11:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 23).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 24).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 12:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 25).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 26).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 13:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 27).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 28).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 14:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 29).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 30).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 15:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 31).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 32).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 16:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 33).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 34).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 17:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 35).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 36).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 18:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 37).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 38).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 19:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 39).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 40).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 20:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 41).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 42).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 21:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 43).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 44).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 22:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 45).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 46).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
                case 23:
                    if (now.Minute < 30)
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 47).Take(1);
                        string bit = kilos.First().Kilos;

                        Micrologix1400Tolvas.Write("B9:0/" + bit, "True");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "False");
                        Record.SetKilos(bit);

                    }
                    else
                    {
                        var context = new KilosAdministratorContext();
                        var kilos = context.SetKilos150
                            .Select(C => new { C.Kilos, C.Id })
                            .Where(C => C.Id == 48).Take(1);
                        string bit = kilos.First().Kilos;
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "TRUE");
                        Thread.Sleep(200);
                        Micrologix1400Tolvas.Write("B9:0/" + bit, "FALSE");
                        Record.SetKilos(bit);
                    }
                    break;
             
            }
            try
            {
                var context = new BlogDbContext();
                var registro = new Registro
                {
                    TipoDeArena = Record.GetArenaType(),
                    HoraYFecha = Record.GetDateTime(),
                    NombreDeSandblast = Record.GetSandBlastName(),
                    Kilos = Record.GetKilos(),
                    Name = Record.GetBadge(),
                    Clock = Convert.ToString(PersonalData.Clock)
                };
                //aqui lo mando a la base de datos
                context.Registros.Add(registro);
                context.SaveChanges();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
               
            }
            this.Close();
        }**/

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            var sandBlastNumber = new HopperNumber();
        
            this.Close();
         
            sandBlastNumber.Show();
        }
    }
}
