global using System.ComponentModel;
global using todo.Data;
global using todo.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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
