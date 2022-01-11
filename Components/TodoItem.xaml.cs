using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace todo.Components
{
    /// <summary>
    /// Interaction logic for Todo.xaml
    /// </summary>
    public partial class TodoItem : UserControl
    {
        public TodoItem()
        {
            InitializeComponent();
        }




        private void onMouseDownEdit(object sender, MouseButtonEventArgs e)
        {
            var EditWindow = new Edit((Todo)DataContext);
            EditWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            EditWindow.ShowDialog();
        }

        private async void OnMouseDownDelete(object sender, MouseButtonEventArgs e)
        {
            var inputData = (DataContext as Todo)!;

            using (var db = new TodoContext())
            {
                db.Remove(inputData);
                await db.SaveChangesAsync();
                retriveData();
            }
        }
        private void retriveData()
        {

            {
                using (var db = new TodoContext())
                {

                    var list = db.Todos.ToList();
                    list.Reverse();

                    Application.Current.MainWindow.DataContext = new ObservableCollection<Todo>(list);
                }
            }
        }


    }
}
