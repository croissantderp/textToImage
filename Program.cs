using System.Drawing;
using System.Text.RegularExpressions;

Console.Write("Enter a path: \n>");
string inputPath = Console.ReadLine() ?? "";

if (!File.Exists(inputPath))
{
    Console.WriteLine("not a valid file");
    return;
}

string input = File.ReadAllText(inputPath);

int y = input.Count(a => a == '\n') + 1;
int x = (input.Length + 1) / y - 1;

input = Regex.Replace(input, @"\t|\n|\r", "");

Bitmap bitmap = new(x, y);

Color light = Color.FromArgb(255, 255, 255);
Color dark = Color.FromArgb(0, 0, 0);

int index = 0;
for (int i = 0; i < y; i++)
{
    for (int j = 0; j < x; j++)
    {
        if (index < input.Length)
        {
            bitmap.SetPixel(j, i, input[index] == '#' ? dark : light);
            index++;
        }
    }
}

bitmap.Save(Regex.Replace(inputPath, @"txt$", "png"));