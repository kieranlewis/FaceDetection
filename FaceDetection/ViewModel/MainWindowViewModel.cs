using System.Collections.ObjectModel;
using System.Windows.Input;
using FaceDetection.Model;
using FaceDetection.MVVM;
using Microsoft.Win32;

namespace FaceDetection.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ImageModel> Images { get; set; }
        public RelayCommand ProcessCommand => new (execute => ProcessImage());

        public MainWindowViewModel()
        {
            Images = [];
        }

        private ImageModel _selectedImage;
        public ImageModel SelectedImage
        {
            get => _selectedImage;
            set
            {
                _selectedImage = value;
                OnPropertyChanged();
            }
        }

        private void ProcessImage()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image files|*.bmp;*.jpg;*.png",
                FilterIndex = 1
            };

            if (ofd.ShowDialog() == true)
            {
                Mouse.OverrideCursor = Cursors.Wait; // set the cursor to loading spinner

                var imageModel = new ImageModel(ofd.FileName);
                Images.Add(imageModel);

                SelectedImage = imageModel;

                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }
    }
}
