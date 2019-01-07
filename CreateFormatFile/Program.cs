/*
 * Created by SharpDevelop.
 * User: blind
 * Date: 1/6/2019
 * Time: 8:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using CreateFormatFile.Createfile;
using Options;
	
namespace CreateFormatFile
{
	class Program
	{
		public static void Main(string[] args)
		{
			string Filepath = "";
            string Filename = "";
            string Outfile = "";
            string Delim = "";
            bool showHelp = false;
            
            var Opts = new OptionSet()
            {
                {"p|filepath=", "(req) The path to the folder containing file", (string v)=>Filepath=v },
                {"f|filename=", "(req) The filename to read from", (string v)=>Filename=v },
                {"o|outfile=", "(req) The output filename (the format file)", (string v)=>Outfile=v },
                {"d|delim=", "(req) The column delimiter for the header row", (string v)=>Delim=v },
                {"help", "show help and close", v=>showHelp = v != null },
            };
			
			try
            {
                Opts.Parse(args);

                if(showHelp)
                {
                    ShowHelp(Opts);
                    return;
                }
                if (string.IsNullOrWhiteSpace(Filepath))
                {
                    throw new OptionException("File path cannot be blank or empty.", "sti");
                }
                if (!string.IsNullOrWhiteSpace(Filepath) && !Directory.Exists(Filepath))
                {
                    throw new OptionException("The path '{FilePath}' does not exist.", "sti");
                }
                if (string.IsNullOrWhiteSpace(Outfile))
                {
                    throw new OptionException("The output file '{Outfile}' cannot be blank or empty.", "Outfile");
                }
                if (string.IsNullOrWhiteSpace(Filename))
                {
                    throw new OptionException("File name cannot be blank or empty.","Filename");
                }
                if(!string.IsNullOrWhiteSpace(Filename) && !File.Exists(Filepath + Filename))
                {
                    throw new OptionException("The file '{Filename}' does not exist.", "Filename");
                }
                if (string.IsNullOrWhiteSpace(Delim))
                {
                    throw new OptionException("The delimiter cannot be blank or empty.", "filename");
                }

            }
            catch (OptionException e)
            {
                Console.Write("CreateFormatFile: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `CreateFormatFile --help' for more information");
                return;
            }
			
			
			
			var cf = new CreateFile();
            //cf.CreateFmtFile(args[0],args[1],args[2],Convert.ToInt32(args[3]));
            cf.CreateFmtFile(Filepath,Filename,Outfile,"9",Delim);
           //return 1;
		}
		static void ShowHelp(OptionSet Opts)
        {
            Console.WriteLine("Use: CreateFormatFile [OPTIONS]");
            Console.WriteLine("Creates a Non-XML BCP format file to be used in dynamic import of flatfiles.");
            Console.WriteLine("© dotneteddie 2019");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Opts.WriteOptionDescriptions(Console.Out);
        }
	}
}