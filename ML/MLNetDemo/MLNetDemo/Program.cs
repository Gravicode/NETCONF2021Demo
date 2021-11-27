// See https://aka.ms/new-console-template for more information
using MLNetDemo;

Console.WriteLine("Hello, World!");
//Load sample data
var sampleData = new CancerModel.ModelInput()
{
    Age = @"30-39",
    Menopause = @"premeno",
    Tumor_size = @"30-34",
    Inv_nodes = @"0-2",
    Node_caps = @"no",
    Deg_malig = 3F,
    Breast = @"left",
    Breast_quad = @"left_low",
    Irradiat = @"no",
};

//Load model and predict output
var result = CancerModel.Predict(sampleData);
Console.WriteLine($"Result: {result.Prediction} ({result.Score[0]*100} %)");
Console.ReadLine();