using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
namespace DispensadorDeArena
{
    /// <summary>
    /// Interaction logic for HopperNumber.xaml
    /// </summary>
    public partial class HopperNumber : Window
    {
        public HopperNumber()
        {
            InitializeComponent();
            StartClock();

            labelFistname.Content = PersonalData.FirstName;
            labelLastname.Content = PersonalData.LastName;
            labelClock.Content = Convert.ToString(PersonalData.Clock);
            
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
     

        private void ButtonSB01_Click(object sender, RoutedEventArgs e)
        {
           
            Record.SetSandblastName(SANB01_A.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB01_B_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB01_B.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB01C_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB01C.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
            
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB02_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB02.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
          
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB03_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB03.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
            
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB04_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB04.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
          
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB05_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB05.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
           
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB07_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB07.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
           
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB08_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB08.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
            
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB09_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB09.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
           
            tipoDeArena.Show();
            this.Close();
        }

    
        private void SANB11_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB11.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
           
            tipoDeArena.Show();
            this.Close();
        }

      

      


       

     


      
      
       

        private void SANB20_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB20.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
           
            tipoDeArena.Show();
            this.Close();
        }


  
 
    

    

      

        private void SANB28_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB28.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
            
            tipoDeArena.Show();
            this.Close();
        }


   

   
    
    

        private void SANB34_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB34.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
           
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB35_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB35.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
            
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB36_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB36.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
           
            tipoDeArena.Show();
            this.Close();
        }

        private void SANB37_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB37.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();
            
            tipoDeArena.Show();
            this.Close();
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
        //componer 
        private void SANB39_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB39.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();

            tipoDeArena.Show();
            this.Close();
        }

    
        private void SANB41_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB41.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();

            tipoDeArena.Show();
            this.Close();
        }
      
        private void SANB47_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB47.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();

            tipoDeArena.Show();
            this.Close();
        }

  


     

        //Se agrego el sanblast 50 5/10/2018
        private void SANB50_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB50.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();

            tipoDeArena.Show();
            this.Close();
        }



        //Se agrego sanblast 33,29,26
        private void SANB33_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB33.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();

            tipoDeArena.Show();
            this.Close();
        }

        private void SANB26_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB26.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();

            tipoDeArena.Show();
            this.Close();
        }

        private void SANB29_Click(object sender, RoutedEventArgs e)
        {
            Record.SetSandblastName(SANB29.Name);
            TipoDeArena tipoDeArena = new TipoDeArena();

            tipoDeArena.Show();
            this.Close();
        }
    }
}
