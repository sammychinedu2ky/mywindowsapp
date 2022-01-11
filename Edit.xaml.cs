using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace todo
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        Todo item;
        public Edit(Todo context)
        {
            item = context;
            DataContext = new TextBoxData()
            {
                Text = item.Task
            };
            InitializeComponent();

        }

        public class TextBoxData : INotifyPropertyChanged
        {
            private string _text = "";
            public string Text
            {
                get => _text;
                set
                {
                    _text = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));

                }
            }


            public event PropertyChangedEventHandler? PropertyChanged;
        }
        private async Task saveData()
        {
            var inputData = DataContext as TextBoxData;
            if (inputData != null)
            {
                using (var db = new TodoContext())
                {

                    var myTodo = db.Todos.Find(item!.TodoId)!;
                    myTodo.Task = inputData.Text;
                    await db.SaveChangesAsync();

                    item.Task = inputData.Text;



                }
            }
        }

        private async void onKeyDownEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await saveData();
                Close();
            }
        }

        private async void onClickUpdate(object sender, RoutedEventArgs e)
        {
            await saveData();
            Close();
        }

        private void onClickCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
