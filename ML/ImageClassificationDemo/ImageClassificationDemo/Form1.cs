namespace ImageClassificationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            button1.Text = "Load Gambar";
            button1.Click += (a, b) =>
            {
                // Wrap the creation of the OpenFileDialog instance in a using statement,
                // rather than manually calling the Dispose method to ensure proper disposal

                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    dlg.Filter = "jpeg files (*.jpg)|*.jpg";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        PictureBox PictureBox1 = new PictureBox();

                        // Create a new Bitmap object from the picture file on disk,
                        // and assign that to the PictureBox.Image property
                        pictureBox1.Image = new Bitmap(dlg.FileName);
                        //Load sample data
                        var sampleData = new ImageModel.ModelInput()
                        {
                            ImageSource = dlg.FileName,
                        };

                        //Load model and predict output
                        var result = ImageModel.Predict(sampleData);
                        toolStripStatusLabel1.Text = $"predict => {result.Prediction}, {result.Score[0] * 100:n2} %";
                    }
                }



            };
        }
    }
}