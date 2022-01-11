using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace todo.Components
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Add : UserControl
    {
        public Add()
        {
            InitializeComponent();
            DataContext = new TextBoxData();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await saveData();
        }

        private async Task saveData()
        {
            var inputData = DataContext as TextBoxData;
            if (inputData != null)
            {
                using (var db = new TodoContext())
                {
                    var Id = Guid.NewGuid().ToString();

                    await db.AddAsync(new Todo()
                    {
                        TodoId = Id,
                        Task = inputData.Text
                    });
                    await db.SaveChangesAsync();

                    var Item = await db.Todos.FindAsync(Id);


                    (Application.Current.MainWindow.DataContext as ObservableCollection<Todo>)!.Insert(0, Item!);

                    inputData.Text = "";
                }
            }
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

        private async void onKeyDownEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await saveData();
            }
        }
    }
}
