using System;
using System.Collections.Generic;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numd = 0;
        int i = 0;
        List<Path> cg = new List<Path>();
        Vector relativeMousePos;
        FrameworkElement draggedObject;
        List<Point> coord = new List<Point>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void geom_MouseDoubleClick(object sender, MouseButtonEventArgs e)//фокус на составную фигуру фигуру при нажатии
        {
            Path combFig = sender as Path;
            numd = int.Parse((string)(combFig.Tag));
        }

        void StartDrag(object sender, MouseButtonEventArgs e)//начала перетаскивания
        {
            draggedObject = (FrameworkElement)sender;
            relativeMousePos = e.GetPosition(draggedObject) - new Point();
            draggedObject.MouseMove += OnDragMove;
            draggedObject.LostMouseCapture += OnLostCapture;
            draggedObject.MouseUp += OnMouseUp;
            Mouse.Capture(draggedObject);
        }
        void OnDragMove(object sender, MouseEventArgs e)//во время перетаскивания
        {
            UpdatePosition(e);
        }

        void UpdatePosition(MouseEventArgs e)//обновление позиции
        {
            var point = e.GetPosition(Gostinnaya);
            var newPos = point - relativeMousePos;
            Canvas.SetLeft(draggedObject, newPos.X);
            Canvas.SetTop(draggedObject, newPos.Y);
        }

        void OnMouseUp(object sender, MouseButtonEventArgs e)//когда кнопка мыши не нажата
        {
            FinishDrag(sender, e);
            Mouse.Capture(null);
        }

        void OnLostCapture(object sender, MouseEventArgs e)//когда управление жлементом потеряно
        {
            FinishDrag(sender, e);
        }

        void FinishDrag(object sender, MouseEventArgs e)//событие окончания переноса
        {
            draggedObject.MouseMove -= OnDragMove;
            draggedObject.LostMouseCapture -= OnLostCapture;
            draggedObject.MouseUp -= OnMouseUp;
            UpdatePosition(e);
        }

        void Add(object sender, RoutedEventArgs e)//добавление
        {
            if (BraButton.IsChecked == true)//кровати
            {
                EllipseGeometry first = new EllipseGeometry();
                first.Center = new Point(75, 75);
                first.RadiusX = 50;
                first.RadiusY = 50;
                EllipseGeometry second = new EllipseGeometry();
                second.Center = new Point(125, 75);
                second.RadiusX = 50;
                second.RadiusY = 50;
                CombinedGeometry bra = new CombinedGeometry(first, second);
                Path braPath = new Path();
                braPath.Data = bra;
                braPath.Fill = Brushes.Yellow;
                braPath.Stroke = Brushes.Black;
                braPath.StrokeThickness = 1;
                coord.Add(new Point(100, 75));
                cg.Add(braPath);
                braPath.Tag = (cg.Count - 1).ToString();
                braPath.MouseLeftButtonDown += new MouseButtonEventHandler(StartDrag);
                braPath.MouseLeftButtonDown += new MouseButtonEventHandler(geom_MouseDoubleClick);
                Canvas.SetLeft(braPath, 100);
                Canvas.SetTop(braPath, 100);
                Gostinnaya.Children.Add(braPath);
            }
            if (SofaButton.IsChecked == true)//Углового дивана
            {
                RectangleGeometry firstRectangle = new RectangleGeometry();
                firstRectangle.Rect = new Rect(0, 0, 360, 200);
                RectangleGeometry secontRectangle = new RectangleGeometry();
                secontRectangle.Rect = new Rect(200, 200, 160, 320);
                CombinedGeometry sofa = new CombinedGeometry(firstRectangle, secontRectangle);
                Path myPath = new Path();
                myPath.Data = sofa;
                myPath.Fill = Brushes.Red;
                myPath.Stroke = Brushes.Black;
                myPath.StrokeThickness = 1;
                cg.Add(myPath);
                coord.Add(new Point(250, 300));
                myPath.Tag = (cg.Count - 1).ToString();
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(StartDrag);
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(geom_MouseDoubleClick);
                Canvas.SetLeft(myPath, 100);
                Canvas.SetTop(myPath, 100);
                Gostinnaya.Children.Add(myPath);
            }

            if (TableButton.IsChecked == true)
            {
                RectangleGeometry table = new RectangleGeometry();
                table.Rect = new Rect(new Size(275, 275));
                Path myPath = new Path();
                myPath.Data = table;
                myPath.Fill = Brushes.RosyBrown;
                myPath.Stroke = Brushes.Black;
                myPath.StrokeThickness = 1;
                cg.Add(myPath);
                coord.Add(new Point(137.5, 137.5));
                myPath.Tag = (cg.Count - 1).ToString();
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(StartDrag);
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(geom_MouseDoubleClick);
                Canvas.SetLeft(myPath, 100);
                Canvas.SetTop(myPath, 100);
                Gostinnaya.Children.Add(myPath);
            }

            if (ChairButton.IsChecked == true)
            {
                RectangleGeometry table = new RectangleGeometry();
                table.Rect = new Rect(new Size(75, 120));
                EllipseGeometry first = new EllipseGeometry();
                first.Center = new Point(0, 60);
                first.RadiusX = 60;
                first.RadiusY = 60;
                CombinedGeometry chair = new CombinedGeometry(table, first);
                chair.GeometryCombineMode = GeometryCombineMode.Exclude;
                Path myPath = new Path();
                myPath.Data = chair;
                myPath.Fill = Brushes.SandyBrown;
                myPath.Stroke = Brushes.Black;
                myPath.StrokeThickness = 1;
                cg.Add(myPath);
                coord.Add(new Point(50, 50));
                myPath.Tag = (cg.Count - 1).ToString();
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(StartDrag);
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(geom_MouseDoubleClick);
                Canvas.SetLeft(myPath, 100);
                Canvas.SetTop(myPath, 100);
                Gostinnaya.Children.Add(myPath);

            }
            if (shkafbutton.IsChecked == true)//Углового дивана
            {
                RectangleGeometry firstRectangle = new RectangleGeometry();
                firstRectangle.Rect = new Rect(180, 260, 20, 20);
                RectangleGeometry secontRectangle = new RectangleGeometry();
                secontRectangle.Rect = new Rect(200, 200, 220, 500);
                CombinedGeometry sofa = new CombinedGeometry(firstRectangle, secontRectangle);
                Path myPath = new Path();
                myPath.Data = sofa;
                myPath.Fill = Brushes.Brown;
                myPath.Stroke = Brushes.Black;
                myPath.StrokeThickness = 1;
                cg.Add(myPath);
                coord.Add(new Point(300, 380));
                myPath.Tag = (cg.Count - 1).ToString();
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(StartDrag);
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(geom_MouseDoubleClick);
                Canvas.SetLeft(myPath, 100);
                Canvas.SetTop(myPath, 100);
                Gostinnaya.Children.Add(myPath);
            }

            if (TVButton.IsChecked == true)//Углового дивана
            {
                RectangleGeometry firstRectangle = new RectangleGeometry();
                firstRectangle.Rect = new Rect(405, 540, 225, 225);
                EllipseGeometry second = new EllipseGeometry();
                second.Center = new Point(405, 652.5);
                second.RadiusX = 33.75;
                second.RadiusY = 122.5;
                CombinedGeometry sofa = new CombinedGeometry(firstRectangle, second);
                Path myPath = new Path();
                myPath.Data = sofa;
                myPath.Fill = Brushes.DarkGray;
                myPath.Stroke = Brushes.Black;
                myPath.StrokeThickness = 1;
                coord.Add(new Point(400, 625));
                cg.Add(myPath);
                myPath.Tag = (cg.Count - 1).ToString();
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(StartDrag);
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(geom_MouseDoubleClick);
                Canvas.SetLeft(myPath, 100);
                Canvas.SetTop(myPath, 100);
                Gostinnaya.Children.Add(myPath);
            }

            if (def_sofabutton.IsChecked == true)
            {
                RectangleGeometry firstRectangle = new RectangleGeometry();
                firstRectangle.Rect = new Rect(180, 0, 20, 40);
                RectangleGeometry secontRectangle = new RectangleGeometry();
                secontRectangle.Rect = new Rect(200, 0, 200, 320);
                RectangleGeometry thrid = new RectangleGeometry();
                thrid.Rect = new Rect(180, 280, 20, 40);
                GeometryGroup sofa = new GeometryGroup();
                sofa.Children.Add(firstRectangle);
                sofa.Children.Add(secontRectangle);
                sofa.Children.Add(thrid);
                Path myPath = new Path();
                myPath.Data = sofa;
                myPath.Fill = Brushes.Red;
                myPath.Stroke = Brushes.Black;
                coord.Add(new Point(200, 200));
                cg.Add(myPath);
                myPath.StrokeThickness = 1;
                myPath.Tag = (cg.Count - 1).ToString();
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(StartDrag);
                myPath.MouseLeftButtonDown += new MouseButtonEventHandler(geom_MouseDoubleClick);
                Canvas.SetLeft(myPath, 100);
                Canvas.SetTop(myPath, 100);
                Gostinnaya.Children.Add(myPath);
            }
        }

        private void Angle_setter(object sender, RoutedEventArgs e)//поворачиватель
        {
            i = int.Parse(tb.Text);
            RotateTransform rotate = new RotateTransform();
            rotate.CenterX = coord[numd].X;
            rotate.CenterY = coord[numd].Y;
            rotate.Angle = i;
            cg[numd].RenderTransform = rotate;
            i = 0;

        }
        private void Delete(object sender, EventArgs e)
        {
            Gostinnaya.Children.Remove(cg[numd]);
            cg.Remove(cg[numd]);
            coord.Remove(coord[numd]);
        }
    }
}
