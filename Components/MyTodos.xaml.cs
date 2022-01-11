using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace todo.Components
{
    /// <summary>
    /// Interaction logic for MyTodos.xaml
    /// </summary>
    public partial class MyTodos : UserControl
    {
        public MyTodos()
        {
            InitializeComponent();
          
        }
     
      
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

   
}
