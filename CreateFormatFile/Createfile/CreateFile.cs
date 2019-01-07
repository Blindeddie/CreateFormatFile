using System;
using System.IO;
using System.Text;
namespace CreateFormatFile.Createfile
{
	
	public class CreateFile
	{
		public void CreateFmtFile(string path,string infile,string outfile,string subfolder,string delimiter)
        {
            using (TextReader tr = File.OpenText(path + infile))
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!Directory.Exists(path + subfolder))
                {
                Directory.CreateDirectory(path + subfolder);
                }
				
                char delim;
                string delimtxt;
                switch (delimiter)
                {
                	case "t":
                		delim = '\t';
                		delimtxt = @"\t";
                		break;
                	case "|":
                		delim = '|';
                		delimtxt = "|";
                		break;
                	default:
                		delim = ',';
                		delimtxt = ",";
                		break;
                }
				const char dq = '"';
				//const char sq = '\t';
			    const string sep = "  ";
                string output = "";
                string line;
                int counter = 0;
                int maxrow;
                
                StreamWriter sw = new StreamWriter(path + subfolder + "\\" + outfile);

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
                        output = (i + 1).ToString() + sep + "SQLCHAR" + sep + "0" + sep + "50" + sep + dq + delimtxt + dq + sep + (i + 1).ToString() + sep + items[i] + sep + "Latin1_General_CI_AS";
                    }else{
                        output = (i + 1).ToString() + sep + "SQLCHAR" + sep + "0" + sep + "50" + sep + dq + @"\r\n" + dq + sep + (i + 1).ToString() + sep + items[i] + sep + "Latin1_General_CI_AS";
                    }
                    
                   sw.WriteLine(output);
                }
                counter++;
                }
                tr.Close();
                sw.Close();
                
            }
            
           // Console.WriteLine("Hello World!");
        }
	}
}
