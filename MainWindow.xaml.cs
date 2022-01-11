global using System.ComponentModel;
global using todo.Data;
global using todo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace todo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = getData();
        }

        private ObservableCollection<Todo> getData()
        {
            using (var db = new TodoContext())
            {
                var list = db.Todos.ToList();
                list.Reverse();
                return new ObservableCollection<Todo>(list);
            }
        }

        private void Search_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MyTodos_Loaded(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
