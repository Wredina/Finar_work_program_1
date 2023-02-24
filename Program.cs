string[] СreationarrString(int sizeArr)
{
 string[] array = new string[sizeArr];
 string[] letters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
 for (int j = 0; j < sizeArr; j++)
 {
  string word = "";
  Random rnd = new Random();
  int wordSize = rnd.Next(1, 10);
  for (int i = 0; i < wordSize; i++)
  {
   word += letters[rnd.Next(0, 26)];
  }
  array[j] = word;
 }
 return array;
}



string[] arr = СreationarrString(new Random().Next(4, 8));
Console.WriteLine(String.Join(", ", arr));
System.Console.WriteLine();

