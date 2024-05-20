using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task1.EFEntitys;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using(ConsDbContext context = new ConsDbContext())
            {
                Notes = new BindingList<Note>(context.Notes.ToList());
                DGVNotes.ItemsSource=Notes;
            }
        }
        BindingList<Note> Notes;

        private void BtnAddNote_Click(object sender, RoutedEventArgs e)
        {
            if(TimeOnly.TryParse(Time.Text, out TimeOnly time) && !string.IsNullOrEmpty(FullName.Text))
            {
                using(ConsDbContext context = new ConsDbContext())
                {
                    Note note = new Note()
                    {
                        StudentFullName = FullName.Text,
                        ConsultationTime=Date.DisplayDate+time.ToTimeSpan(),
                        ConstSubject=Subject.Text
                    };
                    context.Notes.Add(note);
                    context.SaveChanges();
                    Notes.Add(note);
                }
            }
        }

        private void BtnCancelNote_Click(object sender, RoutedEventArgs e)
        {
            if (DGVNotes.SelectedItems.Count == 1)
            {
                int id = ((Note)DGVNotes.SelectedItem).IdNote;
                Notes.Remove((Note)DGVNotes.SelectedItem);
                using(ConsDbContext context = new ConsDbContext())
                {
                    context.Notes.Remove(context.Notes.FirstOrDefault(x => x.IdNote == id));
                    context.SaveChanges();
                }
            }
        }
    }
}