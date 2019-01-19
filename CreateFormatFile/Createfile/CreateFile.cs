using System;
using System.IO;
using System.Text;
namespace CreateFormatFile.Createfile
{
	
	public class CreateFile
	{
		public void CreateFmtFile(string path,string infile,string outfile,string delimiter)
        {
            using (TextReader tr = File.OpenText(path + infile))
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
               	
                char delim;
                string delimtxt;
                switch (delimiter)
                {
                	case "t":
                		delim = '\t';
                		delimtxt = @"\t";
                		break;
                	case "p":
                		delim = '|';
                		delimtxt = "|";
                		break;
                	case "c":
                		delim = ',';
                		delimtxt = ",";
                		break;
                	default:
                		delim = ';';
                		delimtxt = ";";
                		break;
                		
                }
				const char dq = '"';
				const string sep = "  ";
                string output = "";
                string line;
                int counter = 0;
                int maxrow;
                
                StreamWriter sw = new StreamWriter(path + outfile);

                while (counter < 1)
                {
                    line = tr.ReadLine();
                // split the line of text into an array
                string[] items = line.Split(delim);
                    maxrow = items.Length;
                    
                    sw.WriteLine("14.0");
                    sw.WriteLine(maxrow.ToString());
                    
                    for( int i = 0; i < items.Length; i++){
                        if (maxrow  !=(i + 1) ){
                        output = (i + 1).ToString() + sep + "SQLCHAR" + sep + "0" + sep + "100" + sep + dq + delimtxt + dq + sep + (i + 1).ToString() + sep + items[i] + sep + "Latin1_General_CI_AS";
                    }else{
                        output = (i + 1).ToString() + sep + "SQLCHAR" + sep + "0" + sep + "100" + sep + dq + @"\r\n" + dq + sep + (i + 1).ToString() + sep + items[i] + sep + "Latin1_General_CI_AS";
                    }
                    
                   sw.WriteLine(output);
                }
                counter++;
                }
                tr.Close();
                sw.Close();
                
            }
            
          
        }
    }
}
