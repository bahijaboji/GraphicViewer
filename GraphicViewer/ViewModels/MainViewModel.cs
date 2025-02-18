using GraphicViewer.Commands;
using GraphicViewer.Models;
using GraphicViewer.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GraphicViewer.ViewModels
{
    public class MainViewModel
    {

        public ObservableCollection<ShapeViewModel> Shapes { get; set; }
        public ICommand LoadJsonCommand { get; }

            private readonly JsonLoaderService _jsonLoaderService;

        public MainViewModel()
        {
            Shapes = new ObservableCollection<ShapeViewModel>();
            _jsonLoaderService = new JsonLoaderService();
            LoadJsonCommand = new RelayCommand(LoadJson);
        }
        private void LoadJson(object parameter)
            {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                    Title = "Select a JSON file"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;

                    var shapes = _jsonLoaderService.LoadShapes(filePath);
                    Shapes.Clear(); // Clear existing shapes before loading a new file 

                    foreach (var shape in shapes)
                    {
                        if (shape is Line line)
                        {
                            Shapes.Add(new LineViewModel(line.A, line.B, ParseColor(line.Color)));
                        }
                        else if (shape is Circle circle)
                        {
                            Shapes.Add(new CircleViewModel(circle.Center, circle.Radius, circle.Filled, ParseColor(circle.Color)));
                        }
                        else if (shape is Triangle triangle)
                        {
                            Shapes.Add(new TriangleViewModel(triangle.A, triangle.B, triangle.C, triangle.Filled, ParseColor(triangle.Color)));
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"File not found: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Invalid JSON format: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //converta string representation of a color (formatted as "A;R;G;B") into a Color object
        private Color ParseColor(string color)
        {
            var parts = color.Split(';');
            byte a = byte.Parse(parts[0].Trim());
            byte r = byte.Parse(parts[1].Trim());
            byte g = byte.Parse(parts[2].Trim());
            byte b = byte.Parse(parts[3].Trim());
            return Color.FromArgb(a, r, g, b);
        }
    }


    }
    
