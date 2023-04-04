

using Microsoft.VisualBasic.FileIO;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<int, List<string>> mydict = new Dictionary<int, List<string>>();
        Console.WriteLine("Please enter your filename:"); 
        string name = Console.ReadLine(); 


        //https://stackoverflow.com/questions/3507498/reading-csv-files-using-c-sharp
        using (TextFieldParser parser = new TextFieldParser(name))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(";");
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                foreach (string field in fields)
                {
                    //https://www.techiedelight.com/find-index-of-element-array-csharp/
                    int index = Array.IndexOf(fields, field);
                    //https://stackoverflow.com/questions/31869887/best-way-to-check-if-a-key-exists-in-a-dictionary-before-adding-it
                    if (mydict.ContainsKey(index))
                    {
                        List<string> l = mydict[index]; 
                        l.Add(field);
                    }
                    else
                    {
                        //https://www.c-sharpcorner.com/UploadFile/mahesh/create-a-list-in-C-Sharp/
                        List<string> list = new List<string>();
                        list.Add(field);
                        mydict.Add(index, list);
                    }


                }
            }
        }
        //https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file?source=recommendations
        string a = "_transposed";
        StreamWriter sw = new StreamWriter(name.Split('.')[0] + a + ".csv" );
        foreach (var v in mydict)
        {
            //https://stackoverflow.com/questions/3575029/c-sharp-liststring-to-string-with-delimiter
            sw.WriteLine(String.Join(";", v.Value));
        }
        sw.Close();
    }
}
