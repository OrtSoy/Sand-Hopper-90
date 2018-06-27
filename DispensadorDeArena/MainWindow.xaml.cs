using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using AdvancedHMIDrivers;
using System.Deployment.Application;
using System.Reflection;


namespace DispensadorDeArena
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Version getRunningVersion()
        {

            try
            {

                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch (Exception)
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        EthernetIPforSLCMicroCom Micro1100 = new EthernetIPforSLCMicroCom { IPAddress = "10.15.106.208" };
        public MainWindow()
        {
            InitializeComponent();
            //Display Version
            mainWindow.Title = "SandHopper90 v" + getRunningVersion();


            StartClock();
            passwordBox.Focus();
            DispatcherTimer timerReadPLC = new DispatcherTimer();

            //every 200ms update
            timerReadPLC.Interval = TimeSpan.FromMilliseconds(100);
            timerReadPLC.Tick += new EventHandler(timerReadPLC_Tick);
            timerReadPLC.Start();

        }



        //color brush object
        SolidColorBrush brushRed = new SolidColorBrush(Color.FromRgb(224, 25, 25));
        SolidColorBrush brushGreen = new SolidColorBrush(Color.FromRgb(34, 170, 40));

        public void timerReadPLC_Tick(object sender, EventArgs e)
        {
            //Hopper 1
            if (Micro1100.Read("B3:0/0") == "False")
            {
                ElipseSand90.Fill = brushRed;
            }
            else
            {
                ElipseSand90.Fill = brushGreen;
            }
       
        }
        public void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TickEvent;
            timer.Start();
        }

        private void TickEvent(object sender, EventArgs e)
        {
            datelbl.Text = DateTime.Now.ToString();
        }




        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.Key == Key.Return)
            {

                var context = new EmployeeContext();
                var clock = context.Employees
                    .Select(C => new { C.Name, C.Clock, C.BadgePin, C.Last, C.First })
                    .Where(C => C.BadgePin == passwordBox.Password).Take(1);
                if (clock.Any())
                {
                    PersonalData.FirstName = clock.First().First;
                    PersonalData.LastName = clock.First().Last;
                    PersonalData.Clock = clock.First().Clock;
                    //en realidad este es el nombre del usuario
                    Record.SetBadge(clock.First().Name);
                    var formHopper = new HopperNumber();
                    //aqui llamo al metodo bloqueos
                    var bloqueos = new Bloqueos();
                  
                    if (bloqueos.SePuedeServir || DateTime.Now.Hour == 7 || DateTime.Now.Hour == 3 || DateTime.Now.Hour == 22 || DateTime.Now.Hour == 23 )
                    {
                        if (clock.First().BadgePin == passwordBox.Password)
                        {
                            formHopper.Show();
                            this.Close();

                        }
                    }
                    else
                    {
                        
                        MessageBox.Show("Ya te serviste, vuelve a intentarlo dentro de 3 horas");
                        passwordBox.Clear();
                        passwordBox.Focus();
                    }
                 
                }
                else
                {
                    MessageBox.Show("El badge No esta registrado en la base de datos");
                    passwordBox.Password = string.Empty;
                }

            }
        }

    }
}
